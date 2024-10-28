using LanguageTranslator.Models;
using Microsoft.AspNetCore.Mvc;

namespace LanguageTranslator.Controllers
{
    public class TranslationController : Controller
    {
        private TranslationModel _translationModel;

        public TranslationController()
        {
            _translationModel = new TranslationModel();
        }

        // Display the form
        public IActionResult Index()
        {
            return View();
        }

        // Handle translation request
        [HttpPost]
        public IActionResult Translate(string word, string language)
        {
            // Check if the word and language are not empty
            if (!string.IsNullOrWhiteSpace(word) && !string.IsNullOrWhiteSpace(language))
            {
                // Get the translated word from the model
                string translatedWord = _translationModel.Translate(word, language);

                // Pass the translated word to the view using ViewBag
                ViewBag.TranslatedWord = translatedWord;
            }
            else
            {
                ViewBag.TranslatedWord = "Invalid input. Please try again.";
            }

            // Return the view with the translation result
            return View("Index");
        }
    }
}
