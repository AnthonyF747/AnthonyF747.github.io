using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryConverter

    /// A single linked node class
{
    public class LinkedListNode<T>
    { 
        public T data;                      // data is within the node
        public LinkedListNode<T> next;                // next is the next node (reference to)
    
        public LinkedListNode(T data, LinkedListNode<T> next)
        {
            this.data = data;              // current data 
            this.next = next;              // current reference to next node
        }
    }
}
