//https://github.com/dlemstra/Magick.NET
using ImageMagick;

namespace PdfToImageCompare.Libs;

public class ImageMagick : ILibAdapter
{
    public List<string> PDFToImageBase64(byte[] pdfBytes) => PDFToImageBase64(pdfBytes, MagickFormat.Jpg);

    public List<string> PDFToImageBase64(byte[] pdfBytes, MagickFormat formato = MagickFormat.Png)
    {
        using MagickImageCollection images = new(pdfBytes, MagickFormat.Pdf);
        using MemoryStream ms = new(pdfBytes.Length);

        List<string> imagnesPngBase64 = new();
        foreach (var image in images)
        {
            ms.SetLength(0);
            image.Write(ms, formato);
            imagnesPngBase64.Add(Convert.ToBase64String(ms.ToArray()));
        }

        return imagnesPngBase64;
    }
}