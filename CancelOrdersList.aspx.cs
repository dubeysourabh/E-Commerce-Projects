using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_CancelOrdersList : System.Web.UI.Page
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
            adptCart = new SqlDataAdapter("select RepMem.repurchaseNo,RepMem.Loginid,RepMem.UpiId,RepMem.Description,RepMem.Uploadimg,RepMem.TotQty,RepMem.TotRV,RepMem.TotPrice,RepMem.TotShipping,RepMem.TotCost,RepMem.PaymentMode,RepMem.OrderDate,RepMem.Status,MM.membername from Repurchase_Members as RepMem inner join membermaster as MM on MM.Loginid = RepMem.Loginid where RepMem.Status = 'Cancelled'\r\n", con);
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
                lblmsg.Text = "No product ordered";
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
            // Assuming the full path (like "~/CompanyImg/Sample-png-image-500kb.png") is stored in the Uploadimg field
            string fullImagePath = imagePath.ToString();

            // Check if the file exists on the server
            if (System.IO.File.Exists(Server.MapPath(fullImagePath)))
            {
                return ResolveUrl(fullImagePath); // Return the image URL if it exists
            }
        }

        // If no image path is provided or image file doesn't exist, return a default image
        return ResolveUrl("~/Images/Receipts/default.png");
    }
}