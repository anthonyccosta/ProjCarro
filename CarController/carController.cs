using Models;
using Services;
using System.Collections.Generic;

namespace Controllers
{
    public class carController
    {
        private carService _carroService;

        public carController()
        {
            _carroService = new carService();
        }

        // Retorna todos os carros
        public List<Carro> RetornarCarros()
        {
            return _carroService.RetornarCarros();
        }

        // Retorna carros com serviços
        public List<Carro> CarrosComServicos()
        {
            return _carroService.CarrosComServicos();
        }

        // Retorna serviços dos carros
        public List<carService> ServicosCarros()
        {
            return _carroService.ServicosCarros();
        }
    }
}
