﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using SoftServeTechnicalTask.Model;

namespace SoftServeTechnicalTask.Validators
{
    public class FamilyValidator : AbstractValidator<Family>
    {
        public FamilyValidator()
        {
            RuleFor(x => x.Id).Null().WithMessage("Request should not contain id, because it will be generated automatically");

            RuleFor(x => x.Name).NotEmpty().WithMessage("Name should not be empty")
                .Length(1, 100).WithMessage("Name has invalid length");

            RuleFor(x => x.BusinessId).NotEmpty().WithMessage("BusinessId should not be empty");

            RuleFor(x => x.Offerings).Null().WithMessage("Offerings should be added/modified via another route");
        }
    }
}