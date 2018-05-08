using System;

namespace lab4
{
    internal static class Program
    {
        public static void Main()
        {
            Mather mather = null;
            try
            {
                mather = new Mather("FPM", "Dmytro", 1003, 32);

                // Determine the maximum number of generations the system
                // garbage collector currently supports.
                Console.WriteLine("The highest generation is {0}", GC.MaxGeneration);

                mather.WriteHelloToConsole();

                // Determine which generation mather object is stored in.
                Console.WriteLine("Generation: {0}", GC.GetGeneration(mather));

                // Determine the best available approximation of the number 
                // of bytes currently allocated in managed memory.
                Console.WriteLine("Total Memory (without waiting of garbage collection): {0}",
                    GC.GetTotalMemory(false));

                Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(true));

                // Perform a collection of generation 0 only.
                GC.Collect(0);

                var wr = new WeakReference(mather);
                Console.WriteLine("Is first object alive: " + wr.IsAlive);

                GC.Collect(2, GCCollectionMode.Forced);
                Console.WriteLine("Is first object alive: " + wr.IsAlive);
            }
            finally
            {
                if (mather != null)
                {
                    mather.Dispose();
                    Console.WriteLine(mather.ToString());
                }
            }
        }
    }
}