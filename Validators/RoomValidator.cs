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
            
            RuleFor(x => x.RoomNumber).InclusiveBetween(1, 12);
        }
    }
}
