using System;
using System.Collections.Generic;

namespace Votacao
{
    class Cadastro
    {
        public void CadastrarPautas()
        {
            string caminho = "list_pauta.json";
            List<Pauta> lst_pautas = JsonManipula.Desserializador(caminho);
            var pauta = new Pauta();
            Console.Write("Digite o nome da Pauta: ");
            pauta.nome_Pauta = Console.ReadLine();
            pauta.id_Pauta = lst_pautas.Count;
            lst_pautas.Add(pauta);
            JsonManipula.Serializador(lst_pautas, caminho);
        }


        public void CadastrarEleitores()
        {
            string caminho = "list_eleitor.json";
            List<Eleitor> lst_eleitores = JsonManipula.DesserializadorEleitor(caminho);
            Console.Write("Digite o nome do Eleitor: ");
            string Nome = Console.ReadLine();
            Console.Write("Digite o CPF do Eleitor: ");
            string cpf = Console.ReadLine();

            if (lst_eleitores.Exists(a => a.cpf == cpf))
            {
                Console.WriteLine("CPF Cadastrado!");
                return;
            }


            Eleitor Eleitor = new Eleitor(Nome, cpf);
            lst_eleitores.Add(Eleitor);
            JsonManipula.Serializador(lst_eleitores, caminho);
        }

    }
}
