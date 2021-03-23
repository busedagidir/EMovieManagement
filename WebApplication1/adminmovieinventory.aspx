<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminmovieinventory.aspx.cs" Inherits="WebApplication1.adminmovieinventory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('#imgview').attr('src', e.target.result);
                };

                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>
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
                                    <h4>Movie Details</h4>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center><img id="imgview" height="150" width="100px" src="movie_inventory/image_part_016.jpg" /></center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <asp:FileUpload onchange="readURL(this);" class="form-control" ID="FileUpload1" runat="server" />
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-md-4">
                                <label>Movie ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Movie ID" TextMode="SingleLine"></asp:TextBox>
                                        <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Go" />
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-8">
                                <label>Movie Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Movie Name"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-md-4">
                                <label>Language</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                                        <asp:ListItem Text="English" Value="English" />
                                        <asp:ListItem Text="Turkish" Value="Turkish" />
                                        <asp:ListItem Text="French" Value="French" />
                                        <asp:ListItem Text="German" Value="German" />
                                        <asp:ListItem Text="Spanish" Value="Spanish" />
                                        <asp:ListItem Text="Korean" Value="Korean" />
                                    </asp:DropDownList>
                                </div>


                                <label>Producer Name</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownList2" runat="server">
                                        <asp:ListItem Text="Coen Brothers" Value="Coen Brothers" />
                                        <asp:ListItem Text="Zeynep Ozbatur Atakan" Value="Zeynep Ozbatur Atakan" />
                                    </asp:DropDownList>
                                </div>
                            </div>


                            <div class="col-md-4">
                                <label>Director Name</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownList3" runat="server">
                                        <asp:ListItem Text="Coen Brothers" Value="Coen Brothers" />
                                        <asp:ListItem Text="Nuri Bilge Ceylan" Value="Nuri Bilge Ceylan" />
                                    </asp:DropDownList>
                                </div>


                                <label>Publish Date</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="Date" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>


                            <div class="col-md-4">
                                <label>Genre</label>
                                <div class="form-group">
                                    <asp:ListBox CssClass="form-control" ID="ListBox1" runat="server" SelectionMode="Multiple" Rows="4">
                                        <asp:ListItem Text="Comedy" Value="Comedy" />
                                        <asp:ListItem Text="Sci-Fi" Value="Sci-Fi" />
                                        <asp:ListItem Text="Horror" Value="Horror" />
                                        <asp:ListItem Text="Romance" Value="Romance" />
                                        <asp:ListItem Text="Action" Value="Action" />
                                        <asp:ListItem Text="Thriller" Value="Thriller" />
                                        <asp:ListItem Text="Drama" Value="Drama" />
                                        <asp:ListItem Text="Mystery" Value="Mystery" />
                                        <asp:ListItem Text="Crime" Value="Crime" />
                                        <asp:ListItem Text="Animation" Value="Animation" />
                                        <asp:ListItem Text="Adventure" Value="Adventure" />
                                        <asp:ListItem Text="Fantasy" Value="Fantasy" />
                                        <asp:ListItem Text="Comedy-Romance" Value="Comedy-Romance" />
                                        <asp:ListItem Text="Action-Comedy" Value="Action-Comedy" />
                                        <asp:ListItem Text="Superhero" Value="Superhero" />
                                    </asp:ListBox>
                                </div>

                            </div>

                        </div>


                        <div class="row">
                            <div class="col-md-4">
                                <label>Year</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="Year"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Movie Cost</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="Movie Cost" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>


                            <div class="col-md-4">
                                <label>Total Time</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" placeholder="Total Time" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>Actual Stock</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Actual Stock" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Current Stock</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Current Stock" TextMode="Number" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>


                            <div class="col-md-4">
                                <label>Issued Movies</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Issued Movies" TextMode="Number" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>

                        </div>


                        <div class="row">
                            <div class="col">
                                <label>Movie Description</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server" placeholder="Movie Description" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                </div>
                            </div>

                        </div>

                        <br />

                        <!-- Add-Update-Delete buttons -->
                        <div class="row">
                            <div class="col-4 mx-auto">
                                <asp:Button ID="Button2" CssClass="btn btn-lg w-100 btn-outline-success" runat="server" Text="Add" OnClick="Button2_Click"/>
                            </div>

                            <div class="col-4 mx-auto">
                                <asp:Button ID="Button3" CssClass="btn btn-lg w-100 btn-outline-warning" runat="server" Text="Update" OnClick="Button3_Click"/>
                            </div>

                            <div class="col-4 mx-auto">
                                <asp:Button ID="Button4" CssClass="btn btn-lg w-100 btn-outline-danger" runat="server" Text="Delete" OnClick="Button4_Click"/>
                            </div>
                        </div>

                    </div>
                </div>

                <a href="homepage.aspx"><< Back to Homepage </a>
                <br />
                <br />
            </div>



            <!-- Member List -->
            <div class="col-md-6">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Movie Inventory List</h4>
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
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:emovieDBConnectionString %>" SelectCommand="SELECT * FROM [movie_master_tbl]"></asp:SqlDataSource>
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="movie_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="movie_id" HeaderText="movie_id" ReadOnly="True" SortExpression="movie_id" />
                                        <asp:BoundField DataField="movie_name" HeaderText="movie_name" SortExpression="movie_name" />
                                        <asp:BoundField DataField="genre" HeaderText="genre" SortExpression="genre" />
                                        <asp:BoundField DataField="director_name" HeaderText="director_name" SortExpression="director_name" />
                                        <asp:BoundField DataField="producer_name" HeaderText="producer_name" SortExpression="producer_name" />
                                        <asp:BoundField DataField="publish_date" HeaderText="publish_date" SortExpression="publish_date" />
                                        <asp:BoundField DataField="language" HeaderText="language" SortExpression="language" />
                                        <asp:BoundField DataField="edition" HeaderText="edition" SortExpression="edition" />
                                        <asp:BoundField DataField="movie_cost" HeaderText="movie_cost" SortExpression="movie_cost" />
                                        <asp:BoundField DataField="duration" HeaderText="duration" SortExpression="duration" />
                                        <asp:BoundField DataField="movie_description" HeaderText="movie_description" SortExpression="movie_description" />
                                        <asp:BoundField DataField="actual_stock" HeaderText="actual_stock" SortExpression="actual_stock" />
                                        <asp:BoundField DataField="current_stock" HeaderText="current_stock" SortExpression="current_stock" />
                                        <asp:BoundField DataField="movie_img_link" HeaderText="movie_img_link" SortExpression="movie_img_link" />
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
