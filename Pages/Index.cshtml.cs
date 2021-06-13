using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using pwebsite.Models;

namespace pwebsite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly pwebsite.Data.pwebsiteContext _context;

        public IList<Summary> Summary { get; set; }

        //卧槽，我把logger和context位置换过也能跑对
        //怀疑传进来的参数是在某个全局单例"池"，根据类型取
        public IndexModel(ILogger<IndexModel> logger, pwebsite.Data.pwebsiteContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task OnGetAsync()
        {
            Summary = await _context.Summary.ToListAsync();
        }
    }
}
