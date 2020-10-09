using System.Drawing;

namespace Aps_Process_Img.Models
{
    public class Usuario
    {
        public string NomeUsuario { get; private set; }
        public byte[,] ImpressaoDigital { get; private set; }

        public Usuario(string nomeUsuario, byte[,] impressaoDigital)
        {
            NomeUsuario = nomeUsuario;
            ImpressaoDigital = impressaoDigital;
        }
    }
}
