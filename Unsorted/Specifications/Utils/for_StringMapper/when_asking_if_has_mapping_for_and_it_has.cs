﻿using Dolittle.Utils;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace Dolittle.Utils.for_StringMapper
{
    public class when_asking_if_has_mapping_for_and_it_has
    {
        const string input = "something";
        static StringMapper mapper = new StringMapper();
        static Mock<IStringMapping> first_mapping_mock;
        static Mock<IStringMapping> second_mapping_mock;
        static bool result;

        Establish context = () =>
        {
            first_mapping_mock = new Mock<IStringMapping>();
            first_mapping_mock.Setup(f => f.Matches(input)).Returns(false);
            second_mapping_mock = new Mock<IStringMapping>();
            second_mapping_mock.Setup(f => f.Matches(input)).Returns(true);
            mapper.AddMapping(first_mapping_mock.Object);
            mapper.AddMapping(second_mapping_mock.Object);
        };

        Because of = () => result = mapper.HasMappingFor(input);

        It should_return_true = () => result.ShouldBeTrue();

    }
}
