namespace QuickStart.iText.ConsoleApp;

/// <summary>
/// 文档对象的图片内容
/// </summary>
public class ExtractedImage
{
    public ExtractedImage() { }
    /// <summary>
    /// 页码
    /// </summary>
    public int PageNumber { get; set; }
    /// <summary>
    /// 对应的页码中的图片的索引
    /// </summary>
    public int Index { get; set; }
    /// <summary>
    /// 图片的内容
    /// </summary>
    public byte[]? Content { get; set; }

    /// <summary>
    /// 图片的扩展名 不带.
    /// </summary>
    public string Extension { get; set; } = string.Empty;

    /// <summary>
    /// 图片的URL
    /// </summary>
    public string Url { get; set; } = string.Empty;

    /// <summary>
    /// 如果没有解析到二进制内容/扩展名则无法保存图片文件
    /// 等价于解析到的内容是空的
    /// </summary>
    /// <returns></returns>
    public bool IsEmpty()
    {
        return Content == null || string.IsNullOrEmpty(Extension);
    }
}