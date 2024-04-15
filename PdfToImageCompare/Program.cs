using PdfToImageCompare.Libs;
using System.Diagnostics;

namespace PdfToImageCompare;

public static class Program
{
    public static List<string> FileNames = ["samplePdf10pages.pdf", "samplePdf1page.pdf"];
    public const int NumberOfExecutions = 10;

    public static void Main(string[] args)
    {
        // ConvertPdfsToImages(new Libs.Aspose(), nameof(Libs.Aspose)); // Lib paga
        ConvertPdfsToImages(new FreewarePdf2Png(), nameof(FreewarePdf2Png)); // Baixa performance
        ConvertPdfsToImages(new Libs.ImageMagick(), nameof(Libs.ImageMagick)); // Contem vazamento de memoria
        ConvertPdfsToImages(new PDFiumSharp_e_ImageSharp(), nameof(PDFiumSharp_e_ImageSharp)); // Falha ao realizar diversas conversoes em sequencia
        ConvertPdfsToImages(new PdfToImage(), nameof(PdfToImage));
    }

    public static void ConvertPdfsToImages(ILibAdapter lib, string libName)
    {
        foreach (string fileName in FileNames)
        {
            byte[] pdfInBytes = File.ReadAllBytes($"SamplePDFs/{fileName}");
            List<string> imagesBase64 = [];
            for (int i = 0; i < NumberOfExecutions; i++) { 
                imagesBase64 = MeasureLibExecution(pdfInBytes, fileName, libName, lib);
            }
            SaveImageFiles(libName, fileName, imagesBase64);
        }
    }

    public static List<string> MeasureLibExecution(byte[] pdfInBytes, string fileName, string libName, ILibAdapter lib)
    {
        Stopwatch stopwatch = new();
        stopwatch.Start();
        List<string> imagens = lib.PDFToImageBase64(pdfInBytes);
        stopwatch.Stop();
        Console.WriteLine($"{libName} on {fileName} | Execution time (ms): {stopwatch.ElapsedMilliseconds}");

        return imagens;
    }

    private static void SaveImageFiles(string path, string fileName, List<string> images)
    {
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        int pagina = 1;
        foreach (string imagemBase64 in images)
        {
            string arquivo = $"{path}/{fileName}-p{pagina++}.jpg";
            File.WriteAllBytes(arquivo, Convert.FromBase64String(
                imagemBase64.Contains(',') ? imagemBase64.Split(",")[1] : imagemBase64
            ));
        }
    }
}