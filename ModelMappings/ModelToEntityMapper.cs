using AutoMapper;
using Elca.Sms.Api.Domain.Entity;
using ELCAStock.Models;

namespace ELCAStock.ModelMappings
{
    public class ModelToEntityMapper : Profile
    {
        public ModelToEntityMapper()
        {
            CreateMap<ItemRequestDTO, ItemRequest>();
            CreateMap<OrderBatchDTO, OrderBatch>();
            CreateMap<OrderBatchSupplierDTO, OrderBatchSupplier>();
            CreateMap<OrderDTO, Order>();
            CreateMap<OrderItemDTO, OrderItem>();
            CreateMap<ProductDTO, Product>();
            CreateMap<ProductLineDTO, ProductLine>();
            CreateMap<ProductItemDTO, ProductItem>();
            CreateMap<ProductTypeDTO, ProductType>();
            CreateMap<RequestorDTO, Requestor>();
            CreateMap<SupplierDTO, Supplier>();


        }
    }
}
