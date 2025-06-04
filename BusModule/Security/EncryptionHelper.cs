using System.Security.Cryptography;
using System.Text;

public static class EncryptionHelper
{
    private static readonly string key = "your-32-char-long-secret-key!!!"; // 32 chars for AES-256
    // Encrypts the plain text using AES-256
    public static string Encrypt(string plainText)
    {
        using var aes = Aes.Create();
        aes.Key = Encoding.UTF8.GetBytes(key);
        aes.GenerateIV();

        using var encryptor = aes.CreateEncryptor();
        var plainBytes = Encoding.UTF8.GetBytes(plainText);
        var encryptedBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);

        var result = Convert.ToBase64String(aes.IV.Concat(encryptedBytes).ToArray());
        return result;
    }
    // decrypts the encrypted text using AES-256
    public static string Decrypt(string encryptedText)
    {
        var fullBytes = Convert.FromBase64String(encryptedText);
        var iv = fullBytes.Take(16).ToArray();
        var cipherBytes = fullBytes.Skip(16).ToArray();

        using var aes = Aes.Create();
        aes.Key = Encoding.UTF8.GetBytes(key);
        aes.IV = iv;

        using var decryptor = aes.CreateDecryptor();
        var decryptedBytes = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
        return Encoding.UTF8.GetString(decryptedBytes);
    }
}
