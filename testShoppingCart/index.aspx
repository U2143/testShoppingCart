<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" %>

<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="mycss" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="mycontent" runat="server">


    <asp:Repeater ID="Repeater1" runat="server">
        <HeaderTemplate>
            <div class="row">
                <div class="col-lg-12 text-center">
                    <div class="section-title">
                        <h2>Related Products</h2>
                    </div>
                </div>
           
        </HeaderTemplate>
        <ItemTemplate>
            <div class="row">
                <div class="col-lg-3 col-sm-6">
                    <div class="single-product-item">
                        <figure>
                            <a href="#">
                                <img src='<%# Eval("ImageFileName", "img/products/{0}") %>' alt=""></a>
                            <div class="p-status">new</div>
                        </figure>
                        <div class="product-text">
                            <h6>產品名稱:<%# Eval("Name") %></h6>
                            <p>價格:<%# Eval("Price","{0:C0}") %>元</p>
                        </div>
                    </div>
                </div>
            </div>

        </ItemTemplate>
        <FooterTemplate>
            </div>
        </FooterTemplate>

    </asp:Repeater>

</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="myJavaScript" runat="server">
</asp:Content>


