using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryConverter
{

    /// <summary>
    /// Print the binary representations of all numbers 1 to n.
    /// This is accomplished by using a FIFO queue to perform a level
    /// order (i.e. BFS) traversal of a virtual binary tree.
    /// </summary>
    class TestConverter
    {
        private static LinkedList<string> GenerateBinaryRepresentationList(int n)
        {
            // Create an empty queue of strings with which to perform the traversal
            LinkedQueue<StringBuilder> q = new LinkedQueue<StringBuilder>();

            // A list for returning the binary numbers
            LinkedList<string> output = new LinkedList<string>();

            if(n < 1)
            {
                // Binary representation of negative values are not supported; return an empty list
                throw new InvalidOperationException();
            }

            // Enqueue the first binary number. Use a dynamic string to avoid string concat
            q.Push(new StringBuilder("1"));

            // BFS
            while(n-- > 0)
            {
                // Print the front of the queue
                StringBuilder sb = q.Pop();
                output.AddLast(sb.ToString());

                // Make a copy
                StringBuilder sbc = new StringBuilder(sb.ToString());

                // Left child
                sb.Append('0');
                q.Push(sb);

                // Right child
                sbc.Append('1');
                q.Push(sbc);
            }
            return output;
        }

        //Driver program to test above function
        static void Main(string[] args)
        {
            int n = 0;

            if(args.Length < 1)
            {
                Console.WriteLine("Please invoke with the max value to print binary up to, like this: ");
                Console.WriteLine("\t BinaryConverter.exe 12");
                return;
            }

            try
            {
                n = Int32.Parse(args[0]);
            }
            catch(FormatException)
            {
                Console.WriteLine("I'm sorry, I can't understand the number: {0}", args[0]);
                return;
            }
            
            if(n < 0)
            {
                throw new InvalidOperationException(message: "Message: Negative numbers are not supported");
            }

            LinkedList<string> output = GenerateBinaryRepresentationList(n);

            // Print right justified. Longest string is last one.
            // Print enough spaces to move it over the correct distance
            int maxLength = output.Last().Length;
            foreach (string s in output)
            {
                for (int i = 0; i < maxLength - s.Length + 1; ++i)
                {
                    Console.Write(" ");
                }
                Console.WriteLine(s);
            }
        }
    }
}
