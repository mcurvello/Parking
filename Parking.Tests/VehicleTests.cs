using System;
using Parking.Models;
using Xunit;

namespace Parking.Tests
{
    public class VehicleTests
    {
        [Fact(DisplayName = "Teste nº 1")]
        [Trait("Funcionalidade", "Acelerar")]
        public void TestaVeiculoAcelerar()
        {
            //Arrange
            var veiculo = new Vehicle();

            //Act
            veiculo.SpeedUp(10);

            //Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact(DisplayName = "Teste nº 2")]
        [Trait("Funcionalidade", "Frear")]
        public void TestaVeiculoFrear()
        {
            //Arrange
            var veiculo = new Vehicle();

            //Act
            veiculo.Brake(10);

            //Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact(DisplayName = "Teste nº 3", Skip = "Teste ainda não implementado")]
        public void ValidaNomeProprietario()
        {

        }

        [Fact]
        public void DadosVeiculo()
        {
            //Arrange
            var carro = new Vehicle();
            carro.Proprietario = "Carlos Silva";
            carro.Tipo = VehicleType.Automovel;
            carro.Placa = "AGC-1235";
            carro.Cor = "vermelho";
            carro.Modelo = "Corolla";

            //Act
            string dados = carro.ToString();

            //Assert
            Assert.Contains("Tipo do Veículo: Automovel", dados);
        }

        [Fact]
        public void TestaNomeProprietarioVeiculoComMenosDeTresCaracteres()
        {
            //Arrange
            string nomeProprietario = "Ab";

            //Assert
            Assert.Throws<FormatException>(
                //Act
                () => new Vehicle(nomeProprietario)
                ) ;
        }

        [Fact]
        public void TestaMensagemDeExcecaoDoQuartoCaracterDaPlaca()
        {
            //Arrange
            string placa = "ADSF8739";

            //Act
            var mensagem = Assert.Throws<FormatException>(() => new Vehicle().Placa = placa);

            //Assert
            Assert.Equal("O 4º caractere deve ser um hífen", mensagem.Message);
        }
    }
}

