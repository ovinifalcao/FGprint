using System;
using System.Collections.Generic;
using System.Linq;

namespace Aps_Process_Img.Modules
{
    public class Comparador
    {  
        public static List<Tuple<string, int>> ComparaHistogramas(byte[,] digitalComparar, List<Models.Usuario> usuariosCadastrados)
        {
            var HistorgamasComparados = new List<Tuple<string, int>>();

            foreach (Models.Usuario Us in usuariosCadastrados)
            {
                HistorgamasComparados.Add(new Tuple<string, int>
                        (Us.NomeUsuario,
                        ContarSemelhançaDoHistograma(
                            Tratamento.MontaHistograma(digitalComparar),
                            Tratamento.MontaHistograma(Us.ImpressaoDigital))));
            }

            return HistorgamasComparados.OrderByDescending(T => T.Item2).ToList();
        }

        public static int ContarSemelhançaDoHistograma(Dictionary<byte, int> HistogramaComparar, Dictionary<byte, int> HistogramaUsuario)
        {
            int SomaSemelhancas = 0;
            for (byte B = 0; B < 255; B++)
            {
                var comparar = HistogramaComparar.ContainsKey(B) ? HistogramaComparar[B] : 0 ;
                var usuario = HistogramaUsuario.ContainsKey(B) ? HistogramaUsuario[B] : 0;

                if (comparar > (usuario - (usuario * 0.20)) && comparar < (usuario + (usuario * 0.20)))
                {
                    SomaSemelhancas++;
                }
            }
            return SomaSemelhancas;
        }

        public static Models.Usuario CompararImagem(List<Tuple<string, int>> PrioridadePorHistograma, byte[,] DigitalComparar, List<Models.Usuario> UsuariosCadastrados)
        {
            var FinalList = ReordenarLista(PrioridadePorHistograma, UsuariosCadastrados);
            var ResultadoDaComparacao = new List<Tuple<Models.Usuario, int>>();  

            foreach (Models.Usuario U in FinalList)
            {
                var ing = InserteccionarMatrizes(BinarizarImagem(U.ImpressaoDigital), BinarizarImagem(DigitalComparar));
                if (ing >= ((DigitalComparar.GetLength(0) * DigitalComparar.GetLength(1)) * 0.85)) ResultadoDaComparacao.Add(new Tuple<Models.Usuario, int>(U, ing));
                if (ing >= ((DigitalComparar.GetLength(0) * DigitalComparar.GetLength(1)) * 0.95)) return U;
            }

            if (ResultadoDaComparacao.Count > 0)
            {
                ResultadoDaComparacao.OrderByDescending(T => T.Item2);
                return ResultadoDaComparacao[0].Item1;
            }

            return null;
        }

        private static List<Models.Usuario> ReordenarLista(List<Tuple<string, int>> PrioridadePorHistograma, List<Models.Usuario> UsuariosCadastrados)
        {
            return (from U in UsuariosCadastrados
                    join P in PrioridadePorHistograma
                    on U.NomeUsuario equals P.Item1
                    orderby P.Item2 descending
                    select new Models.Usuario
                    {
                        NomeUsuario = U.NomeUsuario,
                        ImpressaoDigital = U.ImpressaoDigital,
                        CategoriaUser = U.CategoriaUser
                    }).ToList();
        }

        public static int InserteccionarMatrizes(bool[,] boolImgA, bool[,] boolImgB)
        {
            var ImgIntersec = 0;

            for (int w = 0; w < boolImgA.GetLength(0) - 1; w++)
            {
                for (int h = 0; h < boolImgA.GetLength(1) - 1; h++)
                {
                    if(boolImgA[w, h] == boolImgB[w, h]) ImgIntersec++;
                }
            }
            return ImgIntersec;
        }

        public static bool[,] BinarizarImagem(byte[,] img)
        {
            var BinImg = new bool[img.GetLength(0), img.GetLength(1)];
            for (int w = 0; w < img.GetLength(0) - 1; w++)
            {
                for (int h = 0; h < img.GetLength(1) - 1; h++)
                {
                    BinImg[w, h] = true;
                    if(img[w,h] < 247) BinImg[w, h] = false;
                }
            }
            return BinImg;
        }

    }
}
