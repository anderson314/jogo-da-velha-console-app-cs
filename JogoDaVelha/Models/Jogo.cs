using System;
using System.Collections.Generic;
using System.Text;

namespace JogoDaVelha.Models
{
    class Jogo
    {
        public static void inicioMenu()
        {
            Console.Title = "Jogo da Velha";
            Console.SetWindowSize(70, 20);

            string resposta = Jogo.escolhaMenu();

            while(resposta != "1" && resposta != "2" && resposta != "3")
            {
                resposta = Jogo.escolhaMenu();
            }

            // Inicia o jogo
            if(resposta == "1")
            {
                Tabuleiro.jogarPessoa();
            }
            //
            if(resposta == "2")
            {
                Tabuleiro.jogarComputador();
            }
            // Sai do jogo
            if (resposta == "3")
            {
                Console.Beep();
            }

        }

        private static string escolhaMenu()
        {
            Console.Clear();

            string resposta;

            Console.WriteLine("                        ===== JOGO DA VELHA =====\n\n");
            Console.WriteLine("         1 - Jogar 1x1");
            Console.WriteLine("         2 - Jogar contra o computador");
            Console.WriteLine("         3 - Sair");
            resposta = Console.ReadLine();

            return resposta;
        }
    }
}
