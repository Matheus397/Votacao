using System;
using System.Collections.Generic;

namespace Votacao
{
    class Program
    {

        static void Main(string[] args)
        {
            bool laco = true;
            int op;
            List<Pauta> lst_pautas = new List<Pauta>();
            List<Eleitor> lst_eleitores = new List<Eleitor>();                   
            Cadastro cadastrando = new Cadastro();

            while (laco == true){

                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Beep();
                Console.WriteLine();
                Console.WriteLine("\t\t============================== MENU DE REGISTRO ==============================\t\t");
                Console.WriteLine();
                Console.WriteLine("\t\t\t\t\tDigite um Opção a ser feita !:");
                Console.WriteLine();
                Console.WriteLine("\t\t\t\t\t1 - Cadastrar Pautas\n\t\t\t\t\t2 - Cadastrar Eleitores\n\t\t\t\t\t3 - Exibir Pautas\n\t\t\t\t\t4 - Exibir Eleitores\n\t\t\t\t\t");
                Console.WriteLine();
                op = Convert.ToInt32(Console.ReadLine());
       
                if (op == 1)
                {

                    Console.Write("Digite quantas Pautas você deseja cadastrar: \n");
                    int N = Convert.ToInt32(Console.ReadLine());

                    if (N == 0)
                        laco = false;

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
                        laco = false;

                    if (lst_pautas.Count == 0)
                    {
                        Console.WriteLine("Ainda não há pautas para cadastrar um eleitor");
                        Console.WriteLine();
                       
                        for (int u = 0; u < G; u++)
                        {
                            cadastrando.CadastrarPautas();
                        }
                    }
                 
                    Console.WriteLine();

                    for (int i = 0; i < G; i++)
                    {                       
                        cadastrando.CadastrarEleitores();
                    }     
                }
                else if (op == 3)
                {
                    foreach (var d in lst_pautas)
                    {
                        Console.WriteLine(d);
                    }
                }
                else if (op == 4)
                {
                    foreach(var t in lst_eleitores)
                    {
                        Console.WriteLine(t);
                    }
                }
            }
        }
    }
}
