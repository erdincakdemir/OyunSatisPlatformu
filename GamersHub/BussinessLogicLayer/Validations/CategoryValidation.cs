using DataAccessLayer.Abstract;
using Entity.POCO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLogicLayer.Validations
{
    internal class CategoryValidation:AbstractValidator<Category>
    {
        ICategoryDAL categoryDAL;
        public CategoryValidation(ICategoryDAL dAL)
        {
            RuleFor(x => x.CategoryName).NotNull().WithMessage("Kategori İsmi Boş Geçilemez!");
            RuleFor(x => x.CategoryName).Length(3,50).WithMessage("Kategori İsmi 3-50 Karakter Uzunluğunda Olmalıdır!");
            categoryDAL = dAL;
        }
    }
}
