﻿/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Commands;
using Dolittle.FluentValidation.Concepts.given;
using Dolittle.Validation;
using FluentValidation;

namespace Dolittle.FluentValidation.Commands
{
    public class commands
    {
        public class MySimpleCommand : ICommand
        {
            public concepts.StringConcept StringConcept { get; set; }
            public concepts.LongConcept LongConcept { get; set; }
        }

        public class StringConceptInputValidator : InputValidator<concepts.StringConcept>
        {
            public StringConceptInputValidator()
            {
                RuleFor(s => s.Value)
                    .NotEmpty();
            }
        }

        public class StringConceptBusinessValidator : BusinessValidator<concepts.StringConcept>
        {
            public StringConceptBusinessValidator()
            {
                RuleFor(s => s.Value)
                    .Equals("Blah");
            }
        }

        public class LongConceptInputValidator : InputValidator<concepts.LongConcept>
        {
            public LongConceptInputValidator()
            {
                RuleFor(s => s.Value)
                    .NotEmpty();
            }
        }

        public class LongConceptBusinessValidator : BusinessValidator<concepts.LongConcept>
        {
            public LongConceptBusinessValidator()
            {
                RuleFor(s => s.Value)
                    .GreaterThanOrEqualTo(100);
            }
        }
    }
}