using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class InventoryPage : System.Web.UI.Page
{
    public List<InventoryItem> InventoryItems { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        InventoryItems = (List<InventoryItem>) Session["InventoryItems"];
        if (InventoryItems is null)
        {
            InventoryItems = new List<InventoryItem>();
            ReadFromDatabase();
            Session["InventoryItems"] = InventoryItems;
        }
        GenerateHtml();
    }

    public void GenerateHtml()
    {
        HtmlGenericControl div = new HtmlGenericControl("div");
        div.Attributes["class"] = "row";
        foreach (InventoryItem item in InventoryItems)
        {
            div.InnerHtml += item.ToHTML(false);
        }
        inventoryDump.Controls.Add(div);
    }

    public void ReadFromDatabase()
    {
        SqlConnection connection = new SqlConnection();
        SqlCommand command;
        SqlDataReader dataReader;
        connection.ConnectionString = "Data Source=sql5039.site4now.net;Initial Catalog=DB_A444A7_sales;Persist Security Info=True;User ID=DB_A444A7_sales_admin;Password=Jigglypuff42";
        try
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
            connection.Open();
            command = new SqlCommand("SELECT * FROM Inventory", connection);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                InventoryItem currentItem = new InventoryItem
                {
                    ItemId = int.Parse(dataReader["ItemId"].ToString()),
                    ItemName = dataReader["ItemName"].ToString(),
                    Quantity = int.Parse(dataReader["QOH"].ToString()),
                    Price = double.Parse(dataReader["Price"].ToString()),
                    Weight = double.Parse(dataReader["Weight"].ToString()),
                    Status = dataReader["Status"].ToString(),
                    ShortDescription = dataReader["ShortDescription"].ToString(),
                    LongDescription = dataReader["LongDescription"].ToString(),
                    SmallImageUrl = dataReader["SmallImageUrl"].ToString(),
                    LargeImageUrl = dataReader["LargeImageUrl"].ToString()
                };
                InventoryItems.Add(currentItem);
            }
        }
        catch (Exception e)
        {
            HtmlGenericControl div = new HtmlGenericControl("div");
            div.InnerText = e.Message;
            inventoryDump.Controls.Add(div);
        }
        finally
        {
            connection.Close();
        }
    }
}