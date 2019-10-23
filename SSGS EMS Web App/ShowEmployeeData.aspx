<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShowEmployeeData.aspx.cs" Inherits="SSGS_EMS_Web_App.ShowEmployeeData" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p> 
        Enter Employee Id:
        <asp:TextBox ID="TextBox1" runat="server" Enabled="False"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="Get  Basic Data" 
            onclick="Button1_Click" />
    </p>
    <p> 
        <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>
       </p>
    <p> 
         <asp:Label ID="Label2" runat="server" Visible="False"></asp:Label></p>
    <p> 
         <asp:Label ID="Label3" runat="server" Visible="False"></asp:Label></p>
         <p> 
         <asp:Label ID="Label4" runat="server" Visible="False"></asp:Label></p>
         <p> 
         <asp:Label ID="Label5" runat="server" Visible="False"></asp:Label></p>
         <p>
         
             <asp:Button ID="Button2" runat="server" Text="Get Extended Data" 
                 onclick="Button2_Click" Visible="False" />
         
         </p>
         <p> 
         <asp:Label ID="Label6" runat="server" Visible="False"></asp:Label></p>
         <p> 
         <asp:Label ID="Label7" runat="server" Visible="False"></asp:Label></p>
         <p> 
         <asp:Label ID="Label8" runat="server" Visible="False"></asp:Label></p>
    <p> 
         Change My Password</p>
    <p> 
         <asp:Label ID="Label9" runat="server" Text="New Password"></asp:Label>
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:TextBox ID="txtNewPwd" runat="server" TextMode="Password"></asp:TextBox>
    </p>
    <p> 
         Confirm Password&nbsp; <asp:TextBox ID="txtconfPwd" runat="server" 
             TextMode="Password"></asp:TextBox>
    </p>
    <p> 
         <asp:Button ID="btnChangePwd" runat="server" Text="Change my Password" 
             onclick="btnChangePwd_Click" style="height: 26px" />
    </p>
    <p> 
         <asp:Label ID="PwdLabel" runat="server"></asp:Label>
    </p>
</asp:Content>
