using System;

namespace Trabalho_TiGIRay.Utils {
    public class MenuUtils {
        public static void MenuDeslogado () {
            string barraMenu = "================================";

            System.Console.WriteLine (barraMenu);
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine (" ====== Finanças de Mesa ====== ");
            Console.ResetColor ();
            System.Console.WriteLine (barraMenu);
            System.Console.WriteLine (" ||   (1) Cadastrar Usuário   || ");
            System.Console.WriteLine (" ||   (2) Fazer Login         || ");
            System.Console.WriteLine (" ||   (0) Sair                || ");
            System.Console.WriteLine (barraMenu);
            System.Console.WriteLine (" ||   Escolha uma opção       || ");
            System.Console.WriteLine (barraMenu);
        }

        public static void MenuLogado () {
            string barraMenu = "================================";

            System.Console.WriteLine (barraMenu);
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine (" ====== Finanças de Mesa ====== ");
            Console.ResetColor ();
            System.Console.WriteLine (barraMenu);
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine (" ======      Logado      ====== ");
            Console.ResetColor ();
            System.Console.WriteLine (barraMenu);
            System.Console.WriteLine (" || (1) Cadastrar Transações  || ");
            System.Console.WriteLine (" || (2) Listar Trasaçôes      || ");
            System.Console.WriteLine (" || (3) Relatório no Word     || ");
            System.Console.WriteLine (" || (0) Sair                  || ");
            System.Console.WriteLine (barraMenu);
            System.Console.WriteLine (" ||   Escolha uma opção       || ");
            System.Console.WriteLine (barraMenu);
        }
    }
}
