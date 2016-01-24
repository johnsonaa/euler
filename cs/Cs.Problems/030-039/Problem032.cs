﻿// Author: Aaron Johnson
// Date:   2016-01-23
//
// Sovles Euler problem 32.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Cs.Problems
{
    /// <title>Pandigital Products</title>
    /// <summary>
    /// We shall say that an n-digit number is pandigital if it makes use of all the digits 1 to n exactly once; for example, the 5-digit number, 15234, is 1 through 5 pandigital.
    /// 
    /// The product 7254 is unusual, as the identity, 39 × 186 = 7254, containing multiplicand, multiplier, and product is 1 through 9 pandigital.
    /// 
    /// Find the sum of all products whose multiplicand/multiplier/product identity can be written as a 1 through 9 pandigital.
    /// HINT: Some products can be obtained in more than one way so be sure to only include it once in your sum.
    /// </summary>
    public class Problem032 : IProblem
    {
        // Permute logic should ideally exist in a library, not here
        #region Permutations
        public IEnumerable<char[]> Permute(char[] characters)
        {
            yield return characters;
            while (NextPermutation(characters))
                yield return characters;
        }

        /// https://github.com/eoincampbell/combinatorics/blob/master/Combinatorics.Net40/Collections/Permutations.cs
        /// http://www.cut-the-knot.org/do_you_know/AllPerm.shtml
        private bool NextPermutation(char[] characters)
        {
            int i = characters.Length - 1;
            while (characters[i-1] >= characters[i])
            {
                i--;
                if (i == 0)
                    return false;
            }

            int j = characters.Length;
            while (characters[j-1] <= characters[i-1])
            {
                j--;
            }

            Swap(characters, i-1, j-1);
            i++;
            j = characters.Length;
            while (i < j)
            {
                Swap(characters, i-1, j-1);
                i++;
                j--;
            }

            return true;
        }

        public void Swap(char[] a, int i, int j)
        {
            char c = a[i];
            a[i] = a[j];
            a[j] = c;
        }
        #endregion

        private IEnumerable<Tuple<int,int,int>> FindValidProducts(ICollection<char> digits)
        {
            var sdigits = string.Join("", digits);
            for (var i = 1; i <= 7; i++)
                for (var j = 1; j <= 8-i; j++)
                {
                    var a = int.Parse(sdigits.Substring(0, i));
                    var b = int.Parse(sdigits.Substring(i, j));
                    var c = int.Parse(sdigits.Substring(i+j));
                    if (a*b == c)
                        yield return Tuple.Create(a, b, c);
                }
        }

        private IEnumerable<IList<char>> PandigitalPermutations()
        {
            return Permute(new [] { '1', '2', '3', '4', '5', '6', '7', '8', '9' });
        }

        private HashSet<Tuple<int,int,int>> CalculatePandigitalProducts()
        {
            var permutations = PandigitalPermutations();
            var set = new HashSet<Tuple<int,int,int>>();

            foreach (var p in permutations)
            {
                var validProducts = FindValidProducts(p);
                validProducts.ToList().ForEach(x => set.Add(x));
            }

            return set;
        }

        public string Solve()
        {
            var products = CalculatePandigitalProducts();
            var answer = products.Select(x => x.Item3).Distinct().Sum();
            return answer.ToString();
        }
    }
}
