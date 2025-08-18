namespace SistemaClientesSenai.Classes
{
    public class Clientes
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }

        protected float valor;
        protected float valor_imposto;
        protected float total;

        public Clientes(string nome, string endereco)
        {
            Nome = nome;
            Endereco = endereco;
        }

        public virtual void Pagar_Imposto(float v)
        {
            valor = v;
            valor_imposto = valor * 0.10f;
            total = valor + valor_imposto;

            Console.WriteLine("\n--- Pagamento ---");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Valor: {valor:C}");
            Console.WriteLine($"Imposto (10%): {valor_imposto:C}");
            Console.WriteLine($"Total: {total:C}");
        }
    }
}
