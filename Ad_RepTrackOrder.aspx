<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Ad_RepTrackOrder.aspx.cs" Inherits="Admin_Ad_RepTrackOrder" EnableEventValidation="true" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        .modalBackground
        {
            background-color: Black;
            filter: alpha(opacity=40);
            opacity: 0.4;
        }
        .modalPopup
        {
            background-color: #FFFFFF;
            width: 300px;
            border: 3px solid #0DA9D0;
        }
        .modalPopup .header
        {
            background-color: #2FBDF1;
            height: 30px;
            color: White;
            line-height: 30px;
            text-align: center;
            font-weight: bold;
        }
        .modalPopup .body
        {
            min-height: 50px;
            line-height: 30px;
            text-align: center;
            padding: 5px;
        }
        .modalPopup .footer
        {
            padding: 3px;
        }
        .modalPopup .button
        {
            height: 23px;
            color: White;
            line-height: 23px;
            text-align: center;
            font-weight: bold;
            cursor: pointer;
            background-color: #9F9F9F;
            border: 1px solid #5C5C5C;
        }
        .modalPopup td
        {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<cc1:ToolkitScriptManager ID="ScriptManager1" runat="server">
    </cc1:ToolkitScriptManager>--%>
    <asp:Label ID="Label1" runat="server" Style="font-weight: 700"></asp:Label>
    <div class="portlet box blue">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-comments"></i>Track Orders
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
                        <tr class="active">
                            <td align="center">
                                <asp:RadioButtonList ID="radSearch" runat="server" RepeatDirection="Horizontal" CellPadding="10"
                                    CellSpacing="5" AutoPostBack="true" OnSelectedIndexChanged="radSearch_SelectedIndexChanged">
                                    <asp:ListItem Selected="True">All Orders</asp:ListItem>
                                    <asp:ListItem>Individual Order</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td align="center" id="TdText" runat="server">
                                Enter Receipt No. :
                                <asp:TextBox ID="txtReceipt" runat="server" CssClass="form-control" Width="250px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtReceipt"
                                    Display="Dynamic" ErrorMessage="*" ValidationGroup="s"></asp:RequiredFieldValidator>
                            </td>
                            <td align="center" id="TdBtn" runat="server">
                                <asp:Button ID="btnSearch" runat="server" Text="Submit" CssClass="btn blue" ValidationGroup="s"
                                    OnClick="btnSearch_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                &nbsp;
                            </td>
                        </tr>
                        <tr class="success">
                            <td colspan="3" align="center" style="color: Black;">
                                <asp:Label ID="lblmsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="Grid"
                                    BorderColor="#DCEDDD" HeaderStyle-BackColor="#D5D8DC" HeaderStyle-HorizontalAlign="Center"
                                    HeaderStyle-VerticalAlign="Middle" HeaderStyle-ForeColor="black" HeaderStyle-Height="35"
                                    UseAccessibleHeader="false" CellPadding="3" PageSize="30" Width="100%" OnRowCreated="GridView1_RowCreated1"
                                    ShowFooter="false" OnSelectedIndexChanged="OnSelectedIndexChanged" 
                                    onrowdeleting="GridView1_RowDeleting">
                                    <RowStyle Font-Size="11px" Height="36px" HorizontalAlign="Center" Font-Bold="true"
                                        BackColor="#DCEDDD" ForeColor="#996633" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr. No" FooterText="Total :">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Receipt No.">
                                            <ItemTemplate>
                                                <asp:Label ID="RecNo" runat="server" Text='<%# Eval("repurchaseno") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Login Id">
                                            <ItemTemplate>
                                                <asp:Label ID="LoginID" runat="server" Text='<%# Eval("LoginId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Name">
                                            <ItemTemplate>
                                                <asp:Label ID="Name" runat="server" Text='<%# Eval("membername") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Quantity">
                                            <ItemTemplate>
                                                <asp:Label ID="Quantity" runat="server" Text='<%# Eval("TotQty") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total RV">
                                            <ItemTemplate>
                                                <asp:Label ID="TotalRV" runat="server" Text='<%# Eval("TotRV") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Price">
                                            <ItemTemplate>
                                                <asp:Label ID="Price" runat="server" Text='<%# Eval("TotPrice") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Shipping Price">
                                            <ItemTemplate>
                                                <asp:Label ID="ShippingCost" runat="server" Text='<%# Eval("TotShipping") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total Price">
                                            <ItemTemplate>
                                                <asp:Label ID="TotalCost" runat="server" Text='<%# Eval("TotCost") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Payment<br/>Mode">
                                            <ItemTemplate>
                                                <asp:Label ID="Payment" runat="server" Text='<%# Eval("PaymentMode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Order Date">
                                            <ItemTemplate>
                                                <asp:Label ID="OrderDate" runat="server" Text='<%# Eval("OrderDate") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Status" Visible="true">
                                            <ItemTemplate>
                                                <asp:Label ID="Status" runat="server" Text='<%# Eval("status") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="View">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkDelete" runat="server" Text="View" CommandName="Select"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Cancel Order">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkCancel" runat="server" Text="Cancel Order" CommandName="delete"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" Font-Bold="true" HorizontalAlign="Center" />
                                    <PagerStyle BackColor="#6D8C8F" ForeColor="White" HorizontalAlign="Center" />
                                    <SelectedRowStyle Font-Bold="True" ForeColor="#996633" />
                                    <HeaderStyle HorizontalAlign="Center" Font-Bold="true" BackColor="#D5D8DC" />
                                </asp:GridView>
                                <asp:LinkButton Text="" ID="lnkFake" runat="server" />
                                <cc1:ModalPopupExtender ID="mpe" runat="server" PopupControlID="pnlPopup" TargetControlID="lnkFake"
                                    CancelControlID="btnClose" BackgroundCssClass="modalBackground">
                                </cc1:ModalPopupExtender>
                                <asp:Panel ID="pnlPopup" runat="server" CssClass="modalPopup" Style="display: none;
                                    width: 500px;">
                                    <div class="header">
                                        Order Status
                                    </div>
                                    <div>
                                        <table border="0" cellpadding="0" cellspacing="0" style="font-weight:bold; text-align:left">
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CssClass="Grid"
                                                        BorderColor="#DCEDDD" HeaderStyle-BackColor="#D5D8DC" HeaderStyle-HorizontalAlign="Center"
                                                        HeaderStyle-VerticalAlign="Middle" HeaderStyle-ForeColor="black" HeaderStyle-Height="35"
                                                        UseAccessibleHeader="false" CellPadding="3" PageSize="30" Width="100%" OnRowCreated="GridView1_RowCreated1"
                                                        ShowFooter="true" OnRowDataBound="GridView1_RowDataBound">
                                                        <RowStyle Font-Size="11px" Height="36px" HorizontalAlign="Center" Font-Bold="true"
                                                            BackColor="#DCEDDD" ForeColor="#996633" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="#" FooterText="Total :">
                                                                <ItemTemplate>
                                                                    <%#Container.DataItemIndex + 1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%-- <asp:TemplateField HeaderText="Receipt No.">
                                            <ItemTemplate>
                                                <asp:Label ID="RecNo" runat="server" Text='<%# Eval("repurchaseno") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                                            <asp:TemplateField HeaderText="PCode">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="PrCode" runat="server" Text='<%# Eval("ProductCode") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="PName">
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
                                                            <asp:TemplateField HeaderText="Product MRP">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Price" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Shipping Charge">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="ShippingCost" runat="server" Text='<%# Eval("ShippingCost") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Final MRP">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="TotalCost" runat="server" Text='<%# Eval("TotalCost") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <FooterStyle BackColor="White" ForeColor="#000066" Font-Bold="true" HorizontalAlign="Center" />
                                                        <PagerStyle BackColor="#6D8C8F" ForeColor="White" HorizontalAlign="Center" />
                                                        <SelectedRowStyle Font-Bold="True" ForeColor="#996633" />
                                                        <HeaderStyle HorizontalAlign="Center" Font-Bold="true" BackColor="#D5D8DC" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr id="trSts" runat="server">
                                              <td colspan="3">
                                                <table width="100%">
                                                    <tr>
                                                       <td>
                                                    <asp:Label ID="txtordered" runat="server" CssClass="form-control" Width="100%"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtshipped" runat="server" CssClass="form-control" Width="100%"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtDelivered" runat="server" CssClass="form-control" Width="100%"></asp:Label>

                                                </td>
                                                    
                                                    </tr>
                                                </table>
                                            </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <asp:Label ID="lblStatus" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align:left;">
                                                    Courier Name :
                                                </td>
                                                <td style="text-align:left;">
                                                    <asp:Label ID="CourierName" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                             <tr>
                                                <td style="text-align:left;">
                                                    Courier Date :
                                                </td>
                                                <td style="text-align:left;">
                                                    <asp:Label ID="CourierDate" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                             <tr>
                                                <td style="text-align:left;">
                                                   Contact :
                                                </td>
                                                <td style="text-align:left;">
                                                    <asp:Label ID="Contact" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="footer" align="right">
                                        <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="button" />
                                    </div>
                                </asp:Panel>

                                    <%--===================================================================================================================--%>
                                <asp:LinkButton Text="" ID="LinkButton1" runat="server" />
                                <cc1:ModalPopupExtender ID="mpExtra" runat="server" PopupControlID="Panel1" TargetControlID="LinkButton1"
                                    CancelControlID="Button1" BackgroundCssClass="modalBackground">
                                </cc1:ModalPopupExtender>
                                <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" Style="display: none;
                                    width: 500px;">
                                    <div class="header">
                                        Order Cancellation
                                    </div>
                                    <div>
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td colspan="3">
                                                    <asp:Label ID="stat" runat="server" Text="" Visible="false"></asp:Label>
                                                    <asp:Label ID="recno" runat="server" Text="" Visible="false"></asp:Label>
                                                    <asp:Label ID="TotalCost" runat="server" Text="" Visible="false"></asp:Label>
                                                    <asp:Label ID="LogId" runat="server" Text="" Visible="false"></asp:Label>
                                                       <asp:Label ID="mode" runat="server" Text="" Visible="false"></asp:Label>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td colspan="3" align="center">
                                                   &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" align="center">
                                                    <asp:Label ID="Label5" runat="server" Text="" Font-Bold="true" ForeColor="Red"></asp:Label>
                                                </td>
                                            </tr>
                                              <tr>
                                                <td colspan="3" align="center">
                                                    <asp:TextBox ID="txtReason" runat="server" TextMode="MultiLine" placeholder="Enter order cancellation reason" CssClass="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" Display="Dynamic" ControlToValidate="txtReason" ValidationGroup="r"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" align="center">
                                                   &nbsp;
                                                </td>
                                            </tr>
                                              <tr>
                                                <td colspan="3" align="center">
                                                  <asp:Button ID="btnCancel" runat="server" Text="Yes" CssClass="btn blue" OnClick="btnCancel_Click"  ValidationGroup="r"/>
                                                  <asp:Button ID="Button1" runat="server" Text="No" CssClass="btn blue" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="footer" align="right">
                                   
                                    </div>
                                </asp:Panel>

                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>