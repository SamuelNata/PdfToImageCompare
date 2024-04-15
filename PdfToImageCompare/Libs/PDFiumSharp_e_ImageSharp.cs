using PDFiumSharp;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;

namespace PdfToImageCompare.Libs;

public class PDFiumSharp_e_ImageSharp : ILibAdapter
{
    public List<string> PDFToImageBase64(byte[] pdfBytes)
    {
        int width = 600, height = 900;
        using PdfDocument pdfDocument = new (pdfBytes);
        List<string> imagesBase64 = new();

        for (int page = 0; page < pdfDocument.Pages.Count; page++)
        {
            using PDFiumBitmap pageBitmap = new (width, height, true);
            pdfDocument.Pages[page].Render(pageBitmap);
            Image image = Image.Load(pageBitmap.AsBmpStream());

            // Set the background to white, otherwise it's black. https://github.com/SixLabors/ImageSharp/issues/355#issuecomment-333133991
            image.Mutate(x => x.BackgroundColor(Color.White));
            imagesBase64.Add(image.ToBase64String(JpegFormat.Instance));
        }
        return imagesBase64;
    }
}