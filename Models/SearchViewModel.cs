using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace _2022_87_Alpha_Golftours.Models
{
    public class SearchViewModel : PublishedContentWrapped
    {

        public SearchViewModel(IPublishedContent content, IPublishedValueFallback publishedValueFallback)
            : base(content, publishedValueFallback)
        {
        }

        public IEnumerable<IPublishedContent> SearchResults { get; set; } = Enumerable.Empty<IPublishedContent>();
        public bool HasSearched { get; set; }
    }
}
