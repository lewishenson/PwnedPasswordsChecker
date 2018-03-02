using System.Threading.Tasks;

namespace PwnedPasswordsChecker
{
    public interface IPwnedPasswords
    {
         Task<bool> IsPwnedAsync(string password);

         Task<int> PwnedCountAsync(string password);
    }
}