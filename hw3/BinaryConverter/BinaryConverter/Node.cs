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
    public class Node<T>
    {
        public T Data { get; set; }                   // data is within the node
        public Node<T> Next { get; set; }            // next is the next node (reference to)

        /// <summary>
        /// Constructor for a node
        /// </summary>
        /// <param name="Data"></param>
        public Node(T Data, Node<T> Next) => this.Data = Data;    // current data 
    }
}
