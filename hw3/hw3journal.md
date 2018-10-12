# Homework 3

We didn't have a webpage to build this week, but we did have to use our brains and try to convert a program written in Java to a C# program. Since Western Oregon University has two required courses which teach you programming in Java, I felt pretty confident going into this week's homework.

There are five classes:

* Node
* QueueInterface
* QueueUnderflowException
* LinkedQueue
* Main

### Node:

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

There are some differences between the two codes:

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
        /// <exception name="NullReferenceException">Null element</exception>
        /// <returns name="element">Returns the element</returns>>
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

The first difference is the use of the `throw new NotImplementedException`. What is that? And why do I have to have it? Visual Studio was not happy with me when I tried to take these out, so I left them in. I need to figure out why this happens. Another difference is the capitalization of the node names. Java accepted lowercase letters while C# wanted these names in uppercase. I'm sure the constructor could have been added inline when creating the `Front` and `Rear` nodes, but I think I failed on a couple of attempts to get it correct and decided to move on in case there were problems later down the road. I can understand trying to rewrite things, but if they're working I feel I should leave as much of the original code intact to cause fewer disruptions in the program. So, if the C# code looks like the Java code, you're right. I only changed what needed to be changed to make the Java code work in C#.

`IsEmpty` appears to be something I could have made into one line by using a `null` verifier (I'm still learning folks) like `?`. I'll figure it out but for now, I need to move on to keep up with the pace of the class.

### Main (TestConverter)

I did not name my `Main` class *Main* and named it `TestConverter`.


