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
            System.Console.WriteLine (barraMenu);
        }
    }
}