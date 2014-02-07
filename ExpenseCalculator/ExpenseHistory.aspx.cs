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
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void ViewAll()
        {
            String connectionString = "Data Source=SHAD-PC;Initial Catalog=practice;Integrated Security=true";
            SqlDataAdapter da = new SqlDataAdapter("select * from history", connectionString);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);
            DataTable dt = new DataTable();
            da.Fill(dt);
            SqlDataAdapter da1 = new SqlDataAdapter("select * from history where price !=0", connectionString);
            SqlCommandBuilder cmd = new SqlCommandBuilder(da);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            GridView1.DataSource = dt1;
            GridView1.DataBind();
            Int64 sum = (Int64)dt.Compute("Sum (price)", null);
            total.Text = "Total Expense = " + sum.ToString();
            decimal per = sum / (decimal)5;
            perhead.Text = "Per Head Amount = " + per.ToString();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewAll();
            }

        }

        

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            ViewAll();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string serial = GridView1.DataKeys[e.RowIndex].Value.ToString();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=SHAD-PC;Initial Catalog=practice;Integrated Security=true";
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from history where serial =@serial", con);
            cmd.Parameters.Add("@serial", SqlDbType.Int);
            cmd.Parameters["@serial"].Value = serial;
            cmd.ExecuteNonQuery();
            Response.Redirect("ExpenseHistory.aspx");
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ViewAll();
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();

        }

        protected void btn_filter_Click(object sender, EventArgs e)
        {
           
            if (DropDownList1.SelectedValue != "null" && DropDownList2.SelectedValue != "null")
            {

                String connectionString = "Data Source=SHAD-PC;Initial Catalog=practice;Integrated Security=true";
                SqlDataAdapter da = new SqlDataAdapter("select * from history where person='" + DropDownList1.SelectedItem + "' and month(expdate)=" + DropDownList2.SelectedValue, connectionString);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                try
                {
                    Int64 sum = (Int64)dt.Compute("Sum (price)", null);
                    total.Text = "Total Expense for " + DropDownList1.SelectedItem + " in " + DropDownList2.SelectedItem + " is " + sum.ToString();
                    perhead.Text = "";
                }
                catch
                {
                    Response.Write("<script>alert('Invalid Parameters(1)');</script>");
                }
            }
            else if (DropDownList1.SelectedValue != "null" && DropDownList2.SelectedValue == "null")
            {
                try
                {
                    String connectionString = "Data Source=SHAD-PC;Initial Catalog=practice;Integrated Security=true";
                    SqlDataAdapter da = new SqlDataAdapter("select * from history where person='" + DropDownList1.SelectedItem + "'", connectionString);
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);
                    DataTable dt1 = new DataTable();
                    da.Fill(dt1);
                    GridView1.DataSource = dt1;
                    GridView1.DataBind();
                    try
                    {
                        Int64 sum = (Int64)dt1.Compute("Sum (price)", null);
                        total.Text = "Total Expense for " + DropDownList1.SelectedItem + " = " + sum.ToString();
                        perhead.Text = "";
                    }
                    catch
                    {
                        total.Text = "Nil";
                    }
                }
                catch
                {
                    Response.Redirect("ExpenseHistory.aspx");
                }
            }
            else if (DropDownList1.SelectedValue == "null" && DropDownList2.SelectedValue != "null")
            {
                String connectionString = "Data Source=SHAD-PC;Initial Catalog=practice;Integrated Security=true";
                SqlDataAdapter da = new SqlDataAdapter("select * from history where month(expdate)=" + DropDownList2.SelectedValue, connectionString);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);
                DataTable dt1 = new DataTable();
                da.Fill(dt1);
                GridView1.DataSource = dt1;
                GridView1.DataBind();
                try
                {
                    Int64 sum = (Int64)dt1.Compute("Sum (price)", null);
                    total.Text = "Total Expense of Home for " + DropDownList2.SelectedItem + " = " + sum.ToString();
                    decimal per = sum / (decimal)5;
                    perhead.Text = "Per Head Amount in "+ DropDownList2.SelectedItem + " is " + per.ToString();
                }
                catch
                {
                    total.Text = "Nil";
                }

            }
            else
            {
                Response.Write("<script>alert('Invalid Parameters(2)');</script>");
            }
            

        }
          

        }

       
    }

