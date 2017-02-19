﻿using System.Linq;
using Bifrost.Applications;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace Bifrost.Specs.Applications.for_ApplicationStructureConfigurationBuilder
{
    public class when_building_with_two_added_structure_format
    {
        const string first_structure_format = "[.]FirstFormat";
        const string second_structure_format = "[.]SecondFormat";
        static IApplicationStructureConfigurationBuilder builder;
        static IApplicationStructure structure;

        Establish context = () =>
        {
            var b = new ApplicationStructureConfigurationBuilder();

            builder = b.Include(first_structure_format).Include(second_structure_format);
        };

        Because of = () => structure = builder.Build();

        It should_hold_two_structure_formats = () => structure.StructureFormats.Count().ShouldEqual(2);
    }
}
