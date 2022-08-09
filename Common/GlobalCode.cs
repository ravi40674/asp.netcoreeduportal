using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace EducationPortal.Common
{
    public class GlobalCode
    {
        public static string strEncryptionKey = "HMS";
        public static string Male = "Male";
        public static string Female = "Female";
        public static string YesText = "Yes";
        public static string NoText = "No";
        public static string activeText = "Active";
        public static string inActiveText = "Inactive";
        public static bool TrueText = true;
        public static bool FalseText = false;
        public static string foreignKeyReference = "The DELETE statement conflicted with the REFERENCE constraint";
        public static string sameTableReference = "The DELETE statement conflicted with the SAME TABLE REFERENCE";
        public static string RainDP = "HMS";
        public static string InfoCulture = "en-GB";
        public static string timeFormat = "hh:mm tt";
        public static string strHttp = "https://{0}";
        public static string dateTimeFormat = "dd/MM/yyyy hh:mm:ss tt";

        public static string AdminEmailAddress = "shubhampithadiya1996@gmail.com";
        public static decimal DocumentMaxUploadSize = 10;
        public static string[] AllowedDocumentTypes = { ".doc", ".docx", ".xls", ".xlsx", ".pdf", ".txt", ".ppt", ".pptx", ".jpg", ".jpeg", ".png", ".bmp", ".gif", ".7z", ".rar", ".zip" };

        public enum Actions
        {
            Index,
            Create,
            Edit,
            Delete,
            Detail,
            Search
        }

        public class Encryption
        {
            protected static string strKey = GlobalCode.strEncryptionKey;

            public static string Encrypt(string textToBeEncrypted)
            {
                if (textToBeEncrypted == string.Empty || textToBeEncrypted == null)
                {
                    return textToBeEncrypted;
                }

                RijndaelManaged rijndaelCipher = new RijndaelManaged();
                string password = GlobalCode.strEncryptionKey;
                byte[] plainText = System.Text.Encoding.Unicode.GetBytes(textToBeEncrypted);
                byte[] salt = Encoding.ASCII.GetBytes(password.Length.ToString());
                PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(password, salt);

                //Creates a symmetric encryptor object.
                ICryptoTransform encryptor = rijndaelCipher.CreateEncryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16));
                MemoryStream memoryStream = new MemoryStream();

                //Defines a stream that links data streams to cryptographic transformations
                CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
                cryptoStream.Write(plainText, 0, plainText.Length);

                //Writes the final state and clears the buffer
                cryptoStream.FlushFinalBlock();
                byte[] cipherBytes = memoryStream.ToArray();
                memoryStream.Close();
                cryptoStream.Close();
                string encryptedData = Convert.ToBase64String(cipherBytes);

                return encryptedData;
            }

            // Used for password dercrption
            public static string Decrypt(string textToBeDecrypted)
            {
                RijndaelManaged rijndaelCipher = new RijndaelManaged();
                string password = GlobalCode.strEncryptionKey;
                string decryptedData;

                try
                {
                    byte[] encryptedData = Convert.FromBase64String(textToBeDecrypted.Replace(' ', '+'));
                    byte[] salt = Encoding.ASCII.GetBytes(password.Length.ToString());

                    //Making of the key for decryption
                    PasswordDeriveBytes secretKey = new PasswordDeriveBytes(password, salt);

                    //Creates a symmetric Rijndael decryptor object.
                    ICryptoTransform decryptor = rijndaelCipher.CreateDecryptor(secretKey.GetBytes(32), secretKey.GetBytes(16));
                    MemoryStream memoryStream = new MemoryStream(encryptedData);

                    //Defines the cryptographics stream for decryption.THe stream contains decrpted data
                    CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
                    byte[] plainText = new byte[encryptedData.Length];
                    int decryptedCount = cryptoStream.Read(plainText, 0, plainText.Length);
                    memoryStream.Close();
                    cryptoStream.Close();

                    //Converting to string
                    decryptedData = Encoding.Unicode.GetString(plainText, 0, decryptedCount);
                }
                catch
                {
                    decryptedData = textToBeDecrypted;
                }

                return decryptedData;
            }
        }

        #region Encryption
        public static string UrlEncrypt(string TextToBeEncrypted)
        {
            if (TextToBeEncrypted == string.Empty || TextToBeEncrypted == null)
            {
                return TextToBeEncrypted;
            }

            RijndaelManaged RijndaelCipher = new RijndaelManaged();
            string Password = GlobalCode.RainDP;
            byte[] PlainText = System.Text.Encoding.Unicode.GetBytes(TextToBeEncrypted);
            byte[] Salt = Encoding.ASCII.GetBytes(Password.Length.ToString());
            PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(Password, Salt);

            //Creates a symmetric encryptor object.
            ICryptoTransform Encryptor = RijndaelCipher.CreateEncryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16));
            MemoryStream memoryStream = new MemoryStream();

            //Defines a stream that links data streams to cryptographic transformations
            CryptoStream cryptoStream = new CryptoStream(memoryStream, Encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(PlainText, 0, PlainText.Length);

            //Writes the final state and clears the buffer
            cryptoStream.FlushFinalBlock();
            byte[] CipherBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            string EncryptedData = Convert.ToBase64String(CipherBytes);

            return EncryptedData.Replace('+', '-').Replace('/', '_').Replace('=', ',');

        }
        #endregion

        #region Decryption
        public static string UrlDecrypt(string TextToBeDecrypted)
        {
            RijndaelManaged RijndaelCipher = new RijndaelManaged();
            TextToBeDecrypted = TextToBeDecrypted.Replace('-', '+').Replace('_', '/').Replace(',', '=');
            string Password = GlobalCode.RainDP;
            string DecryptedData;

            try
            {
                byte[] EncryptedData = Convert.FromBase64String(TextToBeDecrypted.Replace(' ', '+'));
                byte[] Salt = Encoding.ASCII.GetBytes(Password.Length.ToString());

                //Making of the key for decryption
                PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(Password, Salt);

                //Creates a symmetric Rijndael decryptor object.
                ICryptoTransform Decryptor = RijndaelCipher.CreateDecryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16));
                MemoryStream memoryStream = new MemoryStream(EncryptedData);

                //Defines the cryptographics stream for decryption.THe stream contains decrpted data
                CryptoStream cryptoStream = new CryptoStream(memoryStream, Decryptor, CryptoStreamMode.Read);
                byte[] PlainText = new byte[EncryptedData.Length];
                int DecryptedCount = cryptoStream.Read(PlainText, 0, PlainText.Length);
                memoryStream.Close();
                cryptoStream.Close();

                //Converting to string
                DecryptedData = Encoding.Unicode.GetString(PlainText, 0, DecryptedCount);
            }
            catch (Exception)
            {
                return string.Empty;
            }

            return DecryptedData;
        }
        #endregion
    }
}
