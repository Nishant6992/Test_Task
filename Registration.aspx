<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Test_Task.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
    
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>


 
<body>
    
     <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />  
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js" ></script>
      
    <form id="form1" runat="server">
        <center>
    <br /><h1>Employee Registration</h1>
            <br /><br />
        
        <asp:Label runat="server">FirstName</asp:Label>
        <asp:TextBox runat="server" ID="txtfirstname" ClientIDMode="Static"></asp:TextBox><br /><br />
           <%-- <asp:RequiredFieldValidatorID="user" runat="server" ControlToValidate="txtfirstname" ErrorMessage="Please enter a user name" ForeColor="Red"/>--%>
                    
        <asp:Label runat="server">LastName</asp:Label>
        <asp:TextBox runat="server" ID="txtlastname" ClientIDMode="Static"></asp:TextBox><br /><br />
        <asp:Label runat="server">Email</asp:Label>
        <asp:TextBox runat="server" ID="txtmail"></asp:TextBox><br /><br />
        <asp:Label runat="server">PhoneNumber</asp:Label>
        <asp:TextBox runat="server" ID="txtphonenum" ClientIDMode="Static"></asp:TextBox><br /><br />
    
        <asp:Label runat="server">HireDate</asp:Label>
        <asp:TextBox runat="server" ID="txthiredate" TextMode="Date" ClientIDMode="Static" ></asp:TextBox><br /><br />

          <asp:Label runat="server">Position</asp:Label>
         <asp:TextBox runat="server" ID="txtposition" ClientIDMode="Static" ></asp:TextBox><br /><br />
          <asp:Label runat="server">Salary</asp:Label>
        <asp:TextBox runat="server" TextMode="Number" ID="txtsalary"  min="5000"  ClientIDMode="Static"  ></asp:TextBox><br /> <br />
            <asp:Button ID="txtsave" Text="Save" runat="server" CssClass="btn-dark" OnClick="txtsave_Click"/>
          &nbsp&nbsp&nbsp&nbsp
            <asp:Button ID="reset" Text="Reset" runat="server" CssClass="btn-danger" OnClick="reset_Click" OnClientClick="return validation();"/>
            <asp:Label ID="Label1" runat="server" Visible="false">
          
            </asp:Label>
         </center>
       
    </form>
    <script language="javascript" type="text/javascript">  
        function validate() {
            if (document.getElementById("<%=txtfirstname.ClientID%>").value == "") {
            alert("Name Feild can not be blank");
            document.getElementById("<%=txtfirstname.ClientID%>").focus();
            return false;
        }
        if (document.getElementById("<%=txtlastname.ClientID %>").value == "") {
        alert("Last Name Feild can not be blank");
        document.getElementById("<%=txtlastname.ClientID %>").focus();
        return false;
    }
        if (document.getElementById("<%=txtsalary.ClientID %>").value>50000) {
        alert("Salary should not be greater than 50k");
        document.getElementById("<%=txtsalary.ClientID %>").focus();
                return false;
            }
            return true;
        }
    </script> 
   
</body>

</html>
