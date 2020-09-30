using System;
using System.Collections.Generic;
using System.IO;
using Lavanderia.Domain.Dto.Requests;
using Lavanderia.Domain.Models;
using Newtonsoft.Json;

namespace Lavanderia.UnitTests.Helpers
{
    public static class DataFiles
    {
        private static char Slash = Path.DirectorySeparatorChar;

        static DataFiles()
        {
            var customers = $"TestData{ Slash }Customers.json";
            var orders = $"TestData{ Slash }Orders.json";
            var items = $"TestData{ Slash }Items.json";

            // Services
            DataFileNames.Add(typeof(Customer), customers);
            DataFileNames.Add(typeof(CustomerRequest), customers);
            
            DataFileNames.Add(typeof(Order), orders);
            DataFileNames.Add(typeof(CreateOrderRequest), orders);
            DataFileNames.Add(typeof(UpdateOrderRequest), orders);
            
            DataFileNames.Add(typeof(OrderItem), items);
            DataFileNames.Add(typeof(CreateOrderItemRequest), items);
            DataFileNames.Add(typeof(UpdateOrderItemRequest), items);
        }

        public static List<T> Get<T>()
        {
            string content = File.ReadAllText(FileName<T>());
            return JsonConvert.DeserializeObject<List<T>>(content);
        }

        private static string FileName<T>() { return DataFileNames[typeof(T)]; }

        private static Dictionary<Type, string> DataFileNames { get; }
            = new Dictionary<Type, string>();
    }
}