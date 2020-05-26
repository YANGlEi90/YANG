<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClassList.aspx.cs" Inherits="T6_1_1.ClassList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="ddClass" runat="server" AutoPostBack="true"></asp:DropDownList>
            <a href="Class_<%=ddClass.SelectedValue %>.html">查询</a>
        </div>
    </form>
</body>
</html>
