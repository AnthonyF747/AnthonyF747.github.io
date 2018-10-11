using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryConverter
{
    /// <summary>
<<<<<<< HEAD
    /// Exception class for pop()
    /// Exception class for linked-list queue pop() attribute
=======
    /// Exception class for linked-list queue pop() attribute
    /// 
>>>>>>> 95a141800cae33eaf90fef4042ba010c21c0e8c5
    /// </summary>
    [Serializable]
    class QueueUnderflowException : System.Exception
    {
        /// <summary>
        /// Multiple constructors for different situations
        /// </summary>
        public QueueUnderflowException() : base() { }   // Default constructor
        public QueueUnderflowException(string message) : base(message) { }    // Constructor that sets message property
        public QueueUnderflowException(string message, System.Exception inner) : base(message, inner) { }   // Sets message and inner properties

        // Constructor for Serialization; Exception propagates from remote server to client
        protected QueueUnderflowException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
        { }
    }
}
