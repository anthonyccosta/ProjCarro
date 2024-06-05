using Controllers;
using Models;
using System;
using System.Linq;

void Enter()
{
    Console.WriteLine("Press Enter to continue");
    Console.ReadLine();
    Console.Clear();
}

void CriarMenu()
{
    do
    {
        switch (new Menu().ChamarMenu())
        {
            case 0:
                Console.WriteLine("Finalizando o Programa");
                Environment.Exit(0);
                break;
            case 1:
                Console.WriteLine("Carros Amarelos");
                new carController().RetornarCarros().Where(c => c.Cor == "Amarelo").ToList().ForEach(c => Console.WriteLine(c));
                Enter();
                break;
            case 2:
                Console.WriteLine("Gerando XML Carros Amarelos");
                var carrosAmarelos = new carController().RetornarCarros().Where(c => c.Cor == "Amarelo").ToList();
                Console.WriteLine(new GenerateXMLs().GenerateXMLCarroAmarelo(carrosAmarelos) ? "Criado com sucesso" : "Erro ao criar");
                Enter();
                break;
            case 3:
                Console.WriteLine("Carros com Status True");
                new carController().ServicosCarros().ForEach(c => Console.WriteLine(c));
                Enter();
                break;
            case 4:
                Console.WriteLine("Gerando XML Carros com Status True");
                var carrosStatusTrue = new carController().CarrosComServicos();
                Console.WriteLine(new GenerateXMLs().GenerateXMLStatusTrue(carrosStatusTrue) ? "Criado com sucesso" : "Erro ao criar");
                Enter();
                break;
            case 5:
                Console.WriteLine("Carros fabricados entre 2015 e 2016");
                new carController().RetornarCarros().Where(c => c.AnoFabricacao >= 2015 && c.AnoFabricacao <= 2016).ToList().ForEach(c => Console.WriteLine(c));
                Enter();
                break;
            case 6:
                Console.WriteLine("Gerando XML Carros fabricados entre 2015 e 2016");
                var carrosFabricados2015_2016 = new carController().RetornarCarros().Where(c => c.AnoFabricacao >= 2015 && c.AnoFabricacao <= 2016).ToList();
                Console.WriteLine(new GenerateXMLs().GenerateXMLAnoFabricado(carrosFabricados2015_2016) ? "Criado com sucesso" : "Erro ao criar");
                Enter();
                break;
        }
    } while (true);
}

CriarMenu();
