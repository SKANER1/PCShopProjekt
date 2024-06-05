using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PCShopProjekt.Models
{
    public class Zlecenia
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Urzadzenia")]
        public int Id_urzadzenia { get; set; }
        [ForeignKey("Klienci")]
        public int Id_klienta { get; set; }
        [ForeignKey("Technicy")]
        public int? Id_technika { get; set; }
        [ForeignKey("Uslugi")]
        public int? Id_uslugi { get; set; }
        [ForeignKey("Platnosci")]
        public int Id_platnosci { get; set; }

        [DataType(DataType.Date)]
        public DateTime Data_przyjecia { get; set; }

        public string Opis_usterki { get; set; }

        public string Status { get; set; }

        public Zlecenia()
        {

        }
    }
}
