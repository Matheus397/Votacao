using System;
using System.Collections.Generic;

namespace Votacao
{
    class Cadastro
    {
        public void CadastrarPautas()
        {

            List<Pauta> lst_pautas = new List<Pauta>();
            Eleitor eleitor = new Eleitor();
            Console.Write("Digite o nome da Pauta: ");
            string nome_Pauta = Console.ReadLine();
            Console.Write("Digite o ID da Pauta: ");
            string id_Pauta = Console.ReadLine();
            Pauta pt = new Pauta(id_Pauta, nome_Pauta);
            lst_pautas.Add(pt);

        }

        public void CadastrarEleitores()
        {

            List<Eleitor> lst_eleitores = new List<Eleitor>();              
            Console.Write("Digite o nome do Eleitor: ");
            string Nome = Console.ReadLine();
            Console.Write("Digite o CPF do Eleitor: ");
            string cpf = Console.ReadLine();
            Eleitor Eleitor = new Eleitor(Nome, cpf);
            lst_eleitores.Add(Eleitor);

        }

    }
}
