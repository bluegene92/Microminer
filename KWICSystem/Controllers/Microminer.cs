using KWICSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace KWICSystem.Controllers
{
    public class Microminer : IMicrominer
    {
        private IDatabaseManager _databaseManager;
        public Microminer(IDatabaseManager databaseManager)
        {
            _databaseManager = databaseManager;
        }

        public List<string> FindUrl(string keywords)
        {
            string[] keywordArray = keywords.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            List<string> sourceResult = new List<string>();
            List<string> firstKeyMatchList = new List<string>();
            List<string> sourceOriginal = new List<string>(_databaseManager
                                                    .GetLastSource()
                                                    .Body
                                                    .Split(new string[] { "\r\n" },
                                                        StringSplitOptions.RemoveEmptyEntries));

            List<string> sourceInputList = new List<string>(_databaseManager
                                                    .GetLastKWICSource()
                                                    .Body
                                                    .Split(new string[] { "\r\n" },
                                                        StringSplitOptions.RemoveEmptyEntries));
            string firstKeyword = keywordArray[0];

            while (BinarySearchSource(ref sourceInputList, firstKeyword) != -1)
            {
                int foundIndex = BinarySearchSource(ref sourceInputList, firstKeyword);
                firstKeyMatchList.Add(sourceInputList.ElementAt(foundIndex));
                sourceInputList.RemoveAt(foundIndex);
                if (keywordArray.Length > 1)
                {
                    for (int i = 1; i<keywordArray.Length; i++)
                    {
                        for (int j = 0; j< firstKeyMatchList.Count; j++)
                        {
                            if (!firstKeyMatchList.ElementAt(j).Contains(keywordArray[i]))
                            {
                                firstKeyMatchList.RemoveAt(j);
                            }
}
                    }
                }
            }

            List<string> finalOutput = new List<string>();
            for (int i = 0; i < sourceOriginal.Count; i++)
            {
                firstKeyMatchList.ForEach(x => {
                    int urlIndexHttp = Regex.Match(x, @"\bhttp|https\b").Index;
                    string currHttpString = x.Substring(urlIndexHttp);
                    if (sourceOriginal[i].Contains(currHttpString))
                    {
                        finalOutput.Add(sourceOriginal[i]);
                    }
                });
            }
            return finalOutput;
        }


        public static int BinarySearchSource(ref List<string> inputArray, string key)
        {
            int min = 0;
            int max = inputArray.Count - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                string firstWord = inputArray[mid].Substring(0, inputArray[mid].IndexOf(" "));
                if (key.CompareTo(firstWord) == 0) { return mid; }
                else if (key.CompareTo(firstWord) == -1) { max = mid - 1; }
                else { min = mid + 1; }
            }
            return -1;
        }


    }

}
