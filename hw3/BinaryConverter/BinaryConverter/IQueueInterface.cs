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
        /// <returns>element that was enqueued</returns>
        T Push(T element);

        /// <summary>
        /// Remove and return the front element
        /// 
        /// </summary>>
        /// <throws><thrown>if queue is empty</thrown></throws>
        /// <returns></returns>
        T Pop();

        /// </summary>> 
        /// <throws><thrown>if queue is empty</thrown></throws>
        /// <returns></returns>
        T Pop();
        
        /// <summary>
        /// Test if the queue is empty
        /// 
        /// </summary>>
        /// <returns>true if the queue is empty; otherwise false</returns>
        bool IsEmpty { get; }
    }
}
