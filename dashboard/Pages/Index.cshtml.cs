using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dashboard.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; } = "csharp";

        public Models.Item[] Items { get; set; }

        public string Body { get; set; }

        public void OnGet()
        {
            this.Items = new Models.Item[] { };

            var _Body = string.Empty;

            try
            {
                _Body = new System.Net.WebClient()
                {
                    Encoding = System.Text.Encoding.UTF8
                }.DownloadString($"https://raw.githubusercontent.com/data-go-kr/static-data-ekapepia-{Id}/main/Data/legacy-latest.xml");

                var _Response = dashboard.Models.Response.ToModel(_Body);

                this.Body = System.Xml.Linq.XDocument.Parse(_Body).ToString();
                this.Items = _Response.Body.Items.Item.ToArray();
            }
            catch
            {
            }

        }
    }
}
