using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityLayer.Concrete
{
    [Table("Kalems", Schema = "pem")]
    public class Kalem
    {
        [Key]
        public int KalemId { get; set; }

        [DisplayName("Adı")]
        public string KalemAdi { get; set; }
        //
        //
        //Kategoride Listelenecek
        public virtual IList<Kat> Kats { get; set; }
    }
}
