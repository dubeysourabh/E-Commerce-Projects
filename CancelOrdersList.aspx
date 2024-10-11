<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true"
    CodeFile="CancelOrdersList.aspx.cs" Inherits="Admin_CancelOrdersList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        body {
            font-family: Arial;
            font-size: 10pt;
        }

        .modalBackground {
            background-color: Black;
            filter: alpha(opacity=40);
            opacity: 0.4;
        }

        .modalPopup {
            background-color: #FFFFFF;
            width: 300px;
            border: 3px solid #0DA9D0;
        }

            .modalPopup .header {
                background-color: #2FBDF1;
                height: 30px;
                color: White;
                line-height: 30px;
                text-align: center;
                font-weight: bold;
            }

            .modalPopup .body {
                min-height: 50px;
                line-height: 30px;
                text-align: center;
                padding: 5px;
            }

            .modalPopup .footer {
                padding: 3px;
            }

            .modalPopup .button {
                height: 23px;
                color: White;
                line-height: 23px;
                text-align: center;
                font-weight: bold;
                cursor: pointer;
                background-color: #9F9F9F;
                border: 1px solid #5C5C5C;
            }

            .modalPopup td {
                text-align: center;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="Label1" runat="server" Style="font-weight: 700"></asp:Label>
    <div class="portlet box blue">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-comments"></i>Cancel Details
            </div>
            <div class="tools">
                <a href="javascript:;" class="collapse"></a><a href="#portlet-config" data-toggle="modal"
                    class="config"></a><a href="javascript:;" class="reload"></a><a href="javascript:;"
              class="remove"></a>
            </div>
        </div>
        <div class="portlet-body">
            <div class="table-responsive" style="width: 100%;">
                <table class="table table-bordered table-hover">
                    <tbody>
                        <tr>
                            <td align="center" style="color: Black;">
                                <asp:Label ID="lblmsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="Grid"
                                    BorderColor="#DCEDDD" HeaderStyle-BackColor="#D5D8DC" HeaderStyle-HorizontalAlign="Center"
                                    HeaderStyle-VerticalAlign="Middle" HeaderStyle-ForeColor="black" HeaderStyle-Height="35"
                                    UseAccessibleHeader="false" CellPadding="3" PageSize="30" Width="100%" 
                                    ShowFooter="false">
                                    <RowStyle Font-Size="11px" Height="36px" HorizontalAlign="Center" Font-Bold="true"
                                        BackColor="#DCEDDD" ForeColor="#996633" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr. No" FooterText="Total :">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Repurchase No">
                                            <ItemTemplate>
                                                <asp:Label ID="RepurchaseNo" runat="server" Text='<%# Eval("RepurchaseNo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Loginid">
                                            <ItemTemplate>
                                                <asp:Label ID="Loginid" runat="server" Text='<%# Eval("Loginid") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Transaction Receipt">
                                            <ItemTemplate>
                                                <!-- Dynamically bind the image URL -->
                                                <asp:Image ID="imgUPloadPaymentReceipt" runat="server"
                                                    ImageUrl='<%# GetImageUrl(Eval("Uploadimg")) %>'
                                                    Width="100px" Height="100px" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Name">
                                            <ItemTemplate>
                                                <asp:Label ID="Name" runat="server" Text='<%# Eval("membername") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Upi Id">
                                            <ItemTemplate>
                                                <asp:Label ID="UpiId" runat="server" Text='<%# Eval("UpiId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Description">
                                            <ItemTemplate>
                                                <asp:Label ID="txtDescription" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Tot Qty">
                                            <ItemTemplate>
                                                <asp:Label ID="TotQty" runat="server" Text='<%# Eval("TotQty") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="TotRV">
                                            <ItemTemplate>
                                                <asp:Label ID="txtTotRV" runat="server" Text='<%# Eval("TotRV") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total Price">
                                            <ItemTemplate>
                                                <asp:Label ID="TotPrice" runat="server" Text='<%# Eval("TotPrice") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total Cost">
                                            <ItemTemplate>
                                                <asp:Label ID="TotCost" runat="server" Text='<%# Eval("TotCost") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total Shipping">
                                            <ItemTemplate>
                                                <asp:Label ID="TotShipping" runat="server" Text='<%# Eval("TotShipping") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="PaymentMode">
                                            <ItemTemplate>
                                                <asp:Label ID="txtPaymentMode" runat="server" Text='<%# Eval("PaymentMode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>                                       
                                        <asp:TemplateField HeaderText="Order Date">
                                            <ItemTemplate>
                                                <asp:Label ID="OrderDate" runat="server" Text='<%# Eval("OrderDate") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>                                      
                                        <asp:TemplateField HeaderText="Status">
                                            <ItemTemplate>
                                                <asp:Label ID="status" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
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
                    </tbody>
                </table>
            </div>
        </div>
    </div>  
</asp:Content>