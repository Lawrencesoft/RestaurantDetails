using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Restaurant.Database.Model;

namespace Restaurant.Database
{
    /// <summary>
    /// Restaurant Database class to store and retrive the data from SQL Server
    /// </summary>
    public class RestaurantDatabase : IRestaurantDatabase
    {
        /// <summary>
        /// Connection string
        /// </summary>
        private readonly string _connectionString;

        /// <summary>
        /// Restaurant Database Constructer
        /// </summary>
        /// <param name="configuration"></param>
        public RestaurantDatabase(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("RestaurantDB");
        }

        /// <summary>
        /// To get the available restaurant details from the given datetime
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public IList<RestaurantDetails> FetchAvailableRestaurantDetails(DateTime dateTime)
        {
            IList<RestaurantDetails> restaurantNames = new List<RestaurantDetails>();
            var day = dateTime.DayOfWeek;
            var time = dateTime.TimeOfDay;
            string cmdString = $"SELECT r.ID, r.Name, ra.Day, ra.FromTime, ra.ToTime FROM Restaurant r JOIN RestaurantAvailability ra on r.Id = ra.RestaurantId where ra.Day = '{day}' and '{time}' between ra.FromTime and ra.ToTime";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = cmdString;
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            RestaurantDetails item = new RestaurantDetails();
                            item.RestaurantId = reader.GetInt32("Id");
                            item.RestaurantName = reader.GetString("Name");
                            item.Day = reader.GetString("Day");
                            item.FromTime = reader.GetValue("FromTime").ToString();
                            item.ToTime = reader.GetValue("ToTime").ToString();
                            restaurantNames.Add(item);
                        }
                    }
                    connection.Close();
                }
            }
            return restaurantNames;
        }

        /// <summary>
        /// To insert the Available Restaurant details into SQL Database
        /// </summary>
        /// <param name="restaurantDetails"></param>
        public void InsertAvailableRestaurantDetails(RestaurantModel restaurantDetails)
        {
            using (SqlConnection objConn = new SqlConnection(_connectionString))
            {
                objConn.Open();
                SqlTransaction objTrans = objConn.BeginTransaction();

                SqlCommand objCmdrestaurant = new SqlCommand("INSERT INTO dbo.Restaurant (Name)  output INSERTED.ID VALUES (@name)", objConn, objTrans);
                objCmdrestaurant.Parameters.AddWithValue("@name", restaurantDetails.Name);
                
                try
                {
                    int restaurantId = (int)objCmdrestaurant.ExecuteScalar();
                    //TODO: Need to change this implementation to bulk insert after create the UserType in database, so that we can avoid loops
                    foreach (var item in restaurantDetails.RestaurantAvailability)
                    {
                        SqlCommand objCmdAvailableTiming = new SqlCommand("INSERT INTO dbo.RestaurantAvailability (RestaurantId,Day,FromTime,ToTime) VALUES (@Id,@day,@fromTime,@toTime)", objConn, objTrans);
                        objCmdAvailableTiming.Parameters.AddWithValue("@Id", restaurantId);
                        objCmdAvailableTiming.Parameters.AddWithValue("@day", item.Day);
                        objCmdAvailableTiming.Parameters.AddWithValue("@fromTime", item.FromTime);
                        objCmdAvailableTiming.Parameters.AddWithValue("@toTime", item.ToTime);

                        objCmdAvailableTiming.ExecuteNonQuery();
                    }

                    objTrans.Commit();
                }
                catch (Exception)
                {
                    // TODO: Log the exception
                    objTrans.Rollback();
                }
                finally
                {
                    objConn.Close();
                }
            }

        }
    }
}
