
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="BugTracker.Users" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
<head runat="server">
    <title></title>
     <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

</head>
<body>
    <div>
        <center>
            <h1><u>Manage User</u> </h1>
        </center>
    </div>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gvUsers" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false" ShowFooter="true" DataKeyNames="id" ShowHeaderWhenEmpty="true" OnRowCommand="gvUsers_RowCommand" OnRowEditing="gvUsers_RowEditing" OnRowCancelingEdit="gvUsers_RowCancelingEdit" OnRowUpdating="gvUsers_RowUpdating" OnRowDeleting="gvUsers_RowDeleting">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775"  ></AlternatingRowStyle>

                <EditRowStyle BackColor="#999999"></EditRowStyle>

                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>

                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>

                <PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>

                <RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

                <SortedAscendingCellStyle BackColor="#E9E7E2"></SortedAscendingCellStyle>

                <SortedAscendingHeaderStyle BackColor="#506C8C"></SortedAscendingHeaderStyle>

                <SortedDescendingCellStyle BackColor="#FFFDF8"></SortedDescendingCellStyle>

                <SortedDescendingHeaderStyle BackColor="#6F8DAE"></SortedDescendingHeaderStyle>





                
                           <Columns>
                    <asp:TemplateField HeaderText=" ID">
                        <ItemTemplate>
                            <asp:Label Text='<%#Eval("id") %>' runat="server" />
                        </ItemTemplate>

                        <EditItemTemplate>
                            <asp:TextBox ID="txtId" Text='<%# Eval("id") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtIdFooter" runat="server" />
                        </FooterTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Email ID">
                        <ItemTemplate>
                            <asp:Label Text='<%#Eval("email_id") %>' runat="server" />
                        </ItemTemplate>

                        <EditItemTemplate>
                            <asp:TextBox ID="txtEmailId" Text='<%# Eval("email_id") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtEmailIdFooter" runat="server" />
                        </FooterTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Password">
                        <ItemTemplate>
                            <asp:Label Text='<%#Eval("password") %>' runat="server" />
                        </ItemTemplate>

                        <EditItemTemplate>
                            <asp:TextBox ID="txtPassword" Text='<%# Eval("password") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtPasswordFooter" runat="server" />
                        </FooterTemplate>

                    </asp:TemplateField>







                    <asp:TemplateField HeaderText="Role">
                        <ItemTemplate>
                            <asp:Label Text='<%#Eval("role") %>' runat="server" />
                        </ItemTemplate>

                        <EditItemTemplate>
                            <asp:TextBox ID="txtRole" Text='<%# Eval("role") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtRoleFooter" runat="server" />
                        </FooterTemplate>

                    </asp:TemplateField>



                    <asp:TemplateField HeaderText=" Username">
                        <ItemTemplate>
                            <asp:Label Text='<%#Eval("user_name") %>' runat="server" />
                        </ItemTemplate>

                        <EditItemTemplate>
                            <asp:TextBox ID="txtUsername" Text='<%# Eval("user_name") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtUsernameFooter" runat="server" />
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
