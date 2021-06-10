using FluentValidation.Validators;

namespace QPH_ParamsChannelsEnterprise.Core.Validations.Customized
{
    public class RUCValidator<T> : PropertyValidator
    {
        protected override bool IsValid(PropertyValidatorContext context)
        {
            var RUC = context.PropertyValue as string;
            return IsValidRUC(RUC);
        }

        protected override string GetDefaultMessageTemplate()
            => "{PropertyName} no es válido.";

        private bool IsValidRUC(string ruc)
        {
            bool estado = false;
            char[] valced = new char[13];

            int provincia;
            if (ruc.Length >= 10)
            {
                valced = ruc.Trim().ToCharArray();
                provincia = int.Parse((valced[0].ToString() + valced[1].ToString()));
                if (provincia > 0 && provincia < 25)
                {
                    if (int.Parse(valced[2].ToString()) < 6)
                    {
                        estado = VerifyID(valced);
                    }
                    else if (int.Parse(valced[2].ToString()) == 6)
                    {
                        estado = VerifyPublicCompanies(valced);
                    }
                    else if (int.Parse(valced[2].ToString()) == 9)
                    {

                        estado = VerifyLegalPerson(valced);
                    }
                }
            }
            return estado;
        }        

        private bool VerifyID(char[] id)
        {
            int aux = 0, par = 0, impar = 0, verifi;
            for (int i = 0; i < 9; i += 2)
            {
                aux = 2 * int.Parse(id[i].ToString());
                if (aux > 9)
                    aux -= 9;
                par += aux;
            }
            for (int i = 1; i < 9; i += 2)
            {
                impar += int.Parse(id[i].ToString());
            }

            aux = par + impar;
            if (aux % 10 != 0)
            {
                verifi = 10 - (aux % 10);
            }
            else
                verifi = 0;
            if (verifi == int.Parse(id[9].ToString()))
                return true;
            else
                return false;
        }
        private bool VerifyLegalPerson(char[] ruc)
        {
            int aux = 0, prod, veri;
            veri = int.Parse(ruc[10].ToString()) + int.Parse(ruc[11].ToString()) + int.Parse(ruc[12].ToString());
            if (veri > 0)
            {
                int[] coeficiente = new int[9] { 4, 3, 2, 7, 6, 5, 4, 3, 2 };
                for (int i = 0; i < 9; i++)
                {
                    prod = int.Parse(ruc[i].ToString()) * coeficiente[i];
                    aux += prod;
                }
                if (aux % 11 == 0)
                {
                    veri = 0;
                }
                else if (aux % 11 == 1)
                {
                    return false;
                }
                else
                {
                    aux = aux % 11;
                    veri = 11 - aux;
                }

                if (veri == int.Parse(ruc[9].ToString()))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool VerifyPublicCompanies(char[] ruc)
        {
            int aux = 0, prod, veri;
            veri = int.Parse(ruc[9].ToString()) + int.Parse(ruc[10].ToString()) + int.Parse(ruc[11].ToString()) + int.Parse(ruc[12].ToString());
            if (veri > 0)
            {
                int[] coeficiente = new int[8] { 3, 2, 7, 6, 5, 4, 3, 2 };

                for (int i = 0; i < 8; i++)
                {
                    prod = int.Parse(ruc[i].ToString()) * coeficiente[i];
                    aux += prod;
                }

                if (aux % 11 == 0)
                {
                    veri = 0;
                }
                else if (aux % 11 == 1)
                {
                    return false;
                }
                else
                {
                    aux = aux % 11;
                    veri = 11 - aux;
                }

                if (veri == int.Parse(ruc[8].ToString()))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }



}
