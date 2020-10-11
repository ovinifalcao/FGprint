using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Aps_Process_Img.Modules
{
    public class Tratamento
    {

        public static byte[,] MontaAray(Bitmap img)
        {
            var ImgArray = new byte[img.Width, img.Height];

            for (int w = 0; w < img.Width - 1; w++)
            {
                for (int h = 0; h < img.Height - 1; h++)
                {
                    ImgArray[w, h] = ConverteParaEscalaDeCinza(img.GetPixel(w, h));
                }
            }
            return ImgArray;
        }

        public static byte ConverteParaEscalaDeCinza(Color ByteColor)
        {
            return byte.Parse(((ByteColor.R + ByteColor.B + ByteColor.G) / 3).ToString());
        }

        public static Dictionary<byte, int> MontaHistograma(byte[,] ByteImg)
        {
            return (from b in LinearizarImagem(ByteImg)
                    group b by b into bcount
                    select new Models.ItemHistograma
                    {
                        TomCinza = bcount.Key,
                        IntensidadeOcorrencia = bcount.Count()
                    }).ToDictionary(d => d.TomCinza, d => d.IntensidadeOcorrencia);
        }

        public static byte[] LinearizarImagem(byte[,] ByteImg)
        {
            var ImgLinar = new byte[ByteImg.Length];
            var ContadorLinear = 0;

            for (int w = 0; w < ByteImg.GetLength(0) - 1; w++)
            {
                for (int h = 0; h < ByteImg.GetLength(1) - 1; h++)
                {
                    ImgLinar[ContadorLinear] = ByteImg[w, h];
                    ContadorLinear++;
                }
            }
            return ImgLinar;
        }

    }
}
