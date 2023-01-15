using _2022_87_Alpha_Golftours.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

namespace _2022_87_Alpha_Golftours.Controller
{
    public class SearchResultsController : RenderController
    {
        private readonly IPublishedValueFallback _publishedValueFallback;
        private readonly ISearchService _searchService;

        public SearchResultsController(
            ILogger<RenderController> logger,
            ICompositeViewEngine compositeViewEngine,
            IUmbracoContextAccessor umbracoContextAccessor,
            IPublishedValueFallback publishedValueFallback,
            ISearchService searchService)
            : base(logger,
                compositeViewEngine,
                umbracoContextAccessor)
        {
            _publishedValueFallback = publishedValueFallback;
            _searchService = searchService;
        }

        public override IActionResult Index()
        {
            // Get the queryString from the request
            string queryString = HttpContext.Request.Query["searchText"];

            // Create the view model and pass it to the view
            SearchViewModel viewModel = new(CurrentPage!, _publishedValueFallback)
            {
                SearchResults = _searchService.SearchContentNames(queryString),
                HasSearched = !string.IsNullOrEmpty(queryString),
            };

            return CurrentTemplate(viewModel);
        }
    }
}
