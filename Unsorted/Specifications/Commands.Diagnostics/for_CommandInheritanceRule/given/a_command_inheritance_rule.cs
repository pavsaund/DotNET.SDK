﻿using Dolittle.Commands.Diagnostics;
using Dolittle.Diagnostics;
using Machine.Specifications;
using Moq;

namespace Dolittle.Commands.Diagnostics.for_CommandInheritanceRule.given
{
    public class a_command_inheritance_rule
    {
        protected static CommandInheritanceRule rule;
        protected static Mock<IProblems> problems_mock;

        Establish context = () =>
        {
            problems_mock = new Mock<IProblems>();
            rule = new CommandInheritanceRule();
        };
    }
}
