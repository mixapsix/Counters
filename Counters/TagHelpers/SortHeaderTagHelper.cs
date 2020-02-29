using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Counters.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Counters.TagHelpers
{
    public class SortHeaderTagHelper : TagHelper
    {
        public SortState Property { get; set; }
        public SortState Current { get; set; }
        public string Action { get; set; }
        public bool Up { get; set; }
        public FilterViewModel filterViewModel { get; set; }

        private readonly IUrlHelperFactory _urlHelperFactory;
        public SortHeaderTagHelper(IUrlHelperFactory urlHelperFactory)
        {
            _urlHelperFactory = urlHelperFactory;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);
            output.TagName = "a";
            string url = urlHelper.Action(Action, new { selectID = filterViewModel.SelectedID, selectValue = filterViewModel.SelectedValue, selectNumber = filterViewModel.SelectedNumber, sortOrder = Property });
            output.Attributes.SetAttribute("href", url);
            if(Current == Property)
            {
                TagBuilder tag = new TagBuilder("i");
                tag.AddCssClass("glyphicon");
                if (Up == true) tag.AddCssClass("glyphicon-chevron-up");
                else tag.AddCssClass("glyphicon-chevron-down");
                output.PreContent.AppendHtml(tag);
            }
        }
    }
}
