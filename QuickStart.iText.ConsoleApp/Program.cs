using QuickStart.iText.ConsoleApp;


string documentDirectory = Path.Join(AppContext.BaseDirectory, "documents");
string imageFileRootDirectory = Path.Join(AppContext.BaseDirectory, "imgs");

if (!Directory.Exists(imageFileRootDirectory))
{
    Directory.CreateDirectory(imageFileRootDirectory);
}


foreach (string fileName in Directory.GetFiles(documentDirectory))
{

    string pdfImageFileDirecotry = Path.Join(imageFileRootDirectory, Path.GetFileNameWithoutExtension(fileName));

    if (!Directory.Exists(pdfImageFileDirecotry))
    {
        Directory.CreateDirectory(pdfImageFileDirecotry);
    }

    using (FileStream stream = File.OpenRead(fileName))
    {
        ImageInPdfExtractor imageInPdfExtractor = new();

        List<ExtractedImage> images = imageInPdfExtractor.Extract(stream);

        foreach (ExtractedImage image in images)
        {
            if (!image.IsEmpty())
            {
                string imageFileName = $"{image.PageNumber}-{image.Index}.{image.Extension}";

                File.WriteAllBytes(Path.Join(pdfImageFileDirecotry, imageFileName), image.Content!);
            }
        }
    }
}