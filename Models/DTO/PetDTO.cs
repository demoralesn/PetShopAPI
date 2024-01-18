namespace PetShopAPI.Models.DTO
{
    public class PetDTO
    {
        public int PetId { get; set; }
        public string Name { get; set; }
        public int RaceId { get; set; }
        public int ColorId { get; set; }
        public int Age { get; set; }
        public float Weight { get; set; }
        public bool IsActive { get; set; }
    }
}
