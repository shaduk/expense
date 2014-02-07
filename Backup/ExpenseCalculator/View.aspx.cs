using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace ExpenseCalculator
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewAll();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ViewAll()
        {
            String connectionString = "Data Source=DTPXP-77A;Initial Catalog=practice;Integrated Security=true";
            SqlDataAdapter da = new SqlDataAdapter("select * from expense", connectionString);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);
            DataTable dt = new DataTable();
            da.Fill(dt);
            SqlDataAdapter da1 = new SqlDataAdapter("select * from expense where price !=0", connectionString);
            SqlCommandBuilder cmd = new SqlCommandBuilder(da);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            GridView1.DataSource = dt1;
            GridView1.DataBind();
            Decimal sum = (Decimal)dt.Compute("Sum (price)", null);
            total.Text = "Total Expense =" + sum.ToString();
            decimal per = sum /(decimal)5;
            perhead.Text = "Per Head Amount =" + per.ToString();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String connectionString = "Data Source=DTPXP-77A;Initial Catalog=practice;Integrated Security=true";
            SqlDataAdapter da = new SqlDataAdapter("select * from expense where person='" + DropDownList1.SelectedItem + "'"+"and price!=0", connectionString);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);
            DataTable dt1 = new DataTable();
            da.Fill(dt1);
            GridView1.DataSource = dt1;
            GridView1.DataBind();
           
            
        }

        protected void viewall_Click(object sender, EventArgs e)
        {
            ViewAll();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string serial = GridView1.DataKeys[e.RowIndex].Value.ToString();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DTPXP-77A;Initial Catalog=practice;Integrated Security=true";
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from expense where serial =@serial", con);
            cmd.Parameters.Add("@serial", SqlDbType.Int);
            cmd.Parameters["@serial"].Value = serial;
            cmd.ExecuteNonQuery();
            Response.Redirect("View.aspx");
        }
    }
}
