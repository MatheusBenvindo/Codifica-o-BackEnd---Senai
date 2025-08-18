using System;
using SistemaClientesSenai.Classes;

namespace SistemaClientesSenai
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Bem-vindo ao Sistema de Controle de Clientes ClientLab");
            Console.WriteLine("-----------------------------------------------------");

            bool continuar = true;
            while (continuar)
            {
                Console.WriteLine("\nSelecione o tipo de cliente para cadastro:");
                Console.WriteLine("1 - Pessoa Física");
                Console.WriteLine("2 - Pessoa Jurídica");
                Console.WriteLine("3 - Sair");
                Console.Write("Opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        CadastrarPessoaFisica();
                        break;
                    case "2":
                        CadastrarPessoaJuridica();
                        break;
                    case "3":
                        continuar = false;
                        Console.WriteLine("\nEncerrando o sistema...");
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida. Tente novamente.");
                        break;
                }
            }
        }

        private static string LerEntradaObrigatoria(string mensagem)
        {
            string entrada;
            do
            {
                Console.Write(mensagem);
                entrada = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(entrada))
                    Console.WriteLine("Campo obrigatório. Por favor, preencha.");
            } while (string.IsNullOrWhiteSpace(entrada));
            return entrada;
        }

        public static void CadastrarPessoaFisica()
        {
            Console.WriteLine("\n--- Cadastro de Pessoa Física ---");

            string nome = LerEntradaObrigatoria("Nome: ");
            string endereco = LerEntradaObrigatoria("Endereço: ");

            string cpf;
            while (true)
            {
                cpf = LerEntradaObrigatoria("CPF (com ou sem formatação): ");
                try
                {
                    _ = new Pessoa_Fisica(nome, endereco, cpf, "000000000", DateTime.Now);
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                }
            }

            string rg;
            while (true)
            {
                rg = LerEntradaObrigatoria("RG (com ou sem formatação): ");
                try
                {
                    _ = new Pessoa_Fisica(nome, endereco, cpf, rg, DateTime.Now);
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                }
            }

            DateTime dataNascimento;
            while (true)
            {
                Console.Write("Data de Nascimento (dd/mm/aaaa): ");
                if (DateTime.TryParse(Console.ReadLine(), out dataNascimento))
                    break;
                Console.WriteLine("Data de nascimento inválida. Use o formato dd/mm/aaaa.");
            }

            try
            {
                Pessoa_Fisica pf = new Pessoa_Fisica(nome, endereco, cpf, rg, dataNascimento);

                Console.WriteLine("\n--- Dados Cadastrados ---");
                Console.WriteLine($"Nome: {pf.Nome}");
                Console.WriteLine($"Endereço: {pf.Endereco}");
                Console.WriteLine($"CPF: {pf.Cpf}");
                Console.WriteLine($"RG: {pf.Rg}");
                Console.WriteLine($"Data de Nascimento: {pf.DataNascimento.ToShortDateString()}");

                float valorPagar;
                while (true)
                {
                    Console.Write("\nDigite um valor para simular o pagamento de imposto: ");
                    if (float.TryParse(Console.ReadLine(), out valorPagar))
                        break;
                    Console.WriteLine("Erro: Valor inválido. Por favor, digite apenas números.");
                }
                pf.Pagar_Imposto(valorPagar);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"\nErro ao cadastrar pessoa física: {ex.Message}");
                Console.WriteLine("Tente novamente, por favor.");
            }
        }

        public static void CadastrarPessoaJuridica()
        {
            Console.WriteLine("\n--- Cadastro de Pessoa Jurídica ---");

            string nome = LerEntradaObrigatoria("Nome da Empresa: ");
            string endereco = LerEntradaObrigatoria("Endereço: ");

            string cnpj;
            while (true)
            {
                cnpj = LerEntradaObrigatoria("CNPJ (com ou sem formatação): ");
                try
                {
                    _ = new Pessoa_Juridica(nome, endereco, cnpj, "000000000");
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                }
            }

            string ie;
            while (true)
            {
                ie = LerEntradaObrigatoria("Inscrição Estadual (com ou sem formatação): ");
                try
                {
                    _ = new Pessoa_Juridica(nome, endereco, cnpj, ie);
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                }
            }

            try
            {
                Pessoa_Juridica pj = new Pessoa_Juridica(nome, endereco, cnpj, ie);

                Console.WriteLine("\n--- Dados Cadastrados ---");
                Console.WriteLine($"Nome da Empresa: {pj.Nome}");
                Console.WriteLine($"Endereço: {pj.Endereco}");
                Console.WriteLine($"CNPJ: {pj.Cnpj}");
                Console.WriteLine($"Inscrição Estadual: {pj.Ie}");

                float valorPagar;
                while (true)
                {
                    Console.Write("\nDigite um valor para simular o pagamento de imposto: ");
                    if (float.TryParse(Console.ReadLine(), out valorPagar))
                        break;
                    Console.WriteLine("Erro: Valor inválido. Por favor, digite apenas números.");
                }
                pj.Pagar_Imposto(valorPagar);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"\nErro ao cadastrar pessoa jurídica: {ex.Message}");
                Console.WriteLine("Tente novamente, por favor.");
            }
        }
    }
}
