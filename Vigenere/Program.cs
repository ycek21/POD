using System;
using System.Collections;
using System.IO;
using System.Text;

namespace Szyfr_Vigenere
{
    class Program
    {

        public static int getIndex(char text)
        {
            int index;

            ArrayList alhabet = new ArrayList();
            alhabet.Add('a');
            alhabet.Add('b');
            alhabet.Add('c');
            alhabet.Add('d');
            alhabet.Add('e');
            alhabet.Add('f');
            alhabet.Add('g');
            alhabet.Add('h');
            alhabet.Add('i');
            alhabet.Add('j');
            alhabet.Add('k');
            alhabet.Add('l');
            alhabet.Add('m');
            alhabet.Add('n');
            alhabet.Add('o');
            alhabet.Add('p');
            alhabet.Add('q');
            alhabet.Add('r');
            alhabet.Add('s');
            alhabet.Add('t');
            alhabet.Add('u');
            alhabet.Add('v');
            alhabet.Add('w');
            alhabet.Add('x');
            alhabet.Add('y');
            alhabet.Add('z');



            index = alhabet.IndexOf(text);

            return index;
        }

        public static String getLetter(int resultIndex)
        {


            ArrayList alhabet = new ArrayList();
            alhabet.Add('a');
            alhabet.Add('b');
            alhabet.Add('c');
            alhabet.Add('d');
            alhabet.Add('e');
            alhabet.Add('f');
            alhabet.Add('g');
            alhabet.Add('h');
            alhabet.Add('i');
            alhabet.Add('j');
            alhabet.Add('k');
            alhabet.Add('l');
            alhabet.Add('m');
            alhabet.Add('n');
            alhabet.Add('o');
            alhabet.Add('p');
            alhabet.Add('q');
            alhabet.Add('r');
            alhabet.Add('s');
            alhabet.Add('t');
            alhabet.Add('u');
            alhabet.Add('v');
            alhabet.Add('w');
            alhabet.Add('x');
            alhabet.Add('y');
            alhabet.Add('z');


            String result = alhabet[resultIndex].ToString();

            return result;
        }


        public static String cypher(String text, String key)
        {

            String key2 = key.ToLower();

            String smallkey = key2.Replace(" ", "");

            String smallText = text.ToLower();



            int spaces = 0;

            var builder = new StringBuilder();

            for (int i = 0; i < smallText.Length; i++)
            {


                if (smallText[i] == ' ')
                {
                    spaces++;
                    builder.Append(smallText[i]);
                }
                else
                {

                    if (spaces != 0)
                    {
                        int textIndex = getIndex(smallText[i]);
                        int keyIndex = getIndex(smallkey[(i - spaces) % smallkey.Length]);
                        int index = (textIndex + keyIndex) % 26;
                        builder.Append(getLetter(index));
                    }
                    else
                    {
                        int textIndex = getIndex(smallText[i]);
                        int keyIndex = getIndex(smallkey[i % smallkey.Length]);
                        int index = (textIndex + keyIndex) % 26;
                        builder.Append(getLetter(index));
                    }


                }


            }
            String result = builder.ToString();

            return result;
        }

        public static String decipher(String text, String key)
        {
            String key2 = key.ToLower();

            String smallkey = key2.Replace(" ", "");

            String smallText = text.ToLower();

            int spaces = 0;

            //String textWithNoSpace = smallText.Replace(" ", "");

            var builder = new StringBuilder();

            for (int i = 0; i < smallText.Length; i++)
            {
                if (smallText[i] == ' ')
                {
                    spaces++;
                    builder.Append(smallText[i]);
                }
                else
                {
                    if (spaces != 0)
                    {
                        if (getIndex(smallText[i]) >= getIndex(smallkey[(i - spaces) % smallkey.Length]))
                        {
                            int textIndex = getIndex(smallText[i]);
                            int keyIndex = getIndex(smallkey[(i - spaces) % smallkey.Length]);

                            builder.Append(getLetter(textIndex - keyIndex));

                        }
                        else
                        {
                            int textIndex = getIndex(smallText[i]);
                            int keyIndex = getIndex(smallkey[(i - spaces) % smallkey.Length]);

                            int resultIndex = (26 - Math.Abs(textIndex - keyIndex)) % 26;

                            builder.Append(getLetter(resultIndex));
                        }
                    }
                    else
                    {
                        if (getIndex(smallText[i]) >= getIndex(smallkey[i % smallkey.Length]))
                        {
                            int textIndex = getIndex(smallText[i]);
                            int keyIndex = getIndex(smallkey[i % smallkey.Length]);

                            builder.Append(getLetter(textIndex - keyIndex));

                        }
                        else
                        {
                            int textIndex = getIndex(smallText[i]);
                            int keyIndex = getIndex(smallkey[i % smallkey.Length]);

                            int resultIndex = (26 - Math.Abs(textIndex - keyIndex)) % 26;

                            builder.Append(getLetter(resultIndex));
                        }
                    }
                }




            }

            String result = builder.ToString();

            return result;

        }



