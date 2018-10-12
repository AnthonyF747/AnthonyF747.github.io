# Homework 3

We didn't have a webpage to build this week, but we did have to use our brains and try to convert a program written in Java to a C# program. Since Western Oregon University has two required courses which teach you programming in Java, I felt pretty confident going into this week's homework.

There are five classes:
    * Node
    * QueueInterface
    * QueueUnderflowException
    * LinkedQueue
    * Main

### __Node:__

This is the original code in Java:

public class Node<T>
{
	public T data;
	public Node<T> next;
	
	public Node( T data, Node<T> next )
	{
		this.data = data;
		this.next = next;
	}
}

I've worked with Visual Studio what seems to be eons ago, so I had to refamiliarize myself with the program to get going, but once that was semi-under control, I started with research and coding. I did have some knowledge of C and some C# and know that it really is close to Java, but I didn't know too much about the "fancy" syntax that C# includes. My knowledge of C# is pretty basic stuff, so I wrote the code pretty much as was given until my research showed some cool stuff. So, I rewrote my code:

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

The inline `get` and `set` methods are sweet! I know I read about them or have seen them before, but I totally forgot about them until I was researching the C# language (thank you Microsoft for wonderful online documentation on the language!). Generics in C# appear similar to Java so that conversion wasn't difficult. In Visual Studio, it's added to the page through `using System.Collections.Generic;`. In the constructor, I wasn't sure if I was supposed to add the `this.next = next;` portion of the code because Visual Studio detested it every time added it to the code. I figured the program would crash if it really needed that piece of code. I'm not sure if the `HML` stuff works? It looks really bulky though. Moving on...

### QueueInterface

The QueueInterface is used to set up the LinkedQueue class to act as a queue (FIFO). There was not much in the class written in Java:

    public interface QueueInterface<T>
    {
        /**
        * Add an element to the rear of the queue
        * 
        * @return the element that was enqueued
        */
        T push(T element);

        /**
        * Remove and return the front element.
        * 
        * @throws Thrown if the queue is empty
        */
        T pop() throws QueueUnderflowException;

        /**
        * Test if the queue is empty
        * 
        * @return true if the queue is empty; otherwise false
        */
        boolean isEmpty();
}

There is a `push`, `pop`, and `isEmpty` method in this class. `push` puts a new node in the linked list, `pop` removes the node from the linked list, and `isEmpty` checks the list to see if any nodes are present in the linked list. This is an interface and Visual Studio does have the option to create one from the *project* tab (*add class* scroll down to *interface*).