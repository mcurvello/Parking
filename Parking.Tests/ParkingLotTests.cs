using System;
using Parking.Models;
using Xunit;

namespace Parking.Tests
{
	public class ParkingLotTests
	{
		[Fact]
		public void ValidaFaturamento()
		{
			//Arrange
			var estacionamento = new ParkingLot();
			var veiculo = new Vehicle();

			veiculo.Proprietario = "Marcio";
			veiculo.Tipo = VehicleType.Automovel;
			veiculo.Cor = "Verde";
			veiculo.Modelo = "Palio";
			veiculo.Placa = "asd-9999";

			estacionamento.RegistrarEntradaVeiculo(veiculo);
			estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

			//Act
			double faturamento = estacionamento.TotalFaturado();

			//Assert
			Assert.Equal(2, faturamento);
		}

		[Theory]
		[InlineData("André Silva", "ASD-1498", "preto", "Gol")]
		[InlineData("Jose Silva", "POL-9242", "cinza", "Fusca")]
		[InlineData("Maria Silva", "GDR-1223", "azul", "Opala")]
		public void ValidaFaturamentoComVariosVeiculos(string proprietario, string placa, string cor, string modelo)
		{
			//Arrange
			var estacionamento = new ParkingLot();
			var veiculo = new Vehicle();

			veiculo.Proprietario = proprietario;
			veiculo.Placa = placa;
			veiculo.Cor = cor;
			veiculo.Modelo = modelo;

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

			//Assert
			Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("André Silva", "ASD-1498", "preto", "Gol")]
		public void LocalizaVeiculoNoPatio (string proprietario, string placa, string cor, string modelo)
		{
            //Arrange
            var estacionamento = new ParkingLot();
            var veiculo = new Vehicle();

            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;

            estacionamento.RegistrarEntradaVeiculo(veiculo);

			//Act
			var consultado = estacionamento.PesquisaVeiculo(placa);

			//Assert
			Assert.Equal(placa, consultado.Placa);
        }
    }
}

