using Albelli.OrderManagement.Application.Common.Mappings;
using Albelli.OrderManagement.Domain;
using AutoMapper;

namespace Albelli.OrderManagement.Application.Orders.Queries
{
    public class OrderLineViewModel : IMapWith<OrderLine>
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string ProductType { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrderLine, OrderLineViewModel>()
                    .ForMember(vm => vm.Id, opt => opt.MapFrom(ol => ol.OrderLineId))
                    .ForMember(vm => vm.Quantity, opt => opt.MapFrom(ol => ol.Quantity))
                    .ForMember(vm => vm.ProductType, opt => opt.MapFrom(ol => ol.ProductInfo.ProductType));
        }
    }
}
