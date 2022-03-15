using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.ValidationRules
{
    public class KasaValidator : AbstractValidator<Kasa>
    {
        public KasaValidator()
        {
            RuleFor(x => x.KasaTutar).NotEmpty().WithMessage("Tutar Boş Geçilemez");
            RuleFor(x => x.KasaTarih).NotEmpty().WithMessage("Tarih Boş Geçilemez");
            RuleFor(x => x.KatId).NotEmpty().WithMessage("Bir kategori seçmelisin");
        }
    }
}
