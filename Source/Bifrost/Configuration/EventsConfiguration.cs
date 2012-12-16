﻿#region License
//
// Copyright (c) 2008-2012, DoLittle Studios AS and Komplett ASA
//
// Licensed under the Microsoft Permissive License (Ms-PL), Version 1.1 (the "License")
// With one exception :
//   Commercial libraries that is based partly or fully on Bifrost and is sold commercially,
//   must obtain a commercial license.
//
// You may not use this file except in compliance with the License.
// You may obtain a copy of the license at
//
//   http://bifrost.codeplex.com/license
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
#endregion
using System;
using System.Collections.Generic;
using Bifrost.Events;
using Bifrost.Execution;

namespace Bifrost.Configuration
{
    /// <summary>
    /// Represents an implementation of <see cref="IEventsConfiguration"/>
    /// </summary>
    public class EventsConfiguration : ConfigurationStorageElement, IEventsConfiguration
    {
        IEventStoreChangeManager _eventStoreChangeManager;

        /// <summary>
        /// Initializes an instance of <see cref="EventsConfiguration"/>
        /// </summary>
        /// <param name="eventStoreChangeManager">An instance of <see cref="IEventStoreChangeManager"/></param>
        public EventsConfiguration(IEventStoreChangeManager eventStoreChangeManager)
        {
            _eventStoreChangeManager = eventStoreChangeManager;
            RepositoryType = typeof(EventRepository);
            EventStoreType = typeof(EventStore);
        }

#pragma warning disable 1591 // Xml Comments
        public Type RepositoryType { get; set; }
        public Type EventStoreType { get; set; }

        public void AddEventStoreChangeNotifier(Type type)
        {
            _eventStoreChangeManager.Register(type);
        }

        public override void Initialize(IContainer container)
        {
            if (EventStoreType != null)
                container.Bind<IEventStore>(EventStoreType);

            if (EntityContextConfiguration != null)
            {
                EntityContextConfiguration.BindEntityContextTo<IEvent>(container);
                EntityContextConfiguration.BindEntityContextTo<EventSubscriptionHolder>(container);
                base.Initialize(container);
            }
        }
#pragma warning restore 1591 // Xml Comments

    }
}