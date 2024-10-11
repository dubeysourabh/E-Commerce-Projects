<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateKyc.aspx.cs" Inherits="Admin_UpdateKyc" MasterPageFile="~/Admin/AdminMasterPage.master" %>


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
                <i class="fa fa-comments"></i>Update Kyc
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
                                    ShowFooter="false" OnRowDeleting="GridView1_RowDeleting">
                                    <RowStyle Font-Size="11px" Height="36px" HorizontalAlign="Center" Font-Bold="true"
                                        BackColor="#DCEDDD" ForeColor="#996633" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr. No" FooterText="Total :">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Kyc">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtKycId" runat="server" Text='<%# Eval("KycId") %>' Visible="false"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Full Name">
                                            <ItemTemplate>
                                                <asp:Label ID="FullName" runat="server" Text='<%# Eval("FullName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Aadhar Card No">
                                            <ItemTemplate>
                                                <asp:Label ID="AadharCardNo" runat="server" Text='<%# Eval("AadharCardNo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Pan Card No">
                                            <ItemTemplate>
                                                <asp:Label ID="PanCardNo" runat="server" Text='<%# Eval("PanCardNo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Front AadharCard">
                                            <ItemTemplate>
                                                <!-- Dynamically bind the image URL -->
                                                <asp:Image ID="FrontAadharCardImg" runat="server"
                                                    ImageUrl='<%# GetImageUrl(Eval("FrontAadharCardImg")) %>'
                                                    Width="100px" Height="100px" />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Back AadharCard">
                                            <ItemTemplate>
                                                <!-- Dynamically bind the image URL -->
                                                <asp:Image ID="BackAadharCardImg" runat="server"
                                                    ImageUrl='<%# GetImageUrl(Eval("BackAadharCardImg")) %>'
                                                    Width="100px" Height="100px" />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Front PanCard">
                                            <ItemTemplate>
                                                <!-- Dynamically bind the image URL -->
                                                <asp:Image ID="FrontPanCardImg" runat="server"
                                                    ImageUrl='<%# GetImageUrl(Eval("FrontPanCardImg")) %>'
                                                    Width="100px" Height="100px" />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Status">
                                            <ItemTemplate>
                                                <asp:Label ID="txtStatus" runat="server" Text='<%# Eval("Status") %>' ForeColor="Red"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Request KYC">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkApprove" runat="server" class="btn btn-sm btn-primary" Text="Approve" OnClick="lnkApprove_Click"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Cancel KYC">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkCancel" runat="server" CssClass="btn btn-sm btn-primary"
                                                    Text="Cancel KYC"  CommandName="delete"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" Font-Bold="true" HorizontalAlign="Center" />
                                    <PagerStyle BackColor="#6D8C8F" ForeColor="White" HorizontalAlign="Center" />
                                    <SelectedRowStyle Font-Bold="True" ForeColor="#996633" />
                                    <HeaderStyle HorizontalAlign="Center" Font-Bold="true" BackColor="#D5D8DC" />
                                </asp:GridView>

                                <%--===================================================================================================================--%>
                                <asp:LinkButton Text="" ID="LinkButton1" runat="server" />
                                <cc1:ModalPopupExtender ID="mpExtra" runat="server" PopupControlID="Panel1" TargetControlID="LinkButton1"
                                    CancelControlID="Button1" BackgroundCssClass="modalBackground">
                                </cc1:ModalPopupExtender>
                                <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" Style="display: none; width: 500px;">
                                    <div class="header">
                                        Kyc Cancellation
                                    </div>
                                    <div>
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td colspan="3">
                                                    <asp:Label ID="stat" runat="server" Text="" Visible="false"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <asp:Label ID="KycId" runat="server" Text="" Visible="false"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" align="center">&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" align="center">
                                                    <asp:Label ID="Label5" runat="server" Text="" Font-Bold="true" ForeColor="Red"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" align="center">
                                                    <asp:TextBox ID="txtReason" runat="server" TextMode="MultiLine" placeholder="Enter Kyc cancellation reason" CssClass="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" Display="Dynamic" ControlToValidate="txtReason" ValidationGroup="r"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" align="center">&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" align="center">
                                                    <asp:Button ID="txtbuttun" runat="server" Text="Yes" CssClass="btn blue" Onclick="txtbuttun_Click" ValidationGroup="r" />
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
