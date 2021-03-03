<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="Client.home" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"/>
        <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
        <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
    <title>Home</title>
</head>
<body>
    <form runat="server">
        <div class="container mt-4">
            <div class="row">
                <div class="col-md-3"></div>
                <div class="col-md-6">
                    <div class="card" style="border:groove">
                        <div class="card-header">
                            <h3 class="card-title" style="text-align:center">Welcome to Live Cricket Score System</h3>
                        </div>
                        <div class="card-body">
                            <asp:Button ID="HostBtn" runat="server" OnClick="HostBtn_Click" Text="Host Match"
                                    CssClass="btn btn-outline-dark btn-lg btn-block" />
                        </div>
                    </div>
                </div>
                <div class="col-md-3"></div>
            </div>
        </div>
    </form>

</body>
</html>
