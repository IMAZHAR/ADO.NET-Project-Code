using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
namespace SqlDataRederDemo
{
    public partial class sqlreader : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("select ProductID,ProductName,UnitPrice from tblproductdetails", con);
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    DataTable table = new DataTable();
                    table.Columns.Add("ID");
                    table.Columns.Add("Name");
                    table.Columns.Add("Price");
                    table.Columns.Add("DiscountedPrice");
                    while (rdr.Read())
                    {
                        DataRow datarow = table.NewRow();
                        int originalprice = Convert.ToInt32(rdr["UnitPrice"]);
                        double DiscountedPrice = originalprice * 0.9;
                        datarow["ID"] = rdr["ProductID"];
                        datarow["Name"] = rdr["ProductName"];
                        datarow["Price"] = rdr["UnitPrice"];
                        datarow["Discount"] = rdr["DiscountedPrice"];
                        table.Rows.Add(datarow);
                    }
                    GridView1.DataSource = table;
                    GridView1.DataBind();

                }

            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
    }            

        
    
