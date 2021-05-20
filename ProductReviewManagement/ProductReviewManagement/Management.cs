using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data;

namespace ProductReviewManagement
{
    public class Management
    {
        /// <summary>
        /// Displaying the data.
        /// </summary>
        /// <param name="recordData">The record data.</param>
        public void Display(List<ProductReview> recordData)
        {
            foreach (var listData in recordData)
            {
                Console.WriteLine("Product id is = " + listData.ProductId + "User id is = " + listData.UserId + "Rating is = " + listData.Rating + " Review is = " + listData.Review + " isLike : " + listData.isLike);
            }
        }

        /// <summary>
        /// Retriving the top 3 records from list.
        /// </summary>
        /// <param name="listProductReviews">The list product reviews.</param>
        public void TopRecords(List<ProductReview> listProductReviews)
        {
            var recordData = (from productReview in listProductReviews orderby productReview.Rating descending select productReview).Take(3).ToList();
            Console.WriteLine("\nTop 3 records are : ");
            Display(recordData);
        }
    }

}