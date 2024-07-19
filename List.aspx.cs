using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Test_Task
{
    public partial class List : System.Web.UI.Page
    {
        private int iPageSize = 10;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetDetails();
            }
        }
        protected void lnk_Command(object sender, CommandEventArgs e)
        {
            string commandName = e.CommandName;
            string commandArgument = e.CommandArgument.ToString();

            switch (commandName)
            {
                case "Edit":



                    int userId;
                    if (int.TryParse(commandArgument, out userId))
                    {
                        DataTable userData = FetchUserDataFromDatabase(userId);
                        Session["UserData"] = userData;
                        Response.Redirect("Registration.aspx");
                    }
                    else
                    {

                    }
                    break;
                case "Delete":
                  
                    DeleteUser(commandArgument);
                    break;

             


                default:

                    break;
            }
        }
     

        private DataTable FetchUserDataFromDatabase(int userId)
        {
            
            DataTable userData = new DataTable();

            string conString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection sqlCon = new SqlConnection(conString))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SELECT * FROM Employees WHERE EmpID=@UserID", sqlCon);
                sqlCmd.Parameters.AddWithValue("@UserID", userId);

                SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
                sqlDa.Fill(userData);
            }

            return userData;
        }

        private void DeleteUser(string userId)
        {
            int intUserId;
            if (int.TryParse(userId, out intUserId))
            {
                // Update the IsDeleted column to 1 for the specified user
                string conString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection sqlCon = new SqlConnection(conString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("UPDATE Employees SET IsDeleted = 1 WHERE EmpID = @EmpId", sqlCon);
                    sqlCmd.Parameters.AddWithValue("@EmpId", intUserId);
                    sqlCmd.ExecuteNonQuery();
                }

             
                GetDetails();
            }
            else
            {
              
            }
        }




        private void GetDetails()
        {
            DataTable dtData = new DataTable();
            string conString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection sqlCon = new SqlConnection(conString))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SELECT * FROM Employees WHERE IsDeleted=0", sqlCon);
                SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
                sqlDa.Fill(dtData);
            }

            PagedDataSource pdsData = new PagedDataSource();
            DataView dv = new DataView(dtData);
            pdsData.DataSource = dv;
            pdsData.AllowPaging = true;
            pdsData.PageSize = iPageSize;
            if (ViewState["PageNumber"] != null)
            {
                pdsData.CurrentPageIndex = Convert.ToInt32(ViewState["PageNumber"]) - 1;
            }
            else
            {
                pdsData.CurrentPageIndex = 0;
            }

            repeater1.Visible = true;
            Repeater2.Visible = true;

            ArrayList alPages = new ArrayList();
            for (int i = 1; i <= pdsData.PageCount; i++)
            {
                alPages.Add(i.ToString());
            }

            Repeater2.DataSource = alPages;
            Repeater2.DataBind();

            repeater1.DataSource = pdsData;
            repeater1.DataBind();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Page")
            {
                ViewState["PageNumber"] = Convert.ToInt32(e.CommandArgument);
                GetDetails();
            }
        }
    }
}