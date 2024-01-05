using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace Morse_Code_Translator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creates a dictionary to store the key (letter) and its morse code value
            Dictionary<string, string> AlphaToMorse = new Dictionary<string, string>();

            // Task 1 Reads in the  Morse code text file contents and store in the dictionary

            StreamReader MyFileRead = new StreamReader("MorseCode.txt");

            for (int chr = 1; MyFileRead.EndOfStream == false; chr++)
            {
                string line = MyFileRead.ReadLine();

                AlphaToMorse.Add(line.Substring(0,1), line.Remove(0,2));
            }

            while (true)
            {
                Console.Clear();

                //Task 2: Enter some text to be converted to Morse code. Replace spaces in the text with string.Empty and convert the whole to text to UpperCase

                Console.Write("Enter text: ");
                string plaintext = Console.ReadLine().ToUpper().Replace(" ", "");

                // Task 3: Copy each character of the text string to a char array

                List<char> plaintextChars = plaintext.ToList();

                // Task 4: create a string list. This will store the morse code for the text you entered

                List<string> morseCode = new List<string>();

                //Task 5: Use a foreach loop and loop through the items in your char array. Compare each item in the Dictionary and store it as a variable  

                plaintextChars.ForEach(chr => morseCode.Add(AlphaToMorse[Convert.ToString(chr)]));

                //Task 6: another for each loop this time through your list. Write out the item plus a blank space.

                morseCode.ForEach(chr => Console.Write(chr + " "));

                Console.WriteLine();
                System.Threading.Thread.Sleep(5000);
                Console.WriteLine("\nThe program will now show the morse as a flash pattern.");
                System.Threading.Thread.Sleep(5000);


                //Task 7: Repeat the foreach loop used in task 6. Copy each item of the text string to another char array e.g char [] morsecharacters = item.ToCharArray();

                List<char> morseCodeChrs = new List<char>();
                morseCode.ForEach(chrs => chrs.ToList().ForEach(chr => morseCodeChrs.Add(chr)));

                // Task 8 For each loop through each item in you char array created in task 7

                foreach (char chr in morseCodeChrs)
                {
                    // Set backrground colour to white
                    // Console Clear

                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Clear();

                    // if the item is a dot 

                    if (chr == '.')
                    {
                        System.Threading.Thread.Sleep(250);
                    }

                    // else item is a dash

                    if (chr == '.')
                    {
                        System.Threading.Thread.Sleep(500);
                    }

                    //Set background colour to Black
                    //Console.Clear

                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Clear();

                    System.Threading.Thread.Sleep(500);

                }


                Console.ReadKey();
            }
        }
    }
}