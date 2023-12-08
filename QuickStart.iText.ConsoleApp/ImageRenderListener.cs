namespace QuickStart.iText.ConsoleApp;

internal class ImageRenderListener : IEventListener
{
    private readonly List<EventType> _supportedEvents = [EventType.RENDER_IMAGE];

    public int CurrentPageNumber { get; set; }

    public List<ExtractedImage> Images { get; set; }

    public ImageRenderListener()
    {
        Images = [];
    }

    public void EventOccurred(IEventData data, EventType type)
    {
        if (type == EventType.RENDER_IMAGE)
        {
            ImageRenderInfo renderInfo = (ImageRenderInfo)data;

            PdfImageXObject image = renderInfo.GetImage();

            if (image is null)
            {
                return;
            }

            Images.Add(new ExtractedImage
            {
                Content = image.GetImageBytes(),
                Extension = image.IdentifyImageFileExtension(),
                PageNumber = CurrentPageNumber,
                Index = GetImageIndex(CurrentPageNumber),
                Url = $"{CurrentPageNumber}-{GetImageIndex(CurrentPageNumber)}.{image.IdentifyImageFileExtension()}"
            });
        }
    }

    public ICollection<EventType> GetSupportedEvents()
    {
        return _supportedEvents;
    }

    private int GetImageIndex(int pageNumber)
    {
        return Images.Count(x => x.PageNumber == pageNumber) + 1;
    }
}