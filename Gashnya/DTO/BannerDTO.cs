namespace Gashnya.DTO
{
    public partial class Banner
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public byte[]? BannerImg { get; set; }

        public int Price { get; set; }
    }
}
