using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web;
using System.Web.UI.WebControls;

public partial class ShoppingCart : System.Web.UI.Page
{
    public double TotalOrderPrice { get; set; }
    public double TotalOrderWeight { get; set; }
    public double TotalOrderQuantity { get; set; }
    public double TotalOrderItems { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var cartItems = (List<InventoryItem>) Session["InventoryItems"];
        if(cartItems != null)
        {
            var table = FillShoppingCart(cartItems);
            shoppingCart.Controls.Add(table);
        }
    }

    private Table FillShoppingCart(List<InventoryItem> cartItems)
    {
        TotalOrderPrice = 0;
        TotalOrderWeight = 0;
        TotalOrderQuantity = 0;
        TotalOrderItems = 0;
        var table = new Table();
        table.Attributes["class"] = "table table-bordered";
        var row = new TableHeaderRow();
        row.TableSection = TableRowSection.TableHeader;
        row.Attributes["class"] = ".thead-dark";
        row.Cells.Add(AddHeaderCell("Item"));
        row.Cells.Add(AddHeaderCell("Price"));
        row.Cells.Add(AddHeaderCell("Quantity"));
        row.Cells.Add(AddHeaderCell("Weight (oz)"));
        row.Cells.Add(AddHeaderCell("Change Item"));
        row.Cells.Add(AddHeaderCell("Delete Item"));
        table.Rows.Add(row);

        foreach (InventoryItem item in cartItems)
        {
            if (item.InShoppingCart)
            {
                var tblrow = new TableRow();
                tblrow.Cells.Add(AddCell(item.ItemName));
                tblrow.Cells.Add(AddCell(item.Price + ""));
                tblrow.Cells.Add(AddCell(item.ShoppingCartQuantity + ""));
                tblrow.Cells.Add(AddCell(item.Weight + ""));

                // change from cart button
                var btnCell = new TableCell();
                var btn = new Button();
                btn.Attributes["class"] = "btn btn-outline-secondary";
                btn.Text = "Change";
                btn.Click += (theSender, evt) =>
                {
                    Server.Transfer("ItemDetailPage.aspx?Item=" + HttpContext.Current.Server.UrlEncode(item.ItemId + ""));
                };
                btnCell.Controls.Add(btn);
                tblrow.Cells.Add(btnCell);

                // remove from cart button
                btnCell = new TableCell();
                btn = new Button();
                btn.Attributes["class"] = "btn btn-outline-warning";
                btn.Text = "Delete";
                btn.Click += (theSender, evt) => RemoveFromCart_Click(theSender, evt, item.ItemId);
                btnCell.Controls.Add(btn);
                tblrow.Cells.Add(btnCell);
                table.Rows.Add(tblrow);

                TotalOrderPrice += item.Price * item.ShoppingCartQuantity;
                TotalOrderQuantity += item.ShoppingCartQuantity;
                TotalOrderWeight += item.Weight * item.ShoppingCartQuantity;
                TotalOrderItems++;
            }
        }
        var footer = new TableFooterRow();
        footer.Cells.Add(AddCell("<strong>Total Order Price: " + TotalOrderPrice.ToString("C", CultureInfo.CurrentCulture) + "</strong>"));
        footer.Cells.Add(AddCell("<strong>Total Order Quantity: " + TotalOrderQuantity + "</strong>"));
        footer.Cells.Add(AddCell("<strong>Total Order Weight: " + TotalOrderWeight + " oz</strong>"));
        table.Rows.Add(footer);
        return table;
    }

    protected void RemoveFromCart_Click(object sender, EventArgs e, int itemId)
    {
        var inventoryItems = (List<InventoryItem>) Session["InventoryItems"];
        foreach(var item in inventoryItems)
        {
            if(item.ItemId == itemId)
            {
                item.InShoppingCart = false;
            }
        }
        Response.Redirect(Request.RawUrl);
    }

    protected void Checkout_Click(object sender, EventArgs e)
    {
        string redirect = "Checkout.aspx?Price=" + HttpContext.Current.Server.UrlEncode(this.TotalOrderPrice + "")
            + "&Weight=" + HttpContext.Current.Server.UrlEncode(this.TotalOrderWeight + "")
            + "&Quantity=" + HttpContext.Current.Server.UrlEncode(this.TotalOrderQuantity + "")
            + "&Item=" + HttpContext.Current.Server.UrlEncode(this.TotalOrderItems + "");
        Response.Redirect(redirect);
    }

    private TableHeaderCell AddHeaderCell(string text)
    {
        var cell = new TableHeaderCell();
        cell.Text = text;
        return cell;
    }

    private TableCell AddCell(string text)
    {
        var cell = new TableCell();
        cell.Text = text;
        return cell;
    }
}