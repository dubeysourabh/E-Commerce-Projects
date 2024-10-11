using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Ad_RepOrderdProducts : System.Web.UI.Page
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
            adptCart = new SqlDataAdapter("select Repurchase_Members2.repurchaseNo,Repurchase_Members2.Status,Repurchase_Members2.Loginid,Repurchase_Members2.UPiId,Repurchase_Members2.Description,Repurchase_Members2.Uploadimg,Repurchase_Members2.PaymentMode," +
                "Repurchase_Members2.TotQty,Repurchase_Members2.TotRV,Repurchase_Members2.TotPrice,Repurchase_Members2." +
                "TotShipping,Repurchase_Members2.TotCost,Repurchase_Members2.OrderDate,membermaster.membername from " +
                "Repurchase_Members2 inner join membermaster on Repurchase_Members2.loginid=membermaster.loginid and " +
                "Repurchase_Members2.Status='Ordered'", con);
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

    protected void GridView1_RowCreated1(object sender, GridViewRowEventArgs e)
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

    double qty = 0, rv = 0, price = 0, shipping = 0, final = 0;
    double totqty = 0, totrv = 0, totprice = 0, totshipping = 0, totfinal = 0;

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            GridViewRow GridView1 = e.Row;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                qty = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Qty"));
                rv = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalRV"));
                price = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Price"));
                shipping = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ShippingCost"));
                final = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalCost"));

                totqty = totqty + qty;
                totrv = totrv + rv;
                totprice = totprice + price;
                totshipping = totshipping + shipping;
                totfinal = totfinal + final;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[3].Text = totqty.ToString();
                e.Row.Cells[4].Text = totrv.ToString();
                e.Row.Cells[5].Text = totprice.ToString();
                e.Row.Cells[6].Text = totshipping.ToString();
                e.Row.Cells[7].Text = totfinal.ToString();
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.ToString();
        }
    }



    protected void OnSelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            SqlDataAdapter adptTrack = new SqlDataAdapter();
            DataSet dsTrack = new DataSet();

            Label recno = (Label)GridView1.SelectedRow.FindControl("RecNo");
            adptTrack = new SqlDataAdapter("select repurchase_members2.repurchaseno,Repurchase_Master2.ProductCode,product.ProductName,Repurchase_Master2.Qty,Repurchase_Master2.TotalRV,(Repurchase_Master2.Qty) * (product.offerprice) as Price,(Repurchase_Master2.Qty) * (product.ShippingCost) as ShippingCost,((Repurchase_Master2.Qty) * (product.ShippingCost)) + ((Repurchase_Master2.Qty) * (product.OfferPrice)) as TotalCost,isnull(convert(varchar,Repurchase_Members2.orderdate,3),'N/A') as orderdate,isnull(convert(varchar,Repurchase_Members2.shippingdate,3),'N/A') as shippingDate,isnull(convert(varchar,Repurchase_Members2.DeliveredDate,3),'N/A') as DeliveredDate,Repurchase_Members2.status from Repurchase_Master2 inner join product on Repurchase_Master2.productcode=product.productcode and Repurchase_Master2.repurchaseno='" + recno.Text + "' and Repurchase_Master2.status='Ordered' inner join Repurchase_Members2 on Repurchase_Members2.repurchaseno=Repurchase_Master2.RepurchaseNo", con);
            adptTrack.Fill(dsTrack);
            if (dsTrack.Tables[0].Rows.Count > 0)
            {
                GridView2.DataSource = dsTrack;
                GridView2.DataBind();
                lblStatus.Text = "";
            }
            else
            {
                lblStatus.Text = "No Orders Found";
            }

            mpe.Show();
        }

        catch (Exception ex)
        {
            lblmsg.Text = ex.ToString();
        }
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            Label recno = (Label)GridView1.Rows[e.RowIndex].FindControl("RecNo");
            //TextBox recno1 = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtPaymentDetails");
            Label r = (Label)GridView1.Rows[e.RowIndex].FindControl("LoginId");


            ReceiptNo.Text = recno.Text;
            //txtPaymentDetails.Text = recno1.Text;


            SqlCommand cmd = new SqlCommand("SELECT TotRV,Totprice, LoginId, UpiId, Description,FullName,PhoneNumber, City,Address,Pincode, landmark,Position FROM Repurchase_Members2 WHERE  RepurchaseNo = @ReceiptNo", con);
            cmd.Parameters.AddWithValue("@ReceiptNo", ReceiptNo.Text);

            con.Open();
            // Assuming txtName is a DropDownList
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read()) // If data is found for the given ReceiptNo
            {
                // Assign data to respective controls
                txtLoginId.Text = reader["LoginId"].ToString();
                txtTotalRV.Text = reader["TotRV"].ToString();
                //txtPrice.Text = reader["Totprice"].ToString();
                txtPaymentDetails.Text = reader["UpiId"].ToString();
                txtDescription.Text = reader["Description"].ToString();
                txtName.Text = reader["FullName"].ToString();
                txtPhoneNumber.Text = reader["PhoneNumber"].ToString();
                txtCity.Text = reader["City"].ToString();
                txtAddress.Text = reader["Address"].ToString();
                txtZip.Text = reader["Pincode"].ToString();
                txtLandmark.Text = reader["Landmark"].ToString();
                ibltotprce.Text = reader["Totprice"].ToString();

                // If Position is a dropdown, you can select the correct value
                lblPosition.Text = reader["Position"].ToString();
            }
            con.Close();
            // Show modal popup
            mpeCourier.Show();
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.ToString();
        }
    }

    //   using (SqlCommand cmd = new SqlCommand("SELECT FullName FROM Repurchase_Members2 WHERE repurchaseNo = @ReceiptNo", con))
    //{
    //    cmd.Parameters.AddWithValue("@ReceiptNo", ReceiptNo);
    //    con.Open();
    //    custname.Text = Convert.ToString(cmd.ExecuteScalar());
    //    con.Close();
    //}

    protected void btnApprove_Click(object sender, EventArgs e)
    {
        try
        {
            //if (DateTime.Now > Convert.ToDateTime(txtDate.Text))
            if (DateTime.Now.Date > DateTime.ParseExact(txtDate.Text, "MM/dd/yyyy", null))
            {
                mpeCourier.Show();
                lblError.Text = "*";
                lblmsg.Text = "";
            }
            else
            {
                SqlCommand cmd = new SqlCommand("update Repurchase_Members2 set status=@status,ShippingDate=@ShippingDate,CourierName=@CourierName,CourierDate=@CourierDate,Contact=@Contact where RepurchaseNo=@RepurchaseNo", con);
                cmd.Parameters.AddWithValue("@RepurchaseNo", ReceiptNo.Text);
                cmd.Parameters.AddWithValue("@ShippingDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@status", "Shipped");
                cmd.Parameters.AddWithValue("@CourierName", txtCName.Text);
                cmd.Parameters.AddWithValue("@CourierDate", txtDate.Text);
                cmd.Parameters.AddWithValue("@Contact", txtContact.Text);

                con.Open();

                cmd.ExecuteNonQuery();

                string logId = txtLoginId.Text;
                string fullName = txtName.Text;
                string Position = lblPosition.Text;
                string Totprice = ibltotprce.Text;
                string totalRV = txtTotalRV.Text;

                // Create and execute the stored procedure command
                SqlCommand cmd_run = new SqlCommand("RepInsertRegiact", con);
                cmd_run.CommandType = CommandType.StoredProcedure;

                // Add parameters for the stored procedure
                cmd_run.Parameters.AddWithValue("@abc", logId);  // Replace 'valueForAbc' with the actual value
                cmd_run.Parameters.AddWithValue("@abccr", 0);
                cmd_run.Parameters.AddWithValue("@abccl", 0);
                cmd_run.Parameters.AddWithValue("@abposi", Position);  // Replace 'valueForAbposi' with the actual value
                cmd_run.Parameters.AddWithValue("@loginid", logId);
                cmd_run.Parameters.AddWithValue("@intro", "0");
                cmd_run.Parameters.AddWithValue("@sponcer", "0");
                cmd_run.Parameters.AddWithValue("@date1", DateTime.Now);

                //cmd_run.Parameters.AddWithValue("@pt", Convert.ToDouble(ibltotprce));
                //cmd_run.Parameters.AddWithValue("@PV", Convert.ToDouble(txtTotalRV));

                cmd_run.Parameters.AddWithValue("@pt", Totprice);
                cmd_run.Parameters.AddWithValue("@PV", totalRV);

                cmd_run.Parameters.AddWithValue("@pinname", "Repurchase");
                cmd_run.Parameters.AddWithValue("@topupBy", logId);
                cmd_run.Parameters.AddWithValue("@PSType", "Daily Profit Sharing");


                //cmd_run.Parameters.AddWithValue("@abc", uid);
                //cmd_run.Parameters.AddWithValue("@abccr", 0);
                //cmd_run.Parameters.AddWithValue("@abccl", 0);
                //cmd_run.Parameters.AddWithValue("@abposi", sides);
                //cmd_run.Parameters.AddWithValue("@loginid", uid);
                //cmd_run.Parameters.AddWithValue("@intro", "0");
                //cmd_run.Parameters.AddWithValue("@sponcer", "0");
                //cmd_run.Parameters.AddWithValue("@date1", DateTime.Now);
                //cmd_run.Parameters.AddWithValue("@pt", Convert.ToDouble(Totprice);
                //cmd_run.Parameters.AddWithValue("@pinname", lblPinname.Text);
                //cmd_run.Parameters.AddWithValue("@topupBy", newLoginId);







                cmd_run.ExecuteNonQuery();


                // Execute the stored procedure


                SqlCommand cmd_master = new SqlCommand("update Repurchase_Master2 set status=@status where RepurchaseNo=@RepurchaseNo", con);
                cmd_master.Parameters.AddWithValue("@RepurchaseNo", ReceiptNo.Text);
                cmd_master.Parameters.AddWithValue("@status", "Shipped");
                cmd_master.ExecuteNonQuery();


                SqlCommand cmdMob = new SqlCommand("select isnull(mobile, '1234567890') as mobile from membermaster where loginid=@loginid", con);
                cmdMob.Parameters.AddWithValue("@loginid", txtLoginId.Text);
                string mob = Convert.ToString(cmdMob.ExecuteScalar());
                cmdMob.ExecuteNonQuery();

                con.Close();
                string msg = "Dear user, your order (Receipt No. : " + ReceiptNo.Text + ") has been successfully shipped through " + txtCName.Text + ". Please contact " + txtContact.Text + " for delivery details.";
                MyFunction fn = new MyFunction();
                fn.sms103(mob, msg);

                bindCart();
                lblmsg.Text = "Order has been successfully shipped";
            }
        }
        catch (Exception ex)
        {
            mpeCourier.Show();
            lblCourier.Text = ex.ToString();
        }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            Label pstat = (Label)GridView1.Rows[e.RowIndex].FindControl("textStatus");
            Label precno = (Label)GridView1.Rows[e.RowIndex].FindControl("RecNo");
            Label pTotalCost = (Label)GridView1.Rows[e.RowIndex].FindControl("TotalCost");
            Label pLogId = (Label)GridView1.Rows[e.RowIndex].FindControl("LoginID");
            Label pmode = (Label)GridView1.Rows[e.RowIndex].FindControl("Payment");

            stat.Text = pstat.Text;
            recno.Text = precno.Text;
            TotalCost.Text = pTotalCost.Text;
            LogId.Text = pLogId.Text;
            mode.Text = pmode.Text;

            if (stat.Text == "Ordered")
            {
                Label5.Text = "";

                txtbuttun.Enabled = true;
                txtReason.Visible = true;
                txtbuttun.Text = "Submit";
                Button1.Text = "Cancel";
            }
            else
            {
                Label5.Text = "Order Cancellation Request Denied";
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
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter adpt = new SqlDataAdapter();
            DataSet ds = new DataSet();

            if (stat.Text == "Ordered")
            {
                Label5.Text = "";
                txtbuttun.Enabled = true;

                adpt = new SqlDataAdapter("select * from Repurchase_Master2 where repurchaseno='" + recno.Text + "'", con);
                adpt.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        int qty = Convert.ToInt32(ds.Tables[0].Rows[i]["Qty"]);
                        string PrCode = Convert.ToString(ds.Tables[0].Rows[i]["ProductCode"]);

                        cmd = new SqlCommand("update product set quantity=quantity + @qty where productcode='" + PrCode + "'", con);
                        cmd.Parameters.AddWithValue("@qty", qty);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        cmd = new SqlCommand("update Repurchase_Master2 set status='Cancelled' where productcode='" + PrCode + "' and repurchaseno='" + recno.Text + "'", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }

                    cmd = new SqlCommand("update Repurchase_Members2 set status='Cancelled',Reason='" + txtReason.Text + "' where repurchaseno='" + recno.Text + "'", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    if (mode.Text == "Ewallet")
                    {
                        cmd = new SqlCommand("update ewallet set GrandTotal=GrandTotal + @TotalCost where loginid='" + LogId.Text + "'", con);
                        cmd.Parameters.AddWithValue("@TotalCost", TotalCost.Text);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }

                    cmdMob = new SqlCommand("select isnull(mobile,'1234567890') as mobile from membermaster where loginid='" + logId + "'", con);
                    con.Open();
                    mob = Convert.ToString(cmdMob.ExecuteScalar());
                    con.Close();

                    string msg = "Dear user, your order(Receipt No. : " + recno.Text + ") has been successfully cancelled.";
                    MyFunction fn = new MyFunction();
                    fn.sms103(mob, msg);

                    bindCart();
                    lblmsg.Text = "Order has been cancelled successfully";
                }
            }
            else
            {
                Label5.Text = "Order Cancellation Request Denied";
                txtbuttun.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            txtbuttun.Enabled = false;
            Label5.Text = ex.ToString();
        }
    }
}