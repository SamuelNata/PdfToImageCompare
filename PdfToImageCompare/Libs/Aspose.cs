using Aspose.Pdf;
using Aspose.Pdf.Devices;

namespace PdfToImageCompare.Libs;

public class Aspose : ILibAdapter
{
    public List<string> PDFToImageBase64(byte[] pdfBytes)
    {
        Resolution resolution = new(300);
        JpegDevice imageDevice = new(resolution);
        using MemoryStream ms = new(pdfBytes);
        Document pdfDocument = new(ms);

        List<string> imagesBase64 = new();
        for (int pageCount = 1; pageCount <= pdfDocument.Pages.Count; pageCount++)
        {
            using MemoryStream pageMs = new();
            imageDevice.Process(pdfDocument.Pages[pageCount], pageMs);
            pageMs.Close();
            imagesBase64.Add(Convert.ToBase64String(pageMs.ToArray()));
        }
        return imagesBase64;
    }
}