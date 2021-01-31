using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using BOL;
namespace DAL
{
    public static class DBManager
    {

        public static readonly string connString = string.Empty;
        static DBManager()
        {
            connString = ConfigurationManager.ConnectionStrings["dbString"].ConnectionString;
        }

        public static usermanager GetByID(int id)
        {
            usermanager theManager = new usermanager();

            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = connString;
            string query = "Select * from usermanager WHERE Id=" + id;
            IDbCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.Connection = conn;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd as MySqlCommand);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds);
                DataRowCollection rows = ds.Tables[0].Rows;
                foreach (DataRow row in rows)
                {
                    theManager.ID = int.Parse(row["Id"].ToString());
                    theManager.Username = row["Username"].ToString();
                    theManager.Email = row["Email"].ToString();
                    theManager.Role = row["Role"].ToString();
                   
                }
            }
            catch (MySqlException e)
            {
                string message = e.Message;
            }
            // implementation 
            return theManager;
        }

      /*  public static List<usermanager> GetAllManagers()
        {
            List<usermanager> allManagers = new List<usermanager>();


            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = connString;
            string query = "Select * from usermanager";
            IDbCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.Connection = conn;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd as MySqlCommand);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds);
                DataRowCollection rows = ds.Tables[0].Rows;
                foreach (DataRow row in rows)
                {
                    usermanager theManager = new usermanager();
                    theManager.ID = int.Parse(row["Id"].ToString());
                    theManager.Username = row["Username"].ToString();
                    theManager.Email = row["Email"].ToString();
                    theManager.Role = row["Role"].ToString();
                    allManagers.Add(theManager);
                }

            }

            catch (MySqlException e)
            {
                string message = e.Message;
            }

            return allManagers;
        }
      */

        public static Manager GetByIDM(int id)
        {
            Manager themanager = new Manager();

            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = connString;
            string query = "Select * from managers WHERE Id=" + id;
            IDbCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.Connection = conn;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd as MySqlCommand);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds);
                DataRowCollection rows = ds.Tables[0].Rows;
                foreach (DataRow row in rows)
                {
                    themanager.Id = int.Parse(row["Id"].ToString());
                    themanager.MName = row["MName"].ToString();
                    themanager.Email = row["Email"].ToString();
                    themanager.Role = row["Role"].ToString();
                    //   thevendor.Quantity = int.Parse(row["Quantity"].ToString());
                    //   thevendor.ImageUrl = row["ImageUrl"].ToString();
                }
            }
            catch (MySqlException e)
            {
                string message = e.Message;
            }
            // implementation 
            return themanager;
        }
        public static List<Manager> GetAllManagers()
        {
            List<Manager> allManagers = new List<Manager>();


            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = connString;
            string query = "Select * from managers";
            IDbCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.Connection = conn;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd as MySqlCommand);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds);
                DataRowCollection rows = ds.Tables[0].Rows;
                foreach (DataRow row in rows)
                {
                    Manager themanager = new Manager();
                    themanager.Id = int.Parse(row["Id"].ToString());
                    themanager.MName = row["MName"].ToString();
                    themanager.Email = row["Email"].ToString();
                    themanager.Role = row["Role"].ToString();
                    //  theproduct.Quantity = int.Parse(row["Quantity"].ToString());
                    allManagers.Add(themanager);
                }

            }

            catch (MySqlException e)
            {
                string message = e.Message;
            }

            return allManagers;
        }

        public static bool InsertM(Manager newManager)
        {
            bool status = false;
            try
            {
                using (MySqlConnection con = new MySqlConnection(connString))   //DI via Constructor
                {
                    if (con.State == ConnectionState.Closed)        //if connection is closed?
                        con.Open();
                    string query = "INSERT INTO managers (Id,MName ,Email, Role) " +
                                                "VALUES (@Id, @MName, @Email, @Role)";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.Add(new MySqlParameter("@Id", newManager.Id));
                    cmd.Parameters.Add(new MySqlParameter("@MName", newManager.MName));
                    cmd.Parameters.Add(new MySqlParameter("@Email", newManager.Email));
                    cmd.Parameters.Add(new MySqlParameter("@Role", newManager.Role));
                    //    cmd.Parameters.Add(new MySqlParameter("@Quantity", newProduct.Quantity));
                    //   cmd.Parameters.Add(new MySqlParameter("@ImageUrl", newProduct.ImageUrl));
                    cmd.ExecuteNonQuery();
                    con.Close();
                    status = true;
                }
            }
            catch (MySqlException exp)
            {
                string message = exp.Message;
            }
            return status;
        }


        public static bool UpdateM(Manager existingManager)
        {
            bool status = false;
            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = connString;
            IDbCommand cmd = new MySqlCommand();
            cmd.CommandText = "Select * from managers";
            cmd.Connection = conn;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd as MySqlCommand);
            DataSet ds = new DataSet();
            try
            {
                MySqlCommandBuilder cmdbuilder = new MySqlCommandBuilder(da);
                da.Fill(ds);
                DataColumn[] keyColumns = new DataColumn[1];
                keyColumns[0] = ds.Tables[0].Columns["Id"];
                ds.Tables[0].PrimaryKey = keyColumns;
                DataRow datarow = ds.Tables[0].Rows.Find(existingManager.Id);
                datarow["MName"] = existingManager.MName;
                datarow["Email"] = existingManager.Email;
                datarow["Role"] = existingManager.Role;
               // datarow["Quantity"] = existingProduct.Quantity;
              //  datarow["ImageUrl"] = existingProduct.ImageUrl;
                da.Update(ds);
                status = true;
            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                string msg = e.Message;
            }
            return status;
        }
     

       /* public static bool UpdateM(Manager existingManager)
        {
            bool status = false;
            try
            {
                using (MySqlConnection con = new MySqlConnection(connString))   //DI via Constructor
                {
                    if (con.State == ConnectionState.Closed)        //if connection is closed?
                        con.Open();
                    string query = "UPDATE managers SET `Id`=@Id,`MName`=@MName,`Email`=@Email,`Role`=@Role WHERE `Id`=@Id'";


                    //   string query = " UPDATE managers SET `Id`=@Id,`MName`=@MName,`Email`=@Email,`Role`=@Role WHERE `Id`=@Id'";



                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.Add(new MySqlParameter("@Id", existingManager.Id));
                    cmd.Parameters.Add(new MySqlParameter("@MName", existingManager.MName));
                    cmd.Parameters.Add(new MySqlParameter("@Email", existingManager.Email));
                    cmd.Parameters.Add(new MySqlParameter("@Role", existingManager.Role));
                    //    cmd.Parameters.Add(new MySqlParameter("@Quantity", newProduct.Quantity));
                    //   cmd.Parameters.Add(new MySqlParameter("@ImageUrl", newProduct.ImageUrl));
                    cmd.ExecuteNonQuery();
                    con.Close();
                    status = true;
                }
            }
            catch (MySqlException exp)
            {
                string message = exp.Message;
            }
            return status;
        }

*/






    }
}
