using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace StoreWebApplication
{
  public class StoreItem
  {
    public int ItemId { get; set; }
    public int ItemKind { get; set; }
    public string ItemLink { get; set; }
    public string ItemFileUrl { get; set; }
    public string ItemHtmlDesc { get; set; }
  }

  public class StoreDatabase
  {
    public const string kStoreItemKindAll = "all"; // 0
    public const string kStoreItemKindElectronics = "electronics"; // 1
    public const string kStoreItemKindClothing = "clothing"; // 2
    public const string kStoreItemKindMultimedia = "multimedia"; // 3
    public const string kStoreItemKindToys = "toys"; // 4

    public static SqlConnection storeConnection = null;

    public static void OpenConnection()
    {
      if (storeConnection == null)
      {
        Debug.WriteLine("store app: establishing sql connection");
        storeConnection = new SqlConnection(@"Data Source=(localdb)\ProjectsV12;Initial Catalog=StoreDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
      }
    }
    public static void CloseConnection()
    {
      if (storeConnection != null)
      {
        Debug.WriteLine("store app: closing sql connection");
        storeConnection.Close();
      }
    }

    public static string HtmlSectionDesc(HttpRequestBase request, int sectionIndex)
    {
      System.Diagnostics.Debug.WriteLine("store app: evaluating html section attributes");
      var requestType = request.Params.Get("store-item-kind");

      int storeItemKind = 0; // all products
      if (requestType == kStoreItemKindElectronics) storeItemKind = 1;
      else if (requestType == kStoreItemKindClothing) storeItemKind = 2;
      else if (requestType == kStoreItemKindMultimedia) storeItemKind = 3;
      else if (requestType == kStoreItemKindToys) storeItemKind = 4;
      storeItemKind++;

      if (storeItemKind == sectionIndex)
      {
        return string.Format("class=\"tab-current\"", sectionIndex);
      }
      else
      {
        return string.Format("", sectionIndex);
      }
    }

    public static string HtmlSectionContainerDesc(HttpRequestBase request, int sectionIndex)
    {
      System.Diagnostics.Debug.WriteLine("store app: evaluating html section desc attributes");
      var requestType = request.Params.Get("store-item-kind");

      int storeItemKind = 0; // all products
      if (requestType == kStoreItemKindElectronics) storeItemKind = 1;
      else if (requestType == kStoreItemKindClothing) storeItemKind = 2;
      else if (requestType == kStoreItemKindMultimedia) storeItemKind = 3;
      else if (requestType == kStoreItemKindToys) storeItemKind = 4;
      storeItemKind++;

      if (storeItemKind == sectionIndex)
      {
        return string.Format("id=\"section-linetriangle-{0}\" class=\"content-current\"", sectionIndex);
      }
      else
      {
        return string.Format("id=\"section-linetriangle-{0}\"", sectionIndex);
      }
    }

    public static string CompileToHtml(HttpRequestBase request)
    {
      System.Diagnostics.Debug.WriteLine("store app: compiling items to html");

      int? storeItemKind = null; // all products
      var requestType = request.Params.Get("store-item-kind");
      if (requestType == kStoreItemKindElectronics) storeItemKind = 1;
      else if (requestType == kStoreItemKindClothing) storeItemKind = 2;
      else if (requestType == kStoreItemKindMultimedia) storeItemKind = 3;
      else if (requestType == kStoreItemKindToys) storeItemKind = 4;

      var htmlStream = new StringBuilder("<li class=\"title-box\"></li>");
      foreach (var item in SelectItems(storeItemKind))
      {
        htmlStream.Append("<li><a href=\"");
        htmlStream.Append(item.ItemLink);
        htmlStream.Append("\"><img src=\"");
        htmlStream.Append(item.ItemFileUrl);
        htmlStream.Append("\">");
        htmlStream.Append(item.ItemHtmlDesc);
        htmlStream.Append("</a></li>");
      }

      System.Diagnostics.Debug.WriteLine("store app: items were compiled to html");
      return htmlStream.ToString();
    }

    public static IEnumerable<StoreItem> SelectItems(int? storeItemKind)
    {
      System.Diagnostics.Debug.WriteLine("store app: selecting items");

      OpenConnection();
      SqlConnection sqlConnection = storeConnection;
      SqlDataReader reader = null;

      try
      {
        SqlCommand cmd = new SqlCommand();
        if (storeItemKind != null) // select by id
          cmd.CommandText = "SELECT * FROM [dbo].[StoreItems] WHERE [dbo].[StoreItems].[ItemKnd]=" + storeItemKind.ToString();
        else // select all
          cmd.CommandText = "SELECT * FROM [dbo].[StoreItems]";
        cmd.CommandType = CommandType.Text;
        cmd.Connection = sqlConnection;

        sqlConnection.Open();
        reader = cmd.ExecuteReader();
      }
      catch (Exception e)
      {
        System.Diagnostics.Debug.WriteLine(e.Message);
      }

      if (reader != null && reader.HasRows)
      {
        uint rows = 0;

        while (reader.Read())
        {
          rows++;
          yield return new StoreItem()
          {
            ItemId = reader.GetInt32(0),
            ItemKind = reader.GetInt32(1),
            ItemLink = reader.GetString(2),
            ItemFileUrl = reader.GetString(3),
            ItemHtmlDesc = reader.GetString(4),
          };
        }

        Debug.WriteLine("store app: found " + rows + " items");
      }

      CloseConnection();
    }


  }
}