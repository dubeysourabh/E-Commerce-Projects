<%@ Page Language="C#" MasterPageFile="~/Agent/AgentMasterPage.master" AutoEventWireup="true" CodeFile="RepCart.aspx.cs" Inherits="Agent_RepCart" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="Label1" runat="server" Style="font-weight: 700"></asp:Label>
    <div class="portlet box blue">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-comments"></i>Shopping Cart
            </div>
            <div class="tools">
                <a href="javascript:;" class="collapse"></a><a href="#portlet-config" data-toggle="modal"
                    class="config"></a><a href="javascript:;" class="reload"></a><a href="javascript:;"
                        class="remove"></a>

            </div>
        </div>
        <div class="portlet-body">
            <div class="table-responsive" style="width: 100%; margin-left: -0.8%">
                <table class="table table-bordered table-hover">
                    <tbody>

                        <tr>
                            <td align="center" colspan="4">
                                <asp:Label ID="lblmsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="Grid"
                                    BorderColor="#DCEDDD" HeaderStyle-BackColor="#D5D8DC" HeaderStyle-HorizontalAlign="Center"
                                    HeaderStyle-VerticalAlign="Middle" HeaderStyle-ForeColor="black" HeaderStyle-Height="35" UseAccessibleHeader="false"
                                    CellPadding="3" PageSize="30" Width="100%" OnRowCreated="GridView1_RowCreated1" ShowFooter="true"
                                    OnRowDeleting="GridView1_RowDeleting"
                                    OnRowDataBound="GridView1_RowDataBound">
                                    <RowStyle Font-Size="11px" ForeColor="Black" Height="25px" HorizontalAlign="Center" Font-Bold="true" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr. No" FooterText="Total :">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Product Code">
                                            <ItemTemplate>
                                                <asp:Label ID="PrCode" runat="server" Text='<%# Eval("ProductCode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText=" Product Image">
                                            <ItemTemplate>
                                                <!-- Dynamically bind the image URL -->
                                                <asp:Image ID="Img1" runat="server"
                                                    ImageUrl='<%# GetImageUrl1(Eval("Img1")) %>'
                                                    Width="100px" Height="100px" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Name">
                                            <ItemTemplate>
                                                <asp:Label ID="Name" runat="server" Text='<%# Eval("ProductName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Quantity">
                                            <ItemTemplate>
                                                <asp:Label ID="Quantity" runat="server" Text='<%# Eval("Qty") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total PV">
                                            <ItemTemplate>
                                                <asp:Label ID="TotalRV" runat="server" Text='<%# Eval("TotalRV") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Price">
                                            <ItemTemplate>
                                                <asp:Label ID="Price" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Shipping Price">
                                            <ItemTemplate>
                                                <asp:Label ID="ShippingCost" runat="server" Text='<%# Eval("ShippingCost") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total Price">
                                            <ItemTemplate>
                                                <asp:Label ID="TotalCost" runat="server" Text='<%# Eval("TotalCost") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CommandName="Delete" OnClientClick="if(confirm('Do you want to remove product from cart ?')) return true; else return false;"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" Font-Bold="true" HorizontalAlign="Center" />
                                    <PagerStyle BackColor="#6D8C8F" ForeColor="White" HorizontalAlign="Center" />
                                    <SelectedRowStyle Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle HorizontalAlign="Center" Font-Bold="true" />
                                </asp:GridView>
                            </td>
                        </tr>

                    </tbody>
                </table>


                <table class="table table-bordered table-hover">
                    <tr class="success">
                        <td style="text-align: center; width: 15%; font-weight: bold;">Payment Mode : 
                        </td>
                        <td style="text-align: center; width: 20%">
                            <asp:DropDownList ID="ddPayment" runat="server" CssClass="form-control" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddPayment_SelectedIndexChanged">
                                <asp:ListItem Selected="True">--- Payment Mode ---</asp:ListItem>
                                <asp:ListItem>Ewallet</asp:ListItem>
                                <asp:ListItem>UPI Payment</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: center; font-weight: bold;">
                            <asp:Label ID="Label2" runat="server" Text="" ForeColor="Red"></asp:Label>
                        </td>
                        <%--<td style="text-align: center; width: 15%; font-weight: bold;">Select Position : 
                        </td>
                        <td style="text-align: center; width: 20%">
                            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                <asp:ListItem Selected="True">--- Select Side ---</asp:ListItem>
                                <asp:ListItem>Left Side</asp:ListItem>
                                <asp:ListItem>Right Side</asp:ListItem>

                            </asp:DropDownList>
                        </td>
                        <td style="text-align: center; font-weight: bold;">
                            <asp:Label ID="LabelMessage" runat="server" CssClass="text-success"></asp:Label>
                        </td>--%>
                    </tr>
                </table>
            </div>
        </div>
    </div>

    <table>
        <!-- QR Code and Description -->
        <asp:Panel ID="pnlUPI" runat="server" Visible="false">

            <div class="row" style="border: 1px solid #b4cef8; margin: 0; padding: 5px;">
                <h4 class="my-3  fw-bold mx-2"><b>&#160;&#160;&#160; <u>Payment Method </u></b></h3>
    <div class="col-sm-6 text-center" style="border-right: 1px solid #b4cef8;">
        <img src="../companyimg/phonepay.png" style="height: 200px; width: 200px" />


        <asp:Label ID="Label3" runat="server" ForeColor="red"><b>!IMPORTANT:</b></asp:Label><br />
        <asp:Label ID="Label4" runat="server" ForeColor="black">
            <b>*Send only By Phone Pay and Google Pay</b><br />
        </asp:Label>

    </div>
                    <div class="col-sm-6">
                        <!-- Payment Details Input -->
                        <div style="margin-top: 10px;">
                            <label for="txtPaymentDetails">Payment Details (UPI Transaction ID):</label><br />
                            <asp:TextBox ID="txtPaymentDetails" runat="server" CssClass="form-control" Placeholder="Enter your UPI Transaction ID"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvPaymentDetails" runat="server" ControlToValidate="txtPaymentDetails"
                                ErrorMessage="Payment Details are required" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>

                        <!-- Description Input -->
                        <div style="margin-top: 10px;">
                            <label for="txtDescription">Description:</label><br />
                            <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" Placeholder="Enter your Description"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ControlToValidate="txtDescription"
                                ErrorMessage="Description is required" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>

                        <!-- Image Upload -->
                        <div style="margin-top: 10px;">
                            <label for="fileUploadReceipt">Upload Payment Receipt:</label><br />
                            <asp:FileUpload ID="fileUploadReceipt" runat="server" CssClass="form-control" />
                            <asp:RequiredFieldValidator ID="rfvReceipt" runat="server" ControlToValidate="fileUploadReceipt"
                                ErrorMessage="Payment receipt is required" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:Label ID="lblUploadMessage" runat="server" ForeColor="Red"></asp:Label>
                        </div>

                        <!-- Position Dropdown -->
                        <div style="margin-top: 10px;">
                            <label for="Position">Position</label><br />
                            <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control" Width="514px" AutoPostBack="true">
                                <asp:ListItem Selected="True" Value="">Select Position</asp:ListItem>
                                <asp:ListItem Value="LeftSide">LeftSide</asp:ListItem>
                                <asp:ListItem Value="RightSide">RightSide</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvPosition" runat="server" ControlToValidate="DropDownList2"
                                InitialValue="" ErrorMessage="Please select a position" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
            </div>
            <br />

            <div class="row" style="border: 1px solid #b4cef8; margin: 0; padding: 5px;">
                <h4 class="my-3  fw-bold mx-2"><b>&#160;&#160;&#160; <u>Shipping Address </u></b></h3>
   <div class="col-sm-6" style="border-right: 1px solid #b4cef8;">
       <!-- Full Name Input -->
       <div class="col-ms-12" style="margin-top: 10px;">
           <label for="txtName">Full Name:</label><br />
           <asp:TextBox ID="txtName" runat="server" CssClass="form-control" Placeholder="Enter your full name"></asp:TextBox>
           <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
               ErrorMessage="Full Name is required" ForeColor="Red"></asp:RequiredFieldValidator>
       </div>

       <!-- City Input -->
       <div class="col-ms-12" style="margin-top: 10px;">
           <label for="txtCity">City:</label><br />
           <asp:TextBox ID="txtCity" runat="server" CssClass="form-control" Placeholder="Enter your city"></asp:TextBox>
           <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="txtCity"
               ErrorMessage="City is required" ForeColor="Red"></asp:RequiredFieldValidator>
       </div>

       <!-- Address Input -->
       <div class="col-ms-12" style="margin-top: 10px;">
           <label for="txtAddress">Address:</label><br />
           <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"
               Placeholder="Enter your address"></asp:TextBox>
           <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress"
               ErrorMessage="Address is required" ForeColor="Red"></asp:RequiredFieldValidator>
       </div>
   </div>
                    <div class="col-sm-6">
                        <!-- Phone Number Input -->
                        <div class="col-ms-12" style="margin-top: 10px;">
                            <label for="txtPhone">Phone Number:</label><br />
                            <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" Placeholder="Enter your phone number"></asp:TextBox>
                            <!-- Required Field Validator -->
                            <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ControlToValidate="txtPhone"
                                ErrorMessage="Phone Number is required" ForeColor="Red"></asp:RequiredFieldValidator>
                            <!-- Regular Expression Validator for Phone Number Format (10 digits) -->
                            <asp:RegularExpressionValidator ID="revPhone" runat="server" ControlToValidate="txtPhone"
                                ValidationExpression="^\d{10}$" ErrorMessage="Phone Number must be 10 digits" ForeColor="Red"></asp:RegularExpressionValidator>
                        </div>

                        <!-- Pin Code Input -->
                        <div class="col-ms-12" style="margin-top: 10px;">
                            <!-- Pin Code Input -->
                            <label for="txtZip">Pin Code:</label><br />
                            <asp:TextBox ID="txtZip" runat="server" CssClass="form-control" Placeholder="Enter your Pin code"></asp:TextBox>
                            <!-- Required Field Validator -->
                            <asp:RequiredFieldValidator ID="rfvPinCode" runat="server" ControlToValidate="txtZip"
                                ErrorMessage="Pin Code is required" ForeColor="Red"></asp:RequiredFieldValidator>
                            <!-- Regular Expression Validator for Pin Code (e.g., 6 digits for Indian Pin Codes) -->
                            <asp:RegularExpressionValidator ID="revPinCode" runat="server" ControlToValidate="txtZip"
                                ValidationExpression="^\d{6}$" ErrorMessage="Pin Code must be 6 digits" ForeColor="Red"></asp:RegularExpressionValidator>
                        </div>

                        <div class="col-ms-12" style="margin-top: 10px;">
                            <!-- Landmark Input -->
                            <label for="txtLandmark">Landmark:</label><br />
                            <asp:TextBox ID="txtLandmark" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"
                                Placeholder="Enter your Landmark"></asp:TextBox>
                            <!-- Required Field Validator for Landmark -->
                            <asp:RequiredFieldValidator ID="rfvLandmark" runat="server" ControlToValidate="txtLandmark"
                                ErrorMessage="Landmark is required" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-sm-12 text-center " style="margin-top: 20px;">
                        <td align="right">
                            <asp:Label ID="lblTotal" runat="server" Text="" Visible="false"></asp:Label>
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn blue" Style="margin-right: 9%" OnClick="btnSubmit_Click" />
                        </td>
                    </div>
            </div>




            <div>
            </div>

            <%-- <!-- Next Button -->
    <div style="margin-top:20px; text-align:center;">
        <asp:Button ID="btnNext" runat="server" Text="Next" CssClass="btn btn-primary" OnClick="btnNext_Click" />
    </div>--%>
        </asp:Panel>

    </table>



</asp:Content>
