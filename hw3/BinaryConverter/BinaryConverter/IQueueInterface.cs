using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryConverter
{
    /// <summary>
    /// A FIFO Queue Interface.
    /// This ADT is suitable for a single linked queue
    /// 
    /// </summary>>
    /// <typeparam name="T"></typeparam>
    public interface IQueueInterface<T>
    {
        /// <summary>
        /// Add an element to the end of the queue
        /// 
        /// </summary>>
        /// <param name="element"></param>
        /// <returns name="element"></returns>>
        T Push(T element);

        /// <summary>
        /// Remove and return the front element
        /// 
        /// </summary>>
        /// <returns name="tmp"></returns>>
        T Pop { get; }

        /// <summary>
        /// Test if the queue is empty
        /// 
        /// </summary>>
        /// <returns name="bool"></returns>>
        bool IsEmpty { get; }
    }
}
