using System;
using System.Globalization;
using System.IO;

namespace ExeFixArquivos
{
    class Program
    {
        static void Main(string[] args)
        {
            //Fazer um programa para ler o caminho de um arquivo .csv contendo os dados de itens vendidos
            //Cada item possui um nome, preço unitário e quantidade, separados por vírgula.
            //Você deve gerar um novo arquivo chamado "summary.csv",
            //localizado em uma subpasta chamada "out" a partir da pasta original do 
            //arquivo de origem, contendo apenas o nome e o valor total para aquele
            //item(preço unitário multiplicado pela quantidade).

            string sourcePath = @"/Users/kelvin/Projects/arquivo/arquivo1.txt";
            string targetPath = @"/Users/kelvin/Projects/arquivo/summary.csv";



            try
            {
                FileInfo fileInfo = new FileInfo(sourcePath);
                string[] lines = File.ReadAllLines(sourcePath);


                using (StreamWriter sw = File.AppendText(targetPath))
                {
                    foreach (string line in lines)
                    {
                        string[] fields = line.Split(',');
                        string product = fields[0];
                        double price = double.Parse((fields[1]), CultureInfo.InvariantCulture);
                        int quantity = int.Parse(fields[2]);

                        Summary summary = new Summary(product, price, quantity);

                        sw.WriteLine(summary.Product + "," + summary.Total().ToString("F2", CultureInfo.InvariantCulture));


                    }
                }

            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }


        }
    }
}
