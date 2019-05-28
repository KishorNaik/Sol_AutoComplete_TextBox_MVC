using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Newtonsoft.Json;

namespace Sol_AutoComplete_Box.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("jQuery-AutoComplete")]
    public class AutoCompleteTextBoxTagHelper : TagHelper
    {
        #region Declaration

        private const string IdAttributeName = "id";
        private const string SourceAttributeName = "items-source";
        private const string MinLengthAttributeName = "min-length";

        private IHtmlHelper htmlHelper = null;

        #endregion Declaration

        #region Constructor

        #region Property

        [HtmlAttributeName(IdAttributeName)]
        public String Id { get; set; }

        [HtmlAttributeName(SourceAttributeName)]
        public ModelExpression ItemSource { get; set; }

        [HtmlAttributeName(MinLengthAttributeName)]
        public int MinLength { get; set; }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        #endregion Property

        public AutoCompleteTextBoxTagHelper(IHtmlHelper htmlHelper)
        {
            this.htmlHelper = htmlHelper;
        }

        #endregion Constructor

        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            //Contextualize the html helper
            (htmlHelper as IViewContextAware).Contextualize(ViewContext);

            var autoCompleteBoxModelObj = new AutoCompleteTextBoxModel()
            {
                Id = Id,
                ItemSource = JsonConvert.SerializeObject(ItemSource.Model),
                MinLength = MinLength
            };

            var content = await htmlHelper?.PartialAsync("~/Views/Shared/_JqueryAutoCompleteTestBoxPartialView.cshtml", autoCompleteBoxModelObj);

            output.Content.SetHtmlContent(content);

            //return base.ProcessAsync(context, output);
        }
    }
}