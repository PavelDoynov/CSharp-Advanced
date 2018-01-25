# CSharp-Advanced
C# Advanced course / SoftUni

01. Stacks and Queues

- Stack 

LIFO - Last In First Out
using System.Collections.Generic 

Stack<int> stack = new Stack<int> ();
     <char>
     <string>
     <object>
     <int[]>

stack.Push(3); - put element "3" in the stack

stack.Pop(); - get and delete last element in the stack
int number = stack.Pop(); - example

stack.Peek(); - get or see the last element

stack.Count; - give you the size of the stack


- Queue

FIFO - First In First Out
using System.Collections.Generic

Queue<int> stack = new Queue<int> ();
     <char>
     <string>
     <object>
     <int[]>

stack.Enqueue(3); - put element "3" in the queue

stack.Dequeue(); - get and delete last element in the queue
int number = stack.Pop(); - example

stack.Peek(); - get or see the last element

stack.Count; - give you the size of the queue
