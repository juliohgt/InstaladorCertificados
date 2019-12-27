using System;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography.X509Certificates;

namespace InstaladorCertificados
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //string zipPath = @"C:\ACcompactado";
                Console.WriteLine("Inserir Caminho do Diretorio");
                var zipPath = $"{Console.ReadLine()}";

                foreach (string file in Directory.EnumerateFiles(zipPath))
                {
                    var cert = new X509Certificate2(file);

                    using (X509Store store = new X509Store(StoreName.Root, StoreLocation.LocalMachine))
                    {
                        store.Open(OpenFlags.ReadWrite);
                        store.Add(cert); //where cert is an X509Certificate object
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);                
            }
        }
    }
}
