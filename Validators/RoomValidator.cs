using FluentValidation;
using MyPlace.Models;
using MyPlace.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPlace.Validators
{
    public class RoomValidator: AbstractValidator<RoomViewModel>
    { 
        public RoomValidator()
        {
            RuleFor(x => x.RoomSize).GreaterThan(1).WithMessage("Room size must be greater than 1 mp"); 
            RuleFor(x => x.RoomNumber).InclusiveBetween(1, 12);
        }
    }
}
