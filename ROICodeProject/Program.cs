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

        private static Dictionary<string, string> inflationaryDict;

        static void Main(string[] args)
        {

            String[] num =
            {
                "one",
                "two",
                "three",
                "four",
                "five",
                "six",
                "seven",
                "eight",
                "nine",
                "ten"
            };


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
            // variable for translated sentence
            String newSentence = "";
            Console.WriteLine("Your original sentence was: " + sentence);

            // first get all words in the string provided, and place them into an array 
            // define a regular expression all that are not letters, or numbers
            Regex regex = new Regex("[^a-zA-Z0-0]");
            // replace that with a space
            sentence = regex.Replace(sentence, " ");
            // generate an array of the words, eliminating spaces
            string[] words = sentence.Split(
                new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);


            // look at the original sentence and replace the words with their dictionary values
            string[] newWords = words.Select(x => x.Replace(x, ((inflationaryDict.ContainsKey(x)) ? inflationaryDict[x] : x))).ToArray();

            string[] finalWords = newWords;
            // increment the words that are numbers by 1

            for (int i = 0; i <= finalWords.Length - 1; i++)
            {
                for (int j = 0; j <= num.Length - 1; j++)
                {
                    if(finalWords[i] == num[j])
                    {
                        finalWords[i] = num[j + 1];
                        break;
                    }
                }

            }

            // join the array up again back into sentence form
            newSentence = String.Join(" ", finalWords);
            //newSentence = String.Join(" ", newWords);
            //Console.WriteLine(finalWords);
            //Console.WriteLine(newWords);
            

            // print results
            Console.WriteLine("Your translated sentence is: " + newSentence + "\n");
            // any key to exit
            Console.ReadKey();
        }


    }



}
