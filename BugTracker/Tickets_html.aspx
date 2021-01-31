<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tickets_html.aspx.cs" Inherits="BugTracker.Tickets_html" %>

<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">

 


<head runat="server">
    
  <title>Tickets Information</title>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <center>
                <h1>
                    Tickets Information
                </h1>
                <hr />
                <asp:Panel ID="Panel1" runat="server" class="panel panel-info" >
                </asp:Panel>
            </center>
        </div>
    </form>
</body>
</html>
