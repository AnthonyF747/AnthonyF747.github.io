using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryConverter
{
    /// <summary>
    /// Exception class for pop()
    /// Exception class for linked-list queue pop() attribute
    /// 
    /// </summary>
    class QueueUnderflowException : System.Exception
    {
        /// <summary>
        /// Multiple constructors for different situations
        /// </summary>
        public QueueUnderflowException() : base() { }   // Default constructor
        public QueueUnderflowException(string message) : base(message) { }    // Constructor that sets message property
        public QueueUnderflowException(string message, System.Exception inner) : base(message, inner) { }   // Sets message and inner properties
    }
}
