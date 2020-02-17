﻿using FluentValidation;
using Lrn.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lrn.Service.Validators
{
    public class CourseTopicValidator : AbstractValidator<CourseTopic>
    {
        public CourseTopicValidator()
        {
            RuleFor(c => c)
                    .NotNull()
                    .OnAnyFailure(x =>
                    {
                        throw new ArgumentNullException("Can't found the object.");
                    });

            /*
            RuleFor(c => c.Cpf)
                .NotEmpty().WithMessage("Is necessary to inform the CPF.")
                .NotNull().WithMessage("Is necessary to inform the CPF.");

            RuleFor(c => c.BirthDate)
                .NotEmpty().WithMessage("Is necessary to inform the birth date.")
                .NotNull().WithMessage("Is necessary to inform the birth date.");

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Is necessary to inform the name.")
                .NotNull().WithMessage("Is necessary to inform the birth date.");
           */
        }
    }
}
