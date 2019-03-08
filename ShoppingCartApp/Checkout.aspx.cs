using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Checkout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        double price = 0, shippingCost = 0, totalCost = 0, weight = 0, items = 0, quantity = 0;
        if(Request.QueryString["Price"] != null)
        {
            price = double.Parse(Request.QueryString["Price"]);
        }
        if(Request.QueryString["Weight"] != null)
        {
            weight = double.Parse(Request.QueryString["Weight"]);
        }
        if (Request.QueryString["Quantity"] != null)
        {
            quantity = double.Parse(Request.QueryString["Quantity"]);
        }
        if (Request.QueryString["Item"] != null)
        {
            items = double.Parse(Request.QueryString["Item"]);
        }
        shippingCost = weight * .42;
        totalCost = price + shippingCost;
        Price.InnerText = "Order Cost: " + price.ToString("C", CultureInfo.CurrentCulture);
        Shipping.InnerText = "Shipping Cost: " + shippingCost.ToString("C", CultureInfo.CurrentCulture);
        Total.InnerText = "Cost + Shipping: " + totalCost.ToString("C", CultureInfo.CurrentCulture);
        Weight.InnerText = "Weight: " + weight + " ounces";
        Quantity.InnerText = "Quantity: " + quantity;
        Items.InnerText = "Unique Items: " + items;
    }

    protected void SubmitOrder_Click(object sender, EventArgs e)
    {
        Server.Transfer("OrderSuccess.aspx");
    }

    protected void BackToCart_Click(object sender, EventArgs e)
    {
        Server.Transfer("ShoppingCart.aspx");
    }
}