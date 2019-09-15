using System.Collections.Generic;

namespace csharptests
{
    public class Node<K, T>
    {
        public K Key;
        public T Item;
        public Node<K, T> Next;
        public Node<K, T> Prev;

        public Node()
        {
            this.Key = default(K);
            this.Item = default(T);
            this.Next = null;
        }

        public Node(K key, T item, Node<K, T> next)
        {
            this.Key = key;
            this.Item = item;
            this.Next = next;
        }
    }

    /// <summary>
    /// Implementation of a generic double linked list
    /// </summary>
    public class LinkedList<K, T> : IEnumerable<T>
    {
        public Node<K, T> head;

        /// <summary>
        /// Constructor
        /// </summary>
        public LinkedList()
        {
            head = null;
        }

        public bool isEmpty()
        {
            if (head == null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Add node to the first of the linked list
        /// </summary>
        /// <param name="key"></param>
        /// <param name="item"></param>
        public void AddNodeFirst(K key, T item)
        {
            head = new Node<K, T>(key, item, head);
        }

        public void AddNodeLast(K key, T item)
        {
            var temp = head;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }

            temp.Next = new Node<K, T>(key, item, null);


        }

        public void DeleteNode(K key)
        {
            if (head == null)
                return;
            //throw some error

            var cur = head;
            Node<K, T> prev = null;

            while (!cur.Key.Equals(key))
            {
                prev = cur;
                cur = cur.Next;
            }

            if (cur == null)
                return;
            //throw some error

            prev.Next = cur.Next;

        }

        /// <summary>
        /// Custom Enumerator 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            var node = head;
            while (node != null)
            {
                yield return node.Item;
                node = node.Next;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
