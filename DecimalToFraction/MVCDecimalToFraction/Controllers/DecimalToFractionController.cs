using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDecimalToFraction.Controllers
{
  public class DecimalToFractionController : Controller
  {
    // GET: DecimalToFraction
    public ActionResult Index()
    {
      return View();
    }

    public ActionResult Welcome(string name, int timesCount = 1)
    {
      ViewBag.Message = "Hello " + name;
      ViewBag.TimesCount = timesCount;
      return View();
    }

    [AllowAnonymous]
    public ActionResult Calculate(Models.DecimalToFractionContent content)
    {
      if (content == null || content.Num == null || content.Num.Length == 0)
      {
        ViewBag.DoubleToFractionNum = "<no input>";
        ViewBag.DoubleToFractionResult = "<no results>";
      }
      else
      {
        double num = double.Parse(content.Num);
        ViewBag.DoubleToFractionNum = num.ToString();
        ViewBag.DoubleToFractionResult = DoubleToFraction(num);
      }

      return View();
    }

    public static string DoubleToFraction(double num, double epsilon = 0.0001, int maxIterations = 20)
    {
      double[] d = new double[maxIterations + 2];
      d[1] = 1;
      double z = num;
      double n = 1;
      int t = 1;

      int wholeNumberPart = (int)num;
      double decimalNumberPart = num - Convert.ToDouble(wholeNumberPart);

      while (t < maxIterations && Math.Abs(n / d[t] - num) > epsilon)
      {
        t++;
        z = 1 / (z - (int)z);
        d[t] = d[t - 1] * (int)z + d[t - 2];
        n = (int)(decimalNumberPart * d[t] + 0.5);
      }

      return string.Format((wholeNumberPart > 0 ? wholeNumberPart.ToString() + " " : "") + "{0}/{1}",
                           n.ToString(),
                           d[t].ToString()
                          );
    }




  }
}