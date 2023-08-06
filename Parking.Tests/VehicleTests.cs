using System;
using Parking.Models;
using Xunit;

namespace Parking.Tests
{
    public class VehicleTests
    {
        [Fact]
        public void TestaVeiculoAcelerar()
        {
            //Arrange
            var veiculo = new Vehicle();

            //Act
            veiculo.SpeedUp(10);

            //Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaVeiculoFrear()
        {
            //Arrange
            var veiculo = new Vehicle();

            //Act
            veiculo.Brake(10);

            //Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }
    }
}

