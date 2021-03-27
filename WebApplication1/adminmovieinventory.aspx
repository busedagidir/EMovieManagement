 <%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminmovieinventory.aspx.cs" Inherits="WebApplication1.adminmovieinventory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        $(document).ready(function () {
            $('.table').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable();
        });


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
                                        <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Go" OnClick="Button1_Click" />
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



            <!-- Movie List -->
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
                                        <asp:BoundField DataField="movie_id" HeaderText="ID" ReadOnly="True" SortExpression="movie_id" >
                                       
                                        <ControlStyle Font-Bold="True" />
                                        </asp:BoundField>
                                       
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="container-fluid">  
                                                    <div class="row">
                                                        <div class="col-lg-10">
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("movie_name") %>' Font-Bold="True" Font-Size="Large"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">

                                                                    Director-<asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("director_name") %>'></asp:Label>
                                                                    &nbsp;| Genre-<asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("genre") %>'></asp:Label>
                                                                    &nbsp;| Language-<asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("language") %>'></asp:Label>

                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">

                                                                    Producer-<asp:Label ID="Label5" runat="server" Font-Bold="True" Text='<%# Eval("producer_name") %>'></asp:Label>
                                                                    &nbsp;| Publish Date-<asp:Label ID="Label6" runat="server" Font-Bold="True" Text='<%# Eval("publish_date") %>'></asp:Label>
                                                                    &nbsp;| Duration-<asp:Label ID="Label7" runat="server" Font-Bold="True" Text='<%# Eval("duration") %>'></asp:Label>

                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">

                                                                    Cost-<asp:Label ID="Label8" runat="server" Font-Bold="True" Text='<%# Eval("movie_cost") %>'></asp:Label>
                                                                    &nbsp;| Actual Stock-<asp:Label ID="Label9" runat="server" Font-Bold="True" Text='<%# Eval("actual_stock") %>'></asp:Label>
                                                                    &nbsp;| Available Stock-<asp:Label ID="Label10" runat="server" Font-Bold="True" Text='<%# Eval("current_stock") %>'></asp:Label>

                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">

                                                                    Description-<asp:Label ID="Label11" runat="server" Font-Bold="False" Font-Italic="True" Text='<%# Eval("movie_description") %>'></asp:Label>

                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-lg-2">
                                                            <asp:Image class="img-fluid" ID="Image1" runat="server" ImageUrl='<%# Eval("movie_img_link") %>' />
                                                        </div>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       
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
