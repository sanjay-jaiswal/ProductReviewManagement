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

        /// <summary>
        /// Creating data table.
        /// </summary>
        public void CreateDataTable()
        {
            //Declaring Data table column
            DataTable tableData = new DataTable();
            tableData.Columns.Add("ProducID");
            tableData.Columns.Add("UserID");
            tableData.Columns.Add("Rating");
            tableData.Columns.Add("Review");
            tableData.Columns.Add("isLike");
            //Adding data in rows
            tableData.Rows.Add(5, 7, 4, "Bad", false);
            tableData.Rows.Add(3, 6, 15, "Good", true);
            tableData.Rows.Add(2, 5, 18, "Good", true);
            tableData.Rows.Add(4, 4, 17, "Good", true);
            tableData.Rows.Add(8, 3, 6, "Bad", false);
            tableData.Rows.Add(7, 2, 10, "Average", true);
            tableData.Rows.Add(11, 1, 10, "Average", true);
            tableData.Rows.Add(2, 12, 8, "Bad", false);
            tableData.Rows.Add(6, 10, 10, "Average", true);
            tableData.Rows.Add(4, 9, 16, "Good", true);
            tableData.Rows.Add(6, 8, 10, "Average", true);
            //Display data table of all records
            DisplayDataTable(tableData);
        }

        public void DisplayDataTable(DataTable table)
        {
            var dataStore = (from products in table.AsEnumerable()
                           select products);

            Console.WriteLine("\nAll Data Table Records are : ");
            foreach (DataRow row in dataStore)
            {
                Console.WriteLine("ProducID = {0}, UserID = {1}, Rating = {2}, Review = {3}, isLike = {4}", row["ProducID"], row["UserID"], row["Rating"], row["Review"], row["isLike"]);
            }
        }

    }
}