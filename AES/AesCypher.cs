using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AES
{
    class AesCypher
    {
        private byte[] key;
        private byte[] IV;


        public void GenerateKeyIV()
        {
            using var aes = new AesManaged();
            this.key = aes.Key;
            this.IV = aes.IV;
        }

       

        public long EncryptFile(String filename, CipherMode mode)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            using (AesManaged aes = new AesManaged())
            {
                aes.Mode = mode;

                var encryptor = aes.CreateEncryptor(key, IV);

                using var fsCrypt = new FileStream("AES" + filename, FileMode.Create);

                using var csStream = new CryptoStream(fsCrypt, encryptor,CryptoStreamMode.Write);

                using var fsIn = new FileStream(filename, FileMode.Open);

                var buffer = new byte[1048576];

                int readBytes;

                while((readBytes = fsIn.Read(buffer,0,buffer.Length)) > 0)
                {
                    csStream.Write(buffer,0,readBytes);
                }

                /* zeby dobrze to zrozumiec =>
                 1.Tworzymy nowy fileStream, w ktorym bedzie zaszyfrowana wiadomosc
                 2. Tworzymy cryptoStream, ktorego targetem jest nasz utowrzony plik, co oznacza, ze jezeli wpiszemy cos do cryptstreama to on to wpisze zaszfrowane do naszego pliku
                 3. Utwiieramy plik, z ktorego bedziemy odczytywac
                 4. Tworzymy buffe
                 5. Odczytujemy plik wejsciowy,az do konca
                 6. CypherStream.Write wpisuje dane do cypherstreamu, kjtory wpisuje szaszyfrowane dane do naszego pliku
             */

            }
            timer.Stop();

            return timer.ElapsedMilliseconds;


        }

        public long DecryptFile(String filename, CipherMode mode)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            using (AesManaged aes = new AesManaged())
            {
                aes.Mode = mode;

                var decryptor = aes.CreateDecryptor(key, IV);

                using var fsIn = new FileStream(filename, FileMode.Open);

                using var csStream = new CryptoStream(fsIn, decryptor, CryptoStreamMode.Read);

                using var fsCrypt = new FileStream("decrypted.txt", FileMode.Create);

                var buffer = new byte[1048576];

                int readBytes;

                while ((readBytes = csStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    fsCrypt.Write(buffer, 0, readBytes);
                }
                
            }
            timer.Stop();

            return timer.ElapsedMilliseconds;

        }


        public long CBCEncrypt(String filename)
        {

            var timer = new Stopwatch();
            timer.Start();
            using (var aes = new AesManaged()
            {
                Mode = CipherMode.ECB
            })
            {
                var encryptor = aes.CreateEncryptor(key, IV);
                
                // Create the streams used for encryption.
                using var fsIn = new FileStream(filename, FileMode.Open);
                using var fsCrypt = new FileStream("CBC.txt", FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                using var encryptedIn = new FileStream("CBC.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                using var csEncrypt = new CryptoStream(fsCrypt, encryptor, CryptoStreamMode.Write);
                var buffer = new byte[16];

               
                    var read = fsIn.Read(buffer, 0, buffer.Length);
                   
                    var byteStore = Or(IV, buffer);
                    
                    csEncrypt.Write(byteStore, 0, read);
                    fsCrypt.Flush();
                    while ((read = fsIn.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        encryptedIn.Read(byteStore, 0, byteStore.Length);
                        byteStore = Or(buffer, byteStore);
                        csEncrypt.Write(byteStore, 0, read);
                        fsCrypt.Flush();
                    }
                
                
            }

            timer.Stop();

            return timer.ElapsedMilliseconds;
        }




        public long CBCDecrypt(string inputFile)
        {
            

            var timer = new Stopwatch();
            timer.Start();
            using var aes = new AesManaged();
            aes.Mode = CipherMode.ECB;
            var decryptor = aes.CreateDecryptor(key, IV);
           

            using var fsCrypt = new FileStream("CBC.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using var encryptedIn = new FileStream("CBC.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using var csDecrypt = new CryptoStream(fsCrypt, decryptor, CryptoStreamMode.Read);
            using var fsOut = new FileStream("mineCBCDecrypted.txt", FileMode.Create);

            var buffer = new byte[16];
            var buffer2 = new byte[16];

            
                csDecrypt.Read(buffer, 0, buffer.Length);
                buffer2 = Or(buffer, IV);
                fsOut.Write(buffer2, 0, buffer2.Length);
                while (csDecrypt.Read(buffer, 0, buffer.Length) > 0)
                {
                    encryptedIn.Read(buffer2, 0, buffer2.Length);
                    buffer2 = Or(buffer, buffer2);
                    fsOut.Write(buffer2, 0, buffer2.Length);
                }
            
           

           
            timer.Stop();

            return timer.ElapsedMilliseconds;

        }
        private byte[] Or(byte[] firstArray, byte[] secondArray)
        {
            var result = new byte[firstArray.Length];

            for (var i = 0; i < firstArray.Length; ++i)
            {
                result[i] = (byte)(firstArray[i] ^ secondArray[i]);
            }

            return result;
        }
    }



}

