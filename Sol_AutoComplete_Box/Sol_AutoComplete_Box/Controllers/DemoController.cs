using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sol_AutoComplete_Box.Models;

namespace Sol_AutoComplete_Box.Controllers
{
    public class DemoController : Controller
    {
        #region Constructor

        public DemoController()
        {
            Language = new LanguageModel();
        }

        #endregion Constructor

        #region Property

        [BindProperty]
        public LanguageModel Language { get; set; }

        #endregion Property

        #region Private Method

        private async Task<List<String>> SetLanguages()
        {
            return await Task.Run(() =>
            {
                var languageListObj = new List<String>()
                {
                    "ActionScript",
                        "AppleScript",
                        "Asp",
                        "BASIC",
                        "C",
                        "C++",
                        "Clojure",
                        "COBOL",
                        "ColdFusion",
                        "Csharp",
                        "Erlang",
                        "Fortran",
                        "Fsharp",
                        "Groovy",
                        "Haskell",
                        "Java",
                        "JavaScript",
                        "Lisp",
                        "Perl",
                        "PHP",
                        "Python",
                        "Ruby",
                        "Scala",
                        "Scheme",
                        "Vb"
                };

                return languageListObj;
            });
        }

        #endregion Private Method

        #region Action

        public async Task<IActionResult> Index()
        {
            // get a language
            var getlanguages = await SetLanguages();

            // Add langugae in Model
            Language.Languages = getlanguages;

            this.TempData["LanguageObject"] = JsonConvert.SerializeObject(Language);
            TempData.Keep();

            return View(Language);
        }

        public IActionResult OnSubmit()
        {
            // Read Hidden data Value
            var hiddenLanguageValue = Request.Form["hiddenSelectedValue"][0];

            ViewBag.SelectedLanguage = hiddenLanguageValue;

            var tempDataObj = TempData["LanguageObject"] as String;
            TempData.Keep();

            Language = JsonConvert.DeserializeObject<LanguageModel>(tempDataObj);

            return View("Index", Language);
        }

        #endregion Action
    }
}