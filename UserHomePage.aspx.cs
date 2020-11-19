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
    public partial class UserBookViewPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadBookRepeater();
            }
        }
        //DIsplaying the initial View of all the books using the Data Repeater 
        protected void LoadBookRepeater()
        {
            SqlConnection sqlCon = new SqlConnection("Data Source=DESKTOP-IRQ0E3L\\SQLEXPRESS;Initial Catalog=Library_Management_DB;Integrated Security=True");
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
        private void searchBooks(object sender, EventArgs e)
        {
            string parameter = search.Value.ToString();
            GetSearchedBooks(parameter);
        }
        private void orderBooks(object sender, EventArgs e)
        {
            int book_id = fetchedBooktable.bookId;
            string user_id = fetchedBooktable.userId;
            LendBook(book_id,user_id);
        }
        //Method to fetch the Search Result for the users search
        private List<Book> GetSearchedBooks(string parameter)
        {
            Book retBooks = new Book();
            List<Book> filteredBooks = new List<Book>();
            SqlConnection sqlCon = new SqlConnection("Data Source=DESKTOP-IRQ0E3L\\SQLEXPRESS;Initial Catalog=Library_Management_DB;Integrated Security=True");
            sqlCon.Open();
            string selectCommand = "SELECT Book.BookId AS BookId,Book.BookName as BookName, Author.AuthorName  AS AuthorName, Publisher.PublisherName as PublisherName " +
                                   "FROM Book B INNERJOIN Author A ON B.AuthorId = A.AuthorId" +
                                   "INNERJOIN Publisher P ON B.PublisherId = P.PublisherId " +
                                   "WHERE Book.BookName LIKE'%" + parameter + "%' OR " +
                                   "Author.AuthorName LIKE'%" + parameter + "%' OR " +
                                   "Publisher.PublisherName LIKE'%" + parameter + "%' " +
                                   "ORDER BY Book.BookName";
            SqlCommand cmd = new SqlCommand(selectCommand, sqlCon);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                retBooks.BookId = reader["BookId"].ToString();
                retBooks.BookName = reader["BookName"].ToString();
                retBooks.AuthorName = reader["AuthorName"].ToString();
                retBooks.PublisherName = reader["PublisherName"].ToString();
            }
            filteredBooks.Add(retBooks);
            return filteredBooks;
        }
        //Method to Create a Transaction Entry in table to set the Flag for the Availability of the book.
        private void LendBook(int book_id,string user_id)
        {
            SqlConnection sqlCon = new SqlConnection("Data Source=DESKTOP-IRQ0E3L\\SQLEXPRESS;Initial Catalog=Library_Management_DB;Integrated Security=True");
            sqlCon.Open();
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add("@BookId", SqlDbType.Int).Value = book_id;
            cmd.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = user_id;
            cmd = new SqlCommand("spUpdateBookTransaction", sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            SqlDataReader reader = cmd.ExecuteReader();
        }
    }
}