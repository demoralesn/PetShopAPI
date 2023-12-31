﻿namespace PetShopAPI.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public string Color { get; set; }
        public int Age { get; set; }
        public float Weight { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
