using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ApproveKycList : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
    string logId, mob;
    SqlDataAdapter adptCart = new SqlDataAdapter();
    DataSet dsCart = new DataSet();
    SqlCommand cmdMob = new SqlCommand();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["Log"] == null)
        {
            lblmsg.Text = "Session Expired!!! Please login again...";
        }
        else
        {
            logId = Convert.ToString(Request.Cookies["Log"].Value);
            if (!Page.IsPostBack)
            {
                bindCart();
            }
        }
    }
    protected void bindCart()
    {
        try
        {
            adptCart = new SqlDataAdapter("select * from tblKyc where Status='Approve'", con);
            adptCart.Fill(dsCart);
            if (dsCart.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = dsCart;
                GridView1.DataBind();
                lblmsg.Text = "";
            }
            else
            {
                GridView1.DataSource = dsCart;
                GridView1.DataBind();
                lblmsg.Text = "No Kyc ";
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.ToString();
        }
    }
    protected string GetImageUrl(object imagePath)
    {
        if (imagePath != null && !string.IsNullOrEmpty(imagePath.ToString()))
        {
            string fullImagePath = imagePath.ToString();

            if (System.IO.File.Exists(Server.MapPath(fullImagePath)))
            {
                return ResolveUrl(fullImagePath);
            }
        }
        return ResolveUrl("~/Images/Receipts/default.png");
    }
}