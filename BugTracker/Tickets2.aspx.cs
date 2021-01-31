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
//using System.Data.DataRowView;

namespace BugTracker
{
    public partial class Tickets2 : System.Web.UI.Page
    {
        string mainconn = ConfigurationManager.ConnectionStrings["dbString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            //string mainconn = ConfigurationManager.ConnectionStrings["dbString"].ConnectionString;
           
            if(!IsPostBack)
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
                MySqlDataAdapter MySqlDa = new MySqlDataAdapter("SELECT * FROM PROJECT", mysqlconn);
                MySqlDa.Fill(dtbl);

            }
            if (dtbl.Rows.Count > 0)
            {
                gvTickets.DataSource = dtbl;
                
                gvTickets.DataBind();
            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                gvTickets.DataSource = dtbl;
                gvTickets.DataBind();
                gvTickets.Rows[0].Cells.Clear();
                gvTickets.Rows[0].Cells.Add(new TableCell());
                gvTickets.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                gvTickets.Rows[0].Cells[0].Text = "No Data Found..";
                gvTickets.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }

        }


        protected void gvTickets_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("Add"))
                {
                    using (MySqlConnection mysqlconn = new MySqlConnection(mainconn))
                    {
                        mysqlconn.Open();
                        string query = "INSERT INTO PROJECT(project_id,project_desc,project_name,project_status,user_id) VALUES (@project_id,@project_desc,@project_name,@project_status,@user_id)";
                        MySqlCommand mysqlCmd = new MySqlCommand(query, mysqlconn);
                        mysqlCmd.Parameters.AddWithValue("@project_id", (gvTickets.FooterRow.FindControl("txtProjectIdFooter") as TextBox).Text.Trim());
                        mysqlCmd.Parameters.AddWithValue("@project_name", (gvTickets.FooterRow.FindControl("txtProjectNameFooter") as TextBox).Text.Trim());
                        mysqlCmd.Parameters.AddWithValue("@project_desc", (gvTickets.FooterRow.FindControl("txtProjectdescFooter") as TextBox).Text.Trim());
                        mysqlCmd.Parameters.AddWithValue("@project_status", (gvTickets.FooterRow.FindControl("txtProjectStatusFooter") as TextBox).Text.Trim());
                        mysqlCmd.Parameters.AddWithValue("@user_id", (gvTickets.FooterRow.FindControl("txtUserIdFooter") as TextBox).Text.Trim());
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

        protected void gvTickets_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvTickets.EditIndex = e.NewEditIndex;
            PopulateGridView();
        }

        protected void gvTickets_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvTickets.EditIndex = -1;
            PopulateGridView();
        }

        protected void gvTickets_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
             
                
                    using (MySqlConnection mysqlconn = new MySqlConnection(mainconn))
                    {
                        mysqlconn.Open();
                        string query = "UPDATE PROJECT SET project_id=@project_id,project_desc=@project_desc,project_name=@project_name,project_status=@project_status,user_id=@user_id where project_id=@project_id";
                        MySqlCommand mysqlCmd = new MySqlCommand(query, mysqlconn);
                        mysqlCmd.Parameters.AddWithValue("@project_id", (gvTickets.Rows[e.RowIndex].FindControl("txtProjectId") as TextBox).Text.Trim());
                        mysqlCmd.Parameters.AddWithValue("@project_name", (gvTickets.Rows[e.RowIndex].FindControl("txtProjectName") as TextBox).Text.Trim());
                        mysqlCmd.Parameters.AddWithValue("@project_desc", (gvTickets.Rows[e.RowIndex].FindControl("txtProjectdesc") as TextBox).Text.Trim());
                        mysqlCmd.Parameters.AddWithValue("@project_status", (gvTickets.Rows[e.RowIndex].FindControl("txtProjectStatus") as TextBox).Text.Trim());
                        mysqlCmd.Parameters.AddWithValue("@user_id", (gvTickets.Rows[e.RowIndex].FindControl("txtUserId") as TextBox).Text.Trim());
                        
                        mysqlCmd.ExecuteNonQuery();
                        gvTickets.EditIndex = -1;
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

        protected void gvTickets_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {


                using (MySqlConnection mysqlconn = new MySqlConnection(mainconn))
                {
                    mysqlconn.Open();
                    string query = "DELETE FROM PROJECT where project_id=@project_id";
                    MySqlCommand mysqlCmd = new MySqlCommand(query, mysqlconn);
                    mysqlCmd.Parameters.AddWithValue("@project_id",(gvTickets.DataKeys[e.RowIndex].Value));
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