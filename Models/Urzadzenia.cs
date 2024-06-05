using System.ComponentModel.DataAnnotations;

namespace PCShopProjekt.Models
{
    public class Urzadzenia
    {
        [Key]
        public int Id { get; set; }

        public int Id_klienta { get; set; }

        public string Producent { get; set; }

        public string Nazwa_urzadzenia { get; set; }

        [DataType(DataType.Date)]
        public DateTime Data_zakupu { get; set; }
        public Urzadzenia()
        {
            
        }
    }
}
