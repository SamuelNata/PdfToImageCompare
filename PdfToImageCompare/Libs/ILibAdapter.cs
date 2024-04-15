namespace PdfToImageCompare.Libs;

public interface ILibAdapter

{
    List<string> PDFToImageBase64(byte[] pdfBytes);
}