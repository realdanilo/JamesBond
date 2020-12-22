using JamesBond.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace JamesBond.Data
{
    internal class GadgetDAO
    {
        //connect to DB
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JamesBondDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //perform all operations related to DB
        public List<GadgetModel> fetchAll()
        {
            List<GadgetModel> returnList = new List<GadgetModel>();

            //opens connection, closes connection after using is done
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM  [dbo].[GADGETS]";
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        //create new Gadget Object and add to the list
                        GadgetModel gadget = new GadgetModel();
                        gadget.Id = reader.GetInt32(0);
                        gadget.Name = reader.GetString(1);
                        gadget.Description = reader.GetString(2);
                        gadget.AppearsIn = reader.GetString(3);
                        gadget.WithThisActor = reader.GetString(4);

                        returnList.Add(gadget);

                    }
                }
            
            }

            return returnList;
        }

        public GadgetModel fetchById(int id)
        {
            GadgetModel gadget = new GadgetModel();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string SqlQuery = "SELECT * FROM [dbo].[GADGETS] where Id = @Id";
                SqlCommand command = new SqlCommand(SqlQuery, connection);
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        gadget.Id = reader.GetInt32(0);
                        gadget.Name = reader.GetString(1);
                        gadget.Description = reader.GetString(2);
                        gadget.AppearsIn = reader.GetString(3);
                        gadget.WithThisActor = reader.GetString(4);
                    }
                }

            }
            return gadget;

        }
        public int Create(GadgetModel newModel)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                string SqlQuery = "INSERT INTO [dbo].[GADGETS] VALUES(@Name, @Description, @AppearsIn, @WithThisActor);";
                
                SqlCommand command = new SqlCommand(SqlQuery, connection);
                
                command.Parameters.Add("@Name", System.Data.SqlDbType.VarChar,1000).Value = newModel.Name;
                command.Parameters.Add("@Description", System.Data.SqlDbType.VarChar,1000).Value = newModel.Description;
                command.Parameters.Add("@AppearsIn", System.Data.SqlDbType.VarChar,1000).Value = newModel.AppearsIn;
                command.Parameters.Add("@WithThisActor", System.Data.SqlDbType.VarChar, 1000).Value = newModel.WithThisActor;

                connection.Open();
                int newId = command.ExecuteNonQuery();
                return newId;
            }
        }
        public int Update(GadgetModel updateModel)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
               string SqlQuery = "UPDATE [dbo].[GADGETS] SET Name=@Name, Description=@Description, AppearsIn = @AppearsIn,WithThisActor=@WithThisActor Where id = @Id";
               SqlCommand command = new SqlCommand(SqlQuery, connection);

               command.Parameters.Add("@Id", System.Data.SqlDbType.VarChar, 1000).Value = updateModel.Id;
                command.Parameters.Add("@Name", System.Data.SqlDbType.VarChar, 1000).Value = updateModel.Name;
                command.Parameters.Add("@Description", System.Data.SqlDbType.VarChar, 1000).Value = updateModel.Description;
                command.Parameters.Add("@AppearsIn", System.Data.SqlDbType.VarChar, 1000).Value = updateModel.AppearsIn;
                command.Parameters.Add("@WithThisActor", System.Data.SqlDbType.VarChar, 1000).Value = updateModel.WithThisActor;
                connection.Open();
                return command.ExecuteNonQuery();
            }
            return -1;
        }
    }
}