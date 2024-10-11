using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Text;
using System.Globalization;
using System.Drawing;
using System.Security.Cryptography;

public partial class Admin_UpdateKyc : System.Web.UI.Page
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
            adptCart = new SqlDataAdapter("select * from tblKyc where Status='Pending'", con);
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
    protected void lnkApprove_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = (GridViewRow)((LinkButton)sender).NamingContainer;
            TextBox recno1 = (TextBox)row.FindControl("txtKycId");

            int kycId = Convert.ToInt32(recno1.Text);

            

            SqlCommand cmd = new SqlCommand("update tblKyc set status=@status where KycId=@KycId", con);
            cmd.Parameters.AddWithValue("@KycId", kycId);
            cmd.Parameters.AddWithValue("@status", "Approve");
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

         //   Response.Redirect("ApproveKycList.aspx");

            bindCart();
            lblmsg.Text = "Kyc successfully Approve";

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.ToString();
        }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            Label pstat = (Label)GridView1.Rows[e.RowIndex].FindControl("txtStatus");
            TextBox pstat1 = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtKycId");

            KycId.Text = pstat1.Text;

            stat.Text = pstat.Text;

            if (stat.Text == "Pending")
            {
                Label5.Text = "";

                txtbuttun.Enabled = true;
                txtReason.Visible = true;
                txtbuttun.Text = "Submit";
                Button1.Text = "Cancel";
            }
            else
            {
                Label5.Text = "Kyc Cancellation Request Denied";
                txtbuttun.Enabled = false;
                txtReason.Visible = false;
                txtbuttun.Text = "Yes";
                Button1.Text = "No";
            }
            mpExtra.Show();
        }
        catch (Exception ex)
        {
            txtbuttun.Enabled = false;
            Label5.Text = ex.ToString();
        }
    }

    protected void txtbuttun_Click(object sender, EventArgs e)
    {
        try
        {
            // Assuming KycId is a Label or TextBox, retrieve its value
            int kycId = Convert.ToInt32(KycId.Text); // Or use another method to retrieve the KycId value from the control

            SqlCommand cmd = new SqlCommand("UPDATE tblKyc SET status = @status, Reason = @Reason WHERE KycId = @KycId", con);
            cmd.Parameters.AddWithValue("@KycId", kycId); // Pass the value, not the control
            cmd.Parameters.AddWithValue("@status", "canceled");
            cmd.Parameters.AddWithValue("@Reason", txtReason.Text); // Assuming txtReason is a TextBox

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            bindCart();
            lblmsg.Text = "Kyc successfully Canceled";
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.ToString();
        }
    }

}