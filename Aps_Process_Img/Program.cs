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
            try
            {
                Saudacao();
                MenuPrincipal();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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
                Console.WriteLine("   2 - Comparar");
                Console.WriteLine("   3 - Listar todos usuários");
                Console.WriteLine("   4 - Sair");

                var MenuResult = int.Parse(Console.ReadLine());

                switch (MenuResult)
                {
                    case 1:
                        CadastrarDigital();
                        break;

                    case 2:
                        Comparar();
                        break;

                    case 3:
                        Listar();
                        break;

                    case 4:
                        MenuMantenedor = false;
                        break;
                }
            }
        }

        private static void Listar()
        {
            try
            {
                foreach(Models.Usuario U in Modules.BancoImagens.Ler())
                {
                    Console.WriteLine(string.Format("Usuário: {0} - Perfil: {1}", U.NomeUsuario, (int)U.CategoriaUser));
                }

                Console.WriteLine("");
                Console.WriteLine("Pressione qualquer tecla para voltar");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static void Comparar()
        {
            try
            {
                Console.WriteLine("");
                Console.WriteLine("Comparar!");
                Console.WriteLine("Digite o caminho completo para imagem:");
                var img = Console.ReadLine();

                var Digital = Modules.Tratamento.MontaAray(new Bitmap(Image.FromFile(img)));
                var LstImagens = Modules.BancoImagens.Ler();
                var histg = Modules.Comparador.ComparaHistogramas(Digital, LstImagens);

                var result = Modules.Comparador.CompararImagem(histg, Digital, LstImagens);
                if (result != null)
                {
                    Console.WriteLine(string.Format("Acesso liberado para Usuário: {0} - Perfil: {1}", result.NomeUsuario, (int)result.CategoriaUser));
                }
                else
                {
                    Console.WriteLine("Digital não reconhecida");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("");
            Console.WriteLine("Pressione qualquer tecla para voltar");
            Console.ReadKey();
        }

        private static void CadastrarDigital()
        {
            try
            {
                Console.WriteLine("");
                Console.WriteLine("Cadastrar!");
                Console.WriteLine("Digite o nome do usuário:");
                var nome = Console.ReadLine();
                Console.WriteLine("");

                Console.WriteLine("Digite o número do perfil de acesso:");
                Console.WriteLine("    1 - Público");
                Console.WriteLine("    2 - Diretor");
                Console.WriteLine("    3 - Ministro");
                var nivel = int.Parse(Console.ReadLine());
                Console.WriteLine("");

                Console.WriteLine("Digite o caminho completo para imagem:");
                var img = Console.ReadLine();
                Console.WriteLine("");

                Modules.BancoImagens.Salvar(new List<Models.Usuario>()
                {
                    new Models.Usuario
                    (nome,
                     Modules.Tratamento.MontaAray(new Bitmap(Image.FromFile(img))),
                     (Models.Usuario.Categoria)nivel)
                });
                Console.WriteLine("Cadastrado com sucesso!");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("");
            Console.WriteLine("Pressione qualquer tecla para voltar");
            Console.ReadKey();
        }
    }
}
