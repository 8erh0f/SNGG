namespace SNGG.Models.Dto
{
    public class PlayerGameDataDto
    {
        public string PlayerName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int NrOfDigits { get; set; }
        public int GameId { get; set; }

        public bool IsEmpty()
        {
            if (string.IsNullOrWhiteSpace(PlayerName)
                && DateOfBirth == default
                && NrOfDigits == 0)
                return true;
            return false;
        }
    }
}
