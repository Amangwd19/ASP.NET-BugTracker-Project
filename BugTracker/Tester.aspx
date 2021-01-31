<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tester.aspx.cs" Inherits="BugTracker.Tester" %>

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
            <h1><u>Manage Tester</u></h1>
        </center>
    </div>
    <form id="form1" runat="server">
        <div>
            <center>
            <asp:GridView ID="gvTesters" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="false" ShowFooter="true" DataKeyNames="tester_id" ShowHeaderWhenEmpty="true" OnRowCommand="gvTesters_RowCommand" OnRowEditing="gvTesters_RowEditing" OnRowCancelingEdit="gvTesters_RowCancelingEdit" OnRowUpdating="gvTesters_RowUpdating" OnRowDeleting="gvTesters_RowDeleting">
                <FooterStyle BackColor="White" ForeColor="#000066"></FooterStyle>

                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White"></HeaderStyle>

                <PagerStyle HorizontalAlign="Left" BackColor="White" ForeColor="#000066"></PagerStyle>

                <RowStyle ForeColor="#000066"></RowStyle>

                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

                <SortedAscendingCellStyle BackColor="#F1F1F1"></SortedAscendingCellStyle>

                <SortedAscendingHeaderStyle BackColor="#007DBB"></SortedAscendingHeaderStyle>

                <SortedDescendingCellStyle BackColor="#CAC9C9"></SortedDescendingCellStyle>

                <SortedDescendingHeaderStyle BackColor="#00547E"></SortedDescendingHeaderStyle>
         
                
                  <Columns>
                    <asp:TemplateField HeaderText="Tester ID">
                        <ItemTemplate>
                            <asp:Label Text='<%#Eval("tester_id") %>' runat="server" />
                        </ItemTemplate>

                        <EditItemTemplate>
                            <asp:TextBox ID="txttesterId" Text='<%# Eval("tester_id") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txttesterIdFooter" runat="server" />
                        </FooterTemplate>

                    </asp:TemplateField>

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

                    <asp:TemplateField HeaderText="Tester Name">
                        <ItemTemplate>
                            <asp:Label Text='<%#Eval("tester_name") %>' runat="server" />
                        </ItemTemplate>

                        <EditItemTemplate>
                            <asp:TextBox ID="txtTester" Text='<%# Eval("tester_name") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtTesterFooter" runat="server" />
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
                </center>

               <br />
            <asp:Label ID="lblSuccessMessage" Text="" runat="server" ForeColor="Green" />
            <br />
            <asp:Label ID="lblErrorMessage" Text="" runat="server" ForeColor="Red" />


        </div>
    </form>
</body>
</html>
