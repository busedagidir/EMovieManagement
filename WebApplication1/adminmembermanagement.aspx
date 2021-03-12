<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminmembermanagement.aspx.cs" Inherits="WebApplication1.adminmembermanagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container-fluid">
        <div class="row">

            <!-- Movie Issuing -->
            <div class="col-md-6">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Member Details</h4>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center><img width="75px" src="images/login.png" /></center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-3">
                                <label>Member ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Member ID" TextMode="SingleLine"></asp:TextBox>
                                        <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Go" />
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Full Name</label>
                                <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Full Name" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>


                            <div class="col-md-5">
                                <label>Account Status</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Account Status" ReadOnly="True"></asp:TextBox>
                                        <asp:LinkButton class="btn btn-success" ID="LinkButton1" runat="server" Text="A"><i class="fas fa-check-circle"></i></asp:LinkButton>

                                        <asp:LinkButton class="btn btn-warning" ID="LinkButton2" runat="server" Text="A"><i class="far fa-pause-circle"></i></asp:LinkButton>

                                        <asp:LinkButton class="btn btn-danger" ID="LinkButton3" runat="server" Text="A"><i class="fas fa-times-circle"></i></asp:LinkButton>
                                    </div>
                                </div>
                            </div>

                        </div>


                        <div class="row">
                            <div class="col-md-3">
                                <label>DOB</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="date of birth" TextMode="Date" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Contact No</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Contact No" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>


                            <div class="col-md-5">
                                <label>Email ID</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="Email ID" TextMode="SingleLine" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>

                        </div>


                        <div class="row">
                            <div class="col-md-4">
                                <label>State</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="State" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>City</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="City" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>


                            <div class="col-md-4">
                                <label>Zip Code</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" placeholder="Zip Code" TextMode="Number" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>

                        </div>


                        <div class="row">
                            <div class="col">
                                <label>Full Postal Address</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server" placeholder="Full Address" TextMode="MultiLine" ReadOnly="True" Rows="2"></asp:TextBox>
                                </div>
                            </div>

                        </div>

                        <br />

                        <!-- Issue - Return buttons -->
                        <div class="row">
                            <div class="col-8 mx-auto">
                                <asp:Button ID="Button2" CssClass="btn btn-lg w-100 btn-outline-danger" runat="server" Text="Delete User Permanently" />
                            </div>
                        </div>

                    </div>
                </div>

                <a href="homepage.aspx"> << Back to Homepage </a> <br /><br />
            </div>



            <!-- Member List -->
            <div class="col-md-6">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Member List</h4>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                       

                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server"></asp:GridView>

                            </div>
                        </div>


                    </div>
                </div>
            </div>

        </div>
    </div>

</asp:Content>
