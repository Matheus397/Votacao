using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;


namespace Votacao
{
    class JsonManipula
    {
        public void Serializador(List<Pauta> trabalho, string trajetoAlvo)
        {

            try
            {
                StreamWriter file = new StreamWriter(trajetoAlvo);
                string armazenaJson = JsonConvert.SerializeObject(trabalho);
                file.Write(armazenaJson);
                file.Close();
            }

            catch (Exception x)
            {

                Console.WriteLine(x.Message);

            }
        }
    }
}
