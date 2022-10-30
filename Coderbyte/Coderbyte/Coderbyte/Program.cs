using System;
using System.Collections.Generic;
using System.Linq;

namespace Coderbyte
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = new string[] { "(2,3)", "(1,2)", "(4,9)", "(9,3)", "(12,9)", "(6,4)" };
            Console.WriteLine(TreeConstructor(str).ToString());
        }

        public static bool TreeConstructor(string[] strArr)
        {
            var pairNumbers = new List<(int, int)>();
            for (int i = 0; i < strArr.Length; i++)
            {
                var result = strArr[i]
                    .Replace("(", "")
                    .Replace(")", "")
                    .Split(",")
                    .Select(x => Convert.ToInt32(x))
                    .ToArray();
                pairNumbers.Add((result[0],result[1]));
            }

            int countBase = 0;
            int? root = null;

            for (int i = 0; i < pairNumbers.Count; i++)
            {
                int aimRootNumber = pairNumbers[i].Item2;
                int aimLeafNumber = pairNumbers[i].Item1;
                int count = 1;
                int countRoot = 0;
                
                for (int j = 0; j < pairNumbers.Count; j++)
                {
                    if (i == j) continue;

                    if (pairNumbers[j].Item2 == aimRootNumber)
                    {
                        count++;
                        if (count > 2) return false;
                    }

                    if (pairNumbers[j].Item1 == aimRootNumber)
                    {
                        countRoot++;
                        if (countRoot > 1) return false;
                    }

                    if (pairNumbers[j].Item1 == aimLeafNumber)
                    {
                        return false;
                    }
                }

                if (countRoot == 0 && root != pairNumbers[i].Item2)
                {
                    root = pairNumbers[i].Item2;
                    countBase++;
                    if (countBase > 1) return false;
                }
            }

            return true;
        }
    }
}
