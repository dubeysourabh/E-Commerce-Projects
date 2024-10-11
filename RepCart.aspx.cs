using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;

public partial class Agent_RepCart : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
    string logId, mob;
    SqlDataAdapter adptCart = new SqlDataAdapter();
    DataSet dsCart = new DataSet();
    SqlCommand cmdMob = new SqlCommand();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["ALog"] == null)
        {
            lblmsg.Text = "Session Expired!!! Please login again...";
        }
        //if (Session["user_id"] == null)
        //{
        //    lblmsg.Text = "Session Expired!!! Please login again...";
        //}
        else
        {
            logId = Convert.ToString(Request.Cookies["ALog"].Value);
            //logId = Session["user_id"].ToString();
            if (!Page.IsPostBack)
            {

                //   bool isRepurchase = CheckRepurchaseNoInDatabase();

                bindCart();

                //string loginId = logId; 
                //string pstatus = CheckLoginIdExists(loginId);

                //if (pstatus == "green")
                //{
                //    // Show and enable the dropdown
                //    DropDownList2.Visible = true;
                //    DropDownList2.Enabled = true;
                //}
                //else
                //{
                //    // Hide or disable the dropdown
                //    DropDownList2.Visible = false;
                //    DropDownList2.Enabled = false;
                //}
            }
            if (ddPayment.SelectedIndex == 0)
            {
                Label2.Text = "Select payment mode";
                btnSubmit.Enabled = false;
            }
            else
            {
                Label2.Text = "";
                btnSubmit.Enabled = true;
            }
        }
    }
    protected void bindCart()
    {
        adptCart = new SqlDataAdapter("select Repurchase_Master2.ProductCode,product.ProductName,product.Img1,Repurchase_Master2.Qty,(Repurchase_Master2.Qty) * (product.productrv) as TotalRV,(Repurchase_Master2.Qty) * (product.offerprice) as Price,(Repurchase_Master2.Qty) * (product.ShippingCost) as ShippingCost,((Repurchase_Master2.Qty) * (product.ShippingCost)) + ((Repurchase_Master2.Qty) * (product.OfferPrice)) as TotalCost from Repurchase_Master2 inner join product on Repurchase_Master2.productcode=product.productcode and Repurchase_Master2.loginid='" + logId + "' and repurchase_master2.status='unpaid'", con);
        adptCart.Fill(dsCart);
        if (dsCart.Tables[0].Rows.Count > 0)
        {
            GridView1.DataSource = dsCart;
            GridView1.DataBind();
            btnSubmit.Enabled = true;
            lblmsg.Text = "";
        }
        else
        {
            GridView1.DataSource = dsCart;
            GridView1.DataBind();
            btnSubmit.Enabled = false;
            lblmsg.Text = "No product ordered";
            //dsCart.Tables[0].Rows.Add(dsCart.Tables[0].NewRow());
            //GridView1.DataSource = dsCart;
            //GridView1.DataBind();
            //int columncount = GridView1.Rows[0].Cells.Count;
            //GridView1.Rows[0].Cells.Clear();
            //GridView1.Rows[0].Cells.Add(new TableCell());
            ////GridView1.Rows[0].Cells[0].ColumnSpan = columncount;
            ////GridView1.Rows[0].Cells[0].Text = "No Products Ordered";

        }
    }
    protected string GetImageUrl1(object imagePath)
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
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Label prCode = (Label)GridView1.Rows[e.RowIndex].FindControl("PrCode");
        Label Qty = (Label)GridView1.Rows[e.RowIndex].FindControl("Quantity");

        SqlCommand cmd = new SqlCommand("update product set quantity=quantity + @qty where productcode='" + prCode.Text + "'", con);
        cmd.Parameters.AddWithValue("@qty", Qty.Text);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

        cmd = new SqlCommand("delete from repurchase_master2 where loginid='" + logId + "' and productcode='" + prCode.Text + "' and status='unpaid'", con);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

        bindCart();
        //Response.Redirect("Cart.aspx",false);
    }

    double qty = 0, rv = 0, price = 0, shipping = 0, final = 0;
    double totqty = 0, totrv = 0, totprice = 0, totshipping = 0, totfinal = 0;
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
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
            e.Row.Cells[4].Text = totqty.ToString();
            e.Row.Cells[5].Text = totrv.ToString();
            e.Row.Cells[6].Text = totprice.ToString();
            e.Row.Cells[7].Text = totshipping.ToString();
            e.Row.Cells[8].Text = totfinal.ToString();
            lblTotal.Text = Convert.ToString(totfinal);
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        double balance = 0;
        SqlCommand cmd = new SqlCommand();
        if (GridView1.Rows.Count > 0)
        {
            cmd = new SqlCommand("select isnull(GrandTotal,0) from topwallet where loginid='" + logId + "'", con);
            con.Open();
            balance = Convert.ToDouble(cmd.ExecuteScalar());
            con.Close();
            if (Convert.ToDouble(lblTotal.Text) > balance && ddPayment.SelectedItem.Text == "Ewallet")
            {
                lblmsg.Text = "You don't have sufficient balance.Please remove some product from cart.";
            }
            else
            {
                //if (ddPayment.SelectedItem.Text == "Ewallet" && Convert.ToDouble(lblTotal.Text) > balance)

                lblmsg.Text = "";
                totqty = totrv = totprice = totshipping = totfinal = 0;

                string RepurchaseNo = Convert.ToString(GenerateCode());
                Boolean a = checkReceipt(RepurchaseNo);
                while (a == false)
                {
                    RepurchaseNo = GenerateCode();
                    a = checkReceipt(RepurchaseNo);
                }

                RepurchaseNo = Convert.ToString(RepurchaseNo);

                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    Label prCode = (Label)GridView1.Rows[i].FindControl("PrCode");
                    Label Quantity = (Label)GridView1.Rows[i].FindControl("Quantity");
                    Label TotalRV = (Label)GridView1.Rows[i].FindControl("TotalRV");
                    Label TPrice = (Label)GridView1.Rows[i].FindControl("Price");
                    Label ShippingCost = (Label)GridView1.Rows[i].FindControl("ShippingCost");
                    Label TotalCost = (Label)GridView1.Rows[i].FindControl("TotalCost");

                    //   Label txtPaymentDetails = (Label)GridView1.Rows[i].FindControl("txtPaymentDetails");

                    cmd = new SqlCommand("update repurchase_master2 set RepurchaseNo=@RepurchaseNo,TotalRV=@TotalRV,TotalMRP=@TotalMRP,ShippingCost=@ShippingCost,TotalCost=@TotalCost,status=@status where loginid=@loginid and status='unpaid' and productcode=@productcode", con);
                    cmd.Parameters.AddWithValue("@loginid", logId);
                    cmd.Parameters.AddWithValue("@productcode", prCode.Text);
                    cmd.Parameters.AddWithValue("@RepurchaseNo", RepurchaseNo);
                    cmd.Parameters.AddWithValue("@TotalRV", TotalRV.Text);
                    cmd.Parameters.AddWithValue("@TotalMRP", TPrice.Text);
                    cmd.Parameters.AddWithValue("@ShippingCost", ShippingCost.Text);
                    cmd.Parameters.AddWithValue("@TotalCost", TotalCost.Text);
                    cmd.Parameters.AddWithValue("@status", "Ordered");
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    totqty = totqty + Convert.ToInt32(Quantity.Text);
                    totrv = totrv + Convert.ToInt32(TotalRV.Text);
                    totprice = totprice + Convert.ToInt32(TPrice.Text);
                    totshipping = totshipping + Convert.ToInt32(ShippingCost.Text);
                    totfinal = totfinal + Convert.ToInt32(TotalCost.Text);
                    //   Payment  = Payment + Convert.ToInt32(txtPaymentDetails.Text);
                }
                if (fileUploadReceipt.HasFile)
                {
                    // Get the uploaded file
                    HttpPostedFile uploadedFile = fileUploadReceipt.PostedFile;

                    // Get the file name and define the path where it should be saved
                    string fileName = Path.GetFileName(uploadedFile.FileName);
                    string folderPath = Server.MapPath("~/CompanyImg/");

                    // Create the folder if it doesn't exist
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    // Save the uploaded file to the folder
                    string filePath = folderPath + fileName;
                    fileUploadReceipt.SaveAs(filePath);

                    // Store the relative path (not the absolute path) to the database
                    string relativeFilePath = "~/CompanyImg/" + fileName;

                    // Prepare the SQL command to insert the record, including the file path
                    cmd = new SqlCommand("INSERT INTO repurchase_members2(RepurchaseNo, LoginId, TotQty, TotRV, TotPrice, TotShipping, TotCost, status, OrderDate, PaymentMode, UpiId, Description, Uploadimg, FullName, PhoneNumber, City, Address, Pincode, LandMark, Position) " +
                                         "VALUES (@RepurchaseNo, @LoginId, @TotQty, @TotRV, @TotPrice, @TotShipping, @TotCost, @status, @OrderDate, @PaymentMode, @UpiId, @Description, @Uploadimg, @FullName, @PhoneNumber, @City, @Address, @Pincode, @LandMark, @Position)", con);

                    // Add parameters for the SQL query
                    cmd.Parameters.AddWithValue("@RepurchaseNo", RepurchaseNo);
                    cmd.Parameters.AddWithValue("@LoginId", logId);
                    cmd.Parameters.AddWithValue("@TotQty", totqty);
                    cmd.Parameters.AddWithValue("@TotRV", totrv);
                    cmd.Parameters.AddWithValue("@TotPrice", totprice);
                    cmd.Parameters.AddWithValue("@TotShipping", totshipping);
                    cmd.Parameters.AddWithValue("@TotCost", totfinal);
                    cmd.Parameters.AddWithValue("@status", "Ordered");
                    cmd.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@PaymentMode", ddPayment.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@UpiId", txtPaymentDetails.Text);
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                    cmd.Parameters.AddWithValue("@Uploadimg", relativeFilePath); // Store file path instead of byte array
                    cmd.Parameters.AddWithValue("@FullName", txtName.Text);
                    cmd.Parameters.AddWithValue("@PhoneNumber", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@City", txtCity.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@Pincode", txtZip.Text);
                    cmd.Parameters.AddWithValue("@LandMark", txtLandmark.Text);
                    cmd.Parameters.AddWithValue("@Position", DropDownList2.SelectedValue);

                    // Execute the SQL command
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    lblUploadMessage.Text = "File uploaded successfully!";
                }
                else
                {
                    lblUploadMessage.Text = "Please upload a file!";
                }


                if (ddPayment.SelectedItem.Text == "Ewallet")
                {
                    //cmd = new SqlCommand("update topwallet set grandtotal=@grandTotal-@Amt where loginid=@loginid", con);
                    //cmd.Parameters.AddWithValue("@loginid", logId);
                    //cmd.Parameters.AddWithValue("@grandTotal", balance);
                    //cmd.Parameters.AddWithValue("@Amt", totfinal);
                    //con.Open();
                    //cmd.ExecuteNonQuery();

                    //SqlCommand cmdEwalletMasterAmt = new SqlCommand();
                    //cmdEwalletMasterAmt.CommandText = "INSERT INTO topwalletMaster (loginid, DebitAmt, CreditAmt, balance, Remark, Edate) " +
                    //                                  "VALUES (@loginid, @Amt, 0, @grandTotal,'Self Purchase', GETDATE())";
                    //cmdEwalletMasterAmt.CommandType = CommandType.Text;
                    //cmdEwalletMasterAmt.Connection = con;
                    //cmdEwalletMasterAmt.Parameters.AddWithValue("@loginid", logId);
                    //cmdEwalletMasterAmt.Parameters.AddWithValue("@Amt", totfinal);
                    //cmdEwalletMasterAmt.Parameters.AddWithValue("@grandTotal", balance - totfinal); // Update the balance after deduction
                    //{
                    //    // Execute the second command
                    //    cmdEwalletMasterAmt.ExecuteNonQuery();



                    // Retrieve sidee from findamaster
                    // con.Open();
                    // SqlCommand cmds = new SqlCommand("SELECT sidee FROM findamaster WHERE loginid = @loginid", con);
                    // cmds.Parameters.AddWithValue("@loginid", logId);
                    //db.SetTimeOut(cmds);

                    // string sides = Convert.ToString(cmds.ExecuteScalar());

                    // Third command: Execute the stored procedure InsertRegiact
                    //SqlCommand cmd_run = new SqlCommand("InsertRegiact", con);
                    // cmd_run.CommandType = CommandType.StoredProcedure;
                    //db.SetTimeOut(cmd_run);

                    //    cmd_run.Parameters.AddWithValue("@abc", logId);
                    //    cmd_run.Parameters.AddWithValue("@abccr", 0);
                    //    cmd_run.Parameters.AddWithValue("@abccl", 0);
                    //    cmd_run.Parameters.AddWithValue("@abposi", sides);
                    //    cmd_run.Parameters.AddWithValue("@loginid", logId);
                    //    cmd_run.Parameters.AddWithValue("@intro", "0");
                    //    cmd_run.Parameters.AddWithValue("@sponcer", "0");
                    //    cmd_run.Parameters.AddWithValue("@date1", DateTime.Now);
                    //    cmd_run.Parameters.AddWithValue("@pt", Convert.ToDouble(totprice));
                    //    cmd_run.Parameters.AddWithValue("@PV", Convert.ToDouble(totrv));
                    //    cmd_run.Parameters.AddWithValue("@pinname", "Repurchase");
                    //    cmd_run.Parameters.AddWithValue("@topupBy", logId);
                    //    cmd_run.Parameters.AddWithValue("@PSType", "Daily Profit Sharing");

                    //    // Execute the stored procedure
                    //    cmd_run.ExecuteNonQuery();

                    //    con.Close();
                }

                else if (ddPayment.SelectedItem.Text == "Cash On Delivery")
                { }
                else
                { }


                cmdMob = new SqlCommand("select isnull(mobile,'1234567890') as mobile from membermaster where loginid='" + logId + "'", con);
                con.Open();
                mob = Convert.ToString(cmdMob.ExecuteScalar());
                con.Close();

                string msg = "Dear user, thank you for shopping. Your shopping receipt number is : " + RepurchaseNo + ". Please track order from your account.";
                MyFunction fn = new MyFunction();
                fn.sms103(mob, msg);

                bindCart();
                lblmsg.Text = "Your order has been successfully processed";
                btnSubmit.Enabled = false;

                //bindCart();
                Response.Redirect("RepTrackOrder.aspx", false);
            }
        }
        else
        {

        }
    }


    protected Boolean checkReceipt(string logids)
    {
        SqlCommand cmd = new SqlCommand("select count(*) from repurchase_members2 where repurchaseno='" + logids + "'", con);
        con.Open();
        int cnt = Convert.ToInt32(cmd.ExecuteScalar());
        con.Close();
        if (cnt > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    protected string GenerateCode()
    {
        string pwdCode = "";
        StringBuilder allowableChars = new StringBuilder("456789");
        Random randomNum = new Random();

        int i = 0, rand = 6;

        for (i = 0; i < 6; i++)
        {
            rand = randomNum.Next(0, 6);
            pwdCode += allowableChars[rand];
        }
        return (pwdCode);
    }
    protected void ddPayment_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Show the QR code and description if UPI Payment is selected
        if (ddPayment.SelectedValue == "UPI Payment")
        {

            pnlUPI.Visible = true;
        }
        else
        {
            pnlUPI.Visible = false;
        }
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        // Hide the payment panel and show the shipping panel
        pnlUPI.Visible = false;
        // pnlShipping.Visible = true;
    }
    //private string CheckLoginIdExists(string loginId)
    //{
    //    string pstatus = string.Empty;
    //    // SQL query to check if pstatus is present for the given LoginId
    //    SqlCommand cmd = new SqlCommand("SELECT pstatus FROM findamaster2 WHERE LoginId = @LoginId", con);

    //    cmd.Parameters.AddWithValue("@LoginId", loginId); // Adding LoginId as a parameter
    //    con.Open();

    //    object result = cmd.ExecuteScalar(); // Get the pstatus value (or null if not found)
    //    con.Close();
    //    if (result != null)
    //    {
    //        pstatus = result.ToString(); // Get the pstatus as string
    //    }
    //    return pstatus; // Returns true if pstatus is found (LoginId exists)
    //}
}