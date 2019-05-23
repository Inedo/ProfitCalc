using System;
using System.Web.Configuration;
using System.Web.UI;
using ProfitCalc.BLL;

namespace ProfitCalc.Web
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            litWebConfigValue.Text = WebConfigurationManager.AppSettings["ProfitCalc.Value"];

            try
            {
                litVersion.Text = typeof(AccountingCalculator).Assembly.GetName().Version.ToString();
            }
            catch { }
        }
    }
}
