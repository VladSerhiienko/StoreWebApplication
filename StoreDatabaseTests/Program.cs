using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDatabaseTests
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
    public static string CompileToHtml(IEnumerable<StoreItem> items)
    {
      string html = string.Empty;


      return null;
    }

    public static IEnumerable<StoreItem> SelectItems()
    {
      SqlConnection sqlConnection = null;
      SqlDataReader reader = null;

      try
      {
        sqlConnection = new SqlConnection(@"Data Source=(localdb)\ProjectsV12;Initial Catalog=StoreDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
        SqlCommand cmd = new SqlCommand();

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
        while (reader.Read())
        {
          yield return new StoreItem()
          {
            ItemId = reader.GetInt32(0),
            ItemKind = reader.GetInt32(1),
            ItemLink = reader.GetString(2),
            ItemFileUrl = reader.GetString(3),
            ItemHtmlDesc = reader.GetString(4),
          };
        }
      }

      if (sqlConnection != null)
      {
        sqlConnection.Close();
      }
    }


  }

  class Program
  {
    static void Main(string[] args)
    {
      foreach (var item in StoreDatabase.SelectItems())
      {
        Console.WriteLine(item.ItemLink);
        Console.WriteLine(item.ItemHtmlDesc);
        Console.WriteLine(item.ItemFileUrl);
      }

      Console.WriteLine("Press any key to exit...");
      Console.ReadKey();
    }
  }
}
