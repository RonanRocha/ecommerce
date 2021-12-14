using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ecommerce.Api.Helpers
{
    public  class SlugBuilder
    {

        public static string GenerateSlug(string phrase)
        {
            string str = RemoveAccent(phrase).ToLower();
            
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
          
            str = Regex.Replace(str, @"\s+", " ").Trim();
       
            str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim();

            str = Regex.Replace(str, @"\s", "-"); 
            return str;
        }

        public static string RemoveAccent(string txt)
        {
            return new string(txt
               .Normalize(NormalizationForm.FormD)
               .Where(ch => char.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
               .ToArray());
        }
    }
}
