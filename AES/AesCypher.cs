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


    }
}
