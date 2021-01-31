<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bugs.aspx.cs" Inherits="BugTracker.Bugs" %>

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
            <h1> <u>Manage Tickets </u></h1>
        </center>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gvBugs" runat="server" CellPadding="4" AutoGenerateColumns="false" ShowFooter="true" DataKeyNames="bug_id" ShowHeaderWhenEmpty="true" OnRowCommand="gvBugs_RowCommand" OnRowEditing="gvBugs_RowEditing" OnRowCancelingEdit="gvBugs_RowCancelingEdit" OnRowUpdating="gvBugs_RowUpdating" OnRowDeleting="gvBugs_RowDeleting" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
                <EditRowStyle BackColor="#999999"></EditRowStyle>

                <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>

                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>

                <PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>

                <RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

                <SortedAscendingCellStyle BackColor="#E9E7E2"></SortedAscendingCellStyle>

                <SortedAscendingHeaderStyle BackColor="#506C8C"></SortedAscendingHeaderStyle>

                <SortedDescendingCellStyle BackColor="#FFFDF8"></SortedDescendingCellStyle>

                <SortedDescendingHeaderStyle BackColor="#6F8DAE"></SortedDescendingHeaderStyle>

                           <Columns>
                    <asp:TemplateField HeaderText="Bug ID">
                        <ItemTemplate>
                            <asp:Label Text='<%#Eval("bug_id") %>' runat="server" />
                        </ItemTemplate>

                        <EditItemTemplate>
                            <asp:TextBox ID="txtBugId" Text='<%# Eval("bug_id") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtBugIdFooter" runat="server" />
                        </FooterTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Bug Description">
                        <ItemTemplate>
                            <asp:Label Text='<%#Eval("bug_desc") %>' runat="server" />
                        </ItemTemplate>

                        <EditItemTemplate>
                            <asp:TextBox ID="txtBugDesc" Text='<%# Eval("bug_desc") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtBugDescFooter" runat="server" />
                        </FooterTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Bug Priority">
                        <ItemTemplate>
                            <asp:Label Text='<%#Eval("bug_priority") %>' runat="server" />
                        </ItemTemplate>

                        <EditItemTemplate>
                            <asp:TextBox ID="txtBugPriority" Text='<%# Eval("bug_priority") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtBugPriorityFooter" runat="server" />
                        </FooterTemplate>

                    </asp:TemplateField>







                    <asp:TemplateField HeaderText="Project Status">
                        <ItemTemplate>
                            <asp:Label Text='<%#Eval("bug_status") %>' runat="server" />
                        </ItemTemplate>

                        <EditItemTemplate>
                            <asp:TextBox ID="txtBugStatus" Text='<%# Eval("bug_status") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtBugStatusFooter" runat="server" />
                        </FooterTemplate>

                    </asp:TemplateField>



                    <asp:TemplateField HeaderText=" Project_id">
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


                    <asp:TemplateField HeaderText=" User_id">
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
