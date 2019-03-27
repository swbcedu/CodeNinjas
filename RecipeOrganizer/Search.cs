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

            // A list of index locations of positive search results
            List<int> indexList = new List<int>();

            // Tracking search terms that have been found. If empty, the search included all terms
            List<string> termsNotFound = new List<string>();

            foreach (string term in searchTerms)
            {
                termsNotFound.Add(term);
            }

            int searchIndex = 0;
            foreach (string thing in toSearch)
            {
                foreach (string term in searchTerms)
                {
                    if (thing.ToLower().Contains(term.ToLower()))
                    {
                        // Store the index of the search object, only if it does not already exist in the indexList (so we only store it once)
                        if (!indexList.Contains(searchIndex))
                        {
                            indexList.Add(searchIndex);
                        }

                        // Remove search term from termsNotFound
                        termsNotFound.Remove(term);
                    }
                }

                searchIndex += 1;
            }

            // The search is only "successful" if all search keywords are found
            if (termsNotFound.Count == 0)
            {
                found = true;
            }

            foundIndex = indexList;
        }
    }
}
