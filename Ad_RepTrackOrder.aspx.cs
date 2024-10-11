using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Ad_RepTrackOrder : System.Web.UI.Page
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
            if (radSearch.SelectedIndex == 0)
            {
                TdText.Visible = false;
                TdBtn.Visible = false;
                adptCart = new SqlDataAdapter("select Repurchase_Members2.repurchaseNo,Repurchase_Members2.Loginid,Repurchase_Members2.TotQty,Repurchase_Members2.TotRV,Repurchase_Members2.TotPrice,Repurchase_Members2.TotShipping,Repurchase_Members2.TotCost,Repurchase_Members2.status,Repurchase_Members2.OrderDate,Repurchase_Members2.PaymentMode,membermaster.membername from Repurchase_Members2 inner join membermaster on Repurchase_Members2.loginid=membermaster.loginid", con);
            }
            else
            {
                TdBtn.Visible = true;
                TdText.Visible = true;
                adptCart = new SqlDataAdapter("select Repurchase_Members2.repurchaseNo,Repurchase_Members2.Loginid,Repurchase_Members2.TotQty,Repurchase_Members2.TotRV,Repurchase_Members2.TotPrice,Repurchase_Members2.TotShipping,Repurchase_Members2.TotCost,Repurchase_Members2.status,Repurchase_Members2.PaymentMode,Repurchase_Members2.OrderDate,membermaster.membername from Repurchase_Members2 inner join membermaster on Repurchase_Members2.loginid=membermaster.loginid and Repurchase_Members2.repurchaseno='" + txtReceipt.Text + "'", con);
            }
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
                lblmsg.Text = "No orders found";

            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.ToString();
        }
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

            Label stat = (Label)GridView1.SelectedRow.FindControl("Status");
            Label recno = (Label)GridView1.SelectedRow.FindControl("RecNo");
            adptTrack = new SqlDataAdapter("select Repurchase_Members2.repurchaseno,isnull(Repurchase_Members2.CourierName,'---') as CourierName,isnull(convert(varchar,Repurchase_Members2.CourierDate,3),'---') as CourierDate,isnull(Repurchase_Members2.Contact,'---') as Contact,Repurchase_Master2.ProductCode,product.ProductName,Repurchase_Master2.Qty,Repurchase_Master2.TotalRV,(Repurchase_Master2.Qty) * (product.offerprice) as Price,(Repurchase_Master2.Qty) * (product.ShippingCost) as ShippingCost,((Repurchase_Master2.Qty) * (product.ShippingCost)) + ((Repurchase_Master2.Qty) * (product.OfferPrice)) as TotalCost,isnull(convert(varchar,Repurchase_Members2.orderdate,3),'N/A') as orderdate,isnull(convert(varchar,Repurchase_Members2.shippingdate,3),'N/A') as shippingDate,isnull(convert(varchar,Repurchase_Members2.DeliveredDate,3),'N/A') as DeliveredDate,Repurchase_Members2.status from Repurchase_Master2 inner join product on Repurchase_Master2.productcode=product.productcode and Repurchase_Master2.repurchaseno='" + recno.Text + "' inner join Repurchase_Members2 on Repurchase_Members2.repurchaseno=Repurchase_Master2.RepurchaseNo", con);
            adptTrack.Fill(dsTrack);
            if (dsTrack.Tables[0].Rows.Count > 0)
            {
                GridView2.DataSource = dsTrack;
                GridView2.DataBind();
                lblStatus.Text = "";

                //=================================================//

                CourierName.Text = Convert.ToString(dsTrack.Tables[0].Rows[0]["CourierName"]);
                CourierDate.Text = Convert.ToString(dsTrack.Tables[0].Rows[0]["CourierDate"]);
                Contact.Text = Convert.ToString(dsTrack.Tables[0].Rows[0]["Contact"]);

                //=================================================//

                trSts.Visible = true;

                if (stat.Text == "Ordered")
                {
                    txtordered.BackColor = System.Drawing.Color.Red;
                    txtshipped.BackColor = System.Drawing.Color.White;
                    txtDelivered.BackColor = System.Drawing.Color.White;
                    lblStatus.Text = "Your order in Ordered Mode";
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                }
                else if (stat.Text == "Shipped")
                {
                    txtordered.BackColor = System.Drawing.Color.Blue;
                    txtshipped.BackColor = System.Drawing.Color.Blue;
                    txtDelivered.BackColor = System.Drawing.Color.White;
                    lblStatus.Text = "Your order in Shipping Mode";
                    lblStatus.ForeColor = System.Drawing.Color.Blue;
                }
                else if (stat.Text == "Delivered")
                {
                    txtordered.BackColor = System.Drawing.Color.Green;
                    txtshipped.BackColor = System.Drawing.Color.Green;
                    txtDelivered.BackColor = System.Drawing.Color.Green;
                    lblStatus.Text = "Your order in Delivered Mode";
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                trSts.Visible = false;
                lblStatus.Text = "No products ordered";

            }



            mpe.Show();
        }

        catch (Exception ex)
        {
            lblmsg.Text = ex.ToString();
        }
    }

    protected void radSearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (radSearch.SelectedIndex == 1)
        {
            txtReceipt.Text = "";
        }
        bindCart();

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        bindCart();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            Label pstat = (Label)GridView1.Rows[e.RowIndex].FindControl("Status");
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

                btnCancel.Enabled = true;
                txtReason.Visible = true;
                btnCancel.Text = "Submit";
                Button1.Text = "Cancel";
            }
            else
            {
                Label5.Text = "Order Cancellation Request Denied";
                btnCancel.Enabled = false;
                txtReason.Visible = false;
                btnCancel.Text = "Yes";
                Button1.Text = "No";
            }
            mpExtra.Show();
        }
        catch (Exception ex)
        {
            btnCancel.Enabled = false;
            Label5.Text = ex.ToString();
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter adpt = new SqlDataAdapter();
            DataSet ds = new DataSet();

            if (stat.Text == "Ordered")
            {
                Label5.Text = "";
                btnCancel.Enabled = true;

                adpt = new SqlDataAdapter("select * from repurchase_master2 where repurchaseno='" + recno.Text + "'", con);
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

                        cmd = new SqlCommand("update repurchase_master2 set status='Cancelled' where productcode='" + PrCode + "' and repurchaseno='" + recno.Text + "'", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }

                    cmd = new SqlCommand("update repurchase_members2 set status='Cancelled',Reason='" + txtReason.Text + "' where repurchaseno='" + recno.Text + "'", con);
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
                btnCancel.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            btnCancel.Enabled = false;
            Label5.Text = ex.ToString();
        }
    }
}