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
	}
}

