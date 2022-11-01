<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" validateRequest=false %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-6">
        	<h2 class="text-center">Servers</h2>
        	<p class="text-center">
	            <asp:GridView ID="dgridShowData" runat="server" CellPadding="4" ForeColor="#333333" OnSelectedIndexChanged="dgridShowData_SelectedIndexChanged" HorizontalAlign="Center">
	                <AlternatingRowStyle BackColor="White" />
	                <Columns>
	                    <asp:CommandField SelectImageUrl="~/Images/checkmark.png" ShowSelectButton="True" />
	                </Columns>
	                <EditRowStyle BackColor="#7C6F57" />
	                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
	                <HeaderStyle BackColor="#1C4A37" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
	                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
	                <RowStyle BackColor="#D8F1E7" />
	                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
	                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
	            </asp:GridView>
            </p>
        </div>
        <div class="col-md-6">
        	<h2 class="text-center">Applications and Libraries versions</h2>
        	<p class="text-center">
	            <asp:GridView ID="dgridShowVersions" runat="server" CellPadding="4" ForeColor="#333333" HorizontalAlign="Center" OnRowDataBound="dgridShowVersions_RowDataBound">
	                <AlternatingRowStyle BackColor="White" />
	                <EditRowStyle BackColor="#7C6F57" />
	                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
	                <HeaderStyle BackColor="#1C4A37" Font-Bold="True" ForeColor="White" />
	                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
	                <RowStyle BackColor="#D8F1E7" />
	                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
	                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
	            </asp:GridView>
            </p>
        </div>
    </div>
</asp:Content>
