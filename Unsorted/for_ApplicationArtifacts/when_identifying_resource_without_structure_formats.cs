﻿using System;
using Machine.Specifications;

namespace Dolittle.Applications.for_ApplicationArtifacts
{
    public class when_identifying_resource_without_structure_formats : given.application_resources_without_structure_formats
    {
        static Exception exception;

        Because of = () => exception = Catch.Exception(() => resources.Identify("something"));

        It should_throw_unable_to_identify_application_resource = () => exception.ShouldBeOfExactType<UnableToIdentifyApplicationResource>();
    }
}
