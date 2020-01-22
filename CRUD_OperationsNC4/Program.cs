using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

namespace CRUD_OperationsNC4
{
    class Program
    {
        static void Main(string[] args)
        {

            string defaultKey = File.ReadAllText("appsettings.Debug.Json");
            JObject jObject = JObject.Parse(defaultKey);
            JToken token = jObject["DefaultConnection"];
            string connectionString = token.ToString();
            ProductRepo.connString = connectionString;



            ProductRepo repo = new ProductRepo();

            //Create Products
            //Console.WriteLine("Creating Product.....");
            //var newProduct = new Product { Name = "Hannahs 2nd Product", Price = 19.99M, CategoryID = 2, OnSale = 0 };
            //repo.CreateProduct(newProduct);
            //Console.WriteLine("Product Created!");

            //Update Products
            //Console.WriteLine("Updating Product.....");
            //var newInfo = new Product { ProductID = 943, StockLevel = 27 };
            //repo.UpdateProduct(newInfo);
            //Console.WriteLine("Product Updated!");

            //Read Products
            List<Product> products = repo.GetProducts();

            foreach (var prod in products)
            {
                Console.WriteLine($"{prod.ProductID}  {prod.Name}-------- ${prod.Price}---------You have {prod.StockLevel} of these items.");
            }

            //Delete Products
            //Console.WriteLine("Deleting Product.....");
            //repo.DeleteNameAndProductID(947, "Hannahs 2nd Product");
            //Console.WriteLine("Product Deleted!");
        }
    }
}
