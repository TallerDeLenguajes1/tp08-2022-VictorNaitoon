using System;
using System.IO;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Ingrese la direccion de su archivo: ");
        string DireccionCarpeta = Console.ReadLine();

        List<string> ListaArchivos = new List<string>();
        if (Directory.Exists(DireccionCarpeta))
        {
            ListaArchivos = Directory.GetFiles(DireccionCarpeta).ToList();
        } else {
            Console.WriteLine("No existe la tal archivo");
        }
        foreach (string ArchivoX in ListaArchivos)
        {
            Console.WriteLine(ArchivoX);
        }

        string NombreDelArchivoCSV = DireccionCarpeta + @"\index.csv";
        if (!File.Exists(NombreDelArchivoCSV))
        {
            File.Create(NombreDelArchivoCSV);
        }

        using (var streamWriter = new StreamWriter(NombreDelArchivoCSV))
        {
            int i = 0;
            foreach (var ArchivoY in ListaArchivos)
            {
                Console.WriteLine(ArchivoY);
                streamWriter.WriteLine(i++ +";");
                streamWriter.WriteLine(Path.GetFileNameWithoutExtension(NombreDelArchivoCSV)+";"+Path.GetExtension(NombreDelArchivoCSV));
            }
        }
    }
}