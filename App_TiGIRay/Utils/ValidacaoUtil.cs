namespace Trabalho_TiGIRay.Utils {
    public class ValidacaoUtil {
        public static bool ValidacaoEmail (string email) {
            if (email.Contains ("@") && email.Contains (".")) {
                return true;
            }
            return false;
        }

        public static bool ValidacaoSenha (string senha, string confirmacaoSenha) {
            if (confirmacaoSenha.Length > 5 && senha.Equals (confirmacaoSenha)) {
                return true;
            }
            return false;
        }
    }
}