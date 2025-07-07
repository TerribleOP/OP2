using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace L2
{
    /// <summary>
    /// Class for the hotel linked list
    /// </summary>
    class HotelLinkedList
    {
        /// <summary>
        /// Class for the hotel node
        /// </summary>
        private sealed class HotelNode
        {
            public Hotel Data { get; set; }
            public HotelNode Link { get; set; }

            /// <summary>
            /// Constructor for the hotel node
            /// </summary>
            /// <param name="data"></param>
            /// <param name="link"></param>
            public HotelNode(Hotel data, HotelNode link)
            {
                Data = data;
                Link = link;
            }
        }
        public int Count { get; private set; } = 0;

        private HotelNode head; //start
        private HotelNode tail; //end
        private HotelNode extraTail; //end (extra)
        private HotelNode ListReader; // list linker
        /// <summary>
        /// Constructor for the hotel linked list
        /// </summary>
        public HotelLinkedList()
        {
            this.tail = new HotelNode(null, null);
            this.head = new HotelNode(null, this.tail);
            this.extraTail = head;
            this.ListReader = null;
        }
        /// <summary>
        /// Method to add a hotel to the end of the linked list
        /// </summary>
        /// <param name="data"></param>
        public void AddToEnd(Hotel data)
        {
            extraTail.Link = new HotelNode(data, null);
            extraTail = extraTail.Link;
            Count++;
        }
        /// <summary>
        /// Method to get the hotel from the linked list
        /// </summary>
        /// <returns></returns>
        public Hotel Get()
        {
            return ListReader.Data;
        }
        /// <summary>
        /// Method to move to the next hotel in the linked list
        /// </summary>
        public void Next()
        {
            ListReader = ListReader.Link;
        }
        /// <summary>
        /// Method to check if the hotel exists in the linked list
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
    }
}