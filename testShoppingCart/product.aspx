<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" %>

<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {
        Repeater1.DataSource = ProductU.GetAllproducts();
        Repeater1.DataBind();
    }
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="mycss" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="mycontent" runat="server">
        <div class="row">
            <div class="col-lg-12 text-center">
                <div class="section-title">
                    <h2>Related Products</h2>
                </div>
            </div>
        </div>
    <asp:Repeater ID="Repeater1" runat="server">
        <HeaderTemplate>
          <section class="related-product spad">
              <div class="row">
        </HeaderTemplate>
        <ItemTemplate>
            
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
           

        </ItemTemplate>
        <FooterTemplate>
              
          </section>
              </div>
        </FooterTemplate>

    </asp:Repeater>

</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="myJavaScript" runat="server">
</asp:Content>


