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
    public partial class Bugs : System.Web.UI.Page
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
                MySqlDataAdapter MySqlDa = new MySqlDataAdapter("SELECT * FROM BUGS", mysqlconn);
                MySqlDa.Fill(dtbl);

            }
            if (dtbl.Rows.Count > 0)
            {
                gvBugs.DataSource = dtbl;
                gvBugs.DataBind();
            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                gvBugs.DataSource = dtbl;
                gvBugs.DataBind();
                gvBugs.Rows[0].Cells.Clear();
                gvBugs.Rows[0].Cells.Add(new TableCell());
                gvBugs.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                gvBugs.Rows[0].Cells[0].Text = "No Data Found..";
                gvBugs.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }

        }





        protected void gvBugs_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("Add"))
                {
                    using (MySqlConnection mysqlconn = new MySqlConnection(mainconn))
                    {
                        mysqlconn.Open();
                        string query = "INSERT INTO BUGS(bug_id,bug_desc,bug_priority,bug_status,project_id,user_id) VALUES (@bug_id,@bug_desc,@bug_priority,@bug_status,@project_id,@user_id)";
                        MySqlCommand mysqlCmd = new MySqlCommand(query, mysqlconn);
                        mysqlCmd.Parameters.AddWithValue("@bug_id", (gvBugs.FooterRow.FindControl("txtBugIdFooter") as TextBox).Text.Trim());
                        mysqlCmd.Parameters.AddWithValue("@bug_desc", (gvBugs.FooterRow.FindControl("txtBugDescFooter") as TextBox).Text.Trim());
                        mysqlCmd.Parameters.AddWithValue("@bug_priority", (gvBugs.FooterRow.FindControl("txtBugPriorityFooter") as TextBox).Text.Trim());
                        mysqlCmd.Parameters.AddWithValue("@bug_status", (gvBugs.FooterRow.FindControl("txtBugStatusFooter") as TextBox).Text.Trim());
                        mysqlCmd.Parameters.AddWithValue("@project_id", (gvBugs.FooterRow.FindControl("txtProjectIdFooter") as TextBox).Text.Trim());
                        mysqlCmd.Parameters.AddWithValue("@user_id", (gvBugs.FooterRow.FindControl("txtUserIdFooter") as TextBox).Text.Trim());
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


    

    protected void gvBugs_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvBugs.EditIndex = e.NewEditIndex;
            PopulateGridView();
        }

        protected void gvBugs_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvBugs.EditIndex = -1;
            PopulateGridView();
        }

        protected void gvBugs_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {


                using (MySqlConnection mysqlconn = new MySqlConnection(mainconn))
                {
                    mysqlconn.Open();
                    string query = "UPDATE BUGS SET bug_id=@bug_id,bug_desc=@bug_desc,bug_priority=@bug_priority,bug_status=@bug_status,project_id=@project_id,user_id=@user_id where bug_id=@bug_id";
                    MySqlCommand mysqlCmd = new MySqlCommand(query, mysqlconn);
                    mysqlCmd.Parameters.AddWithValue("@bug_id", (gvBugs.Rows[e.RowIndex].FindControl("txtBugId") as TextBox).Text.Trim());
                    mysqlCmd.Parameters.AddWithValue("@bug_desc", (gvBugs.Rows[e.RowIndex].FindControl("txtBugDesc") as TextBox).Text.Trim());
                    mysqlCmd.Parameters.AddWithValue("@bug_priority", (gvBugs.Rows[e.RowIndex].FindControl("txtBugPriority") as TextBox).Text.Trim());
                    mysqlCmd.Parameters.AddWithValue("@bug_status", (gvBugs.Rows[e.RowIndex].FindControl("txtBugStatus") as TextBox).Text.Trim());
                    mysqlCmd.Parameters.AddWithValue("@project_id", (gvBugs.Rows[e.RowIndex].FindControl("txtProjectId") as TextBox).Text.Trim());
                    mysqlCmd.Parameters.AddWithValue("@user_id", (gvBugs.Rows[e.RowIndex].FindControl("txtUserId") as TextBox).Text.Trim());
                    mysqlCmd.ExecuteNonQuery();
                    gvBugs.EditIndex = -1;
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

    

    protected void gvBugs_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {


                using (MySqlConnection mysqlconn = new MySqlConnection(mainconn))
                {
                    mysqlconn.Open();
                    string query = "DELETE FROM BUGS where bug_id=@bug_id";
                    MySqlCommand mysqlCmd = new MySqlCommand(query, mysqlconn);
                    mysqlCmd.Parameters.AddWithValue("@bug_id", (gvBugs.DataKeys[e.RowIndex].Value));
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