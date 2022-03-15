using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfKasaRepository : GenericRepository<Kasa>, IKasaDal
    {
        public List<Kasa> KasaIncKat()
        {
            using var c = new ParamEmrimdeContext();
            return c.Kasas.Include(x => x.Kat).ToList();
        }

        public List<Kasa> KasaIncKatFilter(DateTime? tarihKucuk = null, DateTime? tarihBuyuk = null, int? kategori = null, string aciklama = null, decimal? price = null, int? kalem = null, string krediKarti = null, string borcOde = null)
        {
            using var c = new ParamEmrimdeContext();
            var sorgu = c.Kasas.Include(x => x.Kat).ThenInclude(x=>x.Kalem).ToList();

            if (tarihKucuk != null)
            {
                sorgu = sorgu.Where(x => x.KasaTarih >= tarihKucuk).ToList();
            }

            if (tarihBuyuk != null)
            {
                sorgu = sorgu.Where(x => x.KasaTarih <= tarihBuyuk).ToList();
            }

            if (kategori != null)
            {
                sorgu = sorgu.Where(x => x.KatId == kategori).ToList();
            }

            if (aciklama != null)
            {
                sorgu = sorgu.Where(x => x.KasaAciklama.ToLower().Contains(aciklama.ToLower())).ToList();
            }

            if (price != null)
            {
                sorgu = sorgu.Where(x => x.KasaTutar >= price).ToList();
            }

            if (kalem != null)
            {
                sorgu = sorgu.Where(x => x.Kat.KalemId == kalem).ToList();
            }

            if (krediKarti == "on")
            {
                sorgu = sorgu.Where(x => x.KasaKrediKarti == true).ToList();
            }

            if (borcOde == "on")
            {
                sorgu = sorgu.Where(x => x.KasaBorcOde == true).ToList();
            }

            return sorgu.ToList();
        }
    }
}
