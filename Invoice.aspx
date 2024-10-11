<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Invoice.aspx.cs" Inherits="Agent_Invoice" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Invoice</title>
    <link rel="stylesheet" href="styles.css">
    <style>
        body {
            font-family: Arial, sans-serif;
            padding: 20px;
        }

        .invoice-container {
            width: 100%;
            max-width: 900px;
            margin: 0 auto;
            padding: 20px;
            border: 1px solid #ddd;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .invoice-header {
            text-align: center;
            margin-bottom: 30px;
        }

            .invoice-header img {
                width: 150px;
            }

            .invoice-header .company-name {
                font-size: 24px;
                font-weight: bold;
                margin-top: 10px;
            }

        .client-details, .product-details {
            margin-bottom: 20px;
        }

        table {
            width: 100%;
            border-collapse: collapse;
        }

            table th, table td {
                padding: 10px;
                border: 1px solid #ddd;
                text-align: left;
            }

            table th {
                background-color: #f8f8f8;
                font-weight: bold;
            }

        .total-label {
            text-align: right;
        }

        .total {
            font-weight: bold;
            text-align: right;
            font-size: 18px;
            margin-top: 20px;
        }

        .auto-style2 {
            width: 883px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="invoice-container">
            <header class="invoice-header">
                <img src="logo.png" alt="Company Logo" class="logo">
                <h1 class="company-name">Swaliya Softtech Pvt. Ltd</h1>
                <p class="company-address">
                    123 Business Rd.<br>
                    City, State, ZIP
                </p>
            </header>

            <section class="Client-details">
                <h2>Client Details</h2>
                <table>
                    <tbody>
                        <asp:Label ID="lblmsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                            OnRowCreated="GridView1_RowCreated" CssClass="table">
                            <Columns>
                                <asp:TemplateField HeaderText="Loginid">
                                    <ItemTemplate>
                                        <asp:Label ID="Loginid" runat="server" Text='<%# Eval("Loginid") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Contact">
                                    <ItemTemplate>
                                        <asp:Label ID="Contact" runat="server" Text='<%# Eval("Contact") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </tbody>
                </table>
            </section>

            <section class="Shipping-details">
                <h2>Shipping Details</h2>
                <table>
                    <tbody>
                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CssClass="table">
                            <Columns>
                                 <asp:TemplateField HeaderText="UpiId">
                                    <ItemTemplate>
                                        <asp:Label ID="UpiId" runat="server" Text='<%# Eval("UpiId") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Description">
                                    <ItemTemplate>
                                        <asp:Label ID="Description" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="FullName">
                                    <ItemTemplate>
                                        <asp:Label ID="FullName" runat="server" Text='<%# Eval("FullName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="PhoneNumber">
                                    <ItemTemplate>
                                        <asp:Label ID="PhoneNumber" runat="server" Text='<%# Eval("PhoneNumber") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="City">
                                    <ItemTemplate>
                                        <asp:Label ID="City" runat="server" Text='<%# Eval("City") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Address">
                                    <ItemTemplate>
                                        <asp:Label ID="Address" runat="server" Text='<%# Eval("Address") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Pincode">
                                    <ItemTemplate>
                                        <asp:Label ID="Pincode" runat="server" Text='<%# Eval("Pincode") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="landmark">
                                    <ItemTemplate>
                                        <asp:Label ID="landmark" runat="server" Text='<%# Eval("landmark") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Position">
                                    <ItemTemplate>
                                        <asp:Label ID="Position" runat="server" Text='<%# Eval("Position") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </tbody>
                </table>
            </section>

            <section class="product-details">
                <h2>Product Details</h2>
                <table>
                    <tbody>
                        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" CssClass="table">
                            <Columns>
                                <asp:TemplateField HeaderText="Order No">
                                    <ItemTemplate>
                                        <asp:Label ID="ProductCode" runat="server" Text='<%# Eval("ProductCode") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Product Name">
                                    <ItemTemplate>
                                        <asp:Label ID="ProductName" runat="server" Text='<%# Eval("ProductName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Quantity">
                                    <ItemTemplate>
                                        <asp:Label ID="Qty" runat="server" Text='<%# Eval("Qty") %>'></asp:Label>
                                    </ItemTemplate>
                                    <%--<FooterTemplate>
                                        <strong>Total Quantity: </strong>
                                        <asp:Label ID="divTotalQty" runat="server"></asp:Label>
                                    </FooterTemplate>--%>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Total RV">
                                    <ItemTemplate>
                                        <asp:Label ID="TotalRV" runat="server" Text='<%# Eval("TotalRV") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Total MRP">
                                    <ItemTemplate>
                                        <asp:Label ID="TotalMRP" runat="server" Text='<%# Eval("TotalMRP") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Date">
                                    <ItemTemplate>
                                        <asp:Label ID="date" runat="server" Text='<%# Eval("date") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="status">
                                    <ItemTemplate>
                                        <asp:Label ID="status" runat="server" Text='<%# Eval("status") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Total Cost">
                                    <ItemTemplate>
                                        <asp:Label ID="TotalCost" runat="server" Text='<%# Eval("TotalCost") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </tbody>
                </table>
            </section>

            <div style="width: 100%; white-space: nowrap;">
                <label>Total</label>
                <div id="divTotalQty" runat="server" style="display: inline-block;margin-left: 341px;margin-right: -50px;">
                </div>
                <div id="divTotalRV" runat="server" style="display: inline-block;margin-left: 164px;margin-right: 108px;">
                   
                </div>
                <div id="divTotalMRP" runat="server" style="display: inline-block;margin-right: 494px;">
                   
                </div>
                <div id="divTotalCost" runat="server" style="display: inline-block;">
                    
                </div>
            </div>



        </div>
    </form>
</body>
</html>
