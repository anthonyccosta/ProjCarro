using Models;
using System.Collections.Generic;

namespace Repositories
{
    public interface ICarroRepository
    {
        // Retorna todos os carros
        List<Carro> RetornarCarros();

        // Retorna serviços dos carros
        List<carroServico> ServicosCarros();

        // Retorna carros com serviços
        List<Carro> CarrosComServicos();
    }
}
