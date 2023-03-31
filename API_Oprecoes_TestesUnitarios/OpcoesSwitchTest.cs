using API_Operacoes;
using API_Operacoes.Interface;
using APINunit.Servico;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Moq;

namespace API_Oprecoes_TestesUnitarios
{
    public class OpcoesSwitchTest
    {
        private Mock<IServico> _servicoMock = default!;
        private Mock<ILogger<OpcoesSwitch>> _logger = default!;
        private OpcoesSwitch _opcoesSwitch = default!;

        [SetUp]
        public void Setup()
        {
            _logger = new Mock<ILogger<OpcoesSwitch>>();
            _servicoMock = new Mock<IServico>();
            _opcoesSwitch = new OpcoesSwitch(_servicoMock.Object,_logger.Object);
        }

        [Test]
        [TestCase("1", 10, 5)]
        [TestCase("2", 6, 4)]
        [TestCase("3", 8, 4)]
        [TestCase("4", 5, 5)]
        [TestCase("5", 10, 2)]
        public void Opcoes_Validas(string opcao, double n1, double n2)
        {
            //Arrange
            var servico = new Servico();
            _opcoesSwitch = new OpcoesSwitch(servico, _logger.Object);

            //Act
            var act = _opcoesSwitch.Opcao(opcao,n1,n2);

            //Assert
            act.Should().NotBe(0);
        }

