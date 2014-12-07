using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace StoreWebApplication
{
  public partial class WebApp : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      Debug.WriteLine("store app: loaded");
      if (Request.QueryString["store-item-kind"] == null)
      {
        Debug.WriteLine("store app: redirecting with 'all products' argument");
        Response.Redirect(Request.Url + "?store-item-kind=all");
      }
    }
  }
}