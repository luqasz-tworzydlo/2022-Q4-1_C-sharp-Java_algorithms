using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e1_indexes_array
{
    /// <remarks>
    /// An unordered IntDynamicArray
    /// </remarks>
    class UnorderedIntDynamicArray : IntDynamicArray
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public UnorderedIntDynamicArray()
      : base()
        {
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Adds the given item to the IntDynamicArray
        /// </summary>
        /// <param name="item">the item to add</param>
        public override void Add(int item)
        {
            // expand array if necessary
            if (count == items.Length)
            {
                Expand();
            }

            // add new item and increment count
            items[count] = item;
            count++;
        }

        /// <summary>
        /// Removes the first occurence of the given item from the 
        /// IntDynamicArray
        /// </summary>
        /// <param name="item">the item to remove</param>
        /// <returns>true if the item is successfully removed, false
        ///     otherwise</returns>
        public override bool Remove(int item)
        {
            // check for given item in array
            int itemLocation = IndexOf(item);
            if (itemLocation == -1)
            {
                return false;
            }
            else
            {
                // move last element in array here and change count
                items[itemLocation] = items[count - 1];
                count--;
                return true;
            }
        }

        /// <summary>
        /// Determines the index of the given item
        /// </summary>
        /// <param name="item">the item to find</param>
        /// <returns>the index of the item or -1 if it's not found</returns>
        public override int IndexOf(int item)
        {
            // look for first occurrence of item in array
            for (int i = 0; i < count; i++)
            {
                if (items[i] == item)
                {
                    return i;
                }
            }

            // didn't find the item in the array
            return -1;
        }

        // [2.1] odwrócenie [!]
        public int LastIndexOf(int item)
        {
            for (int i = count - 1; i >= 0; i--)
            {
                if (items[i] == item)
                {
                    return i;
                }
            }

            return -1;
        }

        // [3.1] wszystkie indeksy
        public List<int> AllIndexesOf(int item)
        {
            List<int> lista = new List<int>();

            for (int i = 0; i < count; i++)
            {
                if (items[i] == item)
                {
                    // return i;
                    // dodaj i do listy
                    lista.Add(i);
                }
            }

            foreach (var elementListy in lista)
            {
                Console.WriteLine("Element listy: " + elementListy);
            }

            return lista;
        }


        #endregion
    }
}
