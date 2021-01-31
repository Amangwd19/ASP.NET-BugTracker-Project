using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Text;

namespace BugTracker
{
    public partial class Users : System.Web.UI.Page
    {
        string mainconn = ConfigurationManager.ConnectionStrings["dbString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateGridView();
            }

        }

        void PopulateGridView()
        {
            DataTable dtbl = new DataTable();
            using (MySqlConnection mysqlconn = new MySqlConnection(mainconn))
            {
                mysqlconn.Open();
                MySqlDataAdapter MySqlDa = new MySqlDataAdapter("SELECT * FROM USER", mysqlconn);
                MySqlDa.Fill(dtbl);

            }
            if (dtbl.Rows.Count > 0)
            {
                gvUsers.DataSource = dtbl;
                gvUsers.DataBind();
            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                gvUsers.DataSource = dtbl;
                gvUsers.DataBind();
                gvUsers.Rows[0].Cells.Clear();
                gvUsers.Rows[0].Cells.Add(new TableCell());
                gvUsers.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                gvUsers.Rows[0].Cells[0].Text = "No Data Found..";
                gvUsers.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }

        }

        protected void gvUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            try
            {
                if (e.CommandName.Equals("Add"))
                {
                    using (MySqlConnection mysqlconn = new MySqlConnection(mainconn))
                    {
                        mysqlconn.Open();
                        string query = "INSERT INTO USER(id,email_id,password,role,user_name) VALUES (@id,@email_id,@password,@role,@user_name)";
                        MySqlCommand mysqlCmd = new MySqlCommand(query, mysqlconn);
                        mysqlCmd.Parameters.AddWithValue("@id", (gvUsers.FooterRow.FindControl("txtIdFooter") as TextBox).Text.Trim());
                        mysqlCmd.Parameters.AddWithValue("@email_id", (gvUsers.FooterRow.FindControl("txtEmailIdFooter") as TextBox).Text.Trim());
                        mysqlCmd.Parameters.AddWithValue("@password", (gvUsers.FooterRow.FindControl("txtPasswordFooter") as TextBox).Text.Trim());
                        mysqlCmd.Parameters.AddWithValue("@role", (gvUsers.FooterRow.FindControl("txtRoleFooter") as TextBox).Text.Trim());
                        mysqlCmd.Parameters.AddWithValue("@user_name", (gvUsers.FooterRow.FindControl("txtUsernameFooter") as TextBox).Text.Trim());
                        //mysqlCmd.Parameters.AddWithValue("@user_id", (gvUsers.FooterRow.FindControl("txtUserIdFooter") as TextBox).Text.Trim());
                        mysqlCmd.ExecuteNonQuery();
                        PopulateGridView();
                        lblSuccessMessage.Text = "New Record Added";
                        lblErrorMessage.Text = "";

                    }
                }
            }
            catch (Exception ex)
            {

                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }

        protected void gvUsers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvUsers.EditIndex = e.NewEditIndex;
            PopulateGridView();

        }

        protected void gvUsers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvUsers.EditIndex = -1;
            PopulateGridView();
        }

        protected void gvUsers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {


                using (MySqlConnection mysqlconn = new MySqlConnection(mainconn))
                {
                    mysqlconn.Open();
                    string query = "UPDATE USER SET id=@id,email_id=@email_id,password=@password,role=@role,user_name=@user_name where id=@id";
                    MySqlCommand mysqlCmd = new MySqlCommand(query, mysqlconn);
                    mysqlCmd.Parameters.AddWithValue("@id", (gvUsers.Rows[e.RowIndex].FindControl("txtId") as TextBox).Text.Trim());
                    mysqlCmd.Parameters.AddWithValue("@email_id", (gvUsers.Rows[e.RowIndex].FindControl("txtEmailId") as TextBox).Text.Trim());
                    mysqlCmd.Parameters.AddWithValue("@password", (gvUsers.Rows[e.RowIndex].FindControl("txtPassword") as TextBox).Text.Trim());
                    mysqlCmd.Parameters.AddWithValue("@role", (gvUsers.Rows[e.RowIndex].FindControl("txtRole") as TextBox).Text.Trim());
                    mysqlCmd.Parameters.AddWithValue("@user_name", (gvUsers.Rows[e.RowIndex].FindControl("txtUsername") as TextBox).Text.Trim());
                   // mysqlCmd.Parameters.AddWithValue("@user_id", (gvUsers.Rows[e.RowIndex].FindControl("txtUserId") as TextBox).Text.Trim());
                    mysqlCmd.ExecuteNonQuery();
                    gvUsers.EditIndex = -1;
                    PopulateGridView();
                    lblSuccessMessage.Text = "Selected Row Updated";
                    lblErrorMessage.Text = "";


                }

            }
            catch (Exception ex)
            {

                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }

        }


        protected void gvUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {


                using (MySqlConnection mysqlconn = new MySqlConnection(mainconn))
                {
                    mysqlconn.Open();
                    string query = "DELETE FROM USER where id=@id";
                    MySqlCommand mysqlCmd = new MySqlCommand(query, mysqlconn);
                    mysqlCmd.Parameters.AddWithValue("@bug_id", (gvUsers.DataKeys[e.RowIndex].Value));
                    //mysqlCmd.Parameters.RemoveAt("@project_id", (gvTickets.Rows[e.RowIndex].FindControl("txtProjectId") as TextBox).Text.Trim());


                    mysqlCmd.ExecuteNonQuery();

                    PopulateGridView();
                    lblSuccessMessage.Text = "Selected Row Deleted";
                    lblErrorMessage.Text = "";

                }

            }
            catch (Exception ex)
            {

                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }
    }
}

      

   

    
