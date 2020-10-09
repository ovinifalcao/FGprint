using System;
using System.Collections.Generic;
using System.IO;
using Encriptador;
using Newtonsoft.Json;


namespace Aps_Process_Img.Modules
{
    class BancoImagens
    {
        private const string IDSK = "A&Adt8*a8rJEIYR574$%";
        private readonly string PastaLog = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Roaming\\FGcompare";
        private readonly string ArquivoLog = PastaLog + "\\log.json";


        public void SalvaUsuario(Models.Usuario User)
        {
            Directory.CreateDirectory(PastaLog);
            if (!File.Exists(ArquivoLog)) File.Create(ArquivoLog);

            var UsersPreExistentes = LerArquivo();
            UsersPreExistentes.Add(User);
            EscreverArquivo(UsersPreExistentes);
        }

        public List<Models.Usuario> LerArquivo()
        {
            using (var sr = new StreamReader(ArquivoLog))
            {
                var st = sr.ReadToEnd();

                if (string.IsNullOrEmpty(st))
                {
                    return (List<Models.Usuario>)JsonConvert.DeserializeObject(cls_Encriptador.Decriptar(IDSK, st));
                }

                return new List<Models.Usuario>();
                    
            }
        }

        private void EscreverArquivo(List<Models.Usuario> ListaDeUsuarios)
        {
            using (var sw = new StreamWriter(ArquivoLog))
            {
                sw.Write(cls_Encriptador.Encriptar(IDSK, JsonConvert.SerializeObject(ListaDeUsuarios)));
            }
        }
    }
}
