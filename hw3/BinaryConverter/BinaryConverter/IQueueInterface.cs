using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryConverter
{
    /// A FIFO Queue Interface.
    /// This ADT is suitable for a single linked queue
    /// 
    /// <typeparam name="T"></typeparam>
    public interface IQueueInterface<T>
    {
        /// Add an element to the end of the queue
        /// 
        /// 
        /// <param name="element"></param>
        /// <returns>element that was enqueued</returns>
        T Push(T element);

        /// Remove and return the front element
        /// 
        /// <throws><thrown>if queue is empty</thrown></throws>
        /// <returns></returns>
        T Pop() throws QueueUnderflowException;

        /// Test if the queue is empty
        /// 
        /// <returns>true if the queue is empty; otherwise false</returns>
        bool IsEmpty { get; }
    }
}
