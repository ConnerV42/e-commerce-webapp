using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.UI.WebControls;

public partial class ShoppingCart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var cartItems = (List<InventoryItem>) Session["InventoryItems"];
        if(cartItems != null)
        {
            var table = FillShoppingCart(cartItems);
            shoppingCart.Controls.Add(table);
            cartButtons.Controls.Add(GenerateCheckoutButton());
        }
    }

    private Table FillShoppingCart(List<InventoryItem> cartItems)
    {
        double totalCartPrice = 0;
        var table = new Table();
        table.Attributes["class"] = "table table-bordered";
        var row = new TableHeaderRow();
        row.TableSection = TableRowSection.TableHeader;
        row.Attributes["class"] = ".thead-dark";
        row.Cells.Add(AddHeaderCell("Item"));
        row.Cells.Add(AddHeaderCell("Price"));
        row.Cells.Add(AddHeaderCell("Quantity"));
        row.Cells.Add(AddHeaderCell("Weight (oz)"));
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

                // remove from cart button
                var btnCell = new TableCell();
                var btnRemove = new Button();
                btnRemove.Attributes["class"] = "btn btn-outline-warning";
                btnRemove.Text = "Delete";
                btnRemove.Click += (theSender, evt) => RemoveFromCart_Click(theSender, evt, item.ItemId);
                btnCell.Controls.Add(btnRemove);
                tblrow.Cells.Add(btnCell);
                table.Rows.Add(tblrow);

                // price for cart upon checkout
                totalCartPrice += item.Price * item.ShoppingCartQuantity;
            }
        }
        var footer = new TableFooterRow();
        footer.TableSection = TableRowSection.TableFooterRow;
        footer.Cells.Add(AddCell("<strong>Cart Total: " + totalCartPrice.ToString("C", CultureInfo.CurrentCulture) + "</strong>"));
        table.Rows.Add(footer);
        return table;
    }

    private void RemoveFromCart_Click(object sender, EventArgs e, int itemId)
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

    private Button GenerateCheckoutButton()
    {
        var btn = new Button();
        btn.Attributes["class"] = "btn btn-outline-primary";
        btn.Text = "Checkout";
        return btn;
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