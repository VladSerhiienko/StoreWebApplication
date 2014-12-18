using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace RozetkaWebApplication
{
  public class RozetkaFigure
  {
    public int Id { get; set; }
    public string Header { get; set; }
    public string Effect { get; set; }
    public string ImgSrc { get; set; }
    public string CaptureHtml { get; set; }

    public string CompileToHtml()
    {
      var price = (RozetkaDatabase.random.NextDouble() + 0.2) * 1000.0;
      CaptureHtml = CaptureHtml.Replace("$$$", price.ToString("C2"));

      string html = string.Format(
          "<figure class=\"{0}\"> <img src=\"{1}\"/> <figcaption>{2}</figcapture> </figure>"
          , Effect, ImgSrc, CaptureHtml
          );
      return html;
    }

  }

  public class RozetkaDatabase
  {
    public static Random random = new Random();
    public static SqlConnection storeConnection = null;

    public static void OpenConnection()
    {
      if (storeConnection == null)
      {
        Debug.WriteLine("store app: establishing sql connection");
        storeConnection = new SqlConnection(@"Data Source=(localdb)\ProjectsV12;Initial Catalog=RozetkaDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
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

    public static string CompileToHtml(IEnumerable<RozetkaFigure> figures)
    {
      var builder = new StringBuilder();

      foreach (var figGroup in figures.GroupBy(fig => fig.Header))
      {
        builder.Append("<h2>" + figGroup.Key + "</h2>");
        builder.Append("<div class=\"grid\">");
        foreach (var fig in figGroup)
          builder.Append(fig.CompileToHtml());
        builder.Append("</div>");
      }

      return builder.ToString();
    }

    public static IEnumerable<RozetkaFigure> SelectItems()
    {
      Debug.WriteLine("store app: selecting items");

      OpenConnection();
      SqlConnection sqlConnection = storeConnection;
      SqlDataReader reader = null;

      try
      {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SELECT * FROM [dbo].[RozetkaFigures]";
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

        /*
        Debug.WriteLine("store app: visible fields " + reader.VisibleFieldCount);
        for (int i = 0; i < reader.VisibleFieldCount; i++)
        {
          Debug.WriteLine(
            "store app: field " + i + ": " + reader.GetName(i) 
            + " is " + reader.GetFieldType(i).Name
            );
        }
        */

        while (reader.Read())
        {
          rows++;
          yield return new RozetkaFigure()
          {
            Id = reader.GetInt32(0),
            Header = reader.GetString(1),
            Effect = reader.GetString(2),
            ImgSrc = reader.GetString(3),
            CaptureHtml = reader.GetString(4),
          };
        }

        Debug.WriteLine("store app: found " + rows + " items");
      }

      CloseConnection();
    }

  }
}