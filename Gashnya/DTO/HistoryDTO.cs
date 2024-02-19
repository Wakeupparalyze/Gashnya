namespace Gashnya.DTO
{
    public partial class History
    {
        public int Id { get; set; }

        public int RewardId { get; set; }

        public int BannerId { get; set; }

        public string Banner { get; set; } = null!;

        public string Reward { get; set; } = null!;
    }
}