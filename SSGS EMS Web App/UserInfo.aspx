<%@ Page Title="User Information" Language="C#" MasterPageFile="~/Site.Master"
     AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="SSGS_EMS_Web_App.UserInfo" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
       User Information
    </h2>
    <div class="userInfo">
    <p>  
        <asp:Label ID="Label1" runat="server" Text="Initial: "></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem Value="Mr."></asp:ListItem>
            <asp:ListItem Value="Ms"></asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="First Name: "></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtFirst" runat="server"></asp:TextBox>
        <br /> <br />
        <asp:Label ID="Label3" runat="server" Text="Last Name: "></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtLast" runat="server"></asp:TextBox>
        <br /> 
      </p>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Marital Status"></asp:Label>
                </td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" Height="46px" Width="83px">
                <asp:ListItem>Married</asp:ListItem>
                <asp:ListItem>Single</asp:ListItem>
            </asp:RadioButtonList>
                </td>
            </tr>
        </table>
        <p>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Languages: "></asp:Label>
                </td>
                <td>
                    <asp:CheckBox ID="CheckBox1" runat="server" Text="English" />
                    <asp:CheckBox ID="CheckBox2" runat="server" Text="Marathi" />
                </td>
            </tr>
        </table>
            
         &nbsp;&nbsp;&nbsp;
        &nbsp;
        <br /> 
      </p>
        
        <p>
            <br />
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
      </p>
    </div>
</asp:Content>



