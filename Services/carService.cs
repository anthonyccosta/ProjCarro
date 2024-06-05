using Models;
using Repositories;
using System.Collections.Generic;

namespace Services
{
    public class carService
    {
        private ICarroRepository _carroRepository;

        public carService()
        {
            _carroRepository = new CarroRepository();
        }

        // Retorna todos os carros
        public List<Carro> RetornarCarros()
        {
            return _carroRepository.RetornarCarros();
        }

        // Retorna carros com serviços
        public List<Carro> CarrosComServicos()
        {
            return _carroRepository.CarrosComServicos();
        }

        // Retorna serviços dos carros
        public List<carService> ServicosCarros()
        {
            return _carroRepository.ServicosCarros();
        }
    }
}
