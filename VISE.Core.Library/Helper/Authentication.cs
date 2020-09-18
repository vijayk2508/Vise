using System;
using System.Collections.Generic;
using System.Text;

namespace VISE.Core.Library.Helper
{
    public class Authentication
    {
        public static string sPassword { get; private set; }

        public static string Decrypt(string sEncryptText)
        {
            UTF8Encoding encode_pwd = new UTF8Encoding();
            Decoder Decode = encode_pwd.GetDecoder();
            byte[] byteDecodePassword = Convert.FromBase64String(sEncryptText);
            int nCount = Decode.GetCharCount(byteDecodePassword, 0, byteDecodePassword.Length);
            char[] charDecode = new char[nCount];
            Decode.GetChars(byteDecodePassword, 0, byteDecodePassword.Length, charDecode, 0);
            sPassword = new String(charDecode);
            return sPassword;
        }

        public static string Encrypt(string sText)
        {
            byte[] byteEncodePassword = new byte[sText.Length];
            byteEncodePassword = Encoding.UTF8.GetBytes(sText);
            sPassword = Convert.ToBase64String(byteEncodePassword);
            return sPassword;
        }
    }
}
