using System;
using Trabalho_TiGIRay.Utils;

namespace Trabalho_TiGIRay {
    class Program {
        static void Main (string[] args) {
            int resposta = 0;

            do {
                MenuUtils.MenuDeslogado ();
                resposta = int.Parse (Console.ReadLine ());

                switch (resposta) {
                    case 1:
                        // Cadatrar usuario
                        break;

                    case 2:
                        // Efetuar login

                        // Opções de transações

                        break;

                    default:
                        System.Console.WriteLine ("Valor inválido!");
                        break;
                }
            } while ();
        }
    }
}