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