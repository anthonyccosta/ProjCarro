using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Models;

namespace GerarJsonFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] marcas = { "Toyota", "Ford", "Chevrolet", "Volkswagen", "Honda", "BMW", "Audi", "Mercedes-Benz", "Ferrari", "Porsche", "Lamborghini" };
            string[] modelos = { "Corolla", "Mustang", "Camaro", "Golf", "Civic", "3 Series", "A4", "E-Class", "488 GTB", "911", "Aventador" };
            string[] cores = { "Branco", "Preto", "Prata", "Vermelho", "Azul", "Verde", "Amarelo", "Laranja", "Cinza", "Roxo" };

            List<string> placas = new List<string>();
            Random random = new Random();

            for (int i = 0; i < 30; i++)
            {
                string placa;
                do
                {
                    placa = $"{GetRandomLetter()}{GetRandomLetter()}{GetRandomLetter()}-{random.Next(1000, 10000)}";
                } while (placas.Contains(placa));
                placas.Add(placa);
            }

            List<Carro> carros = new List<Carro>();

            for (int i = 0; i < 30; i++)
            {
                carros.Add(new Carro
                {
                    Placa = placas[i],
                    AnoModelo = random.Next(1990, 2024),
                    AnoFabricacao = random.Next(1990, 2024),
                    Cor = cores[random.Next(0, cores.Length)]
                });
            }

            if (carros.Count > 0)
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
                string file = "carros.json";

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                using (StreamWriter sw = new StreamWriter(Path.Combine(path, file)))
                {
                    string json = JsonConvert.SerializeObject(carros, Formatting.Indented);
                    sw.Write(json);
                }
            }
        }

        static char GetRandomLetter()
        {
            string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Random random = new Random();
            return letters[random.Next(0, letters.Length)];
        }
    }
}
