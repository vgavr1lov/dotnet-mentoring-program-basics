using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Tasks.DoNotChange;

namespace Tasks
{
   public class DoublyLinkedList<T> : IDoublyLinkedList<T>, IEnumerable<T>
   {
      public Node<T> HeadNode { get; set; }
      public Node<T> TailNode { get; set; }
      public int Length { get; private set; }

      public void Add(T e)
      {
         if (HeadNode == null)
         {
            HeadNode = new Node<T>(e);
            TailNode = HeadNode;
         }
         else
         {
            var newNode = new Node<T>(e);
            LinkNodes(TailNode, newNode);
            TailNode = newNode;
         }

         Length++;
      }

      public void AddAt(int index, T value)
      {
         if (index < 0 || index > Length)
            throw new IndexOutOfRangeException($"{index} is out of range!");

         if (index == 0)
            AddAtBeginning(value);
         else if (index == Length)
            AddAtEnd(value);
         else if (index <= Length / 2)
            AddAtFirstHalf(index, value);
         else if (index > Length / 2)
            AddAtSecondHalf(index, value);

         Length++;
      }

      private void AddAtBeginning(T value)
      {
         var tempNode = HeadNode;
         HeadNode = new Node<T>(value);
         if (tempNode != null)
            LinkNodes(HeadNode, tempNode);
      }

      private void AddAtEnd(T value)
      {
         var newNode = new Node<T>(value);
         LinkNodes(TailNode, newNode);
         TailNode = newNode;
      }

      private void AddAtFirstHalf(int index, T value)
      {
         var currentNode = HeadNode.Traverse(index);
         var tempNode = new Node<T>(value);
         SwapLinks(tempNode, currentNode);
         LinkNodes(tempNode, currentNode);
      }

      private void AddAtSecondHalf(int index, T value)
      {
         var currentNode = TailNode.TraverseReversal(index);
         var tempNode = new Node<T>(value);
         SwapLinks(tempNode, currentNode);
         LinkNodes(tempNode, currentNode);
      }

      private void LinkNodes(Node<T> firstNode, Node<T> secondNode)
      {
         firstNode.Next = secondNode;
         secondNode.Previous = firstNode;
      }

      private void SwapLinks(Node<T> firstNode, Node<T> secondNode)
      {
         firstNode.Previous = secondNode.Previous;
         secondNode.Previous.Next = firstNode;
      }

      public T ElementAt(int index)
      {
         if (HeadNode == null || index >= Length || index < 0)
            throw new IndexOutOfRangeException($"{index} is out of range!");

         return (index <= Length / 2)
            ? HeadNode.Traverse(index).Value
            : TailNode.TraverseReversal(--Length - index).Value;
      }

      public void Remove(T item)
      {
         if (HeadNode == null)
            return;

         if (HeadNode.Value.Equals(item))
         {
            if (HeadNode.Next != null)
               HeadNode.Next.Previous = null;
            HeadNode = HeadNode.Next;
            Length--;
         }
         else
         {
            RemoveFirstOccurance(HeadNode, item);
         }
      }
      private void RemoveFirstOccurance(Node<T> node, T value)
      {
         if (node.Value.Equals(value))
         {
            if (node.Previous != null)
               node.Previous.Next = node.Next;
            if (node.Next != null)
               node.Next.Previous = node.Previous;
            if (node == TailNode)
               TailNode = node.Previous;

            Length--;
         }
         else
         {
            if (node.Next == null)
               return;

            RemoveFirstOccurance(node.Next, value);
         }
      }

      public T RemoveAt(int index)
      {
         if (HeadNode == null || index >= Length || index < 0)
            throw new IndexOutOfRangeException($"{index} is out of range!");

         Node<T> nodeAtIndex;

         nodeAtIndex = (index <= Length / 2)
            ? HeadNode.Traverse(index)
            : TailNode.TraverseReversal(--Length - index);

         if (nodeAtIndex.Previous != null)
            nodeAtIndex.Previous.Next = nodeAtIndex.Next;
         if (nodeAtIndex.Next != null)
            nodeAtIndex.Next.Previous = nodeAtIndex.Previous;
         if (index == 0)
            HeadNode = nodeAtIndex.Next;
         if (index == Length - 1)
            TailNode = nodeAtIndex.Previous;

         Length--;

         return nodeAtIndex.Value;
      }

      IEnumerator IEnumerable.GetEnumerator()
      {
         return GetEnumerator();
      }

      public IEnumerator<T> GetEnumerator()
      {
         return new DoublyLinkedListEnumerator(this);
      }

      private class DoublyLinkedListEnumerator : IEnumerator<T>
      {
         private DoublyLinkedList<T> DoublyLinkedList { get; }
         private Node<T> CurrentNode { get; set; }
         private bool IsStarted { get; set; }
         public DoublyLinkedListEnumerator(DoublyLinkedList<T> doublyLinkedList)
         {
            DoublyLinkedList = doublyLinkedList;
            CurrentNode = null;
            IsStarted = false;
         }
         T IEnumerator<T>.Current
         {
            get
            {
               if (CurrentNode == null)
               {
                  throw new InvalidOperationException();
               }
               return CurrentNode.Value;
            }
         }

         public object Current => CurrentNode.Value;

         public bool MoveNext()
         {
            if (!IsStarted)
            {
               CurrentNode = DoublyLinkedList.HeadNode;
               IsStarted = true;
            }
            else
            {
               CurrentNode = CurrentNode?.Next;
            }

            return CurrentNode != null;
         }

         public void Reset()
         {
            CurrentNode = null;
            IsStarted = false;
         }

         public void Dispose()
         {

         }
      }
   }
}
