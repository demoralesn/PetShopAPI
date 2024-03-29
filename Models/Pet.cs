﻿namespace PetShopAPI.Models
{
    public class Pet
    {
        public int PetId { get; set; }
        public string Name { get; set; }
        public int RaceId { get; set; }
        public int ColorId { get; set; }
        public int Age { get; set; }
        public float Weight { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsActive { get; set; }
    }
}
