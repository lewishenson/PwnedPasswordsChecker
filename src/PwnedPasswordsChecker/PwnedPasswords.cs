using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PwnedPasswordsChecker
{
    public class PwnedPasswords : IPwnedPasswords
    {
        private readonly HttpClient httpClient;

        public PwnedPasswords()
            : this(Shared.HttpClient)
        {
        }

        public PwnedPasswords(HttpClient httpClient)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<bool> IsPwnedAsync(string password)
        {
            var pwnedCount = await this.PwnedCountAsync(password).ConfigureAwait(false);;

            return pwnedCount > 0;
        }

        public async Task<int> PwnedCountAsync(string password)
        {
             if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Password cannot be null or whitespace.", nameof(password));
            }

            var fullPasswordHash = this.GetSha1Hash(password);
            var hashPrefix = fullPasswordHash.Substring(0, 5);

            var hashesInRange = await this.GetPasswordHashesInRange(hashPrefix).ConfigureAwait(false);;

            var hashSuffix = fullPasswordHash.Substring(5);

            return hashesInRange.ContainsKey(hashSuffix) ? hashesInRange[hashSuffix] : 0;
        }

        private string GetSha1Hash(string input)
        {
            using (var sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));

                return this.ToHexadecimalString(hash);
            }
        }

        private string ToHexadecimalString(byte[] hash)
        {
            var stringBuilder = new StringBuilder(hash.Length * 2);

            var hexadecimalCharacters = hash.Select(byteValue => byteValue.ToString("X2"));

            foreach (var hexadecimalCharacter in hexadecimalCharacters)
            {
                stringBuilder.Append(hexadecimalCharacter);
            }

            return stringBuilder.ToString();
        }

        private async Task<IDictionary<string, int>> GetPasswordHashesInRange(string hashPrefix)
        {
            var requestUri = $"https://api.pwnedpasswords.com/range/{hashPrefix}";

            var response = await this.httpClient.GetStringAsync(requestUri).ConfigureAwait(false);

            var hashesWithCounts = response.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                                           .Select(line => line.Split(':'))
                                           .ToDictionary(parts => parts[0], parts => Convert.ToInt32(parts[1]));

            return hashesWithCounts;
        }
    }
}