<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminHomePage.aspx.cs" Inherits="CapeLibManagementSystem.AdminHomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Page</title>
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

    <div>
        Add New Book
        <button type="submit"  onclick="AddNewBook"><i class="fa fa-search"></i></button>
        <div id="Add Popup">
            <asp:UpdatePanel ID="AddNewBook" runat="server">
                <ContentTemplate>
                    <div>
                        <input type="text" placeholder="BookName" id="BookName" runat="server">
                        <asp:DropDownList id="AuthorDropDown" runat="server"  
                         DataSource="<% databindingexpression %>"  
                         DataTextField="DataSourceField"  
                         DataValueField="DataSourceField"  
                         AutoPostBack="True|False"  
                         OnSelectedIndexChanged="OnSelectedIndexChangedMethod">  
                           <asp:ListItem value="value" selected="True|False">  
                              Text  
                           </asp:ListItem>    
                        </asp:DropDownList> 
                         <asp:DropDownList id="PublisherDropDown" runat="server"  
                         DataSource="<% databindingexpression %>"  
                         DataTextField="DataSourceField"  
                         DataValueField="DataSourceField"  
                         AutoPostBack="True|False"  
                         OnSelectedIndexChanged="OnSelectedIndexChangedMethod">  
                           <asp:ListItem value="value" selected="True|False">  
                              Text  
                           </asp:ListItem>    
                        </asp:DropDownList> 
                        
                        <button type="submit"  onclick="searchBooks"><i class="fa fa-search"></i></button>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
        <div>
        Add New Author
        <button type="submit"  onclick="AddNewAuthor"><i class="fa fa-search"></i></button>
    </div>
        <div>
        Add New Publisher
        <button type="submit"  onclick="AddNewPublisher"><i class="fa fa-search"></i></button>
    </div>
</html>
