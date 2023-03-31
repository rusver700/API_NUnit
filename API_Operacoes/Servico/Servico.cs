using API_Operacoes;
using API_Operacoes.Interface;

namespace APINunit.Servico
{
    public class Servico : ValorEntrada, IServico
    {
        public double Dividir(double n1, double n2)
        {
            ValorEntrada(n1, n2);

            return Numero1 / Numero2;
        }

        public double Media(double n1, double n2)
        {
            ValorEntrada(n1, n2);

            return (Numero1 + Numero2) / 2;
        }

        public double Multiplicar(double n1, double n2)
        {
            ValorEntrada(n1, n2);

            return Numero1 * Numero2;
        }

        public double Somar(double n1, double n2)
        {
            ValorEntrada(n1, n2);

            return Numero1 + Numero2;
        }

        public double Subtrair(double n1, double n2)
        {
            ValorEntrada(n1, n2);

            return Numero1 - Numero2;
        }

        public void ValorEntrada(double n1, double n2)
        {
            Numero1 = n1;
            Numero2 = n2;
        }
    }
}
