using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostCommonWordInHamlet
{
    class Program
    {
        static void Main(string[] args)
        {
            string playText = System.IO.File.ReadAllText("C:\\programming\\FullStackDotNet\\WeekThree\\MostCommonWordInHamlet\\MostCommonWordInHamlet\\hamlet.txt");

            // Dictionary creates a collection of keys and values that we can add/remove/sort
            var frequencies = new Dictionary<string, int>();
            string highestWord = null;
            int highestFreq = 0;

            // trying to make our string as clean as possible
            var message = string.Join(" ", playText);
            var splitchar = new char[] { ' ', '.',';',',',':' };
            var single = message.Split(splitchar, StringSplitOptions.RemoveEmptyEntries);

            // I'm setting up an array of words that I _don't_ want to iterate through later
            var removeWords = new String[] { "that", "this", "your", "with" };
            foreach ( var item in single)
            {
                int freq;
                // I still had words with line returns and spaces, so triming should fix most of that
                string trimed = item.Trim();
                // I had setup an array(removeWords) and was manually adding words to it as
                // they showed up as the most frequently used. Then I decided I could probably
                // just not count any word that was three characters are less as those are probably
                // all pretty commonly used words, so I set up this if statement.
                if( trimed.Length > 3)
                {
                    // TryGetValue tries to get the value of the key - in this case trimed
                    // I'm going to presume that "out freq" means that it is assigning the
                    // value of key to a variable named freq
                    frequencies.TryGetValue(trimed, out freq);
                    // if we are accessing this word, we ran across it in our string, 
                    // so increase our counter (freq)
                    freq += 1;

                    if (freq > highestFreq)
                    {
                        highestFreq = freq;
                        highestWord = item.Trim();
                    }

                    frequencies[trimed] = freq;
                }
                // Now iterate through our words to remove. It will re-add them if
                // it comes across them again, but it wasn't working outside of
                // this loop, so I guess this is fine.
                foreach (string removeMe in removeWords)
                {
                    frequencies.Remove(removeMe);
                }
            }

            Console.WriteLine("The most used word is \"{0}\" as it is used {1} times in Shakespeare's \"Hamlet\".", highestWord, highestFreq);
            Console.ReadLine();
        }
    }
}
