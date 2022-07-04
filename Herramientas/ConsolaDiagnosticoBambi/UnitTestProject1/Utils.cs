using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartTest
{
    public static class Utils
    {

        public static bool AreEquals(Queue<byte[]> queue1, Queue<byte[]> queue2)
        {

            if (queue1.Count != queue1.Count) return false;

            for (int i = 0; i < queue1.Count; i++)
            {
                if (!AreEquals(queue1.Dequeue(), queue2.Dequeue())) return false;
            }

            return true;
        }


        public static bool AreEquals(byte[] array1, byte[] array2)
        {
            if (array1.Length != array2.Length) return false;

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i]) return false;
            }

            return true;
        }
    }
}
