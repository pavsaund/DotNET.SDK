/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Dolittle.Assemblies;
using Dolittle.Reflection;

namespace Dolittle.Build
{
    /// <summary>
    /// Represents a class that can do discovery of Artifacts in an Assembly
    /// </summary>
    public class ArtifactsDiscoverer
    {
        readonly IAssemblyContext _assemblyContext;
        readonly ArtifactType[] _artifactTypes;
        readonly IBuildToolLogger _logger;

        /// <summary>
        /// Gets the list of discovered Artifacts
        /// </summary>
        public Type[] Artifacts {get;}
        /// <summary>
        /// Instantiates and instance of <see cref="ArtifactsDiscoverer"/>
        /// </summary>
        /// <param name="assemblyContext"></param>
        /// <param name="artifactTypes"></param>
        /// <param name="logger"></param>
        public ArtifactsDiscoverer(IAssemblyContext assemblyContext, DolittleArtifactTypes artifactTypes, IBuildToolLogger logger)
        {
            _assemblyContext = assemblyContext;
            _artifactTypes = artifactTypes.ArtifactTypes;
            _logger = logger;

            Artifacts = DiscoverArtifacts();
        }

        Type[] DiscoverArtifacts()
        {
            
            var startTime = DateTime.UtcNow;
            var types = GetArtifactsFromAssembly();

            ThrowIfArtifactWithNoModuleOrFeature(types);
            
            return types;
        }
        Type[] GetArtifactsFromAssembly()
        {
            return _assemblyContext
                .GetProjectReferencedAssemblies()
                .SelectMany(_ => _.ExportedTypes)
                .Where(_ =>
                    !_.GetTypeInfo().IsAbstract && !_.ContainsGenericParameters
                    && 
                    _artifactTypes
                    .Any(at => at.Type.IsAssignableFrom(_)))
                .ToArray();
        }

        void ThrowIfArtifactWithNoModuleOrFeature(Type[] types)
        {
            bool hasInvalidArtifact = false;
            foreach(var type in types)
            {
                if (string.IsNullOrEmpty(type.Namespace) || type.Namespace == "null") 
                {
                    _logger.Error($"The artifact '{type.FullName}' is invalid. Artifact has no namespace");
                    hasInvalidArtifact = true;      
                } 
                var numSegments = type.Namespace.Split(".").Count();
                if (numSegments < 1) 
                {
                    hasInvalidArtifact = true;
                    _logger.Error($"The artifact '{type.FullName}' is invalid. An artifact's namespace must consist of at least two segments.");
                }
            }
            if (hasInvalidArtifact) throw new InvalidArtifact();
        }
    }
}
