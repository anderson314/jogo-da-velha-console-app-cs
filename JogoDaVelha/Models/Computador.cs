using System;
using System.Collections.Generic;
using System.Text;

namespace JogoDaVelha.Models
{
    class Computador
    {
        public static int jogar(params string[] tabuleiro)
        {
            string[] tab = new string[9] { "-", "-", "-", "-", "-", "-", "-", "-", "-" };

            Random random = new Random();

            List<int> posicoesLivres = new List<int>();

            int numeroEscolhido;

            int codigoRetorno;

            for (int e = 0; e < 9; e++)
            {
                if (tabuleiro[e] == " ")
                {
                    tab[e] = " ";

                    posicoesLivres.Add(e);
                }
            }

            // Verifica se não há espaços disponívis para o computador preencher
            if(posicoesLivres.Count == 0)
            {
                codigoRetorno = 1000;
                return codigoRetorno;
            }

            numeroEscolhido = posicoesLivres[random.Next(1, posicoesLivres.Count)];

            tabuleiro[numeroEscolhido] = Tabuleiro.vezJogador; 
            
            


            return numeroEscolhido;
        }
    }
}
