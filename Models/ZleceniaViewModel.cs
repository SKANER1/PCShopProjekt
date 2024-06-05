namespace PCShopProjekt.Models
{
    public class ZleceniaViewModel
    {
        public int Id { get; set; }
        public int KlientId { get; set; }
        public string KlientFullName { get; set; }
        public int UrzadzenieId { get; set; }
        public string UrzadzenieDetails { get; set; }
        public int? TechnikId { get; set; }
        public string TechnikFullName { get; set; }
        public string StatusPlatnosci { get; set; }
        public DateTime DataPrzyjecia { get; set; }
        public string OpisUsterki { get; set; }
        public string NazwaUslugi { get; set; }
        public string Status { get; set; }
    }
}
