using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Drawing;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Boolean var1 = false;
        if (args.Length < 1)
        {
            Console.WriteLine("Erro: argumento de entrada ausente");
            return;
        }

        string inputFile = args[0];
        string outputFile = Path.GetFileNameWithoutExtension(inputFile) + ".bmp";

        using (StreamReader sr = new StreamReader(inputFile))
        {
            Bitmap bmp = new Bitmap(800, 800);
           
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] parts = line.Split(',');

                if (parts[0] == "line" && parts.Length == 5)
                {
                    int x1 = int.Parse(parts[1]);
                    int y1 = int.Parse(parts[2]);
                    int x2 = int.Parse(parts[3]);
                    int y2 = int.Parse(parts[4]);

                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        if (var1 == false)
                        {
                            var1 = true;
                            g.Clear(Color.Blue);
                        }
                        g.DrawLine(Pens.White, x1, y1, x2, y2);
                    }
                }
            }

            bmp.Save(outputFile);
        }

        Console.WriteLine($"Conversão concluída. Imagem salva em {outputFile}");
    }
}
