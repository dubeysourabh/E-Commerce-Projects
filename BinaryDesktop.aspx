<%@ Page Title="" Language="C#" MasterPageFile="~/Agent/AgentMasterPage.master" AutoEventWireup="true" CodeFile="BinaryDesktop.aspx.cs" Inherits="Agent_BinaryDesktop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 100%">
        <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Text="" Style="font-family: Verdana; font-size: x-small; margin-left: 0%"></asp:Label>
    </div>
    <style>
        tr td:first-child {
            font-weight: bolder;
        }
    </style>
    <%--==========================================================================================================================--%>

    <div class="portlet box blue">
        <div class="portlet-title">
            <div class="caption" align="center">
                <i class="fa fa-comments"></i>Personal Details
            </div>
            <div class="tools">
                <a href="javascript:;" class="collapse"></a>
                <a href="#portlet-config" data-toggle="modal" class="config"></a>
                <a href="javascript:;" class="reload"></a>
                <a href="javascript:;" class="remove"></a>
            </div>
        </div>
        <div class="portlet-body">
            <div class="table-responsive">

                <div class="portlet-body" style="overflow: auto;">
                    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                    <table class="table table-bordered table-hover">
                        <tbody>
                            <tr class="error">
                                <td style="width: 20%" align="center" valign="middle">
                                    <asp:Image ID="SelfImg" runat="server" ImageUrl="~/CompanyImg/emp.png" Width="126px" Height="120px" Style="margin-left: 0%"></asp:Image><br />
                                    <br />
                                    <asp:FileUpload ID="FileUpload1" runat="server" /><br />
                                    <asp:Button ID="btnChangePhoto" runat="server" Text="Change Photo" ValidationGroup="Img" CssClass="btn blue" OnClick="btnChangePhoto_Click" /><br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                        ErrorMessage="Select Image" ControlToValidate="FileUpload1" Display="Dynamic"
                                        ValidationGroup="Img"></asp:RequiredFieldValidator>

                                </td>
                                <td style="width: 80%" valign="middle">
                                    <table class="table table-bordered table-hover">
                                        <tr>
                                            <td style="width: 25%" align="left">LoginId :
                                            </td>
                                            <td style="width: 25%" align="center">
                                                <asp:Label ID="lblLogin" runat="server" Text="" CssClass="form-control"></asp:Label>
                                            </td>
                                            <th style="width: 25%" align="left">Matching Incentive :
                                            </th>
                                            <td style="width: 25%" align="center">
                                                <asp:Label ID="Iblmatch" runat="server" Text="" CssClass="form-control"></asp:Label>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td style="width: 25%" align="left">Name :
                                            </td>
                                            <td style="width: 25%" align="center">
                                                <asp:Label ID="lblName" runat="server" Text="" CssClass="form-control"></asp:Label>
                                            </td>
                                            <th style="width: 25%" align="left">Monthly Performance Incentive :
                                            </th>
                                            <td style="width: 25%" align="center">
                                                <asp:Label ID="IblMPI" runat="server" Text="" CssClass="form-control"></asp:Label>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td style="width: 25%" align="left">Self Purchase(PV) : 
                                            </td>
                                            <td style="width: 25%" align="center">
                                                <asp:HyperLink ID="iblTolPv" runat="server" Text="View PV" CssClass="form-control" NavigateUrl="../Agent/TrackOrder.aspx" Style="color: green; font-size: 14px; font-weight: bold;"> </asp:HyperLink>

                                            </td>

                                            <th style="width: 25%" align="left">Repurchase Incentive :
                                            </th>
                                            <td style="width: 25%" align="center">
                                                <asp:Label ID="Iblrep" runat="server" Text="" CssClass="form-control"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 25%" align="left">My Rank :
                                            </td>
                                            <td style="width: 25%" align="center">
                                                <%-- <asp:HyperLink ID="HyperLink1" runat="server" Text="View All" CssClass="form-control" NavigateUrl="../Agent/TrackOrder.aspx" style="color:green; font-size:14px; font-weight:bold;"></asp:HyperLink>  --%>
                                                <asp:Label ID="iblrank" runat="server" Text="" CssClass="form-control"></asp:Label>
                                            </td>
                                            <th style="width: 25%" align="left">Total Income :
                                            </th>
                                            <td style="width: 25%" align="center">
                                                <asp:Label ID="Iblincome" runat="server" Text="" CssClass="form-control"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 25%" align="left">Monthly Status :
                                            </td>
                                            <td style="width: 25%" align="center">
                                                <%-- <asp:HyperLink ID="HyperLink1" runat="server" Text="View All" CssClass="form-control" NavigateUrl="../Agent/TrackOrder.aspx" style="color:green; font-size:14px; font-weight:bold;"></asp:HyperLink>  --%>
                                                <asp:Label ID="Label36" runat="server" Text="" CssClass="form-control"></asp:Label>
                                            </td>
                                            <th style="width: 25%" align="left" runat="server" visible="True">Shopping Status :
                                            </th>
                                            <td style="width: 25%" align="center" runat="server" visible="True">
                                                <asp:HyperLink ID="iblshop" runat="server" Text="View PV" CssClass="form-control" NavigateUrl="../Agent/RepTopUp.aspx" Style="color: green; font-size: 14px; font-weight: bold;"> </asp:HyperLink>

                                            </td>
                                        </tr>

                                    </table>
                                </td>

                            </tr>

                        </tbody>
                    </table>


                </div>

            </div>
        </div>
    </div>

    <%--==========================================================================================================================--%>

    <table class="table table-bordered table-hover" style="border: 0px ridge gray;" runat="server" visible="false">
        <tr>
            <td style="border: 0px ridge gray; width: 50%" align="center">
                <div class="portlet box blue">
                    <div class="portlet-title">
                        <div class="caption" align="center">
                            <i class="fa fa-comments"></i>Today's Bussiness (Re-purchase)
                        </div>
                        <div class="tools">
                            <a href="javascript:;" class="collapse"></a>
                            <a href="#portlet-config" data-toggle="modal" class="config"></a>
                            <a href="javascript:;" class="reload"></a>
                            <a href="javascript:;" class="remove"></a>
                        </div>
                    </div>
                    <div class="portlet-body">
                        <div class="table-responsive">
                            <div class="portlet-body" style="overflow: auto;">
                                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                <table class="table table-bordered table-hover">
                                    <tr>
                                        <td style="width: 25%" align="left"></td>
                                        <td style="width: 25%; font-weight: bold" align="center">Total PV's
                                        </td>
                                        <td style="width: 25%; font-weight: bold" align="left">Total ID's
                                        </td>
                                        <%-- <td style="width:25%; font-weight:bold" align="center">
                                                   Total Registration
                                                </td> --%>
                                    </tr>

                                    <tr>
                                        <td style="width: 25%; font-weight: bold" align="left">Left Side:
                                        </td>
                                        <td style="width: 25%" align="center">
                                            <asp:Label ID="TRLeftPP" runat="server" Text="0" CssClass="form-control"></asp:Label>
                                        </td>
                                        <td style="width: 25%" align="left">
                                            <asp:Label ID="TRLeftUP" runat="server" Text="0" CssClass="form-control"></asp:Label>
                                        </td>
                                        <%--                                                <td style="width:25%" align="center">
                                                    <asp:Label ID="TRLeftTP" runat="server" Text="0" CssClass="form-control"></asp:Label>
                                                </td> --%>
                                    </tr>

                                    <tr>
                                        <td style="width: 25%; font-weight: bold" align="left">Right Side :
                                        </td>
                                        <td style="width: 25%; font-weight: bold" align="center">
                                            <asp:Label ID="TRRightPP" runat="server" Text="0" CssClass="form-control"></asp:Label>
                                        </td>
                                        <td style="width: 25%" align="left">
                                            <asp:Label ID="TRRightUP" runat="server" Text="0" CssClass="form-control"></asp:Label>
                                        </td>
                                        <%-- <td style="width:25%" align="center">
                                                    <asp:Label ID="TRRightTP" runat="server" Text="0" CssClass="form-control"></asp:Label>
                                                </td>--%>
                                    </tr>

                                    <tr runat="server" visible="true">
                                        <td style="width: 25%; font-weight: bold" align="left">Carry Left :
                                        </td>
                                        <td style="width: 25%" align="center">
                                            <asp:Label ID="TRLeftPC" runat="server" Text="0" CssClass="form-control"></asp:Label>
                                        </td>
                                        <td style="width: 25%" align="left">
                                            <asp:Label ID="TRLeftUC" runat="server" Text="0" CssClass="form-control"></asp:Label>
                                        </td>
                                        <%-- <td style="width:25%" align="center">
                                                    <asp:Label ID="TRLeftTC" runat="server" Text="0" CssClass="form-control"></asp:Label>
                                                </td> --%>
                                    </tr>

                                    <tr runat="server" visible="true">
                                        <td style="width: 25%; font-weight: bold" align="left">Carry Right :
                                        </td>
                                        <td style="width: 25%; font-weight: bold" align="center">
                                            <asp:Label ID="TRRightPC" runat="server" Text="0" CssClass="form-control"></asp:Label>
                                        </td>
                                        <td style="width: 25%" align="left">
                                            <asp:Label ID="TRRightUC" runat="server" Text="0" CssClass="form-control"></asp:Label>
                                        </td>
                                        <%-- <td style="width:25%" align="center">
                                                    <asp:Label ID="TRRightTC" runat="server" Text="0" CssClass="form-control"></asp:Label>
                                                </td> --%>
                                    </tr>

                                </table>


                            </div>

                        </div>
                    </div>
                </div>
            </td>
            <td style="border: 0px ridge gray; width: 50%" align="center">
                <div class="portlet box blue">
                    <div class="portlet-title">
                        <div class="caption" align="center">
                            <i class="fa fa-comments"></i>All Bussiness (Re-purchase)
                        </div>
                        <div class="tools">
                            <a href="javascript:;" class="collapse"></a>
                            <a href="#portlet-config" data-toggle="modal" class="config"></a>
                            <a href="javascript:;" class="reload"></a>
                            <a href="javascript:;" class="remove"></a>
                        </div>
                    </div>
                    <div class="portlet-body">
                        <div class="table-responsive">
                            <div class="portlet-body" style="overflow: auto;">
                                <asp:Label ID="Label12" runat="server" Text=""></asp:Label>
                                <table class="table table-bordered table-hover">
                                    <tr>
                                        <td style="width: 25%" align="left"></td>
                                        <td style="width: 25%; font-weight: bold" align="center">Total PV's
                                        </td>
                                        <td style="width: 25%; font-weight: bold" align="left">Total ID's
                                        </td>
                                        <%--<td style="width:25%; font-weight:bold" align="center">
                                                   Total Registration
                                                </td> --%>
                                    </tr>

                                    <tr>
                                        <td style="width: 25%; font-weight: bold" align="left">Left Side :
                                        </td>
                                        <td style="width: 25%" align="center">
                                            <asp:Label ID="ARLeftPP" runat="server" Text="0" CssClass="form-control"></asp:Label>
                                        </td>
                                        <td style="width: 25%" align="left">
                                            <asp:Label ID="ARLeftUP" runat="server" Text="0" CssClass="form-control"></asp:Label>
                                        </td>
                                        <%--<td style="width:25%" align="center">
                                                    <asp:Label ID="ARLeftTP" runat="server" Text="0" CssClass="form-control"></asp:Label>
                                                </td> --%>
                                    </tr>

                                    <tr>
                                        <td style="width: 25%; font-weight: bold" align="left">Right Side :
                                        </td>
                                        <td style="width: 25%; font-weight: bold" align="center">
                                            <asp:Label ID="ARRightPP" runat="server" Text="0" CssClass="form-control"></asp:Label>
                                        </td>
                                        <td style="width: 25%" align="left">
                                            <asp:Label ID="ARRightUP" runat="server" Text="0" CssClass="form-control"></asp:Label>
                                        </td>
                                        <%--  <td style="width:25%" align="center">
                                                    <asp:Label ID="ARRightTP" runat="server" Text="0" CssClass="form-control"></asp:Label>
                                                </td> --%>
                                    </tr>

                                    <tr runat="server" visible="true">
                                        <td style="width: 25%; font-weight: bold" align="left">Carry Left :
                                        </td>
                                        <td style="width: 25%" align="center">
                                            <asp:Label ID="ARLeftPC" runat="server" Text="0" CssClass="form-control"></asp:Label>
                                        </td>
                                        <td style="width: 25%" align="left">
                                            <asp:Label ID="ARLeftUC" runat="server" Text="0" CssClass="form-control"></asp:Label>
                                        </td>
                                        <%--     <td style="width:25%" align="center">
                                                    <asp:Label ID="ARLeftTC" runat="server" Text="0" CssClass="form-control"></asp:Label>
                                                </td> --%>
                                    </tr>

                                    <tr runat="server" visible="true">
                                        <td style="width: 25%; font-weight: bold" align="left">Carry  Right :
                                        </td>
                                        <td style="width: 25%; font-weight: bold" align="center">
                                            <asp:Label ID="ARRightPC" runat="server" Text="0" CssClass="form-control"></asp:Label>
                                        </td>
                                        <td style="width: 25%" align="left">
                                            <asp:Label ID="ARRightUC" runat="server" Text="0" CssClass="form-control"></asp:Label>
                                        </td>
                                        <%--  <td style="width:25%" align="center">
                                                    <asp:Label ID="ARRightTC" runat="server" Text="0" CssClass="form-control"></asp:Label>
                                                </td> --%>
                                    </tr>
                                </table>


                            </div>

                        </div>
                    </div>
                </div>
            </td>
        </tr>
    </table>




    <%--==========================================================================================================================--%>
    <%--==========================================================================================================================--%>

    <table class="table table-bordered table-hover" style="border: 0px ridge gray;" runat="server" visible="false">
        <tr>
            <td style="border: 0px ridge gray; width: 50%" align="center">
                <div class="portlet box blue">
                    <div class="portlet-title">
                        <div class="caption" align="center">
                            <i class="fa fa-comments"></i>Today's Bussiness (Matching bussiness)
                        </div>
                        <div class="tools">
                            <a href="javascript:;" class="collapse"></a>
                            <a href="#portlet-config" data-toggle="modal" class="config"></a>
                            <a href="javascript:;" class="reload"></a>
                            <a href="javascript:;" class="remove"></a>
                        </div>
                    </div>
                    <div class="portlet-body">
                        <div class="table-responsive">
                            <div class="portlet-body" style="overflow: auto;">
                                <asp:Label ID="Label26" runat="server" Text=""></asp:Label>
                                <table class="table table-bordered table-hover">
                                    <tr>
                                        <td style="width: 25%" align="left"></td>
                                        <td style="width: 25%; font-weight: bold" align="center">Total PV's
                                        </td>
                                        <td style="width: 25%; font-weight: bold" align="left">Total ID's
                                        </td>
                                        <%-- <td style="width:25%; font-weight:bold" align="center">
                                                   Total Registration
                                                </td> --%>
                                    </tr>

                                    <tr>
                                        <td style="width: 25%; font-weight: bold" align="left">Left Side:
                                        </td>
                                        <td style="width: 25%" align="center">
                                            <asp:Label ID="Label27" runat="server" Text="0" CssClass="form-control"></asp:Label>
                                        </td>
                                        <td style="width: 25%" align="left">
                                            <asp:Label ID="Label28" runat="server" Text="0" CssClass="form-control"></asp:Label>
                                        </td>
                                        <%--                                                <td style="width:25%" align="center">
                                                    <asp:Label ID="TRLeftTP" runat="server" Text="0" CssClass="form-control"></asp:Label>
                                                </td> --%>
                                    </tr>

                                    <tr>
                                        <td style="width: 25%; font-weight: bold" align="left">Right Side:
                                        </td>
                                        <td style="width: 25%; font-weight: bold" align="center">
                                            <asp:Label ID="Label29" runat="server" Text="0" CssClass="form-control"></asp:Label>
                                        </td>
                                        <td style="width: 25%" align="left">
                                            <asp:Label ID="Label30" runat="server" Text="0" CssClass="form-control"></asp:Label>
                                        </td>
                                        <%-- <td style="width:25%" align="center">
                                                    <asp:Label ID="TRRightTP" runat="server" Text="0" CssClass="form-control"></asp:Label>
                                                </td>--%>
                                    </tr>

                                    <tr id="Tr1" runat="server" visible="true">
                                        <td style="width: 25%; font-weight: bold" align="left">Carry Left :
                                        </td>
                                        <td style="width: 25%" align="center">
                                            <asp:Label ID="Label31" runat="server" Text="0" CssClass="form-control"></asp:Label>
                                        </td>
                                        <td style="width: 25%" align="left">
                                            <asp:Label ID="Label33" runat="server" Text="0" CssClass="form-control"></asp:Label>
                                        </td>
                                        <%-- <td style="width:25%" align="center">
                                                    <asp:Label ID="TRLeftTC" runat="server" Text="0" CssClass="form-control"></asp:Label>
                                                </td> --%>
                                    </tr>

                                    <tr id="Tr2" runat="server" visible="true">
                                        <td style="width: 25%; font-weight: bold" align="left">Crry Right :
                                        </td>
                                        <td style="width: 25%; font-weight: bold" align="center">
                                            <asp:Label ID="Label34" runat="server" Text="0" CssClass="form-control"></asp:Label>
                                        </td>
                                        <td style="width: 25%" align="left">
                                            <asp:Label ID="Label35" runat="server" Text="0" CssClass="form-control"></asp:Label>
                                        </td>
                                        <%--   <td style="width:25%" align="center">
                                                    <asp:Label ID="Label36" runat="server" Text="0" CssClass="form-control"></asp:Label>
                                                </td> --%>
                                    </tr>

                                </table>


                            </div>

                        </div>
                    </div>
                </div>
            </td>
            <td style="border: 0px ridge gray; width: 50%" align="center">
                <div class="portlet box blue">
                    <div class="portlet-title">
                        <div class="caption" align="center">
                            <i class="fa fa-comments"></i>All Bussiness (Matching bussiness)
                        </div>
                        <div class="tools">
                            <a href="javascript:;" class="collapse"></a>
                            <a href="#portlet-config" data-toggle="modal" class="config"></a>
                            <a href="javascript:;" class="reload"></a>
                            <a href="javascript:;" class="remove"></a>
                        </div>
                    </div>
                    <div class="portlet-body">
                        <div class="table-responsive">
                            <div class="portlet-body" style="overflow: auto;">
                                <asp:Label ID="Label37" runat="server" Text=""></asp:Label>
                                <table class="table table-bordered table-hover">
                                    <tr>
                                        <td style="width: 25%" align="left"></td>
                                        <td style="width: 25%; font-weight: bold" align="center">Total PV's
                                        </td>
                                        <td style="width: 25%; font-weight: bold" align="left">Total ID's
                                        </td>
                                        <%--<td style="width:25%; font-weight:bold" align="center">
                                                   Total Registration
                                                </td> --%>
                                    </tr>

                                    <tr>
                                        <td style="width: 25%; font-weight: bold" align="left">Left Side :
                                        </td>
                                        <td style="width: 25%" align="center">
                                            <asp:Label ID="Label38" runat="server" Text="0" CssClass="form-control"></asp:Label>
                                        </td>
                                        <td style="width: 25%" align="left">
                                            <asp:Label ID="Label39" runat="server" Text="0" CssClass="form-control"></asp:Label>
                                        </td>
                                        <%--<td style="width:25%" align="center">
                                                    <asp:Label ID="ARLeftTP" runat="server" Text="0" CssClass="form-control"></asp:Label>
                                                </td> --%>
                                    </tr>

                                    <tr>
                                        <td style="width: 25%; font-weight: bold" align="left">Right Side:
                                        </td>
                                        <td style="width: 25%; font-weight: bold" align="center">
                                            <asp:Label ID="Label40" runat="server" Text="0" CssClass="form-control"></asp:Label>
                                        </td>
                                        <td style="width: 25%" align="left">
                                            <asp:Label ID="Label41" runat="server" Text="0" CssClass="form-control"></asp:Label>
                                        </td>
                                        <%--  <td style="width:25%" align="center">
                                                    <asp:Label ID="ARRightTP" runat="server" Text="0" CssClass="form-control"></asp:Label>
                                                </td> --%>
                                    </tr>

                                    <tr id="Tr3" runat="server" visible="true">
                                        <td style="width: 25%; font-weight: bold" align="left">Carry Left :
                                        </td>
                                        <td style="width: 25%" align="center">
                                            <asp:Label ID="Label42" runat="server" Text="0" CssClass="form-control"></asp:Label>
                                        </td>
                                        <td style="width: 25%" align="left">
                                            <asp:Label ID="Label43" runat="server" Text="0" CssClass="form-control"></asp:Label>
                                        </td>
                                        <%-- <td style="width:25%" align="center">
                                                    <asp:Label ID="Label44" runat="server" Text="0" CssClass="form-control"></asp:Label>
                                                </td> --%>
                                    </tr>

                                    <tr id="Tr4" runat="server" visible="true">
                                        <td style="width: 25%; font-weight: bold" align="left">Carry Right :
                                        </td>
                                        <td style="width: 25%; font-weight: bold" align="center">
                                            <asp:Label ID="Label45" runat="server" Text="0" CssClass="form-control"></asp:Label>
                                        </td>
                                        <td style="width: 25%" align="left">
                                            <asp:Label ID="Label46" runat="server" Text="0" CssClass="form-control"></asp:Label>
                                        </td>
                                        <%-- <td style="width:25%" align="center">
                                                    <asp:Label ID="Label47" runat="server" Text="0" CssClass="form-control"></asp:Label>
                                                </td>--%>
                                    </tr>
                                </table>


                            </div>

                        </div>
                    </div>
                </div>
            </td>
        </tr>
    </table>




    <%--==========================================================================================================================--%>

    <table class="table table-bordered table-hover" style="border: 0px ridge gray;" runat="server" visible="false">
        <tr>
            <td style="border: 0px ridge gray; width: 50%" align="center">
                <div class="portlet box blue">
                    <div class="portlet-title">
                        <div class="caption" align="center">
                            <i class="fa fa-comments"></i>Today's Directs
                        </div>
                        <div class="tools">
                            <a href="javascript:;" class="collapse"></a>
                            <a href="#portlet-config" data-toggle="modal" class="config"></a>
                            <a href="javascript:;" class="reload"></a>
                            <a href="javascript:;" class="remove"></a>
                        </div>
                    </div>
                    <div class="portlet-body">
                        <div class="table-responsive">
                            <div class="portlet-body" style="overflow: auto;">
                                <asp:Label ID="Label22" runat="server" Text=""></asp:Label>
                                <table class="table table-bordered table-hover">
                                    <tr>
                                        <%--  <td style="width:25%" align="left">
                                                    
                                                </td> --%>
                                        <td style="width: 25%; font-weight: bold" align="center">Paid Directs
                                        </td>
                                        <td style="width: 25%; font-weight: bold" align="left">Unpaid Directs
                                        </td>
                                        <td style="width: 25%; font-weight: bold" align="center">Total Directs
                                        </td>
                                    </tr>

                                    <tr>
                                        <%-- <td style="width:25%; font-weight:bold" align="left">
                                                   Left :
                                                </td> --%>
                                        <td style="width: 25%" align="center">
                                            <asp:Label ID="TDLeftP" runat="server" Text="0" CssClass="form-control"></asp:Label>
                                        </td>
                                        <td style="width: 25%" align="left">
                                            <asp:Label ID="TDLeftU" runat="server" Text="0" CssClass="form-control"></asp:Label>
                                        </td>
                                        <td style="width: 25%" align="center">
                                            <asp:Label ID="TDLeftT" runat="server" Text="0" CssClass="form-control"></asp:Label>
                                        </td>
                                    </tr>




                                </table>


                            </div>

                        </div>
                    </div>
                </div>
            </td>
            <td style="border: 0px ridge gray; width: 50%" align="center">
                <div class="portlet box blue">
                    <div class="portlet-title">
                        <div class="caption" align="center">
                            <i class="fa fa-comments"></i>All Directs
                        </div>
                        <div class="tools">
                            <a href="javascript:;" class="collapse"></a>
                            <a href="#portlet-config" data-toggle="modal" class="config"></a>
                            <a href="javascript:;" class="reload"></a>
                            <a href="javascript:;" class="remove"></a>
                        </div>
                    </div>
                    <div class="portlet-body">
                        <div class="table-responsive">
                            <div class="portlet-body" style="overflow: auto;">
                                <asp:Label ID="Label32" runat="server" Text=""></asp:Label>
                                <table class="table table-bordered table-hover">
                                    <tr>
                                        <%-- <td style="width:25%" align="left">
                                                    
                                                </td> --%>
                                        <td style="width: 25%; font-weight: bold" align="center">Paid Directs
                                        </td>
                                        <td style="width: 25%; font-weight: bold" align="left">Unpaid Directs
                                        </td>
                                        <td style="width: 25%; font-weight: bold" align="center">Total Directs
                                        </td>
                                    </tr>

                                    <tr>
                                        <%-- <td style="width:25%; font-weight:bold" align="left">
                                                   Left :
                                                </td> --%>
                                        <td style="width: 25%" align="center">
                                            <asp:Label ID="ADLeftP" runat="server" Text="0" CssClass="form-control"></asp:Label>
                                        </td>
                                        <td style="width: 25%" align="left">
                                            <asp:Label ID="ADLeftU" runat="server" Text="0" CssClass="form-control"></asp:Label>
                                        </td>
                                        <td style="width: 25%" align="center">
                                            <asp:Label ID="ADLeftT" runat="server" Text="0" CssClass="form-control"></asp:Label>
                                        </td>
                                    </tr>

                                </table>


                            </div>

                        </div>
                    </div>
                </div>
            </td>
        </tr>
    </table>

    <%--==========================================================================================================================--%>


    <%--Product Master--%>
    <div class="portlet box blue" runat="server" visible="true">
        <div class="portlet-title">
            <div class="caption" align="center">
                <i class="fa fa-comments"></i>ID Counts
            </div>
            <div class="tools">
                <a href="javascript:;" class="collapse"></a>
                <a href="#portlet-config" data-toggle="modal" class="config"></a>
                <a href="javascript:;" class="reload"></a>
                <a href="javascript:;" class="remove"></a>
            </div>
        </div>
        <div class="portlet-body">
            <div class="table-responsive">

                <div class="portlet-body" style="overflow: auto;">
                    <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
                    <table class="table table-bordered table-hover">
                        <tbody>
                            <table class="table table-bordered table-hover">

                                <tr>
                                    <td style="width: 11%" align="center">My Direct
                                    </td>
                                    <td style="width: 11%" align="center">Direct Left ID
                                    </td>
                                    <td style="width: 11%" align="center">Direct Left PV
                                    </td>
                                    <td style="width: 11%" align="center">Direct Right ID
                                    </td>
                                    <td style="width: 11%" align="center">Direct Right PV
                                    </td>
                                    <td style="width: 11%" align="center">Total Team 
                                    </td>

                                </tr>

                                <tr>
                                    <td style="width: 11%" align="center">
                                        <asp:Label ID="ibldirect" runat="server" Text="" CssClass="form-control"></asp:Label>
                                    </td>
                                    <td style="width: 11%" align="center">
                                        <asp:Label ID="iblleftdirect" runat="server" Text="" CssClass="form-control"></asp:Label>
                                    </td>
                                    <td style="width: 11%" align="center">
                                        <asp:Label ID="leftdirectpv" runat="server" Text="" CssClass="form-control"></asp:Label>
                                    </td>
                                    <td style="width: 11%" align="center">
                                        <asp:Label ID="iblrightdirect" runat="server" Text="" CssClass="form-control"></asp:Label>
                                    </td>
                                    <td style="width: 11%" align="center">
                                        <asp:Label ID="rightdirectpv" runat="server" Text="" CssClass="form-control"></asp:Label>
                                    </td>
                                    <td style="width: 11%" align="center">
                                        <asp:Label ID="ibltotal" runat="server" Text="" CssClass="form-control"></asp:Label>
                                    </td>

                                </tr>

                            </table>
                            </td>
                                   
                                </tr>
                                
                        </tbody>
                    </table>


                </div>

            </div>
        </div>
    </div>
    <%--end table--%>
    <div id="Div1" class="portlet box blue" runat="server" visible="true">
        <div class="portlet-title">
            <div class="caption" align="center">
                <i class="fa fa-comments"></i>Repuchase Bussiness
            </div>
            <div class="tools">
                <a href="javascript:;" class="collapse"></a>
                <a href="#portlet-config" data-toggle="modal" class="config"></a>
                <a href="javascript:;" class="reload"></a>
                <a href="javascript:;" class="remove"></a>
            </div>
        </div>
        <div class="portlet-body">
            <div class="table-responsive">

                <div class="portlet-body" style="overflow: auto;">
                    <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
                    <table class="table table-bordered table-hover">
                        <tbody>
                            <table class="table table-bordered table-hover">

                                <tr>
                                    <td style="width: 11%" align="center">Left ID
                                    </td>
                                    <td style="width: 11%" align="center">Left PV
                                    </td>
                                    <td style="width: 11%" align="center">Right ID
                                    </td>
                                    <td style="width: 11%" align="center">Right PV
                                    </td>
                                    <td style="width: 11%" align="center">Carry Left PV
                                    </td>
                                    <td style="width: 11%" align="center">Carry Right PV
                                    </td>

                                </tr>

                                <tr>
                                    <td style="width: 11%" align="center">
                                        <asp:Label ID="IblLeftcount" runat="server" Text="" CssClass="form-control"></asp:Label>
                                    </td>
                                    <td style="width: 11%" align="center">
                                        <asp:Label ID="Iblleftpv" runat="server" Text="" CssClass="form-control"></asp:Label>
                                    </td>
                                    <td style="width: 11%" align="center">
                                        <asp:Label ID="Iblrightcount" runat="server" Text="" CssClass="form-control"></asp:Label>
                                    </td>
                                    <td style="width: 11%" align="center">
                                        <asp:Label ID="IblRightpv" runat="server" Text="" CssClass="form-control"></asp:Label>
                                    </td>
                                    <td style="width: 11%" align="center">
                                        <asp:Label ID="caryleftrv" runat="server" Text="" CssClass="form-control"></asp:Label>
                                    </td>
                                    <td style="width: 11%" align="center">
                                        <asp:Label ID="caryrightrv" runat="server" Text="" CssClass="form-control"></asp:Label>
                                    </td>

                                </tr>

                            </table>
                            </td>
                                   
                                </tr>
                                
                        </tbody>
                    </table>


                </div>

            </div>
        </div>
    </div>
    <%--end table--%>
    <div id="Div2" class="portlet box blue" runat="server" visible="true">
        <div class="portlet-title">
            <div class="caption" align="center">
                <i class="fa fa-comments"></i>Matching Bussiness
            </div>
            <div class="tools">
                <a href="javascript:;" class="collapse"></a>
                <a href="#portlet-config" data-toggle="modal" class="config"></a>
                <a href="javascript:;" class="reload"></a>
                <a href="javascript:;" class="remove"></a>
            </div>
        </div>
        <div class="portlet-body">
            <div class="table-responsive">

                <div class="portlet-body" style="overflow: auto;">
                    <asp:Label ID="Label15" runat="server" Text=""></asp:Label>
                    <table class="table table-bordered table-hover">
                        <tbody>
                            <table class="table table-bordered table-hover">

                                <tr>
                                    <td style="width: 11%" align="center">Left ID
                                    </td>
                                    <td style="width: 11%" align="center">Left PV
                                    </td>
                                    <td style="width: 11%" align="center">Right ID 
                                    </td>
                                    <td style="width: 11%" align="center">Right PV
                                    </td>
                                    <td style="width: 11%" align="center">Carry Left PV
                                    </td>
                                    <td style="width: 11%" align="center">Carry Right PV
                                    </td>

                                </tr>

                                <tr>
                                    <td style="width: 11%" align="center">
                                        <asp:Label ID="leftcount" runat="server" Text="" CssClass="form-control"></asp:Label>
                                    </td>
                                    <td style="width: 11%" align="center">
                                        <asp:Label ID="rightcount" runat="server" Text="" CssClass="form-control"></asp:Label>
                                    </td>
                                    <td style="width: 11%" align="center">
                                        <asp:Label ID="leftpv" runat="server" Text="" CssClass="form-control"></asp:Label>
                                    </td>
                                    <td style="width: 11%" align="center">
                                        <asp:Label ID="rightpv" runat="server" Text="" CssClass="form-control"></asp:Label>
                                    </td>
                                    <td style="width: 11%" align="center">
                                        <asp:Label ID="caryleftpv" runat="server" Text="" CssClass="form-control"></asp:Label>
                                    </td>
                                    <td style="width: 11%" align="center">
                                        <asp:Label ID="caryrightpv" runat="server" Text="" CssClass="form-control"></asp:Label>
                                    </td>

                                </tr>

                            </table>
                            </td>
                                   
                                </tr>
                                
                        </tbody>
                    </table>



                </div>

            </div>
        </div>
    </div>

    <div id="Div3" class="portlet box blue" runat="server" visible="true">
        <div class="portlet-title">
            <div class="caption text-center">
                <i class="fa fa-comments"></i>Monthly Performance Incentive
            </div>

        </div>

        <table class="table table-dark table-bordered text-left" style="border-radius: 8px;">
            <thead>
                <tr>
                    <th scope="col">Rank</th>
                    <th scope="col">Left PV</th>
                    <th scope="col">Right PV</th>
                    <th scope="col">Achive Left PV</th>
                    <th scope="col">Achive Right PV</th>
                    <th scope="col">MPI</th>
                </tr>
            </thead>
            <tbody>
                <tr id="trBronzeDirector" runat="server">
                    <th scope="row">Bronze Director</th>
                    <td>200</td>
                    <td>100</td>
                    <td>
                        <asp:Label ID="LeftDisValue" runat="server" Text="" CssClass="form-control"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="RightDisValue" runat="server" Text="" CssClass="form-control"></asp:Label>
                    </td>
                    <td><span>
                        <asp:Label ID="First_td_Status" runat="server" Text="" CssClass="form-control"></asp:Label></span></td>
                </tr>

                <tr id="trSilverDirector" runat="server">
                    <th scope="row">Silver Director</th>
                    <td>600</td>
                    <td>300</td>
                    <td>
                        <asp:Label ID="trtSilver" runat="server" Text="" CssClass="form-control"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label8" runat="server" Text="" CssClass="form-control"></asp:Label>
                    </td>
                    <td><span>
                        <asp:Label ID="Second_td_Status" runat="server" CssClass="form-control"></asp:Label></span></td>
                </tr>

                <tr>
                    <th scope="row">Gold Director</th>
                    <td>1200</td>
                    <td>600</td>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="" CssClass="form-control"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label9" runat="server" Text="" CssClass="form-control"></asp:Label>
                    </td>
                    <td><span>
                        <asp:Label ID="Third_td_Status" runat="server" CssClass="form-control"></asp:Label></span></td>
                </tr>
                <tr>
                    <th scope="row">Platinum Director</th>
                    <td>2400</td>
                    <td>1200</td>
                    <td>
                        <asp:Label ID="Label23" runat="server" Text="" CssClass="form-control"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label24" runat="server" Text="" CssClass="form-control"></asp:Label>
                    </td>
                    <td><span>
                        <asp:Label ID="Fourth_td_Status" runat="server" CssClass="form-control"></asp:Label></span></td>
                </tr>
                <tr>
                    <th scope="row">Pearl Director</th>
                    <td>4800</td>
                    <td>2400</td>
                    <td>
                        <asp:Label ID="Label25" runat="server" Text="" CssClass="form-control"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label44" runat="server" Text="" CssClass="form-control"></asp:Label>
                    </td>
                    <td><span>
                        <asp:Label ID="Fifth_td_Status" runat="server" CssClass="form-control"></asp:Label></span></td>
                </tr>
                <tr>
                    <th scope="row">Emerald Director</th>
                    <td>12000</td>
                    <td>6000</td>
                    <td>
                        <asp:Label ID="Label47" runat="server" Text="" CssClass="form-control"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label48" runat="server" Text="" CssClass="form-control"></asp:Label>
                    </td>
                    <td><span>
                        <asp:Label ID="Sixth_td_Status" runat="server" CssClass="form-control"></asp:Label></span></td>
                </tr>
                <tr>
                    <th scope="row">Topaz Director</th>
                    <td>24000</td>
                    <td>12000</td>
                    <td>
                        <asp:Label ID="Label49" runat="server" Text="" CssClass="form-control"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label50" runat="server" Text="" CssClass="form-control"></asp:Label>
                    </td>
                    <td><span>
                        <asp:Label ID="Label10" runat="server" CssClass="form-control"></asp:Label></span></td>
                </tr>
                <tr>
                    <th scope="row">Skyblue Director</th>
                    <td>48000</td>
                    <td>24000</td>
                    <td>
                        <asp:Label ID="Label51" runat="server" Text="" CssClass="form-control"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label52" runat="server" Text="" CssClass="form-control"></asp:Label>
                    </td>
                    <td><span>
                        <asp:Label ID="Label11" runat="server" CssClass="form-control"></asp:Label></span></td>
                </tr>
                <tr>
                    <th scope="row">Opal Star Director</th>
                    <td>96000</td>
                    <td>48000</td>
                    <td>
                        <asp:Label ID="Label53" runat="server" Text="" CssClass="form-control"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label54" runat="server" Text="" CssClass="form-control"></asp:Label>
                    </td>
                    <td><span>
                        <asp:Label ID="Label3" runat="server" CssClass="form-control"></asp:Label></span></td>
                </tr>
                <tr>
                    <th scope="row">Diamond Director</th>
                    <td>192000</td>
                    <td>96000</td>
                    <td>
                        <asp:Label ID="Label55" runat="server" Text="" CssClass="form-control"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label56" runat="server" Text="" CssClass="form-control"></asp:Label>
                    </td>
                    <td><span>
                        <asp:Label ID="Label13" runat="server" CssClass="form-control"></asp:Label></span></td>
                </tr>
                <tr>
                    <th scope="row">Blue Director</th>
                    <td>384000</td>
                    <td>192000</td>
                    <td>
                        <asp:Label ID="Label57" runat="server" Text="" CssClass="form-control"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label58" runat="server" Text="" CssClass="form-control"></asp:Label>
                    </td>
                    <td><span>
                        <asp:Label ID="Label14" runat="server" CssClass="form-control"></asp:Label></span></td>
                </tr>
                <tr>
                    <th scope="row">Black Director</th>
                    <td>768000</td>
                    <td>384000</td>
                    <td>
                        <asp:Label ID="Label59" runat="server" Text="" CssClass="form-control"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label60" runat="server" Text="" CssClass="form-control"></asp:Label>
                    </td>
                    <td><span>
                        <asp:Label ID="Label6" runat="server" CssClass="form-control"></asp:Label></span></td>
                </tr>
                <tr>
                    <th scope="row">Royal Director</th>
                    <td>1536000</td>
                    <td>768000</td>
                    <td>
                        <asp:Label ID="Label61" runat="server" Text="" CssClass="form-control"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label62" runat="server" Text="" CssClass="form-control"></asp:Label>
                    </td>
                    <td><span>
                        <asp:Label ID="Label16" runat="server" CssClass="form-control"></asp:Label></span></td>
                </tr>
                <tr>
                    <th scope="row">Crown Diamond Director</th>
                    <td>3072000</td>
                    <td>1536000</td>
                    <td>
                        <asp:Label ID="Label63" runat="server" Text="" CssClass="form-control"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label64" runat="server" Text="" CssClass="form-control"></asp:Label>
                    </td>
                    <td><span>
                        <asp:Label ID="Label17" runat="server" CssClass="form-control"></asp:Label></span></td>
                </tr>
                <tr>
                    <th scope="row">Ambassador Director</th>
                    <td>6133000</td>
                    <td>3072000</td>
                    <td>
                        <asp:Label ID="Label65" runat="server" Text="" CssClass="form-control"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label66" runat="server" Text="" CssClass="form-control"></asp:Label>
                    </td>
                    <td><span>
                        <asp:Label ID="Label18" runat="server" CssClass="form-control"></asp:Label></span></td>
                </tr>
                <tr>
                    <th scope="row">Royal Ambassador Director</th>
                    <td>12288000</td>
                    <td>6133000</td>
                    <td>
                        <asp:Label ID="Label67" runat="server" Text="" CssClass="form-control"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label68" runat="server" Text="" CssClass="form-control"></asp:Label>
                    </td>
                    <td><span>
                        <asp:Label ID="Label19" runat="server" CssClass="form-control"></asp:Label></span></td>
                </tr>
                <tr>
                    <th scope="row">Crown Ambassador Director</th>
                    <td>24276000</td>
                    <td>12288000</td>
                    <td>
                        <asp:Label ID="Label69" runat="server" Text="" CssClass="form-control"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label70" runat="server" Text="" CssClass="form-control"></asp:Label>
                    </td>
                    <td><span>
                        <asp:Label ID="Label20" runat="server" CssClass="form-control"></asp:Label></span></td>
                </tr>
                <tr>
                    <th scope="row">Brand Ambassador Director</th>
                    <td>49152000</td>
                    <td>24276000</td>
                    <td>
                        <asp:Label ID="Label71" runat="server" Text="" CssClass="form-control"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label72" runat="server" Text="" CssClass="form-control"></asp:Label>
                    </td>
                    <td><span>
                        <asp:Label ID="Label21" runat="server" CssClass="form-control"></asp:Label></span></td>
                </tr>
            </tbody>
        </table>
    </div>
    </div>
</div>

</asp:Content>

