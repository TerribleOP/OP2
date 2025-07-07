using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace L3
{
    public sealed class CustomLinkedList<type> : IEnumerable<type> where type : IComparable<type>, IEquatable<type>
    {

        private sealed class Node<type>
        {
            public type Data { get; set; }
            public Node<type> Link { get; set; }

            public Node(type data, Node<type> link)
            {
                Data = data;
                Link = link;
            }
        }

        public int Count { get; private set; } = 0;

        public WebForm WebForm
        {
            get => default;
            set
            {
            }
        }

        public Tourist Tourist
        {
            get => default;
            set
            {
            }
        }

        public Hotel Hotel
        {
            get => default;
            set
            {
            }
        }

        private Node<type> head; //start
        private Node<type> tail; //end
        private Node<type> extraTail; //end (extra)
        private Node<type> ListReader; // list linker
        /// <summary>
        /// Constructor for the linked list
        /// </summary>
        public CustomLinkedList()
        {
            this.tail = new Node<type>(default, null);
            this.head = new Node<type>(default, this.tail);
            this.extraTail = head;
            this.ListReader = null;
        }
        /// <summary>
        /// Method to add data to the end of the linked list
        /// </summary>
        /// <param name="data"></param>
        public void AddToEnd(type data)
        {
            extraTail.Link = new Node<type>(data, null);
            extraTail = extraTail.Link;
            Count++;
        }
        /// <summary>
        /// Method to get data from the linked list
        /// </summary>
        /// <returns></returns>
        public type Get()
        {
            return ListReader.Data;
        }
        /// <summary>
        /// Method to move to the next node in the linked list
        /// </summary>
        public void Next()
        {
            ListReader = ListReader.Link;
        }
        /// <summary>
        /// Method to check if the data exists in the linked list
        /// </summary>
        /// <returns></returns>
        public bool Exists()
        {
            return ListReader != null && ListReader.Data != null;
        }
        /// <summary>
        /// Method for the start of the linked list
        /// </summary>
        public void Start()
        {
            ListReader = head.Link;
        }
        /// <summary>
        /// Method for the end of the linked list
        /// </summary>
        public void End()
        {
            ListReader = tail.Link;
        }
        /// <summary>
        /// returns data in the foreach loop
        /// </summary>
        /// <returns></returns>
        public IEnumerator<type> GetEnumerator()
        {
            for (Start(); Exists(); Next())
            {
                yield return ListReader.Data;
            }
        }
        /// <summary>
        /// Method to allow the linked list to be used in a foreach loop
        /// </summary>
        /// <returns></returns>

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        /// <summary>
        /// Method to sort the linked list
        /// </summary>
        public void BubbleSort()
        {
            if (head.Link == null || head.Link.Link == null)
                return;

            bool flag = true;
            while (flag)
            {
                flag = false;
                Node<type> d = head.Link;
                Node<type> prev = null;

                while (d.Link != null)
                {
                    if (d.Data.CompareTo(d.Link.Data) < 0)
                    {
                        type temp = d.Data;
                        d.Data = d.Link.Data;
                        d.Link.Data = temp;

                        flag = true;
                    }
                    prev = d;
                    d = d.Link;
                }
            }
        }
    }
}