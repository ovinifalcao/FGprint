using System;
using System.IO;
using System.Drawing;

namespace Aps_Process_Img
{
    class Program
    {

        static void Main(string[] args)
        {
            var imgbit = Modules.TratamentoDeImagem.MontaAray(new Bitmap(Image.FromFile(@"C:\Users\andre.falcao\Pictures\fingerprint102.jpg")));
            //var histograma = Modules.TratamentoDeImagem.MontaHistograma(imgbit);

            var eu = new Bitmap(imgbit.GetLength(0), imgbit.GetLength(1));
            Graphics flagGraphics = Graphics.FromImage(eu);

            for (int w = 0; w < imgbit.GetLength(0) - 1; w++)
            {
                for (int h = 0; h < imgbit.GetLength(1) - 1; h++)
                {
                   // if(imgbit[w,h] < 200) 
                        flagGraphics.FillRectangle( new SolidBrush(Color.FromArgb(255, imgbit[w, h], imgbit[w, h], imgbit[w, h])), w, h, 1, 1);
                }
            }

            eu.Save(@"C:\Users\andre.falcao\Pictures\vishiecol.jpg");
            //Saudacao();
            //MenuPrincipal();
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
