using DataAccessLayer.Abstract;
using Entity.POCO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLogicLayer.Validations
{
    internal class GameValidation:AbstractValidator<Game>
    {
        IGameDAL gameDAL;
        public GameValidation(IGameDAL dAL)
        {

            RuleFor(x => x.GameName).NotNull().WithMessage("Oyun İsmi Alanı Boş Geçilemez!");
            RuleFor(x => x.GameName).Length(3,100).WithMessage("Oyun İsminin Uzunluğu 3-100 Karakter Aralığında Olmalıdır!");


            gameDAL = dAL;

        }
    }
}
