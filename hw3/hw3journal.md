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

There is a `push`, `pop`, and `isEmpty` method in this class. `push` puts a new node in the linked list, `pop` removes the node from the linked list, and `isEmpty` checks the list to see if any nodes are present in the linked list. This is an interface and Visual Studio does have the option to create one from the *project* tab (*add class* scroll down to *interface*). The converted code is again similar to Java:

    public interface IQueueInterface<T>
        {
            /// <summary>
            /// Add an element to the end of the queue
            /// 
            /// </summary>>
            /// <param name="element"></param>
            /// <returns name="element"></returns>>
            T Push(T element);

            /// <summary>
            /// Remove and return the front element
            /// 
            /// </summary>>
            /// <returns name="tmp"></returns>>
            T Pop { get; }

            /// <summary>
            /// Test if the queue is empty
            /// 
            /// </summary>>
            /// <returns name="bool"></returns>>
            bool IsEmpty { get; }
        }
    }
    
In the C# version, Visual Studio wanted the `{ get; }` method for `Pop` and `IsEmpty`. If I'm remembering this correctly, I couldn't add the `throw new QueueUnderflowException()` to `Pop`. I will go back and double check that because it might not work. Oh! DON'T FORGET THE 'I' IN FRONT OF THE INTERFACE'S NAME! => IQueueInterface (Use Visual Studio, I think it added it automatically)

### QueueUnderflowException

Java provides a simple way of setting up your own exception class:

    public class QueueUnderflowException extends RuntimeException
    {
        public QueueUnderflowException()
        {
            super();
        }

        public QueueUnderflowException(String message)
        {
            super(message);
        }
}

The original Java version of this code `extends` the system `RuntimeException` and sets up two constructors. One constructor is the default constructor that the system will generate through it's `super` class. The second constructor includes a message that is sent to the user to provide information about the error. Here is the converted code for the QueueUnderflowException class:

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
    
By researching the `Exception` class in C# through the docs, I found that the `extends` command is `:`. The constructors are built a slight bit different than Java also. `base` is the `super` class and is where the system will default to for any errors that are caught regarding this issue. The system will send back a `Unhandled Exception` error message. The second constructor allows for custom messages that will be returned to the user from the system. There are two other constructors, one that is not in this code segment, but I'm not too clear on what they do. Dr. Morse told me not to worry about the one that has been removed and explained what the third one is but I need more knowledge to discuss what it does exactly. Apparently, you don't need to list all four constructors in a custom exception as I thought when reading the docs.

### LinkedQueue

Java offers a linked list class that accepts generics. The original code:

    public class LinkedQueue<T> implements QueueInterface<T>
    {
	   private Node<T> front;
	   private Node<T> rear;

	   public LinkedQueue()
	   {
		  front = null;
		  rear = null;
	   }

	   public T push(T element)
	   { 
		  if( element == null )
		  {
			throw new NullPointerException();
		  }
		
		  if( isEmpty() )
		  {
			Node<T> tmp = new Node<T>( element, null );
			rear = front = tmp;
		  }
		  else
		  {		
			// General case
			Node<T> tmp = new Node<T>( element, null );
			rear.next = tmp;
			rear = tmp;
        }
        return element;
	}     

	public T pop()
	{
		T tmp = null;
		if( isEmpty() )
		{
			throw new QueueUnderflowException("The queue was empty when pop was invoked.");
		}
		else if( front == rear )
		{	// one item in queue
			tmp = front.data;
			front = null;
			rear = null;
		}
		else
		{
			// General case
			tmp = front.data;
			front = front.next;
		}
		
		return tmp;
	}

	public boolean isEmpty()
	{              
		if( front == null && rear == null )
		{
			return true;
		}
		else
		{
			return false;
		}
	}

}


