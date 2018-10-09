using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryConverter

    /// A single linked node class
{
    public class Node<T>
    { 
        public T data;                      // data is within the node
        public Node<T> next;                // next is the next node (reference to)
    
        public Node(T data, Node<T> next)
        {
            this.data = data;              // current data 
            this.next = next;              // current reference to next node
        }
    }
}
