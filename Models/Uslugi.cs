using System.ComponentModel.DataAnnotations;

namespace PCShopProjekt.Models
{
    public class Uslugi
    {
        [Key]
        public int Id { get; set; }

        public string Nazwa_uslugi { get; set; }
        public Uslugi()
        {
            
        }
    }
}
