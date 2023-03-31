using API_Operacoes.Interface;

namespace APINunit.Servico
{
    public class OpcoesSwitch : IOpcoesSwitch
    {
        private readonly IServico _servico;
        private readonly ILogger<OpcoesSwitch> _loggerOpcoesSwitch;
        #region
       // public double Result { get; set; }
        #endregion
        public OpcoesSwitch(IServico servico, ILogger<OpcoesSwitch> logger)
        {
            _servico = servico;
            _loggerOpcoesSwitch = logger;
        }
        public double Opcao(string opcao, double n1, double n2)
        {
            double result = 0;

            switch (opcao)
            {
                case "1":
                    _loggerOpcoesSwitch.LogInformation($"Executando opcao {opcao}: Metado Subtrair");
                    result = _servico.Subtrair(n1, n2);
                    break;
                case "2":
                    result = _servico.Somar(n1, n2);
                    break;
                case "3":
                    result = _servico.Multiplicar(n1, n2);
                    break;
                case "4":
                    result = _servico.Dividir(n1, n2);
                    break;
                #region
                //case "test":
                //    _loggerOpcoesSwitch.LogInformation($"Opcao {opcao} valida");
                //    return Result = _servico.Media(n1, n2);
                #endregion
                case "5":
                    result = _servico.Media(n1, n2);
                    break;
                case "6":
                    _loggerOpcoesSwitch.LogInformation($"{opcao}: Valor Invalido.");
                    break;
                default:
                    _loggerOpcoesSwitch.LogError("Erro");
                    throw new ArgumentException("Erro: Excessão gerada...");
            }

            if (opcao != "6")
            {
                _loggerOpcoesSwitch.LogInformation($"Opcao {opcao} valida");
            }

            return result;
        }
    }
}
