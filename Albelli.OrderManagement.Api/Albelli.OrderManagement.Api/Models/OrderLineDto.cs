using Albelli.OrderManagement.Application.Common.Mappings;
using Albelli.OrderManagement.Application.OrderLines.Commands;
using AutoMapper;

namespace Albelli.OrderManagement.Api.Models
{
    public class OrderLineDto : IMapWith<CreateOrderLineCommand>
    {
        public string ProductType { get; set; }
        public int Quantity { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrderLineDto, CreateOrderLineCommand>()
                .ForMember(orderLineCommand => orderLineCommand.ProductType,
                opt => opt.MapFrom(orderLineDto => orderLineDto.ProductType))
                .ForMember(orderLineCommand => orderLineCommand.Quantity,
                opt => opt.MapFrom(orderLineDto => orderLineDto.Quantity));
        }
    }
}
