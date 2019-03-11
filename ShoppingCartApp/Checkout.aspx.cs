using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Checkout : System.Web.UI.Page
{
    private double Price { get; set; }
    private double Shipping { get; set; }
    private double Weight { get; set; }
    private int Quantity { get; set; }
    private int Items { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        Price = 0;
        Shipping = 0;
        Weight = 0;
        Items = 0;
        Quantity = 0;
        if(Request.QueryString["Price"] != null)
        {
            Price = double.Parse(Request.QueryString["Price"]);
        }
        if(Request.QueryString["Weight"] != null)
        {
            Weight = double.Parse(Request.QueryString["Weight"]);
        }
        if (Request.QueryString["Quantity"] != null)
        {
            Quantity = int.Parse(Request.QueryString["Quantity"]);
        }
        if (Request.QueryString["Item"] != null)
        {
            Items = int.Parse(Request.QueryString["Item"]);
        }
        Shipping = Weight * .42;
        PriceDisplay.InnerText = "Order Cost: " + Price.ToString("C", CultureInfo.CurrentCulture);
        ShippingDisplay.InnerText = "Shipping Cost: " + Shipping.ToString("C", CultureInfo.CurrentCulture);
        TotalDisplay.InnerText = "Cost + Shipping: " + (Price + Shipping).ToString("C", CultureInfo.CurrentCulture);
        WeightDisplay.InnerText = "Weight: " + Weight + " ounces";
        QuantityDisplay.InnerText = "Quantity: " + Quantity;
        ItemsDisplay.InnerText = "Unique Items: " + Items;
    }

    protected void SubmitOrder_Click(object sender, EventArgs e)
    {
        try
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add(EmailInput.Value);
            mailMessage.From = new MailAddress("postmaster@shop.connercodes.com");
            mailMessage.Subject = "Sneaker Corner Order Confirmation";
            mailMessage.Body = "Thank you for your purchase! Your order is being processed, and you will receive an additional email when it has shipped.";
            mailMessage.Body += "--- Order Info ---\nOrder Cost: $" + Price + "\nShipping Cost: $" + Shipping + "\nTotal Cost: $" + (Price + Shipping) + "\nWeight: " + Weight + "\nQuantity: " + Quantity + "\nUnique Items: " + Items;
            SmtpClient smtpClient = new SmtpClient("mail.shop.connercodes.com");
            NetworkCredential Credentials = new NetworkCredential("postmaster@shop.connercodes.com", "hobblewobblejobbletrobblenobblekobble");
            smtpClient.Credentials = Credentials;
            smtpClient.Send(mailMessage);
        }
        catch (Exception ex)
        {
            Response.Write("Could not send the e-mail - error: " + ex.Message);
        }
        Server.Transfer("OrderSuccess.aspx");
    }

    protected void BackToCart_Click(object sender, EventArgs e)
    {
        Server.Transfer("ShoppingCart.aspx");
    }
}