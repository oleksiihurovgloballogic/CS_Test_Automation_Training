/// https://www.codewars.com/kata/515bb423de843ea99400000a

using System;
using System.Collections.Generic;

namespace Homework_08._10_PaginationHelper
{
    public class PagnationHelper<T>
    {
        // TODO: Complete this class

        private List<T> _collection = new List<T>(); // Internal List to store items
        private int _itemsPerPage = 0; // The number of items that fit within a single page

        /// <summary>
        /// Constructor, takes in a list of items and the number of items that fit within a single page
        /// </summary>
        /// <param name="collection">A list of items</param>
        /// <param name="itemsPerPage">The number of items that fit within a single page</param>
        public PagnationHelper(IList<T> collection, int itemsPerPage)
        {
            this._collection = (List<T>)collection;
            if (itemsPerPage > 0)
            {
                this._itemsPerPage = itemsPerPage;
            }
            else
            {
                throw new ArgumentException(
                    $"Please provide positive value for the parameter itemsPerPage. " +
                    $"You have provided value {itemsPerPage}"
                );
            }
        }

        /// <summary>
        /// The number of items within the collection
        /// </summary>
        public int ItemCount
        {
            get
            {
                return _collection.Count;
            }
        }

        /// <summary>
        /// The number of pages
        /// </summary>
        public int PageCount
        {
            get
            {
                return (int)(_collection.Count / _itemsPerPage) + 1;
            }
        }

        /// <summary>
        /// Returns the number of items in the page at the given page index 
        /// </summary>
        /// <param name="pageIndex">The zero-based page index to get the number of items for</param>
        /// <returns>The number of items on the specified page or -1 for pageIndex values that are out of range</returns>
        public int PageItemCount(int pageIndex)
        {
            if (pageIndex < 0) return -1;

            switch (PageCount - 1 - pageIndex)
            {
                case > 0: { return _itemsPerPage; }
                case 0: { return _collection.Count - pageIndex * _itemsPerPage; }
                default: { return -1; }
            }
        }

        /// <summary>
        /// Returns the page index of the page containing the item at the given item index.
        /// </summary>
        /// <param name="itemIndex">The zero-based index of the item to get the pageIndex for</param>
        /// <returns>The zero-based page index of the page containing the item at the given item index or -1 if the item index is out of range</returns>
        public int PageIndex(int itemIndex)
        {
            if (itemIndex < 0 || itemIndex > _collection.Count - 1) return -1;

            int remainder;
            int quotient = Math.DivRem(itemIndex + 1, _itemsPerPage, out remainder);
            if (remainder > 0) quotient++;

            if (quotient <= PageCount)
            {
                return quotient - 1;
            }
            else
            {
                return -1;
            }
        }
    }
}
