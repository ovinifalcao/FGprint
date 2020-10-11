using System.Drawing;

namespace Aps_Process_Img.Models
{
    public class Usuario
    {
        public string NomeUsuario { get; set; }
        public byte[,] ImpressaoDigital { get; set; }

        public Usuario(string nomeUsuario, byte[,] impressaoDigital)
        {
            NomeUsuario = nomeUsuario;
            ImpressaoDigital = impressaoDigital;
        }

        public Usuario()
        {

        }
    }
}
