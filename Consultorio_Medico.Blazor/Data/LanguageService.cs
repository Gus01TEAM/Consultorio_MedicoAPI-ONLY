using System.Globalization;

namespace Consultorio_Medico.Blazor.Data
{
    public class LanguageService
    {
        public int Language = 0;

        public string Traduction(string Spanish, string English)
        {
            if (Language == 0)
            {
                return English;
            }
            else
            {
                return Spanish;
            }
        }
    }
}
