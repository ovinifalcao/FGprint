namespace Aps_Process_Img.Models
{
    public class Usuario
    {
        public string NomeUsuario { get; set; }
        public byte[,] ImpressaoDigital { get; set; }
        public Categoria CategoriaUser { get; set; }

        public enum Categoria
        {
            AcessoAberto = 1,
            DiretoresDivisoes = 2,
            Ministro = 3
        }

        public Usuario()
        {

        }

        public Usuario(string nomeUsuario, byte[,] impressaoDigital)
        {
            NomeUsuario = nomeUsuario;
            ImpressaoDigital = impressaoDigital;
        }

        public Usuario(string nomeUsuario, byte[,] impressaoDigital, Categoria categoriaUser)
        {
            NomeUsuario = nomeUsuario;
            ImpressaoDigital = impressaoDigital;
            CategoriaUser = categoriaUser;
        }
    }
}
