namespace PdfToImageCompare.Libs;

public class FreewarePdf2Png : ILibAdapter
{
    public List<string> PDFToImageBase64(byte[] pdfBytes)
    {
        List<byte[]> pages = Freeware.Pdf2Png.ConvertAllPages(pdfBytes);
        return pages.Select(page => Convert.ToBase64String(page)).ToList();
    }
}
