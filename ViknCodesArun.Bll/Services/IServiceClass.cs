using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViknCodesArun.Bll.Dtos;
using ViknCodesArun.Dll.Models;

namespace ViknCodesArun.Bll.Services
{
    public interface IServiceClass
    {
        Task<Product> CreateProduct(ProductDto productDTO);
        Task<List<Product>> ListProduct();
        Task<bool> AddStock(int subVariantId, decimal quantity);
        Task<bool> RemoveStock(int subVariantId, decimal quantity);
    }
}
