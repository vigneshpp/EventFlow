﻿// The MIT License (MIT)
// 
// Copyright (c) 2015-2018 Rasmus Mikkelsen
// Copyright (c) 2015-2018 eBay Software Foundation
// https://github.com/eventflow/EventFlow
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of
// this software and associated documentation files (the "Software"), to deal in
// the Software without restriction, including without limitation the rights to
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do so,
// subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
// FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
// COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
// IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
// CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System;
using EventFlow.EventStores;
using EventFlow.EventStores.Files;
using Microsoft.Extensions.DependencyInjection;

namespace EventFlow.Extensions
{
    public static class EventFlowOptionsEventStoresExtensions
    {
        public static IEventFlowBuilder UseEventStore(
            this IEventFlowBuilder eventFlowBuilder,
            Func<IServiceProvider, IEventStore> eventStoreResolver,
            ServiceLifetime lifetime = ServiceLifetime.Transient)
        {
            throw new NotImplementedException();
        }

        public static IEventFlowBuilder UseEventStore<TEventStore>(
            this IEventFlowBuilder eventFlowBuilder,
            ServiceLifetime lifetime = ServiceLifetime.Transient)
            where TEventStore : class, IEventPersistence
        {
            throw new NotImplementedException();
        }

        public static IEventFlowBuilder UseFilesEventStore(
            this IEventFlowBuilder eventFlowBuilder,
            IFilesEventStoreConfiguration filesEventStoreConfiguration)
        {
            return eventFlowBuilder.RegisterServices(f =>
                {
                    f.AddSingleton(filesEventStoreConfiguration);
                    f.AddSingleton<IEventPersistence, FilesEventPersistence>();
                    f.AddTransient<IFilesEventLocator, FilesEventLocator>();
                });
        }
    }
}