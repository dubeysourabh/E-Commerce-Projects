<%@ Page Language="C#" MasterPageFile="~/Agent/AgentMasterPage.master" AutoEventWireup ="true" EnableEventValidation="false"  CodeFile="RepAllProduct.aspx.cs" Inherits="Agent_RepAllProduct" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../pw/layout/scripts/responsiveslides.js-v1.53/responsiveslides.css" rel="stylesheet"
        type="text/css" media="all">
    <%--<link href="../Agent/hover_files/bootstrap.css" rel="stylesheet" />--%>
    <link href="../Agent/hover_files/bootstrap-responsive.css" rel="stylesheet" />
    <link href="../Agent/hover_files/style.css" rel="stylesheet" />
    <link href="../Agent/hover_files/css.css" rel="stylesheet" type="text/css" />
    <link href="../Agent/hover_files/css_002.css" rel="stylesheet" type="text/css" />
    <style>
        .jm-item-wrapper {
            position: relative;
            padding: 7px;
            background: #fdfdfd;
            border: 2px solid #4f5f7b78;
        }

        .m-0 {
            margin: 0px;
        }

        .jm-item-title {
            position: absolute;
            left: 0px;
            bottom: -27px;
            background: #FF6B0E;
            color: #FFFFFF;
            font-size: 1.4em;
            line-height: 1.5em;
            font-weight: normal;
            padding: 4px 7px 4px;
            text-transform: uppercase;
            font-family: 'Oswald', sans-serif;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!-- BEGIN PAGE CONTENT-->
    <div class="row">
        <div class="col-md-12">
            <div class="tabbable tabbable-custom boxless">

                <div class="tab-content">
                    <div class="tab-pane active" id="tab_1">
                    </div>

                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="caption"></i>Select Product
                                <asp:DropDownList ID="ddlcatgry" runat="server" ForeColor="Black">
                                    <asp:ListItem>All Categories</asp:ListItem>
                                </asp:DropDownList>
                            </div>

                            <div class="tools">
                                <asp:Label ID="lbl1" runat="server" Text="Product in Cart :-"></asp:Label>
                                <asp:Label ID="lblCart" runat="server" Style="font-weight: bold;"></asp:Label>
                                <asp:Label ID="lbl2" runat="server" Text="Point:-"></asp:Label>
                                <asp:Label ID="lblPv" runat="server" Style="font-weight: bold;"></asp:Label>
                                <asp:Label ID="lbl4" runat="server" Text="Amount :-"></asp:Label>
                                <asp:Label ID="lblAmt" runat="server" Style="font-weight: bold;"></asp:Label>

                                <asp:HyperLink ID="lnkvw" runat="server" class="btn btn-info fw-bolder" Style="height: 30px; font-weight: bold;" Text="View All"
                                    NavigateUrl="~/Agent/RepCart.aspx"></asp:HyperLink>
                                <%-- <a href="javascript:;" class="collapse"></a><a href="#portlet-config" data-toggle="modal"
                                    class="config"></a><a href="javascript:;" class="reload"></a><a href="javascript:;"
                                        class="remove"></a>--%>
                            </div>
                        </div>

                    </div>

                    <div class="portlet-body">
                        <div class="table-responsive">
                            <table class="table">
                                <tr>
                                    <td style="width: 100%;">
                                        <div>
                                            <%-- <div class="portlet-body flip-scroll" style=" height:520px; overflow:auto;">--%>
                                            <div class="tab-content">
                                                <div class="tab-pane active" id="tab_1">
                                                    <asp:Label ID="lblJoin" runat="server" Text=""></asp:Label>




                                                    <asp:DataList ID="dlAds" runat="server" Width="100%"
                                                        RepeatColumns="3">
                                                        <ItemTemplate>

                                                            <div>
                                                                <div class="jm-item ssecond ">
                                                                    <div class="jm-item-wrapper">
                                                                        <div class="jm-item-image  card">
                                                                            <asp:Label ID="lblCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ProductCode")%>' Visible="false"></asp:Label>
                                                                            <center>

                                                                                <asp:Image ID="Img1" runat="server"
                                                                                    ImageUrl='<%# GetImageUrl1(Eval("Img1")) %>'
                                                                                    Width="100px" Height="100px" />

                                                                            </center>
                                                                            <%--<img src="hover_files/image1.jpg" alt="Pizza Ristorante">--%>
                                                                            <div class="jm-item-description">
                                                                                <%--<p style="width:171px; font-weight:bold; text-decoration: line-through;"> Original Price : <%# DataBinder.Eval(Container.DataItem, "ProductMrp")%></p>--%>
                                                                                <div>
                                                                                    <p style="font-weight: bold; text-align: center; font-size: 16px; font-family: Times New Roman;">
                                                                                        <%# DataBinder.Eval(Container.DataItem, "ProductName")%>
                                                                                </div>
                                                                                <div style="width: 100px; font-weight: bold; color: green; margin: auto; font-size: 25px;">
                                                                                    <a><i class="fa fa-rupee"></i>
                                                                                        <%# DataBinder.Eval(Container.DataItem, "ProductMrp")%>&nbsp;/-</a>
                                                                                    <%--<%# DataBinder.Eval(Container.DataItem, "OfferPrice")%></a></div>--%>
                                                                                </div>
                                                                            </div>
                                                                            <div class="jm-item-button1 py-1" style="text-align: center;">

                                                                                <a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CODE:
                                                                                             <%# DataBinder.Eval(Container.DataItem, "ProductCode")%></a>
                                                                                <%--<%# DataBinder.Eval(Container.DataItem, "OfferPrice")%></a></div>--%>
                                                                            </div>
                                                                            <div class="row m-0">
                                                                                <div class="col-sm-6">
                                                                                    <p style="font-size: 17px;">&nbsp;<b> PV: </b><%# DataBinder.Eval(Container.DataItem, "ProductRV")%></p>

                                                                                </div>
                                                                                <div class="col-sm-6">
                                                                                    <p style="font-size: 17px;"><b>Offer Price:</b><%# DataBinder.Eval(Container.DataItem, "OfferPrice")%></p>

                                                                                </div>
                                                                                <div class="col-sm-6">
                                                                                    <p style="font-size: 17px;"><b>Final MRP:</b><%# DataBinder.Eval(Container.DataItem, "FinalMRP")%></p>

                                                                                </div>
                                                                                <div class="col-sm-6">
                                                                                    <p style="font-size: 17px;">&nbsp;<b>  S.C:</b><%# DataBinder.Eval(Container.DataItem, "ShippingCost")%></p>

                                                                                </div>
                                                                                <div class="col-sm-6 py-2">
                                                                                    <div href="pagenews.aspx">
                                                                                        <%--View Details--%>
                                                                                        <asp:LinkButton ID="lnkJoin" runat="server" class="btn btn-warning" OnClick="lnkJoin_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ProductCode")%>'>View Details</asp:LinkButton>
                                                                                    </div>

                                                                                </div>
                                                                                <div class="col-sm-6  py-2">
                                                                                    <div class="jm-item-title1">
                                                                                        <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-info" OnClick="lnkAddToCart_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ProductCode")%>'>Add To Cart</asp:LinkButton>
                                                                                        <%-- <%# DataBinder.Eval(Container.DataItem, "ProductName")%>--%>
                                                                                    </div>
                                                                                </div>





                                                                            </div>




                                                                        </div>
                                                                        <div style="margin-top: 2%">

                                                                            <%--<asp:ImageButton ID="ImgPlus" runat="server" ImageUrl="~/CompanyImg/plus.png" style="height:25px; width:25px; margin-left:20%"  OnClick="lnkPlus_Click"  CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ProductCode")%>'></asp:ImageButton>--%>
                                                                            <%--<asp:Label ID="txtQty" runat="server" ReadOnly="true" Text=' <%# DataBinder.Eval(Container.DataItem, "quantity")%>' CssClass="form-control" Width="45px" Height="25px"></asp:Label>--%>
                                                                            <%--<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/CompanyImg/minus.png" Visible="false" style="height:25px; width:25px;" OnClick="lnkMinus_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ProductCode")%>'></asp:ImageButton>--%>
                                                                            <br />
                                                                            <asp:Label ID="lblText" runat="server" Text="" ForeColor="Red"></asp:Label>

                                                                        </div>

                                                                    </div>
                                                                </div>
                                                        </ItemTemplate>
                                                    </asp:DataList>
                                                </div>
                                                <div class="main_bg1">
                                                </div>
                                    </td>
                                    <td style="color: White; font-weight: bold;">
                                        <%--<div style="margin-top:36%">
                                        <asp:ImageButton ID="Image1" runat="server" ImageUrl="~/CompanyImg/icon-bag.png" 
                                            Height="120px" Width="230px" style="margin-left:-2%" onclick="Image1_Click" /> 
                                        <asp:Image ID="Image2" runat="server"  ImageUrl="~/CompanyImg/board.png" Height="180px" Width="250px"  />
                                        <asp:Label ID="Label1" runat="server" Text="Cart : " style="position:absolute; left:85%; top: 31.5%"></asp:Label><asp:Label ID="lblCart1" runat="server" Text="" style="position:absolute; left:88.7%; top: 31.5%"></asp:Label>

                                         <asp:Label ID="Label2" runat="server" Text="Point : " style="position:absolute; left:83%; top: 47.5%"></asp:Label><asp:Label ID="lblPv1" runat="server" Text="" style="position:absolute; left:88.7%; top: 47.5%"></asp:Label>

                                          <asp:Label ID="Label3" runat="server" Text="Amount : " style="position:absolute; left:83%; top: 52%"></asp:Label><asp:Label ID="lblAmt1" runat="server" Text="" style="position:absolute; left:88.7%; top: 52%"></asp:Label>
                                      </div>--%>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
    </div> 
    
    <asp:Label ID="lblmsg" runat="server"></asp:Label>
    </div>
    </div>
    </div>
    </div>
    </div>
    </div>
    </div>
    </div>
    </div>
    </div>
</asp:Content>

