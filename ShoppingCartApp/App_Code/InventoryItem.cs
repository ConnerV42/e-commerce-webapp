using System;
using System.Web;

[Serializable]
public class InventoryItem
{
    public int ItemId { get; set; }
    public string ItemName { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
    public double Weight { get; set; }
    public string Status { get; set; }
    public string ShortDescription { get; set; }
    public string LongDescription { get; set; }
    public string SmallImageUrl { get; set; }
    public string LargeImageUrl { get; set; }
    public bool InShoppingCart { get; set; }
    public int ShoppingCartQuantity { get; set; }

    public string ToHTML(bool detailedView)
    {
        var html = "";
        if (detailedView)
        {
            html = "<div class='col-md-4 col-md-6 mb-4'>";
            html += "<div class='card h-100'>";
            html += "<img class='card-img-top' src=" + this.LargeImageUrl + " alt=''/>";
            html += "<div class='card-body'>";
            html += "<h4 class='card-title'>";
            html += this.ItemName + "</h4>";
            html += "<h5>" + this.Price + "</h5>";
            html += "<h5>Quantity Available: " + this.Quantity + "</h5></div>";
            html += "<div class='card-footer'>";
            html += "<small class='text-muted'>" + this.LongDescription;
            html += "</small></div></div></div>";
            return html;
        }
        var redirect = "ItemDetailPage.aspx?Item=" + HttpContext.Current.Server.UrlEncode(this.ItemId + "");
        html = "<div class='col-md-4 col-md-6 mb-4'>";
        html += "<div class='card h-100'>";
        html += "<a href=" + redirect + ">";
        html += "<img class='card-img-top' src=" + this.SmallImageUrl + " alt=''/></a>";
        html += "<div class='card-body'>";
        html += "<h4 class='card-title'>";
        html += "<a href=" + redirect + ">" + this.ItemName + "</a></h4>";
        html += "<h5>" + this.Price + "</h5></div>";
        html += "<div class='card-footer'>";
        html += "<small class='text-muted'>" + this.ShortDescription + "</small></div></div></div>";
        return html;
    }  
}