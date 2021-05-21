using System;
using System.Collections.Generic;
using System.Data;

namespace ProductReviewManagement
{
       public class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("======================== WELCOME TO PRODUCT REVIEW MANAGEMENT =================================");

                List<ProductReview> list = new List<ProductReview>()
            {
            new ProductReview() { ProductId = 1, UserId = 1, Rating = 6.5, Review = "Good", isLike=true},
            new ProductReview() { ProductId = 1, UserId = 2, Rating = 4, Review = "Bad", isLike=true },
            new ProductReview() { ProductId = 2, UserId = 3, Rating = 6, Review = "Good", isLike=true },
            new ProductReview() { ProductId = 2, UserId = 4, Rating = 5, Review = "Average", isLike=true },
            new ProductReview() { ProductId = 4, UserId = 5, Rating = 6, Review = "Good", isLike=true },
            new ProductReview() { ProductId = 5, UserId = 6, Rating = 9, Review = "Good", isLike=true },
            new ProductReview() { ProductId = 6, UserId = 7, Rating = 9.5, Review = "Good", isLike=true },
            new ProductReview() { ProductId = 7, UserId = 8, Rating = 7.5, Review = "Good", isLike=false},
            new ProductReview() { ProductId = 4, UserId = 9, Rating = 8.5, Review = "Good", isLike=false },
            new ProductReview() { ProductId = 9, UserId = 10, Rating = 6.5, Review = "Good", isLike=false },
            new ProductReview() { ProductId = 10, UserId = 11, Rating = 5, Review = "Average", isLike=false },
            new ProductReview() { ProductId = 11, UserId = 12, Rating = 3, Review = "Bad", isLike=true },
            new ProductReview() { ProductId = 12, UserId = 13, Rating = 5, Review = "Average", isLike=true },
            new ProductReview() { ProductId = 13, UserId = 14, Rating = 3.5, Review = "Bad", isLike=true },
            new ProductReview() { ProductId = 14, UserId = 15, Rating = 5, Review = "Average", isLike=true },
            new ProductReview() { ProductId = 15, UserId = 16, Rating = 4, Review = "Bad", isLike=true }
            };

                Console.WriteLine("Table rows are :  ");
                foreach (var listData in list)
                {
                    Console.WriteLine("Product id is = " + listData.ProductId + "User id is = " + listData.UserId + "Rating is = " + listData.Rating + " Review is = " + listData.Review + " isLike = " + listData.isLike);
                }

            Management management = new Management();
            management.TopRecords(list);
            management.RecordsGreaterThan3WithId(list);
            management.RetriveEachRevieCountwWithId(list);
            management.RetrieveOnlyProductdAndReview(list);

            //Will skip top 5 records from list and display rest data.
            management.SkipTopFiveRecords(list);

            //Data table
            //management.AddIntoDataTable(list);

            //Retrieves products with isLike = true.
            Console.WriteLine("Records with true review are : \n");
            DataTable table = management.AddIntoDataTable(list);
            management.RetrieveIsLikeTrueProductsFromDataTable(table);
        }
    }
}
