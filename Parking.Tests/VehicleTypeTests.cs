using System;
using Parking.Models;
using Xunit;

namespace Parking.Tests
{
	public class VehicleTypeTests
	{
		[Fact]
		public void TestaTipoVeiculo()
		{
			//Arrange
			var veiculo = new Vehicle();

			//Act

			//Assert
			Assert.Equal(VehicleType.Automovel, veiculo.Tipo);
		}
	}
}

