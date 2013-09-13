using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace permute.me.Permutators {

    public static class Utils {

        public static T[] CopyArray<T>(T[] array) {
            var newArray = new T[array.Length];
            Array.Copy(array, newArray, array.Length);
            return newArray;
        }

        public static void Swap<T>(T[] array, int idxa, int idxb) {
            T temp = array[idxa];
            array[idxa] = array[idxb];
            array[idxb] = temp;
        }

        public static void Reverse<T>(T[] array, int start, int end) {
            while (start < end) {
                Swap(array, start, end);
                start += 1;
                end -= 1;
            }
        }
    }
}