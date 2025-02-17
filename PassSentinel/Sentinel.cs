using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Security;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace PassSentinel
{
    internal class Sentinel
    {
        private SecureString secureKey;

        public Sentinel()
        {
            secureKey = null;
        } // end constructor

        public void DestroyKey()
        {
            if (secureKey != null)
                secureKey.Dispose();
            secureKey = null;
        } // end DestroyKey


        private byte[] Key()
        {
            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                // Convert SecureString to unmanaged memory
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureKey);
                int length = 32;

                // Create a byte array for the result
                byte[] key = new byte[32];

                // Iterate through the SecureString and convert characters to bytes
                for (int i = 0; i < length; i++)
                {
                    key[i] = Convert.ToByte((char)Marshal.ReadByte(unmanagedString, i * 2));
                }

                return key;
            }
            finally
            {
                // Always free the unmanaged memory
                if (unmanagedString != IntPtr.Zero)
                    Marshal.FreeHGlobal(unmanagedString);
            }
        } // end GetKey


        public bool HasMasterKey()
        {
            if (this.secureKey == null)
                return false;
            return true;
        } // end HasMasterKey


        public void DeriveKey(byte[] masterSalt, char[] password)
        {

            if (password == null || password.Length == 0)
                throw new ArgumentException("Master password cannot be null or empty.");
            if (masterSalt == null)
                throw new InvalidOperationException("Cannot derive master key without salt!");

            int iterations = 100000;
            int keyLength = 32; // 256-bit AES Key

            byte[] aesKey = new byte[keyLength];

            // Convert char[] to byte[] securely using UTF-8
            byte[] passwordBytes = null;
            try
            {
                passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);

                // Use Rfc2898DeriveBytes to derive the key
                using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(passwordBytes, masterSalt, iterations, HashAlgorithmName.SHA256))
                {
                    aesKey = rfc2898DeriveBytes.GetBytes(keyLength);
                }

                // Create Secure String
                if (secureKey != null)
                    secureKey.Dispose();
                secureKey = new SecureString();
                for (int i = 0; i < aesKey.Length; i++)
                {
                    secureKey.AppendChar(Convert.ToChar(aesKey[i]));
                }
                secureKey.MakeReadOnly();

            }
            finally
            {
                Array.Clear(passwordBytes, 0, passwordBytes.Length);
            }
        } // end DeriveKey


        public byte[] Encrypt(byte[] plaintext, byte[] iv)
        {
            byte[] key = Key();
            byte[] ciphertext = Security.Encrypt(key, iv, plaintext);
            Array.Clear(key, 0, key.Length);

            return ciphertext;
        } // end Encrypt


        public byte[] Decrypt(byte[] ciphertext, byte[] iv)
        {
            byte[] key = Key();
            byte[] plaintext = Security.Decrypt(key, iv, ciphertext);
            Array.Clear(key, 0, key.Length);

            return plaintext;
        } // end Decrypt


        public void EncryptItem(VaultItem item)
        {
            if (item.Encrypted)
                throw new InvalidOperationException("Item must be plaintext in order to encrypt.");

            item.URL = Encrypt(item.URL, item.IV);
            item.Username = Encrypt(item.Username, item.IV);
            item.Password = Encrypt(item.Password, item.IV);
            item.Notes = Encrypt(item.Notes, item.IV);
            item.Encrypted = true;
        } // end EncryptItem

        public void DecryptItem(VaultItem item)
        {
            if (!item.Encrypted)
                throw new InvalidOperationException("Item must be encrypted in order to decrypt.");

            item.URL = this.Decrypt(item.URL, item.IV);
            item.Username = this.Decrypt(item.Username, item.IV);
            item.Password = this.Decrypt(item.Password, item.IV);
            item.Notes = this.Decrypt(item.Notes, item.IV);
            item.Encrypted = false;
        } // end DecryptItem

    } // end class

} // end namespace
