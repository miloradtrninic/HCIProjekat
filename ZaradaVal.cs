using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using Xceed.Wpf.Toolkit;

namespace HCIProjekat
{
    public class ZaradaVal:ValidationRule
    {
         public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
            {
            if (value is double)
            {
                double d = (double)value;
                if (d < -2100000000) return new ValidationResult(false, "Godišnji prihod je prevelika cifra.");
                if (d > 2100000000) return new ValidationResult(false, "Godišnji prihod je prevelika cifra.");
                return new ValidationResult(true, null);
            }
            else
            {
                return new ValidationResult(false, "Godišnji prihod nije cifra.");
            }
        }

            
    }



    public class OznakaSpomenikUnique : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var oznaka = value as string;
            foreach (Spomenik spomenik in Main.GetInstance().GetSpomenikLista)
            {
                if (spomenik.Oznaka.Equals(oznaka))
                {
                    return new ValidationResult(false, "Već postoji spomenik sa upisanom oznakom.");
                }
            }
            return new ValidationResult(true, null);
        }
    }

    public class OznakaEtiketaUnique : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var oznaka = value as string;
            foreach (Etiketa etiketa in Main.GetInstance().EtiketaLista)
            {
                if (etiketa.Oznaka.Equals(oznaka))
                {
                    return new ValidationResult(false, "Već postoji etiketa sa upisanom oznakom.");
                }
            }
            return new ValidationResult(true, null);
        }
    }

    public class ColorValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var color = value as Color?;
            if (color != null)
            {
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, "Molimo Vas da izaberete boju.");
        }
    }

    public class OznakaTipUnique : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var oznaka = value as string;
            foreach (TipSpomenika tipSpomenika in Main.GetInstance().TipspomenikaLista)
            {
                if (tipSpomenika.Oznaka.Equals(oznaka))
                {
                    return new ValidationResult(false, "Već postoji tip spomenika sa upisanom oznakom.");
                }
            }
            return new ValidationResult(true, null);
        }
    }

    public class StringDoubleValidation:ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var s = value as string;
                double r;
                if (double.TryParse(s, out r))
                {
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "Molimo Vas unesite ispravan broj.");
            }
            catch
            {
                return new ValidationResult(false, "Nepoznata greska. Kontaktirajte administratora.");
            }
        }
    }

    public class EmptyStringValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var s = value as string;

                if (s.Trim().Equals(""))
                {
                    return new ValidationResult(false, "Polje ne sme biti prazno.");
                }
                else
                {
                    return new ValidationResult(true, null);
                }
            }
            catch
            {
                return new ValidationResult(false, "Nepoznata greska. Kontaktirajte administratora.");
            }
        }
    }

    public class NumberCharValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var content = value as string;
                // @"[0-9a-zA-Z\x00-\x7F]+";
                string pattern = @"^[0-9\p{L}]+$";
                if (!Regex.IsMatch(content, pattern))
                {
                    return new ValidationResult(false, "Polje treba da sadrzi samo slova i brojeve.");
                }
                    return new ValidationResult(true, null);
                /*
                if (content.Contains("#") || content.Contains("?") || content.Contains("!") || content.Contains("/") ||
                    content.Contains("\\") || content.Contains("<") || content.Contains(">")
                    || content.Contains("|"))
                {
                    return new ValidationResult(false, "Polje ne sme da sadrzi # ? ! / \\ < > |");
                }
                else
                {
                    return new ValidationResult(true, null);
                }

                */
            }
            catch
            {
                return new ValidationResult(false, "Nepoznata greska. Kontaktirajte administratora.");
            }
        }
    }


}