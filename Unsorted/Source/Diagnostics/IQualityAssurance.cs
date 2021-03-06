﻿/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
namespace Dolittle.Diagnostics
{
    /// <summary>
    /// Defines the API for assuring the quality of the system
    /// </summary>
    public interface IQualityAssurance
    {
        /// <summary>
        /// Validate the quality of the system
        /// </summary>
        void Validate();
    }
}
