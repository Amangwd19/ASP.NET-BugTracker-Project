 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tickets2.aspx.cs" Inherits="BugTracker.Tickets2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
<head runat="server">


  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
   <link href="Views/Shared/_Layout.cshtml"  />

    <title></title>
</head>
<body>
     <div>
        <center>
            <h1> <u>Manage Project </u></h1>
        </center>
    </div>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gvTickets" runat="server" CellPadding="4" Width="1145px" AutoGenerateColumns="false" ShowFooter="true" DataKeyNames="project_id" ShowHeaderWhenEmpty="true" OnRowCommand="gvTickets_RowCommand" OnRowEditing="gvTickets_RowEditing" OnRowCancelingEdit="gvTickets_RowCancelingEdit" OnRowUpdating="gvTickets_RowUpdating" OnRowDeleting="gvTickets_RowDeleting" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px">

                <FooterStyle BackColor="#99CCCC" ForeColor="#003399"></FooterStyle>

                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF"></HeaderStyle>

                <PagerStyle HorizontalAlign="Left" BackColor="#99CCCC" ForeColor="#003399"></PagerStyle>

                <RowStyle BackColor="White" ForeColor="#003399"></RowStyle>

                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99"></SelectedRowStyle>

                <SortedAscendingCellStyle BackColor="#EDF6F6"></SortedAscendingCellStyle>

                <SortedAscendingHeaderStyle BackColor="#0D4AC4"></SortedAscendingHeaderStyle>

                <SortedDescendingCellStyle BackColor="#D6DFDF"></SortedDescendingCellStyle>

                <SortedDescendingHeaderStyle BackColor="#002876"></SortedDescendingHeaderStyle>



                <Columns>
                    <asp:TemplateField HeaderText="Project ID">
                        <ItemTemplate>
                            <asp:Label Text='<%#Eval("project_id") %>' runat="server" />
                        </ItemTemplate>

                        <EditItemTemplate>
                            <asp:TextBox ID="txtProjectId" Text='<%# Eval("project_id") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtProjectIdFooter" runat="server" />
                        </FooterTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Project Name">
                        <ItemTemplate>
                            <asp:Label Text='<%#Eval("project_name") %>' runat="server" />
                        </ItemTemplate>

                        <EditItemTemplate>
                            <asp:TextBox ID="txtProjectName" Text='<%# Eval("project_name") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtProjectNameFooter" runat="server" />
                        </FooterTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Project Description">
                        <ItemTemplate>
                            <asp:Label Text='<%#Eval("project_desc") %>' runat="server" />
                        </ItemTemplate>

                        <EditItemTemplate>
                            <asp:TextBox ID="txtProjectdesc" Text='<%# Eval("project_desc") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtProjectdescFooter" runat="server" />
                        </FooterTemplate>

                    </asp:TemplateField>







                    <asp:TemplateField HeaderText="Project Status">
                        <ItemTemplate>
                            <asp:Label Text='<%#Eval("project_status") %>' runat="server" />
                        </ItemTemplate>

                        <EditItemTemplate>
                            <asp:TextBox ID="txtProjectStatus" Text='<%# Eval("project_status") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtProjectStatusFooter" runat="server" />
                        </FooterTemplate>

                    </asp:TemplateField>



                    <asp:TemplateField HeaderText="User ID">
                        <ItemTemplate>
                            <asp:Label Text='<%#Eval("user_id") %>' runat="server" />
                        </ItemTemplate>

                        <EditItemTemplate>
                            <asp:TextBox ID="txtUserId" Text='<%# Eval("user_id") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtUserIdFooter" runat="server" />
                        </FooterTemplate>

                    </asp:TemplateField>



                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="~/Content/buttonImages/edit2.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="60px" Height="20px" />
                            <asp:ImageButton ImageUrl="~/Content/buttonImages/delete2.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="60px" Height="20px" />
                        </ItemTemplate>

                        <EditItemTemplate>
                            <asp:ImageButton ImageUrl="~/Content/buttonImages/save.png" runat="server" CommandName="Update" ToolTip="Update" Width="60px" Height="20px" />
                            <asp:ImageButton ImageUrl="~/Content/buttonImages/close.png" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="60px" Height="20px" />

                        </EditItemTemplate>

                        <FooterTemplate>
                            <asp:ImageButton ImageUrl="~/Content/buttonImages/plus.png" runat="server" CommandName="Add" ToolTip="Add" Width="20px" Height="20px" />


                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>






            </asp:GridView>

            <br />
            <asp:Label ID="lblSuccessMessage" Text="" runat="server" ForeColor="Green" />
            <br />
            <asp:Label ID="lblErrorMessage" Text="" runat="server" ForeColor="Red" />
           
        </div>
    </form>
</body>
</html>
