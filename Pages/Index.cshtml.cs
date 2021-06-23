using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using pwebsite.Models;

namespace pwebsite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly pwebsite.Data.pwebsiteContext _context;

        private readonly IConfiguration _configuration;

        public IList<Summary> Summary { get; set; }

        public int CurrentPage { get; set; }

        public bool IsLastPage { get; set; }

        //卧槽，我把logger和context位置换过也能跑对
        //怀疑传进来的参数是在某个全局单例"池"，根据类型取
        public IndexModel(ILogger<IndexModel> logger, pwebsite.Data.pwebsiteContext context, IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            _configuration = configuration;
        }

        public async Task OnGetAsync(int? p)
        {
            int page = p.HasValue ? p.Value : 1;
            int summariesPerPage = _configuration.GetValue<int>("SummariesPerPage");
            var summaries = await _context.Summary
                .OrderByDescending(summary => summary.ReleaseDate)
                .Skip(Math.Max(page - 1, 0) * summariesPerPage)
                .Take(summariesPerPage + 1)
                .ToListAsync();
            CurrentPage = page;
            if (summaries.Count <= summariesPerPage)
            {
                IsLastPage = true;
                Summary = summaries;
            }
            else
            {
                IsLastPage = false;
                Summary = summaries.GetRange(0, summariesPerPage);
            }
        }
    }
}