        [Test]
        public void Opcao_Subtrair()
        {
            //Arrange
            string opcao = "1";
            double n1 = 6, n2 = 3;
            //Act
            var act = () => _opcoesSwitch.Opcao(opcao, n1, n2);

            //Assert
            act.Should().NotBeNull();
            act.Should().NotThrow();
            _servicoMock.Verify(x => x.Subtrair(n1,n2), Times.Once());
            _logger.Verify(
                     x => x.Log(
                         It.Is<LogLevel>(l => l == LogLevel.Information),
                         It.IsAny<EventId>(),
                         It.Is<It.IsAnyType>((v, t) => v.ToString() == $"Executando opcao {opcao}: Metado Subtrair"),
                         It.IsAny<Exception>(),
                         It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)), Times.Once());
            _logger.Verify(
                     x => x.Log(
                         It.Is<LogLevel>(l => l == LogLevel.Information),
                         It.IsAny<EventId>(),
                         It.Is<It.IsAnyType>((v, t) => v.ToString() == $"Opcao {opcao} valida"),
                         It.IsAny<Exception>(),
                         It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)), Times.Once());

        }
        [Test]
        public void Opcao_Somar()
        {
            //Arrange
            string opcao = "2";
            double n1 = 6, n2 = 3;
            //Act
            var act = () => _opcoesSwitch.Opcao(opcao, n1, n2);

            //Assert
            act.Should().NotBeNull();
            act.Should().NotThrow();
            _servicoMock.Verify(x => x.Somar(n1,n2), Times.Once());
            _logger.Verify(
                 x => x.Log(
                     It.Is<LogLevel>(l => l == LogLevel.Information),
                     It.IsAny<EventId>(),
                     It.Is<It.IsAnyType>((v, t) => v.ToString() == $"Opcao {opcao} valida"),
                     It.IsAny<Exception>(),
                     It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)), Times.Once());

        }  [Test]
        public void Opcao_Multiplicar()
        {
            //Arrange
            string opcao = "3";
            double n1 = 6, n2 = 3;
            //Act
            var act = () => _opcoesSwitch.Opcao(opcao, n1, n2);

            //Assert
            act.Should().NotBeNull();
            act.Should().NotThrow();
            _servicoMock.Verify(x => x.Multiplicar(n1,n2), Times.Once()); 
            _logger.Verify(
                     x => x.Log(
                         It.Is<LogLevel>(l => l == LogLevel.Information),
                         It.IsAny<EventId>(),
                         It.Is<It.IsAnyType>((v, t) => v.ToString() == $"Opcao {opcao} valida"),
                         It.IsAny<Exception>(),
                         It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)), Times.Once());

        }  [Test]
        public void Opcao_Dividir()
        {
            //Arrange
            string opcao = "4";
            double n1 = 6, n2 = 3;
            //Act
            var act = () => _opcoesSwitch.Opcao(opcao,n1, n2);

            //Assert
            act.Should().NotBeNull();
            act.Should().NotThrow();
            _servicoMock.Verify(x => x.Dividir(n1,n2), Times.Once()); _logger.Verify(
                     x => x.Log(
                         It.Is<LogLevel>(l => l == LogLevel.Information),
                         It.IsAny<EventId>(),
                         It.Is<It.IsAnyType>((v, t) => v.ToString() == $"Opcao {opcao} valida"),
                         It.IsAny<Exception>(),
                         It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)), Times.Once());

        }  

        [Test]
        public void Opcao_Media()
        {
            //Arrange
            string opcao = "5";
            double n1 = 6, n2 = 3;
            //Act
            var act = () => _opcoesSwitch.Opcao(opcao,n1,n2);

            //Assert
            act.Should().NotBeNull();
            act.Should().NotThrow();
            _servicoMock.Verify(x => x.Media(n1,n2), Times.Once()); 
            _logger.Verify(
                     x => x.Log(
                         It.Is<LogLevel>(l => l == LogLevel.Information),
                         It.IsAny<EventId>(),
                         It.Is<It.IsAnyType>((v, t) => v.ToString() == $"Opcao {opcao} valida"),
                         It.IsAny<Exception>(),
                         It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)), Times.Once());

        }
        [Test]
        public void Valor_Invalido()
        {
            //Arrange
            string opcao = "6";
            //Act
            var act = () => _opcoesSwitch.Opcao(opcao,0,0);

            //Assert
            act.Should().NotBeNull();
            act.Should().NotThrow();
            _logger.Verify(
                     x => x.Log(
                         It.Is<LogLevel>(l => l == LogLevel.Information),
                         It.IsAny<EventId>(),
                         It.Is<It.IsAnyType>((v, t) => v.ToString() == $"{opcao}: Valor Invalido."),
                         It.IsAny<Exception>(),
                         It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)), Times.Once());
            _logger.Verify(
                    x => x.Log(
                        It.Is<LogLevel>(l => l == LogLevel.Information),
                        It.IsAny<EventId>(),
                        It.Is<It.IsAnyType>((v, t) => v.ToString() == $"Opcao {opcao} valida"),
                        It.IsAny<Exception>(),
                        It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)), Times.Never());

        }

        [Test]
        public void StringEmpy_Excessao()
        {
            //Arrange
            string opcao = "";

            //Act
            var act = () => _opcoesSwitch.Opcao(opcao, It.IsAny<double>(), It.IsAny<double>());

            //Assert
            act.Should().NotBeNull();
            act.Should().Throw<Exception>();
            _logger.Verify(
                  x => x.Log(
                      It.Is<LogLevel>(l => l == LogLevel.Error),
                      It.IsAny<EventId>(),
                      It.Is<It.IsAnyType>((v, t) => v.ToString() == "Erro"),
                      It.IsAny<Exception>(),
                      It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)), Times.Once());
            _logger.Verify(
                    x => x.Log(
                        It.Is<LogLevel>(l => l == LogLevel.Information),
                        It.IsAny<EventId>(),
                        It.Is<It.IsAnyType>((v, t) => v.ToString() == $"Opcao {opcao} valida"),
                        It.IsAny<Exception>(),
                        It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)), Times.Never());

        }

        [TestCase("1", 20, 10)]
        [TestCase("2", 30, 10)]
        [TestCase("3", 4, 10)]
        [TestCase("4", 100, 10)]
        [TestCase("5", 100, 50)]
        [TestCase("0", 100, 10)]
        [TestCase("", 100, 10)]
        public void Opcao_TryCatch(string opcao, double n1, double n2) 
        {
            //Arrange

            try
            {
                //Act
                var act = _opcoesSwitch.Opcao(opcao, n1, n2);

                //Assert
                act.Should();
                opcao.Should().NotBe("0");
                opcao.Should().NotBe("");

            }
            catch(Exception ex)
            {
                //Assert
                 Assert.That(ex.GetBaseException().Message, Is.EqualTo("Erro: Excessão gerada..."));
             
            }
        }

        [TestCase("1", 20, 10)]
        [TestCase("2", 30, 10)]
        [TestCase("0", 100, 10)]
        [TestCase("", 100, 10)]
        public void Opcao_TryCatch_Case_Funcao(string opcao, double n1, double n2)
        {
            //Arrange

            //Act
            var act = () => _opcoesSwitch.Opcao(opcao, n1, n2);

            //Assert
            try
            {
                act.Should();
                act.Should().NotThrow();
                opcao.Should().NotBe("0");
                opcao.Should().NotBe("");

            }
            catch (Exception)
            {
                act.Should().Throw<Exception>();
            }
        }

        [Test]
        public void Excessao_Funcao()
        {
            //Arrange

            //Act
            var act = () => _opcoesSwitch.Opcao(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<double>());

            //Assert

            act.Should().NotBeNull();
            act.Should().Throw<Exception>();
        }

        [Test]
        public void Excessao_TryCatch()
        {
            //Arrange

            try
            {
                //Act
                var act =_opcoesSwitch.Opcao(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<double>());

            }catch (Exception ex)
            { 
                //Assert
                Assert.That(ex.GetBaseException().Message, Is.EqualTo("Erro: Excessão gerada..."));
            }
        }
    }
}