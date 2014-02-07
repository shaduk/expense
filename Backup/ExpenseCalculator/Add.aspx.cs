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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        protected void InsertHistory()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DTPXP-77A;Initial Catalog=practice;Integrated Security=true";
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into history values(@person,@item,@expdate,@price)", con);
            cmd.Parameters.Add("@person", SqlDbType.VarChar);
            cmd.Parameters.Add("@item", SqlDbType.VarChar);
            cmd.Parameters.Add("@expdate", SqlDbType.DateTime);
            cmd.Parameters.Add("@price", SqlDbType.Int);
            cmd.Parameters["@person"].Value = droplist_person.SelectedItem.ToString();
            cmd.Parameters["@item"].Value = txt_stuff.Text;
            cmd.Parameters["@expdate"].Value = DateTime.Now.ToString();
            cmd.Parameters["@price"].Value = txt_price.Text;
            cmd.ExecuteNonQuery();
    
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DTPXP-77A;Initial Catalog=practice;Integrated Security=true";
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into expense values(@person,@item,@expdate,@price)", con);
            cmd.Parameters.Add("@person", SqlDbType.VarChar);
            cmd.Parameters.Add("@item", SqlDbType.VarChar);
            cmd.Parameters.Add("@expdate", SqlDbType.DateTime);
            cmd.Parameters.Add("@price", SqlDbType.Int);
            cmd.Parameters["@person"].Value = droplist_person.SelectedItem.ToString();
            cmd.Parameters["@item"].Value = txt_stuff.Text;
            cmd.Parameters["@expdate"].Value = DateTime.Now.ToString();
            cmd.Parameters["@price"].Value = txt_price.Text;
            cmd.ExecuteNonQuery();
            InsertHistory();
            Response.Redirect("Add.aspx");
        }


       
        
    }
}
