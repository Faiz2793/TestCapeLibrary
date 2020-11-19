using CapeLibManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapeLibManagementSystem
{
    public partial class AdminHomePage : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection("Data Source=DESKTOP-IRQ0E3L\\SQLEXPRESS;Initial Catalog=Library_Management_DB;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Binding the DropDown Values in the initial Load of the View
                GetAuthorDropdown();
                GetPublisherDropdown();
                //Book Data Repeater Loader
                LoadBookRepeater();
            }
        }
        //DIsplaying the initial View of all the books using the Data Repeater 
        protected void LoadBookRepeater()
        {
            DataSet ds = new DataSet();
            sqlCon.Open();
            string cmdstr = "Select * from Book";
            SqlCommand cmd = new SqlCommand(cmdstr, sqlCon);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(ds);
            BookGrid.DataSource = ds;
            BookGrid.DataBind();
            sqlCon.Close();
        }
        
        private void AddBooks(object sender, EventArgs e)
        {
            string bookName = BookName.Value.ToString();
            int authorId = AuthorDropDown.SelectedIndex;
            int publishId = PublisherDropDown.SelectedIndex;
            AddNewBooks(bookName, authorId, publishId);
        }
        private void DeleteBooks(object sender, EventArgs e)
        {
            int bookid = BookName.BookId;
            DeleteBook(bookid);
        }

        public List<Author> GetAuthorDropdown()
        {
            Author author = new Author();
            List<Author> authorList = new List<Author>();
            DataSet ds = new DataSet();
            sqlCon.Open();
            string sql = "SELECT * from Author";
            SqlCommand cmd = new SqlCommand(sql, sqlCon);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                author.AuthorId = reader["AuthorId"].ToString();
                author.AuthorName = reader["AuthorName"].ToString();
            }
            authorList.Add(author);
            return authorList;
        }
        public List<Publisher> GetPublisherDropdown()
        {
            Publisher publish = new Publisher();
            List<Publisher> publishList = new List<Publisher>();
            DataSet ds = new DataSet();
            sqlCon.Open();
            string sql = "SELECT * from Author";
            SqlCommand cmd = new SqlCommand(sql, sqlCon);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                publish.PuiblisherId = reader["PuiblisherId"].ToString();
                publish.PublisherName = reader["PuiblisherIName"].ToString();
            }
            publishList.Add(publish);
            return publishList;
        }
        private void AddNewBooks(string bookName, int authorId, int publish)
        {
            sqlCon.Open();
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add("@BookName", SqlDbType.NVarChar).Value = bookName;
            cmd.Parameters.Add("@AuthorId", SqlDbType.Int).Value = authorId;
            cmd.Parameters.Add("@PublisherId", SqlDbType.Int).Value = publish;
            cmd = new SqlCommand("spInsertBook", sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            SqlDataReader reader = cmd.ExecuteReader();
        }
        private void DeleteBook(int bookid)
        {
            sqlCon.Open();
            DataSet ds = new DataSet();
            //SqlCommand cmd = new SqlCommand();
            string query = "Delete from Book where BookId=@bookid";
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            cmd.Parameters.AddWithValue("@bookid", bookid);
            cmd.ExecuteNonQuery();
        }
    }
}