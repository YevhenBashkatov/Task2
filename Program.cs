using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    static class Searcher {

        static public string[] PopularWords(string stringInput) {

            List<string> lstString = new List<string>();
            string currentString = "";
            string[] finalResult = new string[3];
            
            //Localization of words
            foreach (var j in stringInput) {
                currentString += j;
                if(j==' ')
                {
                    lstString.Add(currentString.Trim());
                    currentString = "";
                }
            }

            //Adding last word in List
            lstString.Add(stringInput.Substring(stringInput.LastIndexOf(' ')));

            //Cleaning our data in List for objective result in future query
            for (int k = 0; k < lstString.Count; k++) {

                lstString[k] = lstString[k].ToLower();
                lstString[k] = lstString[k].Trim(new char[] { ',' ,'.','!','?',' '});
            
            }
            //Simple sql query, righted by LINQ. 
            //countUniqueWords created to comply technical task
            var uniqueWords = lstString.GroupBy(x => x).OrderByDescending(y => y.Count());
            var countUniqueWords = uniqueWords.Select(x => x).Count();

            if (countUniqueWords < 3)
            {
                return finalResult;
            }
            else
            {
                int i = 0;

                //Technical task requires array in OUT, so here we making OUT array
                foreach (IGrouping<string, string> g in uniqueWords.Take(3))
                {
                    finalResult[i] = g.Key;
                    i++;
                }

                return finalResult;
            }
        }
    
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Expected: IN ----> testString ; OUT ----> array containing words: dear, friend, my
            //Special TODO: different location in array. For example by length or something else.
            string testString = "Hello, dear friend! Hello-hello. Friend,  dear my friend. My Fr`iend.";
          
            foreach (var k in Searcher.PopularWords(testString)) {
                Console.WriteLine(k);
            
            }
        }
    }
}
