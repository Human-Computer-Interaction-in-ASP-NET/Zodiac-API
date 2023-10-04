public class ZodiacObject
{
    public string Name { get; private set; }
    public string ImageUrl { get; private set; }

    public ZodiacObject(string name, string imageUrl)
    {
        Name = name;
        ImageUrl = imageUrl;
    }
}
