# PdfToImageCompare
Comparing PDF to Image convertion libs performance, so you dont have to!

# What this project do?
Measure the time (in milliseconds) needed to converting a PDF (already loaded as e byte array) to a PNG or JPG (as a Base64 string).

# What Libs where tested?
- PdfToImage
    - https://github.com/sungaila/PDFtoImage
    - :white_check_mark: The chosen one
- Aspose
    - :x: It is paid, cant test with more than 4 pages, so I didnt test it.
- FreewarePdf2Png
    - https://www.nuget.org/packages/Freeware.Pdf2Png (cant find repo)
    - :x: To slow, at least in my machine
- ImageMagick
    - https://github.com/dlemstra/Magick.NET
    - :x: Woks pretty well, but aparently has a continuous memory leak
- PDFiumSharp + ImageSharp: 
    - https://github.com/ArgusMagnus/PDFiumSharp
    - https://github.com/SixLabors/ImageSharp
    - :x: It is the fastest I have found, but some times fail on reading a PDF page, witch make it unsuitable for critical operations.
    - I Receive "PDFium Error: No error", caused by internal PDFium method "Native.fpdfview.FPDF_LoadPage" returning null


# Results
And now, stay with the output of the exectution, or clone this repo and try for your self.

The format is: {libName} on {fileName} | Execution time (ms): {stopwatch.ElapsedMilliseconds}

```console
FreewarePdf2Png on samplePdf10pages.pdf | Execution time (ms): 12338
FreewarePdf2Png on samplePdf10pages.pdf | Execution time (ms): 5539
FreewarePdf2Png on samplePdf10pages.pdf | Execution time (ms): 3627
FreewarePdf2Png on samplePdf10pages.pdf | Execution time (ms): 4090
FreewarePdf2Png on samplePdf10pages.pdf | Execution time (ms): 3319
FreewarePdf2Png on samplePdf1page.pdf | Execution time (ms): 953
FreewarePdf2Png on samplePdf1page.pdf | Execution time (ms): 704
FreewarePdf2Png on samplePdf1page.pdf | Execution time (ms): 692
FreewarePdf2Png on samplePdf1page.pdf | Execution time (ms): 1042
FreewarePdf2Png on samplePdf1page.pdf | Execution time (ms): 802
ImageMagick on samplePdf10pages.pdf | Execution time (ms): 5618
ImageMagick on samplePdf10pages.pdf | Execution time (ms): 2407
ImageMagick on samplePdf10pages.pdf | Execution time (ms): 2149
ImageMagick on samplePdf10pages.pdf | Execution time (ms): 2096
ImageMagick on samplePdf10pages.pdf | Execution time (ms): 2200
ImageMagick on samplePdf1page.pdf | Execution time (ms): 565
ImageMagick on samplePdf1page.pdf | Execution time (ms): 648
ImageMagick on samplePdf1page.pdf | Execution time (ms): 535
ImageMagick on samplePdf1page.pdf | Execution time (ms): 636
ImageMagick on samplePdf1page.pdf | Execution time (ms): 408
PDFiumSharp_e_ImageSharp on samplePdf10pages.pdf | Execution time (ms): 3632
PDFiumSharp_e_ImageSharp on samplePdf10pages.pdf | Execution time (ms): 657
PDFiumSharp_e_ImageSharp on samplePdf10pages.pdf | Execution time (ms): 332
PDFiumSharp_e_ImageSharp on samplePdf10pages.pdf | Execution time (ms): 375
PDFiumSharp_e_ImageSharp on samplePdf10pages.pdf | Execution time (ms): 325
PDFiumSharp_e_ImageSharp on samplePdf1page.pdf | Execution time (ms): 53
PDFiumSharp_e_ImageSharp on samplePdf1page.pdf | Execution time (ms): 45
PDFiumSharp_e_ImageSharp on samplePdf1page.pdf | Execution time (ms): 42
PDFiumSharp_e_ImageSharp on samplePdf1page.pdf | Execution time (ms): 45
PDFiumSharp_e_ImageSharp on samplePdf1page.pdf | Execution time (ms): 49
PdfToImage on samplePdf10pages.pdf | Execution time (ms): 5173
PdfToImage on samplePdf10pages.pdf | Execution time (ms): 2275
PdfToImage on samplePdf10pages.pdf | Execution time (ms): 2392
PdfToImage on samplePdf10pages.pdf | Execution time (ms): 2275
PdfToImage on samplePdf10pages.pdf | Execution time (ms): 2514
PdfToImage on samplePdf1page.pdf | Execution time (ms): 305
PdfToImage on samplePdf1page.pdf | Execution time (ms): 297
PdfToImage on samplePdf1page.pdf | Execution time (ms): 322
PdfToImage on samplePdf1page.pdf | Execution time (ms): 362
PdfToImage on samplePdf1page.pdf | Execution time (ms): 339
```