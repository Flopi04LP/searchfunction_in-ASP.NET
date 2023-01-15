using System.Collections.Generic;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace _2022_87_Alpha_Golftours
{
    public interface ISearchService
    {
        IEnumerable<IPublishedContent> SearchContentNames(string searchText);
    }
}