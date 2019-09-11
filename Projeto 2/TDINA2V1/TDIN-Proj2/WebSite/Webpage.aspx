﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Webpage.aspx.cs" Inherits="WebSite.Webpage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Trouble tickets</title>
    <style type="text/css">
        .column {
            float: left;
            width: 40%;
        }
        .row:after {
            content: "";
            display: table;
            clear: both;

        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <font color="red"><h2><asp:Label ID="warningLabel" runat="server" Text=""></asp:Label></h2></font>   
        
        <div class="row">
             <div class="column">
                 <h1>Create new Ticket</h1>
                 <p>Name</p>
                 <asp:TextBox ID="nameTextBox" runat="server" Width="399px"></asp:TextBox>
                 <p>Email</p>
                 <asp:TextBox ID="emailTextBox" runat="server" Width="399px"></asp:TextBox>
                 
                 <p>&nbsp;</p>
                 <p>Problem Title</p>
                 <asp:TextBox ID="TitleText" runat="server" Width="399px"></asp:TextBox>
                 <p>Problem description</p>
                 <asp:TextBox ID="DescriptionText" runat="server" Height="200px" OnTextChanged="TextBox2_TextChanged" Width="400px" TextMode="MultiLine"></asp:TextBox>
                 <br />
                 <asp:Button ID="EnviarBtn" runat="server" Text="Send" OnClick="SendTicket" Width="407px" />

             </div>
             
             <div class="column">
                 <h1>Ticket status</h1>
                 <asp:DropDownList ID="workersDropDownList" runat="server" Width="490px" AutoPostBack="True" OnSelectedIndexChanged="workersDropDownList_SelectedIndexChanged">
                 </asp:DropDownList>
                 <p class="spaceVert"/>
                 <asp:ListBox ID="workersQuestionsListBox" runat="server" Height="200px" Width="490px"></asp:ListBox>
                 <p class="spaceVert"/>
                 <asp:Button ID="reloadBtn" runat="server" OnClick="ReloadBtn_Click" Text="Reload status" Width="490px" />
                 </div>
         </div> 
        
        <p>
            <asp:Label ID="DebugLabel" runat="server" Text=""></asp:Label>
            
        </p>
    </form>
</body>

<script type="text/javascript">
    function reload() {
        $("#reloadBtn").click();
    }
</script>


</html>
