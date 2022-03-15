using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityLayer.Concrete
{
    [Table("Kasas", Schema = "pem")]
    public class Kasa
    {
        [Key]
        public int KasaId { get; set; }

        public decimal KasaTutar { get; set; }

        public decimal KasaTutarDolar { get; set; }

        public decimal KasaTutarEuro { get; set; }

        public DateTime KasaTarih { get; set; }

        public string KasaAciklama { get; set; }

        public bool KasaBorcOde { get; set; }

        public bool KasaKrediKarti { get; set; }
        //
        //
        //Kasanın Bir Kategorisi Olacak
        public int KatId { get; set; }
        public virtual Kat Kat { get; set; }
    }
}
