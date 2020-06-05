using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace AspMVCAdminLTE.Utils
{
    public class Encryption
    {
        public static string HashString(string sourceString)
        {
            byte[] salt;
            byte[] buffer2;
            if (sourceString == null)
            {
                throw new ArgumentNullException("sourceString");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(sourceString, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }

        public static bool CompareHash(string hashedString, string sourceString)
        {
            byte[] buffer4;
            if (hashedString == null)
            {
                return false;
            }
            if (sourceString == null)
            {
                return false;
                //throw new ArgumentNullException("sourceString");
            }
            byte[] src = Convert.FromBase64String(hashedString);
            if (src.Length != 0x31 || src[0] != 0)
            {
                return false;
            }
            byte[] dst = new byte[0x10];
            Buffer.BlockCopy(src, 1, dst, 0, 0x10);
            byte[] buffer3 = new byte[0x20];
            Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(sourceString, dst, 0x3e8))
            {
                buffer4 = bytes.GetBytes(0x20);
            }
            return ByteArraysEqual(buffer3, buffer4);
        }
        private static bool ByteArraysEqual(byte[] b1, byte[] b2)
        {
            if (b1 == b2) return true;
            if (b1 == null || b2 == null) return false;
            if (b1.Length != b2.Length) return false;
            for (int i = 0; i < b1.Length; i++)
            {
                if (b1[i] != b2[i]) return false;
            }
            return true;
        }
        public static string EncryptData(string textData, string Encryptionkey)
        {
            var _encyptor = new RijndaelCrypt("balendin");
            return _encyptor.Encrypt(textData);
        }

        public static string DecryptData(string EncryptedText, string Encryptionkey)
        {
            var _encyptor = new RijndaelCrypt("balendin");
            return _encyptor.Decrypt(EncryptedText);
        }
    }
}