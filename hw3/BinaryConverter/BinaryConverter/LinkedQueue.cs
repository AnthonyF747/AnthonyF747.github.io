using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryConverter
{
    /// <summary>
    /// A single linked FIFO queue
    /// From Dale, Joyce, and Weems "Object-Oriented Data Structures Using Java
    /// Modified by Scot Morse for CS460
    /// 
    /// This project is converting the modified Java version to a working C# version
    /// @author Anthony Franco
    /// @version 10/10/2018 Version 1.0
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class LinkedQueue<T> : IQueueInterface<T>           // LinkedList of generic type which implements IQueueInterface
                                                        // which is a queue interface
    {
        private Node<T> Front;                          // The first node
        private Node<T> Rear;                           // The last node

        public LinkedQueue()                            // Constructor
        {
            Front = null;                               // Set Front to null
            Rear = null;                                // Set Rear to null
        }

        /// <summary>
        /// Used to check if the list is empty
        /// </summary>
        /// <returns name="bool">Returns true is list is empty, otherwise false</returns>
        public bool IsEmpty()
        {
            if(Front == null && Rear == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        T IQueueInterface<T>.Pop => throw new NotImplementedException();

        bool IQueueInterface<T>.IsEmpty => throw new NotImplementedException();

        /// <summary>
        /// Removes a node from the front of the queue
        /// </summary>
        /// <exception name="QueueUnderflowException">throw QueueUnderflowException if list is empty on pop() request</exception>>
        /// <returns name="tmp">returns tmp node</returns>
        public T Pop()
        {
            T tmp;                            // New node

            if(IsEmpty())                     // Check if list is empty
            {
                Exception message = null;     // Set up message for exception; if list is empty, throw exception with message
                throw new QueueUnderflowException("Message: The list is empty\n{0}", message);
            }
            else if(Front == Rear)            // Check if there is one item in the list       
            {
                tmp = Front.Data;             // If one node, assign that node to tmp
                Front = null;                 // Set front to null
                Rear = null;                  // Set rear to null
            }
            else                              // General case
            {
                tmp = Front.Data;             // Assign the first node in the list to tmp
                Front = Front.Next;           // The next node becomes the first node in the list
            }
            return tmp;                       // Return tmp node
        }

        /// <summary>
        /// Use to push an element into the queue
        /// </summary>
        /// <param name="element"></param>
        /// <exception name="NullReferenceException">Null element</exception>>
        /// <returns name="element">Returns the element</returns>
        public T Push(T element)
        {
            if(element == null)                             // Check if there is a null element
            {
                throw new NullReferenceException();         // System exception default
            }

            if(IsEmpty())                                   // Check if the list is empty
            {
                Node<T> tmp = new Node<T>(element, null);   // If empty, make a new node
                Rear = Front = tmp;                         // Make new node front and rear element in the list
            }
            else                                            // General case
            {
                Node<T> tmp = new Node<T>(element, null);   // Make a new node
                Rear.Next = tmp;                            // Put new node at the end of the queue
                Rear = tmp;                                 // Assign that node last element in the list
            }
            return element;                                 // Return the element
        }

        T IQueueInterface<T>.Push(T element)
        {
            throw new NotImplementedException();
        }
    }
}
