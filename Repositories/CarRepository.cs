using Dapper;
using Microsoft.Data.SqlClient;
using Models;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Repositories
{
    public class CarroRepository : ICarroRepository
    {
        private string Conn { get; set; }

        public CarroRepository()
        {
            Conn = ConfigurationManager.ConnectionStrings["StringConnection"].ConnectionString;
        }

        // Retorna todos os carros
        public List<Carro> RetornarCarros()
        {
            var carros = new List<Carro>();
            try
            {
                using (SqlConnection connection = new SqlConnection(Conn))
                {
                    connection.Open();
                    carros = connection.Query<Carro>(Carro.SELECT).AsList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            return carros;
        }

        // Retorna serviços dos carros
        public List<carroServico> ServicosCarros()
        {
            var servicosCarros = new List<carroServico>();
            using (SqlConnection conn = new SqlConnection(Conn))
            {
                conn.Open();
                servicosCarros = conn.Query<carroServico, Carro, Servico, carroServico>(
                    carroServico.SELECT,
                    (carroServico, carro, servico) => { carroServico.Carro = carro; carroServico.Servico = servico; return carroServico; },
                    splitOn: "Placa,Id").AsList();
            }
            return servicosCarros;
        }

        // Retorna carros com serviços
        public List<Carro> CarrosComServicos()
        {
            var carros = new List<Carro>();
            using (SqlConnection conn = new SqlConnection(Conn))
            {
                conn.Open();
                carros = conn.Query<Carro>(Carro.SELECTStatus).AsList();
            }
            return carros;
        }
    }
}
