﻿using System.ComponentModel.DataAnnotations;

namespace PCShopProjekt.Models
{
    public class Technicy
    {
        [Key]
        public int Id { get; set; }

        public string Imie { get; set; }

        public string Nazwisko { get; set; }

        public string Email { get; set; }

        public int Numer_telefonu { get; set; }

        public Technicy()
        {

        }
    }
}
