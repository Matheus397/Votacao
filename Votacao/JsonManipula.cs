using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;


namespace Votacao
{
    class JsonManipula
    {
        public static List<Pauta> Desserializador(string caminho)
        {
            try
            {
                var file = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + caminho);
                var objetos = JsonConvert.DeserializeObject<List<Pauta>>(file);
                return objetos;
            }
            catch (Exception)
            {
                return new List<Pauta>();
            }
        }

        public static List<Eleitor> DesserializadorEleitor(string caminho)
        {

            try
            {
                var file = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + caminho);
                var objetos = JsonConvert.DeserializeObject<List<Eleitor>>(file);
                return objetos;
            }
            catch (Exception)
            {
                return new List<Eleitor>();
            }

        }


        public static void Serializador(List<Pauta> trabalho, string trajetoAlvo)
        {

            try
            {
                StreamWriter file = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + trajetoAlvo);
                string armazenaJson = JsonConvert.SerializeObject(trabalho);
                file.Write(armazenaJson);
                file.Close();
            }

            catch (Exception x)
            {

                Console.WriteLine(x.Message);

            }
        }

        public static void Serializador(List<Eleitor> trabalho, string trajetoAlvo)
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
