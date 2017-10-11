using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ROICodeProject
{
    class Program
    {
        // create the dictorionary with possible translations
        // the key is the word that sounds like the number
        // the value is it's associated value
        private static Dictionary<string, string> inflationaryDict;



        static void Main(string[] args)
        {

            // Example translations:
            // one = won
            // two = to / too
            // three 
            // four = for

            // create the dictorionary with possible translations
            // the key is the word that sounds like the number
            // the value is it's associated value
            inflationaryDict = new Dictionary<string, string>()
            {
                {"won", "one"},
                {"to", "two" },
                {"too", "two" },
                {"for", "four"}
            };


            // get the line for translation
            Console.WriteLine("Please enter your sentence to be translated into Inflationary english: \n");
            String sentence = Console.ReadLine();
            Console.WriteLine("Your original sentence was: " + sentence);

            // variable for translated sentence
            String newSentence = "";


            // first get all words in the string provided, and place them into an array 
            // define a regular expression all that are not letters, or numbers
            Regex regex = new Regex("[^a-zA-Z0-0]");
            // replace that with a space
            sentence = regex.Replace(sentence, " ");
            // generate an array of the words, eliminating spaces
            string[] words = sentence.Split(
                new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);
            // make a list for translated values
            List<string> translatedWords = new List<string>();


            
            //look at the original sentence and replace the words with their dictionary values
            foreach(string s in words)
            {

                if (inflationaryDict.ContainsKey(s))
                {
                    //Regex.Replace(sentence, s, inflationaryDict[s]);
                    newSentence = sentence.Replace(s, inflationaryDict[s]);
                    //Console.WriteLine("Keyfound");
                }
                

            }



            // print results
            Console.WriteLine("Your translated sentence is " + newSentence + "\n");
            // any key to exit
            Console.ReadKey();
        }



        static string InflationaryToNumber(string inflationaryWord)
        {

            string key1 = inflationaryWord;
            // if not in the dictionary return the same word
            if (!inflationaryDict.ContainsKey(key1)) return inflationaryWord;
            else return inflationaryDict[key1];
        }

       

    }



}
