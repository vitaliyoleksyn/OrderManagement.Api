using Albelli.OrderManagement.Api.Models;
using Albelli.OrderManagement.Api.Persistence;
using Albelli.OrderManagement.Application.Common.Mappings;
using Albelli.OrderManagement.Application.Interfaces;
using AutoMapper;
using System;

namespace Albelli.OrderManagement.Api.Tests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly OrdersDbContext Context;
        public IMapper Mapper;

        public TestCommandBase()
        {
            Context = OrdersContextFactory.Create();

            var configurationProvider = new MapperConfiguration(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(typeof(IOrdersDbContext).Assembly));
                config.AddProfile(new AssemblyMappingProfile(typeof(OrderLineDto).Assembly));
            });
            Mapper = configurationProvider.CreateMapper();
        }
        public void Dispose()
        {
            OrdersContextFactory.Destroy(Context);
        }
    }
}
