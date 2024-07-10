using System.Security.Cryptography;
using System.Text;

namespace MyCryptography
{
    public class AES
    {
        public static string GenSecretKey()
        {
            using (Aes aes = Aes.Create())
            {
                aes.KeySize = 256;
                aes.GenerateKey();

                string secret_key = Convert.ToBase64String(aes.Key);
                return secret_key;
            }
        }

        public static string GenIV()
        {
            using (Aes aes = Aes.Create())
            {
                string iv;
                aes.GenerateIV();
                iv = Convert.ToBase64String(aes.IV);

                return iv;

            }
        }

        public static void EncryptFile(string file_path, string key, string iv)
        { 
            using (Aes aes = Aes.Create())
            {
                aes.Key = Convert.FromBase64String(key);
                aes.IV = Convert.FromBase64String(iv);
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                using (FileStream fsInput = new FileStream(file_path, FileMode.Open, FileAccess.Read))
                using (FileStream fsEncrypted = new FileStream(Path.ChangeExtension(file_path, ".metadata"), FileMode.Create, FileAccess.Write))
                using (ICryptoTransform encryptor = aes.CreateEncryptor())
                using (CryptoStream csEncrypt = new CryptoStream(fsEncrypted, encryptor, CryptoStreamMode.Write))
                {
                    fsInput.CopyTo(csEncrypt);
                    csEncrypt.FlushFinalBlock();
                }
            }
            
        }

        public static void DecryptFile(string file_path, string key, string iv, string extension)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Convert.FromBase64String(key);
                aes.IV = Convert.FromBase64String(iv);
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                using (FileStream fsEncrypted = new FileStream(file_path, FileMode.Open, FileAccess.Read))
                using (FileStream fsDecrypted = new FileStream(file_path.Replace(".metadata","_decrypted" + extension), FileMode.Create, FileAccess.Write))
                using (ICryptoTransform decryptor = aes.CreateDecryptor())
                using (CryptoStream csDecrypt = new CryptoStream(fsDecrypted, decryptor, CryptoStreamMode.Write))
                {
                    fsEncrypted.CopyTo(csDecrypt);
                    csDecrypt.FlushFinalBlock();
                }
            }
        }
        


       
    }

    public class RSA
    {
        public static string[] GenerateKeys()
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048))
            {
                string publicKey = rsa.ToXmlString(false); // false = public key
                string privateKey = rsa.ToXmlString(true); // false = private key

                string[] key_pair = { publicKey, privateKey };
                return key_pair;
            }
        }

        public static string Encryption(string publicKey, string plaintext)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048))
            {
                // Convert publicKey from string to RSA key
                rsa.FromXmlString(publicKey);

                // Convert plaintext into binary
                byte[] plaintext_byte = Encoding.UTF8.GetBytes(plaintext);

                // Encrypt plaintext
                byte[] ciphertext = rsa.Encrypt(plaintext_byte, false);

                return Convert.ToBase64String(ciphertext);
            }
        }

        public static string Decryption(string privateKey, string ciphertext)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.FromXmlString(privateKey);

                byte[] ciphertext_byte = Convert.FromBase64String(ciphertext);

                byte[] plaintext = rsa.Decrypt(ciphertext_byte, false);
                return Encoding.UTF8.GetString(plaintext);
            }
        }
    }

    public class HashFunctions
    {
        public static string SHA1_Hash(string plain_text)
        {
            using (SHA1 sha1 = SHA1.Create())
            {
                
                byte[] plain_text_bytes = Encoding.UTF8.GetBytes(plain_text);
                byte[] hash_bytes = sha1.ComputeHash(plain_text_bytes);
                return Convert.ToBase64String(hash_bytes);
            }
        }

        public static string SHA256_Hash(string plain_text)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] plain_text_bytes = Encoding.UTF8.GetBytes(plain_text);
                byte[] hash_bytes = sha256.ComputeHash(plain_text_bytes);
                return Convert.ToBase64String(hash_bytes);
            }
        }
    }

}







