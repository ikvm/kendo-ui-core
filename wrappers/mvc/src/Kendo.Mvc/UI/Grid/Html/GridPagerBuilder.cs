namespace Kendo.Mvc.UI.Html
{
    public class GridPagerBuilder : IGridPagerBuilder
    {
        private readonly IGridPagerSectionsBuilder pagerSections;
        private readonly IGridPagerRefreshBuilder refreshBuilder;
        private readonly IGridPagerStatusBuilder statusBuilder;

        public GridPagerBuilder(IGridPagerSectionsBuilder pagerSections, 
            IGridPagerRefreshBuilder refreshBuilder, IGridPagerStatusBuilder statusBuilder)
        {
            this.pagerSections = pagerSections;
            this.refreshBuilder = refreshBuilder;
            this.statusBuilder = statusBuilder;
        }

        public virtual IHtmlNode Create(GridPagerData section)
        {
            var fragment = new HtmlFragment();

            pagerSections.CreateSections(section).AppendTo(fragment);

            if (section.Refresh)
            {
                refreshBuilder.Create(section.UrlBuilder.SelectUrl(), section.Messages.Refresh).AppendTo(fragment);
            }

            if (section.Input)
            {
                statusBuilder.Create(section).AppendTo(fragment);
            }

            return fragment;
        }
        
        public IHtmlNode CreateRefreshButton(GridPagerData pagerData)
        {
            return refreshBuilder.Create(pagerData.UrlBuilder.SelectUrl(), pagerData.Messages.Refresh);
        }
    }
}