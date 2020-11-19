<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserHomePage.aspx.cs" Inherits="CapeLibManagementSystem.UserBookViewPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Content/UserViewCss.css"/>
</head>
<body>
    <form id="form1" runat="server">
       <div>
        <asp:Repeater ID="BookGrid" runat="server">
            <HeaderTemplate>
                <table cellpadding="1" cellspacing="1" width="50%" style="font-family: Calibri; border: 1px solid #C0C0C0; background-color: #D8D8D8">
                    <tr style="background-color:Gray; color:White">
                        <th>Book Id</th>
                        <th>Name</th>
                        <th>Author Name</th>
                        <th> Publisher Name </th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr style="background-color: White">             
                    <td>  <%#DataBinder.Eval(Container, "DataItem.BookId")%>  </td>
                    <td>  <%#DataBinder.Eval(Container, "DataItem.BookName")%> </td>
                    <td>  <%#DataBinder.Eval(Container, "DataItem.designation")%>  </td>
                    <td>  <%#DataBinder.Eval(Container, "DataItem.city")%> </td>
                    <td>  <%#DataBinder.Eval(Container, "DataItem.country")%> </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr style="background-color:#AED6FF">
                    <td>  <%#DataBinder.Eval(Container, "DataItem.empid")%> </td>
                    <td>  <%#DataBinder.Eval(Container, "DataItem.name")%> </td>
                    <td>  <%#DataBinder.Eval(Container, "DataItem.designation")%> </td>
                    <td>  <%#DataBinder.Eval(Container, "DataItem.city")%> </td>
                    <td>  <%#DataBinder.Eval(Container, "DataItem.country")%> </td>
                </tr>
            </AlternatingItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>    
        <div id="Search Popup">
            <asp:UpdatePanel ID="SearchBookId" runat="server">
                <ContentTemplate>
                    <div>
                        <input type="text" placeholder="Search Books.." id="search" runat="server">
                        <button type="submit"  onclick="searchBooks"><i class="fa fa-search"></i></button>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div>  
             <table width="50%" style="font-family: Calibri; border: 1px solid #C0C0C0; background-color: #D8D8D8" id="fetchedBooktable" runat="server">
                    <tr style="background-color:Gray; color:White">
                        <th>Book Id</th>
                        <th>Name</th>
                        <th>Author Name</th>
                        <th>Publisher Name </th>
                    </tr> 
                    <tr>
                         <td></td>
                    </tr>              
             </table>
        </div> 
    </form>
</body>
</html>
