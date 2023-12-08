namespace QuickStart.iText.ConsoleApp;

/// <summary>
/// 抽取PDF文档中的图片信息
/// </summary>
public class ImageInPdfExtractor
{
    public List<ExtractedImage> Extract(Stream stream)
    {
        try
        {
            using (PdfReader pdfReader = new(stream))
            {
                using PdfDocument pdfDoc = new(pdfReader);

                var listener = new ImageRenderListener();

                for (int i = 1; i <= pdfDoc.GetNumberOfPages(); i++)
                {
                    listener.CurrentPageNumber = i;

                    PdfCanvasProcessor parser = new(listener);

                    parser.ProcessPageContent(pdfDoc.GetPage(i));
                }

                pdfDoc.Close();

                return listener.Images;
            }
        }
        catch (PdfException)
        {
            return new();
        }
        catch (Exception)
        {
            throw;
        }
    }
}