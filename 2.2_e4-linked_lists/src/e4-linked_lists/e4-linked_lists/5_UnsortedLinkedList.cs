﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e4_linked_lists
{
    /// <summary>
    /// An unsorted linked list
    /// </summary>
    class UnsortedLinkedList<T> : LinkedList<T>
    {
        #region Constructors

        public UnsortedLinkedList() : base()
        {
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Adds the given item to the list
        /// </summary>
        /// <param name="item">item to add</param>
        public override void Add(T item)
        {
            // adding to empty list
            if (head == null)
            {
                head = new LinkedListNode<T>(item, null, null);
            }
            else
            {
                // add to front of list
                head = new LinkedListNode<T>(item, head, null);
                // uaktualnienie na co wskazuje stara głowa
                head.Next.Previous = head;
            }
            count++;
        }

        #endregion
    }
}
