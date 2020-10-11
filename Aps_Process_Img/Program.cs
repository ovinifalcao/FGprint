using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;

namespace Aps_Process_Img
{
    class Program
    {

        static void Main(string[] args)
        {
            var imgbit = Modules.Tratamento.MontaAray(new Bitmap(Image.FromFile(@"C:\Users\andre.falcao\Pictures\fingerprint102.jpg")));
            //var imgbitA = Modules.Tratamento.MontaAray(new Bitmap(Image.FromFile(@"C:\Users\andre.falcao\Pictures\fingerprint102.jpg")));
            //var imgbitb = Modules.Tratamento.MontaAray(new Bitmap(Image.FromFile(@"C:\Users\andre.falcao\Pictures\fingerprint102 (2).jpg")));
            var imgbitc = Modules.Tratamento.MontaAray(new Bitmap(Image.FromFile(@"C:\Users\andre.falcao\Pictures\filename.jpg")));
            //var imgbitd = Modules.Tratamento.MontaAray(new Bitmap(Image.FromFile(@"C:\Users\andre.falcao\Pictures\vishiecol.jpg")));
            var imgbitf = Modules.Tratamento.MontaAray(new Bitmap(Image.FromFile(@"C:\Users\andre.falcao\Pictures\vishie.jpg")));
            //var imgbitg = Modules.Tratamento.MontaAray(new Bitmap(Image.FromFile(@"C:\Users\andre.falcao\Pictures\cont.jpg")));
            var imgbith = Modules.Tratamento.MontaAray(new Bitmap(Image.FromFile(@"C:\Users\andre.falcao\Pictures\cont3.jpg")));
            var imgbiti = Modules.Tratamento.MontaAray(new Bitmap(Image.FromFile(@"C:\Users\andre.falcao\Pictures\vishie3.jpeg")));
            //

            var ts = new List<Models.Usuario>();
            //ts.Add(new Models.Usuario() { NomeUsuario = "MesmaImagem", ImpressaoDigital = imgbitA });
            //ts.Add(new Models.Usuario() { NomeUsuario = "MaisBrilho", ImpressaoDigital = imgbitb});
            ts.Add(new Models.Usuario() { NomeUsuario = "OutraImagem", ImpressaoDigital = imgbitc });
            //ts.Add(new Models.Usuario() { NomeUsuario = "MaisContrate(>255)", ImpressaoDigital = imgbitd });
            ts.Add(new Models.Usuario() { NomeUsuario = "MenosConstraste(>200)", ImpressaoDigital = imgbitf });
            //ts.Add(new Models.Usuario() { NomeUsuario = "PoucaPercaDedados", ImpressaoDigital = imgbitg });
            //ts.Add(new Models.Usuario() { NomeUsuario = "GrandePercaDeDados", ImpressaoDigital = imgbith });
            ts.Add(new Models.Usuario() { NomeUsuario = "MesmaImagemEm90Graus", ImpressaoDigital = imgbiti });


            var XAD = Modules.Comparador.ComparaHistogramas(imgbit, ts);

            foreach (Tuple<string, int> u in XAD)
            {
                Console.WriteLine(u.Item1 + ", "  + u.Item2);
            }

            Console.Write(Modules.Comparador.CompararImagem(XAD, imgbit, ts));

            //int A = Modules.Comparador.InserteccionarMatrizes(Modules.Comparador.BinarizarImagem(imgbit), Modules.Comparador.BinarizarImagem(imgbitA));
            //var b = A >= ((imgbit.GetLength(0) * imgbit.GetLength(1)) * 0.85) ? true : false;

            //var histograma = Modules.TratamentoDeImagem.MontaHistograma(imgbit);

            //var eu = new Bitmap(imgbit.GetLength(0), imgbit.GetLength(1));
            //Graphics flagGraphics = Graphics.FromImage(eu);

            //for (int w = 0; w < imgbit.GetLength(0) - 1; w++)
            //{
            //    for (int h = 0; h < imgbit.GetLength(1) - 1; h++)
            //    {
            //       // if(imgbit[w,h] < 200) 
            //            flagGraphics.FillRectangle( new SolidBrush(Color.FromArgb(255, imgbit[w, h], imgbit[w, h], imgbit[w, h])), w, h, 1, 1);
            //    }
            //}

            //eu.Save(@"C:\Users\andre.falcao\Pictures\vishiecol.jpg");
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
