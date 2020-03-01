using FoodAppDAL.Interface;
using FoodAppEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FoodAppDAL
{
    public class FoodieDAL : IFoodieDAL
    {
        SqlConnection con;
        public FoodieDAL()
        {
            string connectionString = "Server=DESKTOP-EGKU7I7;DataBase=FoodApp;User=SqlSvr;Password=sqlsvr";
            con = new SqlConnection(connectionString);
        }
        public List<EntityFoodie> GetProfiles()
        {
            SqlCommand cmd = new SqlCommand("getFoodiesProfiles", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader data = cmd.ExecuteReader();
            List<EntityFoodie> foodiesList = new List<EntityFoodie>();
            EntityFoodie foodie;
            while(data.Read())
            {
                foodie = new EntityFoodie();
                foodie.Id = int.Parse(data["Id"].ToString());
                foodie.Name = data["Name"].ToString();
                foodie.Address = data["Address"].ToString();
                foodie.CurrentAddress = data["CurrentAddress"].ToString();
                foodie.Contact = long.Parse(data["Contact"].ToString());
                foodie.PlanId = int.Parse(data["PlanId"].ToString());
                foodie.Status= data["Status"].ToString();
                foodie.Type= data["Type"].ToString();
                foodiesList.Add(foodie);
            }
            con.Close();
            return foodiesList;
        }
    }
}
