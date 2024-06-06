namespace PCShopProjekt.ViewModels
{
    public class ZleceniaCreateViewModel
    {
        // Dane klienta
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Email { get; set; }
        public int Numer_telefonu { get; set; }
        public string Adres { get; set; }
        public string Kod_pocztowy { get; set; }

        // Dane urządzenia
        public string Producent { get; set; }
        public string Nazwa_urzadzenia { get; set; }

        // Dane płatności
        public string Status_platnosci { get; set; }

        // Dane zlecenia
        public DateTime Data_przyjecia { get; set; }
        public string Opis_usterki { get; set; }
    }
}
