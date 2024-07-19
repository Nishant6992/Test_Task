using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;
using DataAccessLayer;

namespace Test_Task
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserData"] != null)
            {
                DataTable userData = (DataTable)Session["UserData"];
                txtfirstname.Text = userData.Rows[0]["FirstName"].ToString();
                txtlastname.Text = userData.Rows[0]["LastName"].ToString();
                txtmail.Text = userData.Rows[0]["Email"].ToString();
                txtphonenum.Text = userData.Rows[0]["PhoneNumber"].ToString();
                txthiredate.Text = userData.Rows[0]["HireDate"].ToString();
                txtposition.Text = userData.Rows[0]["Position"].ToString();
                txtsalary.Text = userData.Rows[0]["Salary"].ToString();

            }
            Session.Remove("UserData");
        }

        protected void txtsave_Click(object sender, EventArgs e)
        {
            BusinessObjects.object_employee bo = new BusinessObjects.object_employee();
            bo.FirstName = txtfirstname.Text;
            bo.LastName = txtlastname.Text;
            bo.Email = txtmail.Text;
            bo.phonenumber = txtphonenum.Text;
            bo.date = txthiredate.Text;
            bo.position = txtposition.Text;
            bo.Salary = Convert.ToDouble(txtsalary.Text);

            DataAccessLayer.dataaccess newdata = new DataAccessLayer.dataaccess();
            newdata.Save(bo);

            txtfirstname.Text = null;
            txtlastname.Text = null;
            txtmail.Text = null;
            txtphonenum.Text = null;
            txthiredate.Text = null;
            txtposition.Text = null;
            txtsalary.Text = null;
            Label1.Visible = true;
            Label1.Text = "Records are Submitted Successfully";

            Response.Redirect("https://localhost:44388/List.aspx");
        }

        protected void reset_Click(object sender, EventArgs e)
        {
            txtfirstname.Text = null;
            txtlastname.Text = null;
            txtmail.Text = null;
            txtphonenum.Text = null;
            txthiredate.Text = null;
            txtposition.Text = null;
            txtsalary.Text = null;
        }
    }
}