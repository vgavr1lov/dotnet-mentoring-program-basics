using System;
using Tasks.DoNotChange;

namespace Tasks
{
   public class HybridFlowProcessor<T> : IHybridFlowProcessor<T>
   {
      public DoublyLinkedList<T> DoublyLinkedList { get; private set; }
      public HybridFlowProcessor()
      {
         DoublyLinkedList = new DoublyLinkedList<T>();
      }
      public T Dequeue()
      {
         if (DoublyLinkedList.Length == 0)
            throw new InvalidOperationException("No data to be removed");

         return DoublyLinkedList.RemoveAt(0);
      }

      public void Enqueue(T item)
      {
         DoublyLinkedList.Add(item);
      }

      public T Pop()
      {
         if (DoublyLinkedList.Length == 0)
            throw new InvalidOperationException("No data to be removed");

         return DoublyLinkedList.RemoveAt(DoublyLinkedList.Length - 1);
      }

      public void Push(T item)
      {
         DoublyLinkedList.Add(item);
      }
   }

}
