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
    public class ArticleModel : PageModel
    {

        private readonly ILogger<ArticleModel> _logger;

        private readonly pwebsite.Data.pwebsiteContext _context;

        public Article Article;

        public ArticleModel(ILogger<ArticleModel> logger, pwebsite.Data.pwebsiteContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task OnGetAsync(int year, int month, int day, string title)
        {
            var realeaseDate = new DateTime(year, month, day);
            var articles = await _context.Article
                .Where(a => a.ReleaseDate == realeaseDate && a.TitleURL == title)
                .Take(1)
                .ToListAsync();
            if (articles.Count == 0)
            {
                //404
            }
            Article = articles.FirstOrDefault();
        }
    }
}
