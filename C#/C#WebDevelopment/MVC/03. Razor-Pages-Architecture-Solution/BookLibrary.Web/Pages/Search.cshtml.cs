using BookLibrary.Data;
using BookLibrary.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BookLibrary.Web.Pages
{
    public class SearchModel : PageModel
    {
        public SearchModel(BookLibraryContext context)
        {
            this.Context = context;
            this.SearchResults = new List<SearchViewModel>();
        }

        public BookLibraryContext Context { get; private set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public List<SearchViewModel> SearchResults { get; set; }

        public void OnGet()
        {
            if (string.IsNullOrEmpty(this.SearchTerm))
            {
                return;
            }

            var foundAuthors = this.Context.Authors
                .Where(a => a.Name.ToLower().Contains(this.SearchTerm.ToLower()))
                .OrderBy(a => a.Name)
                .Select(a => new SearchViewModel()
                {
                    SearchResult = a.Name,
                    Id = a.Id,
                    Type = "Author"
                })
                .ToList();

            var foundBooks = this.Context.Books
                .Where(b => b.Title.ToLower().Contains(this.SearchTerm.ToLower()))
                .OrderBy(b => b.Title)
                .Select(b => new SearchViewModel()
                {
                    SearchResult = b.Title,
                    Id = b.Id,
                    Type = "Book"
                })
                .ToList();

            this.SearchResults.AddRange(foundAuthors);
            this.SearchResults.AddRange(foundBooks);

            foreach (var result in this.SearchResults)
            {
                string markedResult = Regex.Replace(
                    result.SearchResult, 
                    $"({Regex.Escape(this.SearchTerm)})", 
                    match => $"<strong class=\"text-danger\">{match.Groups[0].Value}</strong>",
                    RegexOptions.IgnoreCase | RegexOptions.Compiled);
                result.SearchResult = markedResult;
            }
        }
    }
}