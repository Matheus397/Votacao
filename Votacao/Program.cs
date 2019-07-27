using System;
using System.Collections.Generic;
using System.Linq;

namespace Votacao
{
    class Program
    {

        static void Main(string[] args)
        {
            bool laco = true;
            int op;
            List<Pauta> lst_pautas = JsonManipula.Desserializador("list_pauta.json");
            List<Eleitor> lst_eleitores = JsonManipula.DesserializadorEleitor("list_eleitor.json");
            Cadastro cadastrando = new Cadastro();

            while (laco == true)
            {
                lst_pautas = JsonManipula.Desserializador("list_pauta.json");
                lst_eleitores = JsonManipula.DesserializadorEleitor("list_eleitor.json");

                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Beep();
                Console.WriteLine();
                Console.WriteLine("\t\t============================== MENU DE REGISTRO ==============================\t\t");
                Console.WriteLine();
                Console.WriteLine("\t\t\t\t\tDigite um Opção a ser feita !:");
                Console.WriteLine();
                Console.WriteLine("\t\t\t\t\t1 - Cadastrar Pautas\n\t\t\t\t\t2 - Cadastrar Eleitores\n\t\t\t\t\t3 - Exibir Pautas\n\t\t\t\t\t4 - Exibir Eleitores\n\t\t\t\t\t5 - Vincular Eleitores à pautas\n\t\t\t\t\t6 - Iniciar votação\n\t\t\t\t\t7 - Exibir resultado\n\t\t\t\t\t");
                Console.WriteLine();
                op = Convert.ToInt32(Console.ReadLine());

                if (op == 1)
                {

                    Console.Write("Digite quantas Pautas você deseja cadastrar: \n");
                    int N = Convert.ToInt32(Console.ReadLine());

                    if (N == 0)
                        return;

                    for (int i = 0; i < N; i++)
                    {
                        cadastrando.CadastrarPautas();
                    }

                }

                else if (op == 2)
                {
                    Console.Write("Digite quantos Eleitores deseja cadastrar: \n");
                    int G = Convert.ToInt32(Console.ReadLine());

                    if (G == 0)
                        return;

                    Console.WriteLine();

                    for (int i = 0; i < G; i++)
                    {
                        cadastrando.CadastrarEleitores();
                    }
                }
                else if (op == 3)
                {
                    if (lst_pautas.Count == 0)
                        Console.WriteLine("Não contém pautas ainda!");
                    foreach (var d in lst_pautas)
                    {
                        Console.WriteLine($"Nome: {d.nome_Pauta}");
                        Console.WriteLine($"Id: {d.id_Pauta}");
                        Console.WriteLine("Eleitores:");

                        if (d.lst_eleitores == null)
                            Console.WriteLine("Sem Eleitores Cadastrados!");
                        else
                            foreach (var item in d.lst_eleitores)
                                Console.WriteLine(item.Nome);

                        Console.WriteLine();
                    }
                }
                else if (op == 4)
                {
                    if (lst_eleitores.Count == 0)
                        Console.WriteLine("Não contém eleitores ainda!");
                    foreach (var d in lst_eleitores)
                    {
                        Console.WriteLine($"Nome: {d.Nome}");
                        Console.WriteLine($"CPF: {d.cpf}");

                        Console.WriteLine();
                    }
                }
                else if (op == 5)
                {
                    Console.Write("Digite o ID da pauta a ser vinculada: \n");
                    int G = Convert.ToInt32(Console.ReadLine());
                    var pauta = new Pauta();

                    if (lst_pautas.Exists(x => x.id_Pauta == G))
                    {
                        pauta = lst_pautas[G];
                        Console.WriteLine();
                        Console.WriteLine($"Nome da pauta: {pauta.nome_Pauta}");
                        Console.WriteLine();
                        Console.Write("Digite quantos Eleitores deseja vincular nessa Pauta: \n");
                        int N = Convert.ToInt32(Console.ReadLine());

                        for (int i = 0; i < N; i++)
                        {
                            Console.WriteLine("Digite o CPF do Eleitor a ser vinculado!: ");
                            var cpf = Console.ReadLine();

                            if (lst_eleitores.Exists(s => s.cpf == cpf))
                            {
                                if (pauta.lst_eleitores == null)
                                    pauta.lst_eleitores = new List<Eleitor>();
                                var eleitor = new Eleitor();
                                foreach (var item in lst_eleitores)
                                    if (item.cpf == cpf)
                                        eleitor = item;

                                pauta.lst_eleitores.Add(eleitor);

                            }

                        }
                        JsonManipula.Serializador(lst_pautas, "list_pauta.json");


                    }
                    else
                        Console.WriteLine("Pauta não encontrada ou não cadastrada!");

                }
                else if (op == 6)
                {
                    Console.Write("Digite o ID da pauta a ser votada : \n");
                    int G = Convert.ToInt32(Console.ReadLine());
                    var pauta = new Pauta();

                    if (lst_pautas.Exists(x => x.id_Pauta == G))
                    {
                        pauta = lst_pautas[G];
                        pauta.votos_Contra = 0;
                        pauta.votos_Favor = 0;
                        Console.WriteLine();
                        Console.WriteLine($"Nome da pauta: {pauta.nome_Pauta}");
                        Console.WriteLine();

                        if (pauta.lst_eleitores == null)                     
                           Console.WriteLine("Não possui eleitores nesta pauta!");
                        

                        else if(pauta.lst_eleitores.Count == (pauta.votos_Favor + pauta.votos_Contra))                       
                          Console.WriteLine("Votação Encerrada");
                       
                        else
                            foreach (var eleitor in pauta.lst_eleitores)
                            {

                                Console.WriteLine($"Nome do Elietor: {eleitor.Nome}");
                                Console.WriteLine("Digite 1 - Para ser a favor da pauta\nDigite 2 - Para ser contra ela");
                                int voto = Convert.ToInt32(Console.ReadLine());

                                if (voto == 1)
                                    pauta.votos_Favor++;
                                else
                                    pauta.votos_Contra++;

                            }

                        JsonManipula.Serializador(lst_pautas, "list_pauta.json");
                        Console.WriteLine("Resultado da votação: ");
                        exibeResultado(pauta);

                    }
                    else
                        Console.WriteLine("Pauta não encontrada ou não cadastrada!");
                }
                else if (op == 7)
                {
                    foreach (var item in lst_pautas)
                    {
                        if (item.lst_eleitores.Count == (item.votos_Contra + item.votos_Favor))
                        {
                            Console.WriteLine($"Resultado da votação da pauta: {item.nome_Pauta}");
                            exibeResultado(item);

                        }
                    }

                }
            }
        }

        private static void exibeResultado(Pauta pauta)
        {
            Console.WriteLine($"Votos a Favor: {pauta.votos_Favor}\n");
            Console.WriteLine($"Votos Contra: {pauta.votos_Contra}\n");

            var pcF = (pauta.votos_Favor / pauta.lst_eleitores.Count) * 100;
            var pcC = (pauta.votos_Contra / pauta.lst_eleitores.Count) * 100;

            Console.WriteLine($"Porcentagem de votos a Favor: {pcF}%\n");
            Console.WriteLine();
            Console.WriteLine($"Porcentagem de votos Contra: {pcC}%\n");

        }
    }
}
