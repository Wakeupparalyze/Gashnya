namespace Gashnya.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string Password { get; set; } = null!;

        public int? UserBalance { get; set; }

        public string Login { get; set; } = null!;

        public int? HistoryId { get; set; }

        public string Name { get; set; } = null!;

        public string History { get; set; }
    }
}
