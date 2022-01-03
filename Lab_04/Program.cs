using System;
using static System.Console;
using System.Diagnostics;

namespace Lab_04
{
    class Program
    {
        const int N = 100;
        const int TRYS = 80;
        static int whileCount = 0;
        static int forCount = 0;
        static int swapCount = 0;

        static void Main(string[] args)
        {
            int[] list = new int[N];
            Random r = new Random();
            Stopwatch sw = new Stopwatch();

            // Step 1 Fill array with random numbers
            for(int i=0; i<N; i++)
            {
                list[i] = r.Next(1, N + 1);
            }

            // Step 2 Show unsorted array
            WriteLine("Unsorted: ");
            foreach(int i in list)
            {
                Write(i + " ");
            }
            WriteLine();

            // step 3 Burn first, reset counters
            BubbleSort(list, N);
            swapCount = 0;
            whileCount = 0;
            forCount = 0;

            // step 4 Show that it worked
            WriteLine("Sorted: ");
            foreach(int i in list)
            {
                Write(i + " ");
            }
            WriteLine();

            // Step 5 Run sort multiple times
            double elapsed = 0;
            for(int t=0; t<TRYS; t++)
            {
                // use a new set of random numbers each time
                for(int i=0; i<N; i++)
                {
                    list[i] = r.Next(1, N + 1);
                }
                sw.Restart();
                BubbleSort(list, N);
                sw.Stop();
                elapsed += sw.Elapsed.TotalMilliseconds;
            }

            // Step 6 Do the math
            WriteLine("Average milliseconds = " + elapsed / TRYS);
            WriteLine("Average while count is " + (double)whileCount / TRYS);
            WriteLine("Average for count is " + (double)forCount / TRYS);
            WriteLine("Average swap count is " + (double)swapCount / TRYS);
            ReadLine();
        }
        static void BubbleSort(int[] list, int max)
        {
            int numberOfPairs = max;
            Boolean swappedElements = true;

            while (swappedElements)
            {
                whileCount = whileCount + 1;
                numberOfPairs = numberOfPairs - 1;
                swappedElements = false;
                for(int i=0; i<numberOfPairs; i++)
                {
                    forCount = forCount + 1;
                    if(list[i] > list[i+1])
                    {
                        Swap(list, i, i + 1);
                        swappedElements = true;
                        swapCount = swapCount + 1;
                    }
                }
            }
        }
        
        // swap is VERY different from the books, USE THIS ONE!
        static void Swap(int[] list, int x, int y)
        {
            int temp = list[y];
            list[y] = list[x];
            list[x] = temp;
        }
    }
}