        static void Main(string[] args)
        {


            int a = 1;

            while (a == 1)
            {

                //Console.WriteLine("1. Write text and key\n" + "2.Load data from file\n" + "0. Exit");
                Console.WriteLine("1. Write text\n" + "2.Load data from file(u need to have  text file called code in the same folder )\n" + "0. Exit");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        {
                            //Console.Write("1.Encipher \n2.Decipher\n");
                            Console.Write("1.Encipher \n");
                            //int whatToDo = Convert.ToInt32(Console.ReadLine());

                            //if(whatToDo == 1)
                            {
                                Console.WriteLine("Enter text to encipher:");
                                String text = Console.ReadLine();
                                /*Console.WriteLine("Enter key:");
                                String key = Console.ReadLine();*/
                                Console.Clear();
                                //Console.WriteLine("Text: " + text + " key: " + key);
                                Console.WriteLine("Text: " + text);

                                String result = cypher(text, "maslo");


                                Console.Write("Encrypted message: " + result + "\n\n");
                            }
                            /* else
                             {
                                 Console.WriteLine("Enter text to encipher:");
                                 String text = Console.ReadLine();
                                 Console.WriteLine("Enter key:");
                                 String key = Console.ReadLine();
                                 Console.Clear();
                                 Console.WriteLine("Text: " + text + " key: " + key);

                                 String result = decipher(text, key);


                                 Console.Write("Encrypted message: " + result + "\n\n");
                             }*/


                            break;
                        }
                    case 2:
                        {

                            using (StreamReader sr = new StreamReader("code.txt"))
                            {
                                String textAndKey = sr.ReadToEnd();

                                //String[] rowArray = textAndKey.Split(':');



                                //String[] array = { rowArray[0].Replace("\n", "").Replace("\r",""), rowArray[1].Replace("\n","").Replace("\r", "") };

                                String array = textAndKey.Replace("\n", "").Replace("\r", "");


                                //Console.Write("1.Encipher \n2.Decipher\n");
                                Console.Write("1.Encipher \n");
                                //int whatToDo = Convert.ToInt32(Console.ReadLine());

                                Console.WriteLine("Text: " + textAndKey);

                                String result = cypher(array, "maslo");

                                Console.Clear();

                                Console.WriteLine("Text: " + textAndKey);
                                Console.Write("Encrypted message: " + result + "\n\n");

                                /*if (whatToDo == 1)
                                {
                                    
                                    Console.WriteLine("Text: " + array[0] + " key: " + array[1]);

                                    String result = cypher(array[0], array[1]);

                                    Console.Clear();

                                    Console.WriteLine("Text: " + array[0] + " key: " + array[1]);
                                    Console.Write("Encrypted message: " + result + "\n\n");
                                }*/
                                /*else
                                {
                                   
                                    Console.WriteLine("Text: " + array[0] + " key: " + array[1]);

                                    String result = decipher(array[0], array[1]);

                                    Console.Clear();

                                    Console.WriteLine("Text: " + array[0] + " key: " + array[1]);
                                    Console.Write("Encrypted message: " + result + "\n\n");
                                }*/

                            }

                            break;
                        }
                    case 0:
                        {
                            a = choice;
                            break;
                        }

                }


            }


        }
    }
}
