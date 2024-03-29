﻿using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProfitCalc.BLL;

#nullable disable

namespace ProfitCalc.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public decimal Revenue { get; set; }
        [BindProperty]
        public decimal Expenses { get; set; }
        [DisplayName("Net Profit")]
        public string NetProfit { get; private set; }

        public IndexModel(ILogger<IndexModel> logger) => this._logger = logger;

        public void OnGet()
        {

        }

        public void OnPost()
        {
            IAccountingCalculator calculator = new AccountingCalculator();
            decimal net = calculator.CalculateNet(this.Revenue, this.Expenses);

            this.NetProfit = net.ToString("C");
        }
    }
}