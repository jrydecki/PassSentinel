using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Konscious.Security.Cryptography;

namespace PassSentinel
{
    internal static class Security
    {

        public static byte[] GenerateIV()
        {
            byte[] iv = null;

            using (System.Security.Cryptography.Aes aes = System.Security.Cryptography.Aes.Create())
            {
                aes.GenerateIV();
                iv = aes.IV;
            }
            return iv;
        } // end GenerateIV

        public static byte[] GenerateSalt()
        {
            byte[] salt = new byte[16];

            using (var rng = RandomNumberGenerator.Create())
                rng.GetBytes(salt);

            return salt;
        } // end GenerateSalt()


        public static byte[] Argon2Hash(byte[] salt, byte[] stringBytes)
        {
            var argon2 = new Argon2i(stringBytes);
            argon2.Salt = salt;
            argon2.DegreeOfParallelism = 1;
            argon2.MemorySize = 65536;
            argon2.Iterations = 10;
            return argon2.GetBytes(64); // 512-bit hash
        }


        /*
        All assumes AES-256 Encryption
        256-bit Keys (byte[32])
        128-bit IV (byte[16])
        */
        public static byte[] Encrypt(byte[] key, byte[] iv, byte[] plaintext)
        {
            byte[] ciphertext;

            using (Aes aes = Aes.Create())
            {
                aes.IV = iv;
                aes.Key = key;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (BinaryWriter bwEncrypt = new BinaryWriter(csEncrypt))
                        {
                            bwEncrypt.Write(plaintext);
                        }
                    }

                    ciphertext = msEncrypt.ToArray();
                }
            }


            return ciphertext;

        } // end Encrypt


        public static byte[] Decrypt(byte[] key, byte[] iv, byte[] ciphertext)
        {
            byte[] plaintext;

            using (Aes aes = Aes.Create())
            {
                aes.IV = iv;
                aes.Key = key;

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream msDecrypt = new MemoryStream(ciphertext))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (MemoryStream resultStream = new MemoryStream())
                        {
                            csDecrypt.CopyTo(resultStream);
                            plaintext = resultStream.ToArray();
                        }

                    }
                }
            }

            return plaintext;
        } // end Decrypt

        public static string RandomPassword(int length, bool includeSymbols = true)
        {
            // Character categories
            char[] UppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            char[] LowercaseChars = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            char[] NumberChars = "0123456789".ToCharArray();
            char[] SymbolChars = "!@#$%^&*()-_=+[]{}|;:,.<>?".ToCharArray();

            // Combine character arrays based on the parameter
            char[] allChars = includeSymbols
                ? CombineArrays(UppercaseChars, LowercaseChars, NumberChars, SymbolChars)
                : CombineArrays(UppercaseChars, LowercaseChars, NumberChars);

            // Initialize the password array and random number generator
            char[] password = new char[length];
            byte[] randomBytes = new byte[length];

            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                // Ensure at least one character from each included category
                password[0] = UppercaseChars[GetRandomInt(rng, UppercaseChars.Length)];
                password[1] = LowercaseChars[GetRandomInt(rng, LowercaseChars.Length)];
                password[2] = NumberChars[GetRandomInt(rng, NumberChars.Length)];
                if (includeSymbols && length > 3)
                {
                    password[3] = SymbolChars[GetRandomInt(rng, SymbolChars.Length)];
                }

                // Fill the rest with a random selection from the allowed characters
                rng.GetBytes(randomBytes);
                for (int i = includeSymbols ? 4 : 3; i < length; i++)
                {
                    password[i] = allChars[randomBytes[i] % allChars.Length];
                }

                // Shuffle to randomize character positions
                ShuffleArray(password, rng);
            }

            return new string(password);
        }

        public static bool VerifyPassword(string username, char[] password)
        {
            // Retrieve stored hash and salt from the database
            byte[][] dbOutput = Globals.DB.GetPasswordHash(username);
            byte[] dbHashSalt = dbOutput[0];
            byte[] dbHash = dbOutput[1];

            if (dbHashSalt == null || dbHash == null)
                return false;

            // Convert char[] password to byte[] securely
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            try
            {
                // Generate the hash using the password and the salt
                byte[] generatedHash = Security.Argon2Hash(dbHashSalt, passwordBytes);

                // Compare the generated hash with the stored hash
                return generatedHash.SequenceEqual(dbHash);
            }
            finally
            {
                Array.Clear(passwordBytes, 0, passwordBytes.Length);
            }
        }


        private static int GetRandomInt(RandomNumberGenerator rng, int max)
        {
            byte[] randomByte = new byte[1];
            do
            {
                rng.GetBytes(randomByte);
            } while (randomByte[0] >= 256 - (256 % max));

            return randomByte[0] % max;
        } // end GetRandomInt

        private static char[] CombineArrays(params char[][] arrays)
        {
            StringBuilder combined = new StringBuilder();
            foreach (char[] array in arrays)
                combined.Append(array);

            return combined.ToString().ToCharArray();
        } // end CombineArrays

        private static void ShuffleArray(char[] array, RandomNumberGenerator rng)
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = GetRandomInt(rng, i + 1);
                (array[i], array[j]) = (array[j], array[i]);
            }
        } // end ShuffleArray


    } // end class
} // end namespace
