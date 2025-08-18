using System;

namespace SistemaClientesSenai.Classes
{
    public class Pessoa_Juridica : Clientes
    {
        private string _cnpj;
        private string _ie;

        public string Cnpj
        {
            get => _cnpj;
            set
            {
                var cnpjLimpo = value.Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", "");
                if (cnpjLimpo.Length != 14 || !long.TryParse(cnpjLimpo, out _))
                    throw new ArgumentException("CNPJ inválido. Deve conter 14 dígitos numéricos.");
                _cnpj = cnpjLimpo;
            }
        }

        public string Ie
        {
            get => _ie;
            set
            {
                var ieLimpo = value.Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", "");
                if (ieLimpo.Length < 9 || ieLimpo.Length > 12 || !long.TryParse(ieLimpo, out _))
                    throw new ArgumentException("Inscrição Estadual inválida. Deve conter entre 9 e 12 dígitos numéricos.");
                _ie = ieLimpo;
            }
        }

        public Pessoa_Juridica(string nome, string endereco, string cnpj, string ie)
            : base(nome, endereco)
        {
            Cnpj = cnpj;
            Ie = ie;
        }

        public override void Pagar_Imposto(float v)
        {
            valor = v;
            valor_imposto = valor * 0.05f;
            total = valor + valor_imposto;

            Console.WriteLine("\n--- Pagamento PJ ---");
            Console.WriteLine($"Empresa: {Nome}");
            Console.WriteLine($"CNPJ: {Cnpj}");
            Console.WriteLine($"Valor: {valor:C}");
            Console.WriteLine($"Imposto (5%): {valor_imposto:C}");
            Console.WriteLine($"Total: {total:C}");
        }
    }
}
