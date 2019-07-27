using System.Collections.Generic;

namespace Votacao
{
    class Pauta
    {  
        public int id_Pauta { get; set; }
        public string nome_Pauta { get; set; }
        public int votos_Favor { get; set; }
        public int votos_Contra { get; set; }
        public List<Eleitor> lst_eleitores { get; set; } 

        public Pauta(int idPauta, string nomePauta, List<Eleitor> lst_eleitor)
        {
            lst_eleitores = lst_eleitor;
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

