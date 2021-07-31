using System;
using System.Collections.Generic;
using System.Text;

namespace JogoDaVelha.Models
{
    class Tabuleiro
    {
        public static string[] tabuleiro = new string[9] {" "," "," "," "," "," "," "," "," "};
        public static string vezJogador = "x";

        public static void imprimirTabuleiro()
        {

            Console.Clear();

            Console.WriteLine("\n");

            Console.WriteLine("          Selecione o campo de acordo com o tabuleiro abaixo:\n");

            Console.WriteLine("                            1 | 2 | 3   ");
            Console.WriteLine("                            4 | 5 | 6  ");
            Console.WriteLine("                            7 | 8 | 9  ");
            Console.WriteLine("     ");

            Console.WriteLine("                            {0} | {1} | {2}", tabuleiro[0].ToUpper(), tabuleiro[1].ToUpper(), tabuleiro[2].ToUpper());
            Console.WriteLine("                            {0} | {1} | {2}", tabuleiro[3].ToUpper(), tabuleiro[4].ToUpper(), tabuleiro[5].ToUpper());
            Console.WriteLine("                            {0} | {1} | {2}", tabuleiro[6].ToUpper(), tabuleiro[7].ToUpper(), tabuleiro[8].ToUpper());
            Console.WriteLine(" \n                 Digite /voltar, para voltar.\n");
            Console.WriteLine("     \n");


        }

        private static string alterarVez()
        {
            if (vezJogador == "x")
                vezJogador = "o";
            else
                vezJogador = "x";

            return vezJogador;
        }

        public static void jogarPessoa()
        {
            jogar(1);
        }
        public static void jogarComputador()
        {
            jogar(2);
        }

        private static void jogar(int modoJogo)
        {
            string jogada;

            // Vai pressionar a jogada até que alguém ganhe
            do
            {
                // vai imprimir o tabuleiro e pressionar a jogada se o jogador
                // pressione a tecla errada ( 1 a 9) ou tentar substituir a jogada.
                do
                {
                    imprimirTabuleiro();
                    jogada = Console.ReadLine();

                    if (jogada == "/voltar")
                    {
                        Tabuleiro.resetarTabuleiro();
                        Jogo.inicioMenu();
                    }

                }
                while (
                     // teclas corretas
                     (jogada != "1" && jogada != "2" &&
                      jogada != "3" && jogada != "4" &&
                      jogada != "5" && jogada != "6" &&
                      jogada != "7" && jogada != "8" && jogada != "9") ||

                      // se houver tentativa de substituição da jogada
                      tabuleiro[Convert.ToInt32(jogada) - 1] == "x" ||
                      tabuleiro[Convert.ToInt32(jogada) - 1] == "o"
                );

                // Verifica se o modo de jogo é contra o computador
                if (modoJogo == 2)
                {
                    // A jogada é atribuida ao tabueliro
                    tabuleiro[Convert.ToInt32(jogada) - 1] = vezJogador;

                    // se o usuário não ganhoum então o computador fará a jogada dele
                    if(verificarTabuleiro(tabuleiro) == " ")
                    {
                        alterarVez();

                        // escolhe um espaço vazio ao caso para jogar
                        int nmrEscolhido = Computador.jogar(tabuleiro);

                        // se houver espaços vazios, então atribuirá a jogada ao tabuleiro
                        if (nmrEscolhido != 1000)
                        {
                            tabuleiro[nmrEscolhido] = vezJogador;
                        }
                    }
 
                }
                else
                {
                    // A jogada é atribuida ao tabueliro
                    tabuleiro[Convert.ToInt32(jogada) - 1] = vezJogador;
                }

                // A vez é alterada
                 alterarVez();

            }
            while (verificarTabuleiro(tabuleiro) == " ");

            imprimirTabuleiro();

            // Emitirá uma mensgem de acordo com o resultado;
            if (verificarTabuleiro(tabuleiro) == "velha")
            {
                Console.WriteLine("                              Velha!"); ;
            }
            else
            {
                    Console.WriteLine("                    Parabéns, O '{0}' ganhou!", alterarVez()); ;

            }

            // Volta para o menu e reseta o tabuleiro
            Tabuleiro.resetarTabuleiro();

            Console.ReadKey();

            Jogo.inicioMenu();


        }

