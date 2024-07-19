<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Test_Task.List" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title></title>
<style>
    .custom-button,
    .custom-button-email,
    .custom-button-delete {
        border: none;
        padding: 5px 10px;
        text-align: center;
        text-decoration: none;
        display: inline-block;
        font-size: 14px;
        margin: 3px 1px;
        cursor: pointer;
        border-radius: 3px;
    }

    .custom-button {
        background-color: #4CAF50; /* Green color, change as needed */
        color: white;
    }

    .custom-button-email {
        background-color: Highlight; /* You may need to replace 'Highlight' with a specific color */
        color: white;
    }

    .custom-button-delete {
        background-color: #f44336; /* Red color, change as needed */
        color: white;
    }

    /* Hover effect */
    .custom-button:hover,
    .custom-button-email:hover,
    .custom-button-delete:hover {
        opacity: 0.8; /* Adjust the opacity to your liking */
    }

    table {
        width: 100%;
        border-collapse: collapse;
    }

    th, td {
        border: 1px solid #ddd;
        padding: 8px;
        text-align: left;
    }

    tr:nth-child(even) {
        background-color: #f2f2f2;
    }
</style>
<script type="text/javascript">
    function confirmDelete() {
        return confirm("Are you sure you want to delete this record?");
    }
</script>
</head>
<body>
<form id="form1" runat="server">
<div>
    <asp:Repeater ID="repeater1" runat="server">
        <HeaderTemplate>
            <table>
                <tr>
                    <th>User ID</th>
                    <th>First Name</th>
                    <th>Last Name</th>
                    <th>Email</th>
                    <th>PhoneNumber</th>
                    <th>Hire Date</th>
                    <th>Position</th>
                    <th>Salary</th>
                    <th>Action Buttons</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <!-- Hidden Field for User ID -->
                    <asp:HiddenField ID="HiddenUserId" runat="server" Value='<%# Eval("EmpID") %>' />
                    <!-- Display User ID -->
                    <%# Eval("EmpID") %>
                </td>
                <td><%# Eval("FirstName") %></td>
                <td><%# Eval("LastName") %></td>
                <td><%# Eval("Email") %></td>
                <td><%# Eval("PhoneNumber") %></td>
                <td><%# Eval("HireDate", "{0:MM-dd-yyyy}") %></td>
                <td><%# Eval("Position") %></td>
                <td><%# Eval("Salary") %></td>
            <td>
                <!-- Edit Button -->
                <asp:LinkButton runat="server" ID="lnkEdit" Text="Edit" CommandName="Edit" CommandArgument='<%# Eval("EmpID") %>' OnCommand="lnk_Command" CssClass="custom-button" />
                <!-- Delete Button -->
                <asp:LinkButton runat="server" ID="lnkDelete" Text="Delete" CommandName="Delete" CommandArgument='<%# Eval("EmpID") %>' OnCommand="lnk_Command" OnClientClick="return confirmDelete();" CssClass="custom-button-delete" />
                
    <!-- Email Button -->
                
            </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr>
                <td>
                    <!-- Hidden Field for User ID -->
                    <asp:HiddenField ID="HiddenUserId" runat="server" Value='<%# Eval("EmpID") %>' />
                    <!-- Display User ID -->
                    <%# Eval("EmpID") %>
                </td>
                <td><%# Eval("FirstName") %></td>
                <td><%# Eval("LastName") %></td>
               <td><%# Eval("Email") %></td>
                <td><%# Eval("PhoneNumber") %></td>
                <td><%# Eval("HireDate", "{0:MM-dd-yyyy}") %></td>
                <td><%# Eval("Position") %></td>
                <td><%# Eval("Salary") %></td>

              
    <td>
        <!-- Edit Button -->
        <asp:LinkButton runat="server" ID="lnkEdit" Text="Edit" CommandName="Edit" CommandArgument='<%# Eval("EmpID") %>' OnCommand="lnk_Command" CssClass="custom-button" />
        <!-- Delete Button -->
        <asp:LinkButton runat="server" ID="lnkDelete" Text="Delete" CommandName="Delete" CommandArgument='<%# Eval("EmpID") %>' OnCommand="lnk_Command" OnClientClick="return confirmDelete();" CssClass="custom-button-delete" />
        <!-- Email Button -->
        
    </td>
            </tr>
        </AlternatingItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</div>
    <br />
    <div style="text-align: center">
        <asp:Repeater ID="Repeater2" runat="server" OnItemCommand="Repeater1_ItemCommand">
            <ItemTemplate>
                <asp:LinkButton runat="server" ID="lnkPage" CssClass="page-link" CommandName="Page" CommandArgument='<%# Container.DataItem %>'>
                    <%# Container.DataItem %>
                </asp:LinkButton>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</form>
</body>
</html>
