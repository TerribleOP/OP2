using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading;
using System.Web;

namespace L2
{
    /// <summary>
    /// Class for the tourist linked list
    /// </summary>
    class TouristLinkedList
    {
        /// <summary>
        /// Class for the tourist node
        /// </summary>
        private sealed class TouristNode
        {
            public Tourist Data { get; set; }
            public TouristNode Link { get; set; }
            /// <summary>
            /// Constructor for the tourist node
            /// </summary>
            /// <param name="data"></param>
            /// <param name="link"></param>
            public TouristNode(Tourist data, TouristNode link)
            {
                Data = data;
                Link = link;
            }
        }
        public int Count { get; private set; } = 0;

        private TouristNode head; //start
        private TouristNode tail; //end
        private TouristNode extraTail; //end (extra)
        private TouristNode ListReader; // list linker
        /// <summary>
        /// Constructor for the tourist linked list
        /// </summary>
        public TouristLinkedList()
        {
            this.tail = new TouristNode(null, null);
            this.head = new TouristNode(null, this.tail);
            this.extraTail = head;
            this.ListReader = null;
        }

        /// <summary>
        /// Method to add a tourist to the end of the linked list
        /// </summary>
        /// <param name="data"></param>
        public void AddToEnd(Tourist data)
        {
            extraTail.Link = new TouristNode(data, null);
            extraTail = extraTail.Link;
            Count++;
        }
        /// <summary>
        /// Method to get the tourist from the linked list
        /// </summary>
        /// <returns></returns>
        public Tourist Get()
        {
            return ListReader.Data;
        }
        /// <summary>
        /// Method for the next tourist in the linked list
        /// </summary>
        public void Next()
        {
            ListReader = ListReader.Link;
        }
        /// <summary>
        /// Method to check if the linked list exists
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
        /// Bubble sort for the linked list using the operator override
        /// </summary>
        public void BubbleSort()
        {
            if (head.Link == null || head.Link.Link == null)
                return;

            bool flag = true;
            while (flag)
            {
                flag = false;
                TouristNode d = head.Link;
                TouristNode prev = null;

                while (d.Link != null)
                {
                    if (d.Data.CompareTo(d.Link.Data) > 0)
                    {
                        Tourist temp = d.Data;
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