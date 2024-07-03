using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace ToDoAPI.Services
{
    public class UsuarioCriptografia
    {
        public byte[] GeraSalt(byte[] salt)
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        public string CriptografarSenha(string senha, byte[] salt)
        {
            string senhaCriptografada = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: senha,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return senhaCriptografada;
        }
    }
}
