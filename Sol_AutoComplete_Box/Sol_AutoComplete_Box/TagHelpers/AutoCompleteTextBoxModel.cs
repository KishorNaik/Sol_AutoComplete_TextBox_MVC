using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol_AutoComplete_Box.TagHelpers
{
    public class AutoCompleteTextBoxModel
    {
        public String Id { get; set; }

        public String ItemSource { get; set; }

        public int MinLength { get; set; }
    }
}