using AutoMapper;
using Elca.Sms.Api.Domain.Entity;
using ELCAStock.Models;

namespace ELCAStock.ModelMappings
{
    public class EntityToModelMapper : Profile
    {
        public EntityToModelMapper()
        {
            CreateMap<ItemRequest, ItemRequestDTO>();
            CreateMap<OrderBatch, OrderBatchDTO>();
            CreateMap<OrderBatchSupplier, OrderBatchSupplierDTO>();
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderItem, OrderItemDTO>();
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductLine, ProductLineDTO>();
            CreateMap<ProductItem, ProductItemDTO>();
            CreateMap<ProductType, ProductTypeDTO>();
            CreateMap<Requestor, RequestorDTO>();
            CreateMap<Supplier, SupplierDTO>();









        }
    }
}
