namespace LanguageTranslator.Models
{
    public class TranslationModel
    {
        private Dictionary<string, Dictionary<string, string>> _translations = new Dictionary<string, Dictionary<string, string>>()
        {
            {"Hello", new Dictionary<string, string>{{"fr", "Bonjour"}, {"es", "Hola"}, {"de", "Hallo"}}},
            {"Goodbye", new Dictionary<string, string>{{"fr", "Au revoir"}, {"es", "Adiós"}, {"de", "Auf Wiedersehen"}}}
        };

        // Method to get translation
        public string Translate(string word, string languageCode)
        {
            if (_translations.ContainsKey(word) && _translations[word].ContainsKey(languageCode))
            {
                return _translations[word][languageCode];
            }
            return "Translation not available";
        }
    }
}
