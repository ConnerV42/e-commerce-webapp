using System;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class ItemDetailPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string itemId = Request.QueryString["Item"];
        if (itemId is null)
        {
            Server.Transfer("InventoryPage.aspx");
        }
        GenerateDetailHtml(int.Parse(itemId));
    }

    public void GenerateDetailHtml(int itemId)
    {
        HtmlGenericControl div = new HtmlGenericControl("div");
        div.Attributes["class"] = "row";
        var inventoryItem = GetInventoryItemById(itemId);
        if(inventoryItem != null)
        {
            div.InnerHtml = inventoryItem.ToHTML(true);
            inventoryDump.Controls.Add(div);
            AddDropdownQuantity(inventoryItem.Quantity);
        }
    }

    public void AddToCart_Click(object sender, EventArgs e)
    {
        var inventoryItem = GetInventoryItemById(int.Parse(Request.QueryString["Item"]));
        if (inventoryItem != null)
        {
            if (inventoryItem.Quantity != 0)
            {
                inventoryItem.InShoppingCart = true;
                inventoryItem.ShoppingCartQuantity = quantityDropDown.SelectedIndex + 1;
                UpdateSessionState(inventoryItem);
                Server.Transfer("ShoppingCart.aspx");
            }
        }
    }

    public void ViewCart_Click(object sender, EventArgs e)
    {
        Server.Transfer("ShoppingCart.aspx");
    }

    private void AddDropdownQuantity(int quantity)
    {
        for (int i = 1; i < quantity + 1; i++)
        {
            quantityDropDown.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }
    }

    public InventoryItem GetInventoryItemById(int itemId)
    {
        var inventoryItems = (List<InventoryItem>) Session["InventoryItems"];
        foreach (var item in inventoryItems)
        {
            if (item.ItemId == itemId)
            {
                return item;
            }
        }
        return null;
    }

    public void UpdateSessionState(InventoryItem updatedItem)
    {
        var inventoryItems = (List<InventoryItem>) Session["InventoryItems"];
        foreach (var item in inventoryItems)
        {
            if (item == updatedItem)
            {
                item.InShoppingCart = updatedItem.InShoppingCart;
            }
        }
        Session["InventoryItems"] = inventoryItems;
    }
}