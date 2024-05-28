using System;

namespace DescontoDeSalário
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcao = 0;
            Console.WriteLine("Seja bem vindo ao nosso sistema de processamento de olerite.");

            while (opcao == 0)
            {
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1: Iniciar;");
                Console.WriteLine("2: Sair;");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        ProcessaHolerite();
                        opcao = 0;
                        break;
                    case 2:
                        Console.WriteLine("Obrigado por usar nosso sistema!");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        public static void ProcessaHolerite()
        {
            Console.WriteLine("Digite o seu valor hora.");
            double valorHora = double.Parse(Console.ReadLine());
            Console.WriteLine("Digite quantas horas trabalhadas.");
            int horaTrabalhada = int.Parse(Console.ReadLine());

            double salarioBruto = CalculaSalarioBruto(horaTrabalhada, valorHora);
            double contribuicao = CalculaContribuicao(salarioBruto);
            double INSS = CalculaINSS(salarioBruto);
            double IR = CalculaIR(salarioBruto);
            double FGTS = CalculaFGTS(salarioBruto);
            double totalDescontos = IR + INSS + contribuicao;
            double salarioLiquido = salarioBruto - totalDescontos;
            
        }

        public static void ImprimeOlerite(double salarioBruto, double IR, double INSS, double FGTS, double totalDescontos, double salarioLiquido)
        {
            Console.WriteLine($"Salário bruto: R$ {salarioBruto.ToString("C")}\n");
            Console.WriteLine($"IR: R$ {IR.ToString("C")}\n");
            Console.WriteLine($"INSS: R$ {INSS.ToString("C")}\n");
            Console.WriteLine($"FGTS: R$ {FGTS.ToString("C")}\n");
            Console.WriteLine($"Total de descontos: R$ {totalDescontos.ToString("C")}\n");
            Console.WriteLine($"Salário líquido: R$ {salarioLiquido.ToString("C")}\n");
        }
        
        public static double CalculaSalarioBruto(int horas, double valorHora)
        {
            return valorHora * horas;
        }

        public static double CalculaContribuicao(double salarioBruto)
        {
            return salarioBruto * 0.03;
        }

        public static double CalculaFGTS(double salarioBruto)
        {
            return salarioBruto * 0.11;
        }

        public static double CalculaINSS(double salarioBruto)
        {
            return salarioBruto * 0.10;
        }

        public static double CalculaIR(double salarioBruto)
        {
            if (salarioBruto < 0)
            {
                Console.WriteLine("O salário não pode ser menor que 0.");
                return 0;
            }

            if (salarioBruto <= 900)
            {
                return 0;
            }

            else if (salarioBruto > 900 && salarioBruto <= 1500)
            {
                return salarioBruto * 0.05;
            }

            else if (salarioBruto > 1500 && salarioBruto <= 3500)
            {
                return salarioBruto * 0.1;
            }

            else if (salarioBruto > 3500)
            {
                return salarioBruto * 0.2;
            }

            return 0;
        }
    }
}

    

