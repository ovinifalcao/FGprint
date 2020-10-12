using System;
using System.Collections.Generic;
using System.IO;
using Encriptador;
using Newtonsoft.Json;


namespace Aps_Process_Img.Modules
{
    class BancoImagens
    {
        private static string IDSK = "f58dr5744tt54758$22fghy%egsd4211";
        private static readonly string PastaLog = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Roaming\\FGcompare";
        private static readonly string ArquivoLog = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Roaming\\FGcompare\\log.json";


        public static void Salvar(List<Models.Usuario> User)
        {
            Directory.CreateDirectory(PastaLog);
            if (!File.Exists(ArquivoLog))
            {
                var fs = File.Create(ArquivoLog);
                fs.Close();
            }

            var UsersPreExistentes = Ler();
            UsersPreExistentes.AddRange(User);
            EscreverArquivo(UsersPreExistentes);
        }

        public static List<Models.Usuario> Ler()
        {
            using (var sr = new StreamReader(ArquivoLog))
            {
                var st = sr.ReadToEnd();

                if (!string.IsNullOrEmpty(st))
                {
                    return JsonConvert.DeserializeObject<List<Models.Usuario>>(cls_Encriptador.Decriptar(IDSK, st));
                }

                return new List<Models.Usuario>();
                    
            }
        }

        private static void EscreverArquivo(List<Models.Usuario> ListaDeUsuarios)
        {
            using (var sw = new StreamWriter(ArquivoLog))
            {
                sw.Write(cls_Encriptador.Encriptar(IDSK, JsonConvert.SerializeObject(ListaDeUsuarios)));
            }
        }
    }
}
