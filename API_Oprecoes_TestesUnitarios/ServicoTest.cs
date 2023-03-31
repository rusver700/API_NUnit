using APINunit.Servico;
using Moq;

namespace API_Oprecoes_TestesUnitarios
{
    public class ServicoTest
    {
        private Servico _servico = default!;

        [SetUp]
        public void Setup()
        {
            _servico = new Servico() { Numero1 = 100, Numero2 = 40 };
        }

        [Test]
        public void Soma_Sucesso()
        {
            //Arrange
            double n1 = _servico.Numero1;
            double n2 = _servico.Numero2;

            //Act
            var result = _servico.Somar(n1, n2);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(140));
                Assert.That(result.ToString(), Is.Not.Empty);
                Assert.That(result, Is.Not.EqualTo(0));
            });
        }

        [Test]
        public void Subtrair_Sucesso()
        {
            //Arrange

            double n1 = _servico.Numero1;
            double n2 = _servico.Numero2;

            //Act
            var result = _servico.Subtrair(n1, n2);

            //Assert
            Assert.That(result, Is.EqualTo(60));
        }

        [Test]
        public void Dividir_Sucesso()
        {
            //Arrange

            double n1 = _servico.Numero1;
            double n2 = _servico.Numero2;

            //Act
            var result = _servico.Dividir(n1, n2);

            //Assert
            Assert.That(result, Is.EqualTo(2.5));
        }

        [Test]
        public void Multiplicar_Sucesso()
        {
            //Arrange
            double n1 = _servico.Numero1;
            double n2 = _servico.Numero2;

            //Act
            var result = _servico.Multiplicar(n1, n2);

            //Assert
            Assert.That(result, Is.EqualTo(4000));
        }

        [Test]
        public void Media_Sucesso()
        {
            //Arrange
            double n1 = _servico.Numero1;
            double n2 = _servico.Numero2;

            //Act
            var result = _servico.Media(n1, n2);

            //Assert
            Assert.That(result, Is.EqualTo(70));
        }

        [TestCase(20, 5)]
        [TestCase(-24, 12)]
        [TestCase(10, 5)]
        [TestCase(15, 15)]
        public void Divide_Sucesso_ValorEntrada(double n1, double n2)
        {
            //Arrange
            double divisao = n1 / n2;

            //Act
            var result = _servico.Dividir(n1, n2);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(divisao));
                Assert.That(n2, Is.Not.EqualTo(0));
            });
        }

        [TestCase(2, 5)]
        [TestCase(-2, 12)]
        [TestCase(10, -5)]
        [TestCase(10, 15)]
        public void Soma_Sucesso_ValorEntrada(double n1, double n2)
        {
            //Arrange
            double soma = n1 + n2;

            //Act
            var result = _servico.Somar(n1, n2);

            //Assert
            Assert.That(result, Is.EqualTo(soma));
            Assert.Multiple(() =>
            {
                Assert.That(result.ToString(), Is.Not.Empty);
                Assert.That(n2, Is.Not.EqualTo(0));
            });
        }

        [Test]
        public void Subtrair_Sucesso_ValorEntrada()
        {
            //Arrange
            double n1 = 15;
            double n2 = 10;
            double subtrair = n1 - n2;

            //Act
            var result = _servico.Subtrair(n1, n2);

            //Assert
            Assert.That(result, Is.EqualTo(5));
            Assert.That(result, Is.EqualTo(subtrair));
        }

        [Test]
        public void Multiplicar_Sucesso_ValorEntrada()
        {
            //Arrange
            double n1 = 5;
            double n2 = 10;
            double multiplicacao = n1 * n2;

            //Act
            var result = _servico.Multiplicar(n1, n2);

            //Assert
            Assert.That(result, Is.EqualTo(50));
            Assert.That(result, Is.EqualTo(multiplicacao));
        }

        [Test]
        public void Media_Sucesso_ValorEntrada()
        {
            //Arrange
            double n1 = 5;
            double n2 = 10;
            double media = (n1 + n2) /2;

            //Act
            var result = _servico.Media(n1, n2);

            //Assert
            result.Equals(7.5);
            Assert.That(result, Is.EqualTo(7.5));
            Assert.That(result, Is.LessThanOrEqualTo(8));
            Assert.That(result, Is.LessThanOrEqualTo(media));
            Assert.That(result, Is.EqualTo(media));
            Assert.That(result, Is.LessThanOrEqualTo(7.5));
        }
    }
}
