<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FullKyc.aspx.cs" Inherits="Agent_FullKyc" MasterPageFile="~/Agent/AgentMasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="portlet box blue">
        <div class="portlet-title">
            <div class="caption"><i class="fa fa-comments"></i>KYC Details</div>
        </div>

        <asp:Panel ID="pnlUPI" runat="server" Visible="true">
            <div class="row" style="border: 1px solid #b4cef8; margin: 0; padding: 5px;">
                <h4 class="my-3 fw-bold mx-2">KYC details</h4>
                <asp:Label ID="lblmsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                <div class="col-sm-6">
                    <!-- Full Name -->
                    <div class="col-sm-12">
                        <label for="txtName">Full Name:</label><br />
                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control" Placeholder="Enter your full name"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" ErrorMessage="Full Name is required" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>

                    <!-- Aadhar Number -->
                    <div class="col-sm-12" style="margin-top: 10px;">
                        <label for="txtAadhar">Aadhar Number:</label><br />
                        <asp:TextBox ID="txtAadhar" runat="server" CssClass="form-control" Placeholder="Enter your Aadhar Number"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvAadhar" runat="server" ControlToValidate="txtAadhar" ErrorMessage="Aadhar Number is required" ForeColor="Red"></asp:RequiredFieldValidator>
<%--                        <asp:RegularExpressionValidator ID="revAadhar" runat="server" ControlToValidate="txtAadhar" ValidationExpression="^\d{12}$" ErrorMessage="Aadhar Number must be 12 digits" ForeColor="Red"></asp:RegularExpressionValidator>--%>
                    </div>
                </div>

                <div class="col-sm-6">
                    <!-- PAN Number -->
                    <div class="col-sm-12" style="margin-top: 10px;">
                        <label for="TxtPan">Pan Number:</label><br />
                        <asp:TextBox ID="TxtPan" runat="server" CssClass="form-control" Placeholder="Enter your Pan number"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPan" runat="server" ControlToValidate="TxtPan" ErrorMessage="Pan Number is required" ForeColor="Red"></asp:RequiredFieldValidator>
<%--                        <asp:RegularExpressionValidator ID="revPan" runat="server" ControlToValidate="TxtPan" ValidationExpression="^[A-Z]{5}\d{4}[A-Z]{1}$" ErrorMessage="Invalid PAN format" ForeColor="Red"></asp:RegularExpressionValidator>--%>
                    </div>

                    <!-- Front Aadhar Image -->
                    <div class="col-sm-12" style="margin-top: 10px;">
                        <label for="txtFrontAadharImg">Front Aadhar Image:</label><br />
                        <asp:FileUpload ID="txtFrontAadharImg" runat="server" CssClass="form-control" />
                        <asp:RequiredFieldValidator ID="rfvFrontAadharImg" runat="server" ControlToValidate="txtFrontAadharImg" ErrorMessage="Front Aadhar Image is required" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="col-sm-6">
                    <!-- Back Aadhar Image -->
                    <div class="col-sm-12" style="margin-top: 10px;">
                        <label for="txtBackAadharImg">Back Aadhar Image:</label><br />
                        <asp:FileUpload ID="txtBackAadharImg" runat="server" CssClass="form-control" />
                        <asp:RequiredFieldValidator ID="rfvBackAadharImg" runat="server" ControlToValidate="txtBackAadharImg" ErrorMessage="Back Aadhar Image is required" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>

                    <!-- Front Pan Image -->
                    <div class="col-sm-12" style="margin-left: 542px;margin-top: -76px;">
                        <label for="txtFrontPanImg">Front Pan Image:</label><br />
                        <asp:FileUpload ID="txtFrontPanImg" runat="server" CssClass="form-control" />
                        <asp:RequiredFieldValidator ID="rfvFrontPanImg" runat="server" ControlToValidate="txtFrontPanImg" ErrorMessage="Front Pan Image is required" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <asp:Label ID="Label1" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                </div>

                <!-- Submit Button -->
                <div class="col-sm-12 text-center" style="margin-top: 20px;">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn blue" OnClick="btnSubmit_Click" />
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
