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

        /// <summary>
        /// Retrive the Records who's rating is Greater Than 3 With Id.
        /// </summary>
        /// <param name="listProductReviews"></param>
        public void RecordsGreaterThan3WithId(List<ProductReview> retriveWithProductReviews)
        {
            var recordData = (from productReview in retriveWithProductReviews where (productReview.ProductId == 1 || productReview.ProductId == 4 || productReview.ProductId == 9) && productReview.Rating > 3 select productReview).ToList();
            Console.WriteLine("\nRecords who's rating are greater than 3 with product id 1 , 4 or 9 : ");
            Display(recordData);
        }

        /// <summary>
        /// Retrive each product review id with count.
        /// </summary>
        /// <param name="listProductReviews"></param>
        public void RetriveEachRevieCountwWithId(List<ProductReview> countProductReviews)
        {
            var countDataRecord = countProductReviews.GroupBy(x => x.ProductId).Select(x => new { ProductId = x.Key, Count = x.Count() });
            Console.WriteLine("\nProduct id and count are : ");
            foreach (var countList in countDataRecord)
            {
                Console.WriteLine(countList.ProductId + " = " + countList.Count);
            }
        }

        /// <summary>
        /// Retrive only product id and review from list using linq.
        /// </summary>
        /// <param name="listProductReviews"></param>
        public void RetrieveOnlyProductdAndReview(List<ProductReview> onlyIdAndReview)
        {
            var dataStore = onlyIdAndReview.Select(x => new { ProductId = x.ProductId, Review = x.Review });
            Console.WriteLine("\nProduct id and review are : ");
            foreach (var list in dataStore)
            {
                Console.WriteLine(list.ProductId + "======================>>>" + list.Review);
            }
        }

        /// <summary>
        /// Skip top 5 records from list.
        /// </summary>
        /// <param name="listProductReviews"></param>
        public void SkipTopFiveRecords(List<ProductReview> listRecords)
        {
            var skip5Records = (from productReview in listRecords select productReview).Skip(5).ToList();
            Console.WriteLine("\nAfter skipping top 5 records from list : ");
            Display(skip5Records);
        }
    }
}