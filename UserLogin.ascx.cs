using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapeLibManagementSystem.Content.UserControls
{
    public partial class UserLogin : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void submitfunction(object sender, EventArgs e)
        {
            string username = userId.Value.ToString();
            string password = passwdId.Value.ToString();
            SqlConnection sqlCon = new SqlConnection("Data Source=DESKTOP-IRQ0E3L\\SQLEXPRESS;Initial Catalog=Library_Management_DB;Integrated Security=True");
            sqlCon.Open();
            string sql = "SELECT * from UserTable where UserName=''" + username + "'' and UserPassword= ''" + password + "''";
            SqlCommand cmd = new SqlCommand(sql, sqlCon);
            SqlDataReader reader = cmd.ExecuteReader();

            string userRole = "";
            while (reader.Read())
            {
                userRole = reader["UserRole"].ToString();
            }
            if (!string.IsNullOrEmpty(userRole))
            {

            }
            else if (userRole == "Admin")
            {
                Response.Redirect("AdminHomePage.aspx");
            }
            else if (userRole == "User")
            {
                Response.Redirect("UserHomePage.aspx");
            }
        }
    }
}