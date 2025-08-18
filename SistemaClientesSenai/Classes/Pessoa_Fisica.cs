using SistemaClientesSenai.Classes;
using System;
using System.Drawing;

namespace SistemaClientesSenai.Classes
{
    public class Pessoa_Fisica : Clientes
    {
        private string _cpf;
        private string _rg;

        public string Cpf
        {
            get => _cpf;
            set
            {
                var cpfLimpo = value.Replace(".", "").Replace("-", "").Replace(" ", "");
                if (cpfLimpo.Length != 11 || !long.TryParse(cpfLimpo, out _))
                {
                    throw new ArgumentException("CPF inválido. Deve conter 11 dígitos numéricos.");
                }
                _cpf = cpfLimpo;
            }
        }

        public string Rg
        {
            get => _rg;
            set
            {
                var rgLimpo = value.Replace(".", "").Replace("-", "").Replace(" ", "");
                if (rgLimpo.Length != 9 || !long.TryParse(rgLimpo, out _))
                {
                    throw new ArgumentException("RG inválido. Deve conter 9 dígitos numéricos.");
                }
                _rg = rgLimpo;
            }
        }

        public DateTime DataNascimento { get; set; }

        public Pessoa_Fisica(string nome, string endereco, string cpf, string rg, DateTime dataNascimento)
            : base(nome, endereco)
        {
            Cpf = cpf;
            Rg = rg;
            DataNascimento = dataNascimento;
        }

        public override void Pagar_Imposto(float v)
        {
            valor = v;
            valor_imposto = valor * 0.15f;
            total = valor + valor_imposto;

            Console.WriteLine("\n--- Dados do Pagamento PF ---");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"CPF: {Cpf}");
            Console.WriteLine($"Valor a ser pago: {valor:C}");
            Console.WriteLine($"Valor do Imposto (15%): {valor_imposto:C}");
            Console.WriteLine($"Valor Total com Imposto: {total:C}");
        }
    }
}
