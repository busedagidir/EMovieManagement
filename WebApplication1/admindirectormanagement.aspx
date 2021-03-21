﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="admindirectormanagement.aspx.cs" Inherits="WebApplication1.admindirectormanagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        $(document).ready(function () {
            $('.table').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable();
        });

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">

            <!-- Director Details -->
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Director Details</h4>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center><img width="100px" src="images/image_part_015.jpg" /></center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>Director ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="ID" ></asp:TextBox>
                                        <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Go" OnClick="Button1_Click" />
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-8">
                                <label>Director Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="director name" TextMode="SingleLine"></asp:TextBox>
                                </div>
                            </div>

                        </div>

                        <br />



                        <div class="row">
                            <div class="col-4">
                                <asp:Button ID="Button2" CssClass="btn btn-lg w-100 btn-success" runat="server" Text="Add" OnClick="Button2_Click" />
                            </div>

                            <div class="col-4">
                                <asp:Button ID="Button3" CssClass="btn btn-lg w-100 btn-warning" runat="server" Text="Update" OnClick="Button3_Click" />
                            </div>

                            <div class="col-4">
                                <asp:Button ID="Button4" CssClass="btn btn-lg w-100 btn-danger" runat="server" Text="Delete" OnClick="Button4_Click" />
                            </div>
                        </div>



                    </div>
                </div>

                <a href="homepage.aspx"> << Back to Homepage </a> <br /><br />
            </div>



            <!-- Director Movie List -->
            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Director-Movie List</h4>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                       

                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:emovieDBConnectionString %>" SelectCommand="SELECT * FROM [director_master_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                <hr>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="director_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="director_id" HeaderText="director_id" ReadOnly="True" SortExpression="director_id" />
                                        <asp:BoundField DataField="director_name" HeaderText="director_name" SortExpression="director_name" />
                                    </Columns>
                                </asp:GridView>

                            </div>
                        </div>


                    </div>
                </div>
            </div>

        </div>
    </div>


</asp:Content>
