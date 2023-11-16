//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using System.Security.Cryptography;
//using System.Text;

//namespace DecryptEncryptPasswordPortalAcademy.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class WeatherForecastController : ControllerBase
//    {
      
//        private readonly ILogger<WeatherForecastController> _logger;

//        public WeatherForecastController(ILogger<WeatherForecastController> logger)
//        {
//            _logger = logger;
//        }


//        [HttpGet(Name = "EncryptPass")]
//        public async Task<IActionResult> EncryptPassword(string password)
//        {
//            /***********************Encryption**********************************************/
//            // Get the bytes of the string
//            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(password);
//            byte[] passwordBytes = Encoding.UTF8.GetBytes("Password");

//            // Hash the password with SHA256
//            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

//            byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);

//            string encryptedResult = Convert.ToBase64String(bytesEncrypted);
//            return Ok(encryptedResult);
//            /***********************End*Encryption******************************************/
//        }

//        [HttpGet(Name = "DecryptPass")]
//        public async Task<IActionResult> DecryptPassword(string encryptedResult)
//        {
//            /***********************Decryption**********************************************/
//            // Get the bytes of the string
//            byte[] bytesToBeDecrypted = Convert.FromBase64String(encryptedResult);
//            byte[] passwordBytesdecrypt = Encoding.UTF8.GetBytes("Password");
//            passwordBytesdecrypt = SHA256.Create().ComputeHash(passwordBytesdecrypt);
//            //byte[] passwordBytes = Encoding.UTF8.GetBytes("Password");
//            byte[] bytesDecrypted = AES_Decrypt(bytesToBeDecrypted, passwordBytesdecrypt);

//            string decryptedResult = Encoding.UTF8.GetString(bytesDecrypted);
//            return Ok(decryptedResult);
//            /***********************End*Decryption******************************************/
//        }

//        private static byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
//        {
//            byte[] encryptedBytes = null;

//            // Set your salt here, change it to meet your flavor:
//            // The salt bytes must be at least 8 bytes.
//            byte[] saltBytes = new byte[] { 2, 1, 7, 3, 6, 4, 8, 5 };

//            using (MemoryStream ms = new MemoryStream())
//            {
//                using (RijndaelManaged AES = new RijndaelManaged())
//                {
//                    AES.KeySize = 256;
//                    AES.BlockSize = 128;

//                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
//                    AES.Key = key.GetBytes(AES.KeySize / 8);
//                    AES.IV = key.GetBytes(AES.BlockSize / 8);

//                    AES.Mode = CipherMode.CBC;

//                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
//                    {
//                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
//                        cs.Close();
//                    }
//                    encryptedBytes = ms.ToArray();
//                }
//            }

//            return encryptedBytes;
//        }

//        private static byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
//        {
//            byte[] decryptedBytes = null;

//            // Set your salt here, change it to meet your flavor:
//            // The salt bytes must be at least 8 bytes.
//            byte[] saltBytes = new byte[] { 2, 1, 7, 3, 6, 4, 8, 5 };

//            using (MemoryStream ms = new MemoryStream())
//            {
//                using (RijndaelManaged AES = new RijndaelManaged())
//                {
//                    AES.KeySize = 256;
//                    AES.BlockSize = 128;

//                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
//                    AES.Key = key.GetBytes(AES.KeySize / 8);
//                    AES.IV = key.GetBytes(AES.BlockSize / 8);

//                    AES.Mode = CipherMode.CBC;

//                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
//                    {
//                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
//                        cs.Close();
//                    }
//                    decryptedBytes = ms.ToArray();
//                }
//            }

//            return decryptedBytes;
//        }

      
//    }
//}