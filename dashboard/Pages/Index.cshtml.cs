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

        public string Language { get; set; } = "csharp";

        public Models.Item[] Items { get; set; }

        public string Body { get; set; }

        public string SourceBody { get; set; }

        public void OnGet()
        {
            base.ViewData["Title"] = this.Id;
            this.Items = new Models.Item[] { };

            var _Body = string.Empty;

            try
            {
                _Body = new System.Net.WebClient()
                {
                    Encoding = System.Text.Encoding.UTF8
                }.DownloadString($"https://raw.githubusercontent.com/data-go-kr/static-data-ekapepia-{Id}/main/Data/legacy-latest.xml");

                var _Response = dashboard.Models.Response.ToModel(_Body);

                this.Body = _Body;
                this.Body = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>\r\n" + System.Xml.Linq.XDocument.Parse(_Body).ToString();
                this.Items = _Response.Body.Items.Item.ToArray();
            }
            catch
            {
            }

            var _Url = this.Id switch
            {
                "python" => $"https://raw.githubusercontent.com/data-go-kr/static-data-ekapepia-python/main/Source/main.py",
                "nodejs" => $"https://raw.githubusercontent.com/data-go-kr/static-data-ekapepia-nodejs/main/Source/main.js",
                _ => $"https://raw.githubusercontent.com/data-go-kr/static-data-ekapepia-csharp/main/Source/Program.cs"
            };

            this.Language = this.Id == "nodejs" ? "javascript" : this.Id;

            try
            {
                _Body = new System.Net.WebClient()
                {
                    Encoding = System.Text.Encoding.UTF8
                }.DownloadString(_Url);

                this.SourceBody = _Body;
            }
            catch
            {
            }
        }
    }
}
