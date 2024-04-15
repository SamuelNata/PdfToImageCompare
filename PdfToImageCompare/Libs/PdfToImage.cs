using PDFtoImage;
using System.Drawing;

namespace PdfToImageCompare.Libs;

public class PdfToImage : ILibAdapter
{
    public List<string> PDFToImageBase64(byte[] pdfBytes)
    {
        List<string> imagesBase64 = [];
        int page = 0;
        foreach (SizeF imageSize in Conversion.GetPageSizes(pdfBytes))
        {
            MemoryStream imageStream = new();
            Conversion.SaveJpeg(imageStream, pdfBytes, page: page++);
            byte[] imageBytes = imageStream.ToArray();
            imagesBase64.Add(Convert.ToBase64String(imageBytes));
        }
        return imagesBase64;
    }
}
