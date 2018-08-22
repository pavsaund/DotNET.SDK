/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Dolittle.Applications.Configuration;
using Dolittle.Concepts.Serialization.Json;
using Dolittle.Logging;
using Dolittle.Serialization.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Dolittle.Build.Topology
{
    /// <summary>
    /// Represents a class that basically handles the interations with a <see cref="BoundedContextConfiguration"/>
    /// </summary>
    public class TopologyConfigurationHandler
    {
        readonly BoundedContextConfigurationManager _configurationManager;
        readonly ILogger _logger;
        
        readonly static ISerializationOptions _serializationOptions = SerializationOptions
            .Custom(callback:
            serializer => {
                serializer.ContractResolver = new CamelCaseExceptDictionaryKeyResolver();
                serializer.Formatting = Formatting.Indented;
            });
        /// <summary>
        /// Instantiates an instance of <see cref="TopologyConfigurationHandler"/> 
        /// </summary>
        /// <param name="configurationSerializer"></param>
        /// <param name="logger"></param>
        public TopologyConfigurationHandler(ISerializer configurationSerializer, ILogger logger)
        {
            _configurationManager = new BoundedContextConfigurationManager(configurationSerializer, _serializationOptions, logger);
            _logger = logger;
        }

        /// <summary>
        /// Loads the <see cref="BoundedContextConfiguration"/> from file and uses it to build the <see cref="BoundedContextConfiguration"/> using the <see cref="TopologyBuilder"/>
        /// </summary>
        /// <param name="types">The discovered artifact types from the bounded context's assemblies</param>
        public BoundedContextConfiguration Build(Type[] types)
        {
            var boundedContextConfiguration = _configurationManager.Load();
            return new TopologyBuilder(types, boundedContextConfiguration, _logger).Build();
        }

        internal void Save(BoundedContextConfiguration config)
        {
            _configurationManager.Save(config);
        }
    }
}