namespace WebAssemblyPictureApplication.Models
{
    public class TextBlock
    {
        public int Id { get; set; }
        public int PlaceId { get; set; }
        public string Text{ get; set; }
        public string Path { get; set; }
        public string[] FullText { get; set; }
        public string InnerClassInfo { get; set; }

    }

    public enum DesignClass
    {
        TopCardPicker,
        CardDestination
    }
}
