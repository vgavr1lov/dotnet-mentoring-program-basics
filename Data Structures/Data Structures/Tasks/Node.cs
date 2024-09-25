using System;

namespace Tasks
{
   public class Node<T>
   {
      public T Value { get; set; }
      public Node<T> Next { get; set; }
      public Node<T> Previous { get; set; }
      public Node(T value)
      {
         Value = value;
         Next = null;
         Previous = null;

      }

      public Node<T> Traverse(int index)
      {
         if (index < 0)
            throw new IndexOutOfRangeException($"{index} is out of range!");

         if (index == 0)
            return this;
         else
         {
            if (Next == null)
               throw new IndexOutOfRangeException($"{index} is out of range!");
            return Next.Traverse(index - 1);
         }
      }

      public Node<T> TraverseReversal(int index)
      {
         if (index < 0)
            throw new IndexOutOfRangeException($"{index} is out of range!");

         if (index == 0)
            return this;
         else
         {
            if (Previous == null)
               throw new IndexOutOfRangeException($"{index} is out of range!");
            return Previous.TraverseReversal(index - 1);
         }
      }
   }
}
