using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryConverter
{

    /// <summary>
    /// A single linked node class
    /// 
    /// </summary>
    public class LinkedListNode<T>
    { 
        public T Data { get; set; }                             // data is within the node
<<<<<<< HEAD
        public LinkedListNode<T> Next { get; set; };            // next is the next node (reference to)
=======
        public LinkedListNode<T> Next { get; set; }           // next is the next node (reference to)
>>>>>>> 95a141800cae33eaf90fef4042ba010c21c0e8c5

        /// <summary>
        /// Constructor for a node
        /// </summary>
        /// <param name="Data"></param>
        public LinkedListNode(T Data) => this.Data = Data;  // current data 
    }
}
