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
    }
}

