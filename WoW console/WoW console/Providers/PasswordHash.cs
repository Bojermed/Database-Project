using System;
using WoW_console.Contracts;

namespace WoW_console.Providers
{
    public class PasswordHash : IPasswordHash
    {
        public string Hash(string username, string password)
        {
            password += username;
            var charPassword = password.ToCharArray();
            Array.Reverse(charPassword);

            return new string(charPassword);
        }
    }
}
