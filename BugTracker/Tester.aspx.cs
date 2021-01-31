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
    public partial class Tester : System.Web.UI.Page
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
                MySqlDataAdapter MySqlDa = new MySqlDataAdapter("SELECT * FROM TESTER", mysqlconn);
                MySqlDa.Fill(dtbl);

            }
            if (dtbl.Rows.Count > 0)
            {
                gvTesters.DataSource = dtbl;
                gvTesters.DataBind();
            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                gvTesters.DataSource = dtbl;
                gvTesters.DataBind();
                gvTesters.Rows[0].Cells.Clear();
                gvTesters.Rows[0].Cells.Add(new TableCell());
                gvTesters.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                gvTesters.Rows[0].Cells[0].Text = "No Data Found..";
                gvTesters.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }

        }

        protected void gvTesters_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            try
            {
                if (e.CommandName.Equals("Add"))
                {
                    using (MySqlConnection mysqlconn = new MySqlConnection(mainconn))
                    {
                        mysqlconn.Open();
                        string query = "INSERT INTO TESTER(tester_id,project_id,tester_name) VALUES (@tester_id,@project_id,@tester_name)";
                        MySqlCommand mysqlCmd = new MySqlCommand(query, mysqlconn);
                        mysqlCmd.Parameters.AddWithValue("@tester_id", (gvTesters.FooterRow.FindControl("txttesterIdFooter") as TextBox).Text.Trim());
                        mysqlCmd.Parameters.AddWithValue("@project_id", (gvTesters.FooterRow.FindControl("txtProjectIdFooter") as TextBox).Text.Trim());
                        mysqlCmd.Parameters.AddWithValue("@tester_name", (gvTesters.FooterRow.FindControl("txtTesterFooter") as TextBox).Text.Trim());
                        //  mysqlCmd.Parameters.AddWithValue("@role", (gvTesters.FooterRow.FindControl("txtRoleFooter") as TextBox).Text.Trim());
                        //  mysqlCmd.Parameters.AddWithValue("@user_name", (gvTesters.FooterRow.FindControl("txtUsernameFooter") as TextBox).Text.Trim());
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


        protected void gvTesters_RowEditing(object sender, GridViewEditEventArgs e)
        {
           gvTesters.EditIndex = e.NewEditIndex;
            PopulateGridView();

        }

        protected void gvTesters_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvTesters.EditIndex = -1;
            PopulateGridView();
        }

        protected void gvTesters_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {


                using (MySqlConnection mysqlconn = new MySqlConnection(mainconn))
                {
                    mysqlconn.Open();
                    string query = "UPDATE TESTER SET tester_id=@tester_id,project_id=@project_id,tester_name=@tester_name where @tester_id=@tester_id";
                    MySqlCommand mysqlCmd = new MySqlCommand(query, mysqlconn);
                    mysqlCmd.Parameters.AddWithValue("@tester_id", (gvTesters.Rows[e.RowIndex].FindControl("txttesterId") as TextBox).Text.Trim());
                    mysqlCmd.Parameters.AddWithValue("@project_id", (gvTesters.Rows[e.RowIndex].FindControl("txtProjectId") as TextBox).Text.Trim());
                    mysqlCmd.Parameters.AddWithValue("@tester_name", (gvTesters.Rows[e.RowIndex].FindControl("txtTester") as TextBox).Text.Trim());
                  //  mysqlCmd.Parameters.AddWithValue("@role", (gvTesters.Rows[e.RowIndex].FindControl("txtRole") as TextBox).Text.Trim());
                  //  mysqlCmd.Parameters.AddWithValue("@user_name", (gvTesters.Rows[e.RowIndex].FindControl("txtUsername") as TextBox).Text.Trim());
                    // mysqlCmd.Parameters.AddWithValue("@user_id", (gvUsers.Rows[e.RowIndex].FindControl("txtUserId") as TextBox).Text.Trim());
                    mysqlCmd.ExecuteNonQuery();
                    gvTesters.EditIndex = -1;
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
        protected void gvTesters_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {


                using (MySqlConnection mysqlconn = new MySqlConnection(mainconn))
                {
                    mysqlconn.Open();
                    string query = "DELETE FROM TESTER where tester_id=@tester_id";
                    MySqlCommand mysqlCmd = new MySqlCommand(query, mysqlconn);
                    mysqlCmd.Parameters.AddWithValue("@tester_id", (gvTesters.DataKeys[e.RowIndex].Value));
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

   

    
