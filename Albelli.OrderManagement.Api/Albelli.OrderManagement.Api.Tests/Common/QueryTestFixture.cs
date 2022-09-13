using Albelli.OrderManagement.Api.Persistence;
using Albelli.OrderManagement.Application.Common.Mappings;
using Albelli.OrderManagement.Application.Interfaces;
using AutoMapper;
using System;

namespace Albelli.OrderManagement.Api.Tests.Common
{
    public abstract class QueryTestFixture : IDisposable
    {
        public OrdersDbContext Context;
        public IMapper Mapper;

        public QueryTestFixture()
        {
            Context = OrdersContextFactory.Create();

            var configurationProvider = new MapperConfiguration(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(typeof(IOrdersDbContext).Assembly));
            });

            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            OrdersContextFactory.Destroy(Context);
        }
    }
}
