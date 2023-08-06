using System;
namespace Parking.Models
{
	public class Vehicle
	{
		private string _placa;
		private string _proprietario;
		private VehicleType _tipo;

		public string Placa
		{
			get
			{
				return _placa;
			}
			set
			{
				if (value.Length != 8)
				{
					throw new FormatException("A placa deve possuir 8 caracteres");
				}

				for (int i = 0; i < 3; i++)
				{
					if (char.IsDigit(value[i]))
					{
						throw new FormatException("Os 3 primeiros caracteres devem ser letras!");
					}
				}

				if (value[3] != '-')
				{
					throw new FormatException("O 4º caractere deve ser um hífen");
				}

				for (int i = 4; i < 8; i++)
				{
					if (!char.IsDigit(value[i]))
					{
						throw new FormatException("Do 5º ao 8 caractere deve-se ter um número!");
					}
				}
				_placa = value;
			}
		}

		public string Cor { get; set; }
		public double Largura { get; set; }
		public double VelocidadeAtual { get; set; }
		public string Modelo { get; set; }
		public string Proprietario { get; set; }
		public DateTime HoraEntrada { get; set; }
		public DateTime	HoraSaida { get; set; }
		public VehicleType Tipo { get => _tipo; set => _tipo = value; }

		public void SpeedUp(int tempoSeg)
		{
            VelocidadeAtual += tempoSeg * 10;
		}

		public void Brake(int tempoSeg)
		{
            VelocidadeAtual -= tempoSeg * 15;
		}

        public void AlterarDados(Vehicle veiculoAlterado)
        {
			Proprietario = veiculoAlterado.Proprietario;
			Modelo = veiculoAlterado.Modelo;
			Largura = veiculoAlterado.Largura;
			Cor = veiculoAlterado.Cor;
        }

        public Vehicle()
		{

		}

		public Vehicle(string proprietario)
		{
			Proprietario = proprietario;
		}
	}
}

