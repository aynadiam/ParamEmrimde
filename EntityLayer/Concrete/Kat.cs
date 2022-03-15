using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityLayer.Concrete
{
    [Table("Kats", Schema = "pem")]
    public class Kat
    {
        [Key]
        public int KatId { get; set; }

        [DisplayName("Adı")]
        public string KatAdi { get; set; }
        //
        //
        //Kategorinin Bir Kalemi Olacak
        public int KalemId { get; set; }
        public virtual Kalem Kalem { get; set; }
        //
        //
        //Kategorinin Bir Üyesi Olacak
        public int UyeId { get; set; }
        public virtual Uye Uye { get; set; }
        //
        //
        //Kasada Listelenecek
        public virtual IList<Kasa> Kasas { get; set; }
    }
}
