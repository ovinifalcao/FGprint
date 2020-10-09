using System;
using System.IO;
using System.Drawing;

namespace Aps_Process_Img
{
    class Program
    {

        static void Main(string[] args)
        {
            Saudacao();
            MenuPrincipal();
        }

        static void Saudacao()
        {
            Console.WriteLine("|||||||||||||| Bem Vindo ||||||||||||||");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("|||||||||||||| FGCompare ||||||||||||||");
            Console.WriteLine("=======================================");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        static void MenuPrincipal()
        {
            var MenuMantenedor = true;

            while (MenuMantenedor)
            {
                Console.WriteLine("Digite o número de  uma das opções:");
                Console.WriteLine("   1 - Cadastrar");
                Console.WriteLine("   2 - Comparar (Modo de Testes)");
                Console.WriteLine("   3 - Comparar (Modo Rápido)");
                Console.WriteLine("   4 - Sair");

                var MenuResult = int.Parse(Console.ReadLine());

                switch (MenuResult)
                {
                    case 1:
                        CadastrarDigital();
                        break;

                    case 2:
                        CompararModoTeste();
                        break;

                    case 3:
                        ComparaModoRapido();
                        break;

                    case 4:
                        MenuMantenedor = false;
                        break;
                }
            }
        }

        private static void ComparaModoRapido()
        {
            throw new NotImplementedException();
        }

        private static void CompararModoTeste()
        {
            throw new NotImplementedException();
        }

        private static void CadastrarDigital()
        {
            throw new NotImplementedException();
        }
    }
}
