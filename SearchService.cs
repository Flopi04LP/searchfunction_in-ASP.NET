using System;
using System.Collections.Generic;
using System.Linq;
using Examine;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common;
using Umbraco.Extensions;

namespace _2022_87_Alpha_Golftours
{
    public class SearchService : ISearchService
    {
        private readonly IExamineManager _examineManager;
        private readonly UmbracoHelper _umbracoHelper;

        public SearchService(IExamineManager examineManager, UmbracoHelper umbracoHelper)
        {
            _examineManager = examineManager;
            _umbracoHelper = umbracoHelper;
        }

        public IEnumerable<IPublishedContent> SearchContentNames(string searchText)
        {
            IEnumerable<string> ids = Array.Empty<string>();
            if (!string.IsNullOrEmpty(searchText) && _examineManager.TryGetIndex("ExternalIndex", out IIndex? index))
            {
                ids = index
                    .Searcher
                    .CreateQuery("content")
                    .Field("nodeName", searchText)
                    .Execute()
                    .Select(x => x.Id);
            }

            foreach (var id in ids)
            {
                yield return _umbracoHelper.Content(id);
            }
        }
    }
}
