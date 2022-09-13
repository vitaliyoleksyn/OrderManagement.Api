using Albelli.OrderManagement.Domain;
using System.Collections.Generic;
using AutoMapper;
using Albelli.OrderManagement.Application.Common.Mappings;

namespace Albelli.OrderManagement.Application.Orders.Queries
{
    public class OrderViewModel : IMapWith<Order>
    {
        public int OrderId { get; set; }
        public IEnumerable<OrderLineViewModel> Items { get; set; }
        public double MinPackageWidth { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderViewModel>()
                    .ForMember(order => order.OrderId, opt => opt.MapFrom(order => order.OrderId))
                    .ForMember(order => order.Items, opt => opt.MapFrom(order => order.Items))
                    .ForMember(order => order.MinPackageWidth, opt => opt.MapFrom(order => order.MinPackageWidth));
        }
    }
}
