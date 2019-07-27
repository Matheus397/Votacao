using System.Collections.Generic;

namespace Votacao
{
    class Pauta
    {  
        public List<Pauta> lst_pautas { get; set; } 
        public string id_Pauta { get; set; }
        public string nome_Pauta { get; set; }
        public List<Eleitor> lst_eleitores { get; set; } 
        public Eleitor eleitor { get; set; }

        public Pauta(string idPauta, string nomePauta)
        {

            id_Pauta = idPauta;
            nome_Pauta = nomePauta;
            
        }
        public Pauta()
        {
        }

    }

    class Eleitor
    {
        public string Nome { get; set; }
        public string cpf { get; set; }
        public Eleitor(string nome, string CPF)
        {
            Nome = nome;
            cpf = CPF;
        }

        public Eleitor()
        {
        }
    }
}

    //public override string ToString()
    //{
    //    return $"Nome: {nome_Pauta} Genero: {Company} Index: {index}";
    //}

