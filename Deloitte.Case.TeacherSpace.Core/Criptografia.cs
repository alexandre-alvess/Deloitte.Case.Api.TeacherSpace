using System.Security.Cryptography;
using System.Text;

namespace Deloitte.Case.TeacherSpace.Core
{
    /// <summary>
    /// Define a classe <see cref="Criptografia"/>.
    /// </summary>
    public static class Criptografia
    {
        private static string _Key = "E546C8DF278CD5931069B522E695D4F2";

        public static string Encrypt(this string text)
        {
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
            AesManaged tdes = new AesManaged();
            tdes.Key = UTF8.GetBytes(_Key);
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform crypt = tdes.CreateEncryptor();
            byte[] plain = Encoding.UTF8.GetBytes(text);
            byte[] cipher = crypt.TransformFinalBlock(plain, 0, plain.Length);
            String encryptedText = Convert.ToBase64String(cipher);
            return encryptedText;
        }

        public static string Decrypt(this string textoCriptografado)
        {
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
            AesManaged tdes = new AesManaged();
            tdes.Key = UTF8.GetBytes(_Key);
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform crypt = tdes.CreateDecryptor();
            byte[] plain = Convert.FromBase64String(textoCriptografado);
            byte[] cipher = crypt.TransformFinalBlock(plain, 0, plain.Length);
            String encryptedText = Encoding.UTF8.GetString(cipher);
            return encryptedText;
        }
    }
}
