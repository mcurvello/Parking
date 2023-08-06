using System;
using System.Collections.Generic;

namespace Parking.Models
{
	public class ParkingLot
	{
		public ParkingLot()
		{
			Faturado = 0;
			Veiculos = new List<Vehicle>();
		}

		private List<Vehicle> veiculos;
		private double faturado;

		public double Faturado { get => faturado; set => faturado = value; }
		public List<Vehicle> Veiculos { get => veiculos; set => veiculos = value; }

		public double TotalFaturado()
		{
			return Faturado;
		}

		public string MostrarFaturamento()
		{
            string totalfaturado = String.Format("Total faturado até o momento :::::::::::::::::::::::::::: {0:c}", TotalFaturado());
            return totalfaturado;
        }

        public void RegistrarEntradaVeiculo(Vehicle veiculo)
        {
            veiculo.HoraEntrada = DateTime.Now;
            Veiculos.Add(veiculo);
        }

        public string RegistrarSaidaVeiculo(String placa)
        {
            Vehicle procurado = null;
            string informacao = string.Empty;

            foreach (Vehicle v in Veiculos)
            {
                if (v.Placa == placa)
                {
                    v.HoraSaida = DateTime.Now;
                    TimeSpan tempoPermanencia = v.HoraSaida - v.HoraEntrada;
                    double valorASerCobrado = 0;
                    if (v.Tipo == VehicleType.Automovel)
                    {
                        valorASerCobrado = Math.Ceiling(tempoPermanencia.TotalHours) * 2;
                    }
                    if (v.Tipo == VehicleType.Motocicleta)
                    {
                        valorASerCobrado = Math.Ceiling(tempoPermanencia.TotalHours) * 1;
                    }
                    informacao = string.Format(" Hora de entrada: {0: HH: mm: ss}\n " +
                                             "Hora de saída: {1: HH:mm:ss}\n " +
                                             "Permanência: {2: HH:mm:ss} \n " +
                                             "Valor a pagar: {3:c}", v.HoraEntrada, v.HoraSaida, new DateTime().Add(tempoPermanencia), valorASerCobrado);
                    procurado = v;
                    Faturado += valorASerCobrado;
                    break;
                }

            }
            if (procurado != null)
            {
                Veiculos.Remove(procurado);
            }
            else
            {
                return "Não encontrado veículo com a placa informada.";
            }

            return informacao;
        }
    }
}

