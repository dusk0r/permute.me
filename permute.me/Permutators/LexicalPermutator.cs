using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace permute.me.Permutators {

    /// <summary>
    /// Permutates in lexicographic order
    /// http://en.wikipedia.org/wiki/Permutation#Generation_in_lexicographic_order
    /// </summary>
    public class LexicalPermutator : IEnumerable<string> {
        private readonly String[] Parts;

        public LexicalPermutator(IEnumerable<string> parts) {
            this.Parts = parts.ToArray();
        }

        public IEnumerator<string> GetEnumerator() {
            string[] parts = Utils.CopyArray(Parts);

            yield return String.Join("", parts);

            while (true) {
                // find largest k with chars[k] < chars[k+1]
                int k = parts.Length - 2;
                while (k >= 0 && parts[k].CompareTo(parts[k + 1]) >= 0) {
                    k -= 1;
                }

                // finished if not found
                if (k < 0) {
                    break;
                }

                // find largest l with chars[k] < chars[l]
                int l = parts.Length - 1;
                while (parts[k].CompareTo(parts[l]) >= 0) {
                    l -= 1;
                }

                Utils.Swap(parts, k, l);

                // revert from k+1 to end
                Utils.Reverse(parts, k + 1, parts.Length - 1);
                yield return String.Join("", parts);
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}