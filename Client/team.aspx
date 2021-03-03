<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="team.aspx.cs" Inherits="Client.team" %>

    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">

    <head runat="server">
        <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"
            integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
        <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"
            integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo"
            crossorigin="anonymous"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"
            integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1"
            crossorigin="anonymous"></script>
        <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"
            integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM"
            crossorigin="anonymous"></script>
        <title>Team
        </title>
    </head>

    <body>
        <div class="container-fluid" style="padding-top:50px">
            <form id="form1" runat="server">
                <div class="row">
                    <div class="col col-md-1"></div>

                    <div class="col col-md-6 support-article mb-4">
                        <div class="card" style="border:groove;">
                            <div class="card-header">
                                <h4 class="card-title" style="text-align:center"> Add Playing 11 of both the Teams</h4>
                            </div>
                            <div class="card-body">
                                <table class="table table-striped">
                                    <thead class="thead-dark">
                                        <tr>
                                            <th scope="col">Player No.</th>
                                            <th scope="col">Team 1</th>
                                            <th scope="col">Team 2</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <th scope="row">1</th>
                                            <td>
                                                <asp:TextBox ID="t1p1" runat="server" >Rohit</asp:TextBox>
                                                <asp:DropDownList ID="ddlt1p1type" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="t2p1" runat="server">Burns</asp:TextBox>
                                                <asp:DropDownList ID="ddlt2p1type" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th scope="row">2</th>
                                            <td>
                                                <asp:TextBox ID="t1p2" runat="server">Shubman Gill</asp:TextBox>
                                                <asp:DropDownList ID="ddlt1p2type" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="t2p2" runat="server">Sibley</asp:TextBox>
                                                <asp:DropDownList ID="ddlt2p2type" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th scope="row">3</th>
                                            <td>
                                                <asp:TextBox ID="t1p3" runat="server">Pujara</asp:TextBox>
                                                <asp:DropDownList ID="ddlt1p3type" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="t2p3" runat="server">Daniel</asp:TextBox>
                                                <asp:DropDownList ID="ddlt2p3type" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th scope="row">4</th>
                                            <td>
                                                <asp:TextBox ID="t1p4" runat="server">Kohli</asp:TextBox>
                                                <asp:DropDownList ID="ddlt1p4type" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="t2p4" runat="server">Root</asp:TextBox>
                                                <asp:DropDownList ID="ddlt2p4type" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th scope="row">5</th>
                                            <td>
                                                <asp:TextBox ID="t1p5" runat="server">Rahane</asp:TextBox>
                                                <asp:DropDownList ID="ddlt1p5type" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="t2p5" runat="server">Stokes</asp:TextBox>
                                                <asp:DropDownList ID="ddlt2p5type" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th scope="row">6</th>
                                            <td>
                                                <asp:TextBox ID="t1p6" runat="server">Pant</asp:TextBox>
                                                <asp:DropDownList ID="ddlt1p6type" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="t2p6" runat="server">Pope</asp:TextBox>
                                                <asp:DropDownList ID="ddlt2p6type" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th scope="row">7</th>
                                            <td>
                                                <asp:TextBox ID="t1p7" runat="server">Ashwin</asp:TextBox>
                                                <asp:DropDownList ID="ddlt1p7type" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="t2p7" runat="server">Foakes</asp:TextBox>
                                                <asp:DropDownList ID="ddlt2p7type" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th scope="row">8</th>
                                            <td>
                                                <asp:TextBox ID="t1p8" runat="server">Axar</asp:TextBox>
                                                <asp:DropDownList ID="ddlt1p8type" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="t2p8" runat="server">Moeen</asp:TextBox>
                                                <asp:DropDownList ID="ddlt2p8type" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th scope="row">9</th>
                                            <td>
                                                <asp:TextBox ID="t1p9" runat="server">Ishant</asp:TextBox>
                                                <asp:DropDownList ID="ddlt1p9type" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="t2p9" runat="server">Stone</asp:TextBox>
                                                <asp:DropDownList ID="ddlt2p9type" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th scope="row">10</th>
                                            <td>
                                                <asp:TextBox ID="t1p10" runat="server">Kuldeep Yadav</asp:TextBox>
                                                <asp:DropDownList ID="ddlt1p10type" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="t2p10" runat="server">Jack</asp:TextBox>
                                                <asp:DropDownList ID="ddlt2p10type" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th scope="row">11</th>
                                            <td>
                                                <asp:TextBox ID="t1p11" runat="server">Siraj</asp:TextBox>
                                                <asp:DropDownList ID="ddlt1p11type" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="t2p11" runat="server">Broad</asp:TextBox>
                                                <asp:DropDownList ID="ddlt2p11type" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>

                    <div class="col col-md-4">
                        <div class="card" style="border:groove">
                            <div class="card-header">
                                <h4 class="card-title" style="text-align:center"> Match Info</h4>
                            </div>
                            <div class="card-body">
                                <table class="table table-striped">

                                    <tbody>
                                        <tr>
                                            <th scope="row">Match Title </th>
                                            <td>
                                                <asp:TextBox ID="tbmatchtitle" runat="server">
                                                </asp:TextBox>
                                            </td>

                                        </tr>
                                        <tr>
                                            <th scope="row">Team 1</th>
                                            <td>
                                                <asp:TextBox ID="tbteam1" runat="server">
                                                </asp:TextBox>
                                            </td>

                                        </tr>
                                        <tr>
                                            <th scope="row">Team 2</th>
                                            <td>
                                                <asp:TextBox ID="tbteam2" runat="server">
                                                </asp:TextBox>

                                            </td>

                                        </tr>
                                        <tr>
                                            <th scope="row">Overs</th>
                                            <td>
                                                <asp:DropDownList ID="ddlovers" runat="server">
                                                    <asp:ListItem>2</asp:ListItem>
                                                    <asp:ListItem>20</asp:ListItem>
                                                    <asp:ListItem>50</asp:ListItem>
                                                </asp:DropDownList>
                                                
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <asp:Button ID="GoBtn" runat="server" OnClick="GoBtn_Click" Text="Go"
                                    CssClass="btn btn-outline-dark btn-lg btn-block" />
                            </div>
                            <div class="card-footer text-muted">
                                *Fill all the info then click submit
                            </div>
                        </div>
                    </div>
                    <div class="col col-md-1"></div>
                </div>
            </form>

        </div>
    </body>

    </html>