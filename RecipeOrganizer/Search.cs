using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeOrganizer
{
    public static class Search
    {
        public static void IsFound(List<string> searchTerms, List<string> toSearch, out bool found, out List<int> foundIndex)
        {
            found = false;
            List<int> indexList = new List<int>();

            int searchIndex = 0;
            foreach (string thing in toSearch)
            {
                System.Console.WriteLine($"Search string:\n{thing}\n");
                
                foreach (string term in searchTerms)
                {
                    System.Console.WriteLine($"Keyword:\n{term}\n");
                    if (thing.Contains(term))
                    {
                        found = true;

                        if (!indexList.Contains(searchIndex))
                        {
                            indexList.Add(searchIndex);
                        }
                    }
                }

                searchIndex += 1;
            }

            foundIndex = indexList;
        }
    }
}
