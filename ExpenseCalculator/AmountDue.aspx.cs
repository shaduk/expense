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
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txt_abhi.Text = "0";
                txt_kartik.Text = "0";
                txt_pankaj.Text = "0";
                txt_rahul.Text = "0";
                txt_shad.Text = "0";
            }
            String connectionString = "Data Source=SHAD-PC;Initial Catalog=practice;Integrated Security=true";
            SqlDataAdapter da = new SqlDataAdapter("select * from expense where item!='lastdue'", connectionString);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);
            DataTable dt = new DataTable();
            da.Fill(dt);
            SqlDataAdapter da1 = new SqlDataAdapter("select * from expense where item='lastdue'", connectionString);
            SqlCommandBuilder commandBuilder1 = new SqlCommandBuilder(da1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            Decimal total = (Decimal)dt.Compute("Sum (price)", null);
            decimal per = total / (decimal)5;

            Decimal shadsum = (Decimal)dt.Compute("Sum (price)", "person = 'shad'");
            Decimal shaddue = (Decimal)dt1.Compute("Sum (price)", "person = 'shad'");
            lbl_shad.Text = (shaddue + shadsum - per).ToString();

            Decimal kartiksum = (Decimal)dt.Compute("Sum (price)", "person = 'kartik'");
            Decimal kartikdue = (Decimal)dt1.Compute("Sum (price)", "person = 'kartik'");
            lbl_kartik.Text = (kartikdue + kartiksum - per).ToString();

            Decimal pkjsum = (Decimal)dt.Compute("Sum (price)", "person = 'pankaj'");
            Decimal pkjdue = (Decimal)dt1.Compute("Sum (price)", "person = 'pankaj'");
            lbl_pankaj.Text = (pkjdue + pkjsum - per).ToString();

            Decimal abhisum = (Decimal)dt.Compute("Sum (price)", "person = 'abhinav'");
            Decimal abhidue = (Decimal)dt1.Compute("Sum (price)", "person = 'abhinav'");
            lbl_abhinav.Text = (abhidue + abhisum - per).ToString();

            Decimal rahulsum = (Decimal)dt.Compute("Sum (price)", "person = 'rahul'");
            Decimal rahuldue = (Decimal)dt1.Compute("Sum (price)", "person = 'rahul'");
            lbl_rahul.Text = (rahuldue + rahulsum - per).ToString();



        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=SHAD-PC;Initial Catalog=practice;Integrated Security=true";
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from expense", con);
            cmd.ExecuteNonQuery();

            SqlCommand cmd1 = new SqlCommand("insert into expense values('pankaj','lastdue',@date,@due)", con);
            SqlCommand cmd11 = new SqlCommand("insert into expense values('pankaj','null',@date,0)", con);
            cmd1.Parameters.Add("@date", SqlDbType.DateTime);
            cmd1.Parameters["@date"].Value = DateTime.Now.ToString();
            cmd11.Parameters.Add("@date", SqlDbType.DateTime);
            cmd11.Parameters["@date"].Value = DateTime.Now.ToString();
            cmd1.Parameters.Add("@due", SqlDbType.Decimal);
            if (chk_pankaj.Checked == true)
                cmd1.Parameters["@due"].Value = -decimal.Parse(txt_pankaj.Text) + decimal.Parse(lbl_pankaj.Text);
            else
                cmd1.Parameters["@due"].Value = decimal.Parse(txt_pankaj.Text) + decimal.Parse(lbl_pankaj.Text);
            cmd1.ExecuteNonQuery();
            cmd11.ExecuteNonQuery();

            SqlCommand cmd2 = new SqlCommand("insert into expense values('shad','lastdue',@date,@due)", con);
            SqlCommand cmd22 = new SqlCommand("insert into expense values('shad','null',@date,0)", con);
            cmd2.Parameters.Add("@date", SqlDbType.DateTime);
            cmd2.Parameters["@date"].Value = DateTime.Now.ToString();
            cmd22.Parameters.Add("@date", SqlDbType.DateTime);
            cmd22.Parameters["@date"].Value = DateTime.Now.ToString();
            cmd2.Parameters.Add("@due", SqlDbType.Decimal);
            if (chk_shad.Checked == true)
                cmd2.Parameters["@due"].Value = -decimal.Parse(txt_shad.Text) + decimal.Parse(lbl_shad.Text);
            else
                cmd2.Parameters["@due"].Value = decimal.Parse(txt_shad.Text) + decimal.Parse(lbl_shad.Text);
            cmd22.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();

            SqlCommand cmd3 = new SqlCommand("insert into expense values('kartik','lastdue',@date,@due)", con);
            SqlCommand cmd33 = new SqlCommand("insert into expense values('kartik','null',@date,0)", con);
            cmd3.Parameters.Add("@date", SqlDbType.DateTime);
            cmd3.Parameters["@date"].Value = DateTime.Now.ToString();
            cmd33.Parameters.Add("@date", SqlDbType.DateTime);
            cmd33.Parameters["@date"].Value = DateTime.Now.ToString();
            cmd3.Parameters.Add("@due", SqlDbType.Decimal);
            if (chk_kartik.Checked == true)
                cmd3.Parameters["@due"].Value = -decimal.Parse(txt_kartik.Text) + decimal.Parse(lbl_kartik.Text);
            else
                cmd3.Parameters["@due"].Value = decimal.Parse(txt_kartik.Text) + decimal.Parse(lbl_kartik.Text);
            cmd3.ExecuteNonQuery();
            cmd33.ExecuteNonQuery();


            SqlCommand cmd4 = new SqlCommand("insert into expense values('abhinav','lastdue',@date,@due)", con);
            SqlCommand cmd44 = new SqlCommand("insert into expense values('abhinav','null',@date,0)", con);
            cmd4.Parameters.Add("@date", SqlDbType.DateTime);
            cmd4.Parameters["@date"].Value = DateTime.Now.ToString();
            cmd44.Parameters.Add("@date", SqlDbType.DateTime);
            cmd44.Parameters["@date"].Value = DateTime.Now.ToString();
            cmd4.Parameters.Add("@due", SqlDbType.Decimal);
            if (chk_abhi.Checked == true)
                cmd4.Parameters["@due"].Value = -decimal.Parse(txt_abhi.Text) + decimal.Parse(lbl_abhinav.Text);
            else
                cmd4.Parameters["@due"].Value = decimal.Parse(txt_abhi.Text) + decimal.Parse(lbl_abhinav.Text);
            cmd4.ExecuteNonQuery();
            cmd44.ExecuteNonQuery();

            SqlCommand cmd5 = new SqlCommand("insert into expense values('rahul','lastdue',@date,@due)", con);
            SqlCommand cmd55 = new SqlCommand("insert into expense values('rahul','null',@date,0)", con);
            cmd5.Parameters.Add("@date", SqlDbType.DateTime);
            cmd5.Parameters["@date"].Value = DateTime.Now.ToString();
            cmd55.Parameters.Add("@date", SqlDbType.DateTime);
            cmd55.Parameters["@date"].Value = DateTime.Now.ToString();
            cmd5.Parameters.Add("@due", SqlDbType.Decimal);
            if (chk_rahul.Checked == true)
                cmd5.Parameters["@due"].Value = -decimal.Parse(txt_rahul.Text) + decimal.Parse(lbl_rahul.Text);
            else
                cmd5.Parameters["@due"].Value = decimal.Parse(txt_rahul.Text) + decimal.Parse(lbl_rahul.Text);
            cmd5.ExecuteNonQuery();
            cmd55.ExecuteNonQuery();
            Response.Redirect("AmountDue.aspx");
        }

    }
}
