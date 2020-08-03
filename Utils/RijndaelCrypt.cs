using System;
using System.Security.Cryptography;
using System.Text;

namespace AspMVCAdminLTE.Utils
{
    public class RijndaelCrypt
    {
        #region Private/Protected Member Variables

        /// <summary>
        /// Decryptor
        ///
        private readonly ICryptoTransform _decryptor;

        /// <summary>
        /// Encryptor
        ///
        private readonly ICryptoTransform _encryptor;

        /// <summary>
        /// 16-byte Private Key
        ///
        private static readonly byte[] IV = Encoding.UTF8.GetBytes("NdRgUkXp2s5v8x/A");

        /// <summary>
        /// Public Key
        ///
        private readonly byte[] _password;

        /// <summary>
        /// Rijndael cipher algorithm
        ///
        private readonly RijndaelManaged _cipher;

        #endregion Private/Protected Member Variables

        #region Private/Protected Properties

        private ICryptoTransform Decryptor { get { return _decryptor; } }
        private ICryptoTransform Encryptor { get { return _encryptor; } }

        #endregion Private/Protected Properties



        #region Constructor

        /// <summary>
        /// Constructor
        ///
        /// <param name="password">Public key
        public RijndaelCrypt(string password)
        {
            //Encode digest
            var md5 = new MD5CryptoServiceProvider();
            _password = md5.ComputeHash(Encoding.ASCII.GetBytes(password));

            //Initialize objects
            _cipher = new RijndaelManaged();
            _cipher.Padding = PaddingMode.Zeros;
            _decryptor = _cipher.CreateDecryptor(_password, IV);
            _encryptor = _cipher.CreateEncryptor(_password, IV);
        }

        #endregion Constructor



        #region Public Methods

        /// <summary>
        /// Decryptor
        ///
        /// <param name="text">Base64 string to be decrypted
        /// <returns>
        public string Decrypt(string text)
        {
            try
            {
                byte[] input = Convert.FromBase64String(text);

                var newClearData = Decryptor.TransformFinalBlock(input, 0, input.Length);
                return Encoding.ASCII.GetString(newClearData);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine("inputCount uses an invalid value or inputBuffer has an invalid offset length. " + ae);
                return null;
            }
            catch (ObjectDisposedException oe)
            {
                Console.WriteLine("The object has already been disposed." + oe);
                return null;
            }
        }

        /// <summary>
        /// Encryptor
        ///
        /// <param name="text">String to be encrypted
        /// <returns>
        public string Encrypt(string text)
        {
            try
            {
                var buffer = Encoding.ASCII.GetBytes(text);
                return Convert.ToBase64String(Encryptor.TransformFinalBlock(buffer, 0, buffer.Length));
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine("inputCount uses an invalid value or inputBuffer has an invalid offset length. " + ae);
                return null;
            }
            catch (ObjectDisposedException oe)
            {
                Console.WriteLine("The object has already been disposed." + oe);
                return null;
            }
        }

        #endregion Public Methods
    }
}