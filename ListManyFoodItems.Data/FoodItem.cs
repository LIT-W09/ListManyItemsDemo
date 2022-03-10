using System;
using System.Data.SqlClient;

namespace ListManyFoodItems.Data
{
    public class FoodItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CalorieCount { get; set; }
    }

    public class FoodItemDb
    {
        private string _connectionString;
        public FoodItemDb(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddFoodItem(FoodItem item)
        {
            using var connection = new SqlConnection(_connectionString);
            using var cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO FoodItems (Name, Price, CalorieCount) " +
                "VALUES (@name, @price, @calories)";

            cmd.Parameters.AddWithValue("@name", item.Name);
            cmd.Parameters.AddWithValue("@price", item.Price);
            cmd.Parameters.AddWithValue("@calories", item.CalorieCount);
            connection.Open();
            cmd.ExecuteNonQuery();
        }

    }
}
