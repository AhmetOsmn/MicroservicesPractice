﻿using FluentValidation;
using MicroservicesPractice.Web.Models.Catalogs;

namespace MicroservicesPractice.Web.Validators
{
    public class CourseCreateInputValidator : AbstractValidator<CourseCreateInput>
    {
        public CourseCreateInputValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş olamaz.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama alanı boş olamaz.");
            RuleFor(x => x.Feature.Duration).InclusiveBetween(1, int.MaxValue).WithMessage("Süre alanı boş olamaz.");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Kategori seçiniz.");

            // , den sonra 2 karakter olabilir ve toplamda 6 karakter olabilir.
            RuleFor(x => x.Price).NotEmpty().WithMessage("Fiyat alanı boş olamaz.").PrecisionScale(6, 2, false).WithMessage("Hatalı para formatı.");
        }
    }
}
