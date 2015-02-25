﻿#region License
//
// Copyright (c) 2008-2015, Dolittle (http://www.dolittle.com)
//
// Licensed under the MIT License (http://opensource.org/licenses/MIT)
//
// You may not use this file except in compliance with the License.
// You may obtain a copy of the license at 
//
//   http://github.com/dolittle/Bifrost/blob/master/MIT-LICENSE.txt
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
#endregion
using System.Reflection;

namespace Bifrost.Execution
{
    /// <summary>
    /// Defines something that tell wether or not to filter away an assembly.
    /// </summary>
    /// <remarks>
    /// Typically used by implementations of <see cref="IAssemblyLocator"/> to 
    /// get the correct assemblies located for things like implementations of
    /// <see cref="ITypeDiscoverer"/> which relies on knowing about assemblies
    /// to be able to discover types.
    /// </remarks>
    public interface ICanFilterAssembly
    {
        /// <summary>
        /// Method that gets called participating in the chain to decide wether or
        /// not an assembly should be included
        /// </summary>
        /// <param name="assembly"><see cref="Assembly"/> to check</param>
        /// <returns>True if it should be included, false if not</returns>
        bool ShouldInclude(Assembly assembly);
    }
}
