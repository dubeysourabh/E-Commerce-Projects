using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Agent_Invoice : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
    string logId, mob, recNo;
    SqlDataAdapter adptCart = new SqlDataAdapter();
    DataSet dsCart = new DataSet();
    SqlCommand cmdMob = new SqlCommand();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["ALog"] == null)
        {
            lblmsg.Text = "Session Expired!!! Please login again...";
        }
        else
        {
            lblmsg.Text = "";
            if (Request.QueryString["RecNo"] != null)
            {
                recNo = Convert.ToString(Request.QueryString["RecNo"]);
                lblmsg.Text = "";
                if (!Page.IsPostBack)
                {
                    bindCart();
                }
            }
            else
            {
                lblmsg.Text = "Session Expired!!! Please login again...";
            }
            //bindCart1();
        }
    }
    protected void bindCart()
    {
        try
        {
            string loginId = "";  // To store the loginId extracted from the first query
                                  // Assuming 'recNo' is a variable storing the Repurchase number
            string query = "SELECT Loginid, Contact FROM Repurchase_Members WHERE RepurchaseNo = @recNo";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@recNo", recNo);  // Add parameter for repurchase number

                SqlDataAdapter adptCart = new SqlDataAdapter(cmd);
                DataSet dsCart = new DataSet();
                adptCart.Fill(dsCart);

                if (dsCart.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = dsCart;
                    GridView1.DataBind();
                    lblmsg.Text = "";

                    // Extract loginId from the first query result
                    loginId = dsCart.Tables[0].Rows[0]["Loginid"].ToString();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    lblmsg.Text = "No orders found";
                }
            }

            // Call the second method (bindCart1) if loginId was retrieved successfully
            if (!string.IsNullOrEmpty(loginId))
            {
                bindCart1(loginId);
                bindCart2(loginId);
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;  // Consider logging the full exception details separately for debugging
        }
    }

    protected void bindCart1(string loginId)
    {
        try
        {
            if (!string.IsNullOrEmpty(loginId))  // Check if loginId is valid
            {
                // Query to fetch additional details using the loginId
                string query = "SELECT UpiId, Description,FullName,PhoneNumber, City,Address,Pincode, landmark,Position FROM repurchase_members WHERE loginid = @loginid and RepurchaseNo = @recNo";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@loginid", loginId);  // Pass loginId from the previous method
                    cmd.Parameters.AddWithValue("@recNo", recNo);

                    SqlDataAdapter adptCart = new SqlDataAdapter(cmd);
                    DataSet dsCart = new DataSet();
                    adptCart.Fill(dsCart);

                    if (dsCart.Tables[0].Rows.Count > 0)
                    {
                        GridView2.DataSource = dsCart;
                        GridView2.DataBind();
                        lblmsg.Text = "";
                    }
                    else
                    {
                        GridView2.DataSource = null;
                        GridView2.DataBind();
                        lblmsg.Text = "No details found";
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;  // Consider logging the full exception details separately
        }
    }
    protected void bindCart2(string loginId)
    {
        try
        {
            if (!string.IsNullOrEmpty(loginId))  // Check if loginId is valid
            {
                // Query to fetch additional details using the loginId
                string query = "SELECT RM.ProductCode, P.ProductName, RM.Qty, RM.TotalRV, RM.TotalMRP, P.date, RM.status, RM.TotalCost " +
                               "FROM repurchase_master AS RM " +
                               "INNER JOIN product AS P ON P.ProductCode = RM.ProductCode " +
                               "WHERE RM.loginid = @loginid AND RM.RepurchaseNo = @recNo";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@loginid", loginId);  // Pass loginId from the previous method
                    cmd.Parameters.AddWithValue("@recNo", recNo);

                    SqlDataAdapter adptCart = new SqlDataAdapter(cmd);
                    DataSet dsCart = new DataSet();
                    adptCart.Fill(dsCart);

                    if (dsCart.Tables[0].Rows.Count > 0)
                    {
                        // Variables to store total values
                        decimal totalQty = 0;
                        decimal totalRV = 0;
                        decimal totalMRP = 0;
                        decimal totalCost = 0;

                        // Iterate over each row and sum the required columns
                        foreach (DataRow row in dsCart.Tables[0].Rows)
                        {
                            totalQty += Convert.ToDecimal(row["Qty"]);
                            totalRV += Convert.ToDecimal(row["TotalRV"]);
                            totalMRP += Convert.ToDecimal(row["TotalMRP"]);
                            totalCost += Convert.ToDecimal(row["TotalCost"]);
                        }

                        // Bind GridView
                        GridView3.DataSource = dsCart;
                        GridView3.DataBind();

                        // Display the totals in different div tags
                        divTotalQty.InnerText = " " + totalQty.ToString();
                        divTotalRV.InnerText = " " + totalRV.ToString();  // "C" for currency formatting
                        divTotalMRP.InnerText = " " + totalMRP.ToString();
                        divTotalCost.InnerText = " " + totalCost.ToString();

                        lblmsg.Text = "";  // Clear any previous messages
                    }
                    else
                    {
                        GridView3.DataSource = null;
                        GridView3.DataBind();
                        lblmsg.Text = "No details found";
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;  // Consider logging the full exception details separately
        }
    }


    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //On Mouse Over Highlight Row
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#D5D8DC'");
            //e.Row.Attributes.Add("onmouseover", "this.style.ForeColor='White'");

            //On Mouse out restore default row color
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#DCEDDD'");
        }
    }

}