

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using System.Configuration;

namespace CRUD_WithMongo.Models
{
    public class MongoHelper
    {
        public static IMongoClient client { get; set; }
        public static IMongoDatabase database { get; set; }
        public static string MongoDatabase = "crud_mongodb";
        public static string MongoConnection = ConfigurationManager.ConnectionStrings["MongoConnection"].ConnectionString.Replace("&amp;", "&");
        // You might need to replace & with &amp; in your Mongo Connection string stored in Web.Config

        public static IMongoCollection<Models.Student> students_collection { get; set; }


        internal static void ConnectToMongoService()
        {
            try
            {
                client = new MongoClient(MongoConnection);
                database = client.GetDatabase(MongoDatabase);
                // If you look in your https://cloud.mongodb.com  database overview you 
                // should see the connection and graph change, you may need to whitelist your IP

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}