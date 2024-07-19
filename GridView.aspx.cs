using System;
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
    public partial class GridView : System.Web.UI.Page
    {

        //Connection String from web.config File
        readonly string  cs = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con;
        SqlDataAdapter adapt;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowData();
            }
        }
        //ShowData method for Displaying Data in Gridview
        protected void ShowData()
        {
            dt = new DataTable();
            con = new SqlConnection(cs);
            con.Open();
            adapt = new SqlDataAdapter("select * from Employees", con);
            adapt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            con.Close();
        }

        protected void GridView1_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            //NewEditIndex property used to determine the index of the row being edited.
            GridView1.EditIndex = e.NewEditIndex;
            ShowData();
        }
        protected void GridView1_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            //Finding the controls from Gridview for the row which is going to update
            Label id = GridView1.Rows[e.RowIndex].FindControl("lbl_ID") as Label;
            TextBox name = GridView1.Rows[e.RowIndex].FindControl("txt_Name") as TextBox;
            TextBox mail = GridView1.Rows[e.RowIndex].FindControl("txt_mail") as TextBox;
            TextBox PhoneNumber = GridView1.Rows[e.RowIndex].FindControl("PhoneNumber") as TextBox;
            TextBox HireDate = GridView1.Rows[e.RowIndex].FindControl("HireDate") as TextBox;
            TextBox Position = GridView1.Rows[e.RowIndex].FindControl("Position") as TextBox;
            TextBox Salary = GridView1.Rows[e.RowIndex].FindControl("Salary") as TextBox;

            con = new SqlConnection(cs);
            con.Open();
            //updating the record

            //SqlCommand cmd = new SqlCommand("Update Employees set Name='" + name.Text + "',City='" + city.Text + "' where ID=" + Convert.ToInt32(id.Text), con);
            SqlCommand cmd = new SqlCommand("update_emp", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", name.Text);
           
            cmd.Parameters.AddWithValue("@Email", mail.Text);
            cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber.Text);
            cmd.Parameters.AddWithValue("@HireDate", HireDate.Text);
            cmd.Parameters.AddWithValue("@Position", Position.Text);
            cmd.Parameters.AddWithValue("@Salary", Salary.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview
            GridView1.EditIndex = -1;
            //Call ShowData method for displaying updated data
            ShowData();
        }
        protected void GridView1_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview
            GridView1.EditIndex = -1;
            ShowData();
        }
    }
}