        public static string verificarTabuleiro(params string[] tab)
        {
            string resultado = " ";

            string[] velha = new string[9];

            // Velha ou empate
            if( (tab[0] == "x" || tab[0] == "o") &&
                (tab[1] == "x" || tab[1] == "o") &&
                (tab[2] == "x" || tab[2] == "o") &&
                (tab[3] == "x" || tab[3] == "o") &&
                (tab[4] == "x" || tab[4] == "o") &&
                (tab[5] == "x" || tab[5] == "o") &&
                (tab[6] == "x" || tab[6] == "o") &&
                (tab[7] == "x" || tab[7] == "o") &&
                (tab[8] == "x" || tab[8] == "o")
               )
            {
                resultado = "velha";
            }

            // 1.

            //  x | x | x
            //    |   |
            //    |   |

            // Ou

            //  o | o | o
            //    |   |
            //    |   |

            if ((tab[0] == "x" && tab[1] == "x" && tab[2] == "x") ||
               (tab[0] == "o" && tab[1] == "o" && tab[2] == "o"))
            {
                resultado = "ganha";
            }

            // 2.

            //    |   | 
            //  x | x | x
            //    |   |

            // Ou

            //    |   | 
            //  o | o | o
            //    |   |

            if ((tab[3] == "x" && tab[4] == "x" && tab[5] == "x") ||
               (tab[3] == "o" && tab[4] == "o" && tab[5] == "o"))
            {
                resultado = "ganha";
            }

            // 3.

            //    |   | 
            //    |   |
            //  x | x | x

            // Ou

            //    |   | 
            //    |   |
            //  o | o | o

            if ((tab[6] == "x" && tab[7] == "x" && tab[8] == "x") ||
               (tab[6] == "o" && tab[7] == "o" && tab[8] == "o"))
            {
                resultado = "ganha";
            }

            // 4.

            //  x |   | 
            //  x |   |
            //  x |   | 

            // Ou

            //  o |   | 
            //  o |   |
            //  o |   |  

            if ((tab[0] == "x" && tab[3] == "x" && tab[6] == "x") ||
               (tab[0] == "o" && tab[3] == "o" && tab[6] == "o"))
            {
                resultado = "ganha";
            }

            // 5.

            //    | x | 
            //    | x |
            //    | x | 

            // Ou

            //    | o | 
            //    | o |
            //    | o |  

            if ((tab[1] == "x" && tab[4] == "x" && tab[7] == "x") ||
               (tab[1] == "o" && tab[4] == "o" && tab[7] == "o"))
            {
                resultado = "ganha";
            }

            // 6.

            //    |   | x 
            //    |   | x
            //    |   | x

            // Ou

            //    |   | o
            //    |   | o
            //    |   | o

            if ((tab[2] == "x" && tab[5] == "x" && tab[8] == "x") ||
               (tab[2] == "o" && tab[5] == "o" && tab[8] == "o"))
            {
                resultado = "ganha";
            }

            // 7.

            //  x |   |  
            //    | x | 
            //    |   | x

            // Ou

            //  o |   | 
            //    | o | 
            //    |   | o

            if ((tab[0] == "x" && tab[4] == "x" && tab[8] == "x") ||
               (tab[0] == "o" && tab[4] == "o" && tab[8] == "o"))
            {
                resultado = "ganha";
            }

            // 8.

            //    |   | x
            //    | x | 
            //  x |   | 

            // Ou

            //    |   | o 
            //    | o | 
            //  o |   | 

            if ((tab[2] == "x" && tab[4] == "x" && tab[6] == "x") ||
               (tab[2] == "o" && tab[4] == "o" && tab[6] == "o"))
            {
                resultado = "ganha";
            }

            return resultado;
        }

        private static void resetarTabuleiro()
        {
            // Reseta o tabuleiro
            for (int e = 1; e < 10; e++)
            {
                tabuleiro[e - 1] = " ";
            }

            vezJogador = "x";
        }
    }
}
