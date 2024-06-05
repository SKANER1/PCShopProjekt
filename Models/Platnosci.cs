using System.ComponentModel.DataAnnotations;

namespace PCShopProjekt.Models
{
    public class Platnosci
    {
        [Key]
        public int Id { get; set; }

        public int Id_klienta { get; set; }

        public string Status_platnosci { get; set; }
        public Platnosci()
        {
            
        }
    }
}
