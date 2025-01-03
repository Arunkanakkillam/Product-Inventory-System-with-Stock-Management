using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViknCodesArun.Bll.Dtos;
using ViknCodesArun.Dll.ApplicationDbContext;
using ViknCodesArun.Dll.Models;

namespace ViknCodesArun.Bll.Services
{
    public class ServiceClass:IServiceClass
    {
        private readonly Context _context;
        public ServiceClass(Context context)
        {
            _context = context;
        }

        public async Task<Product> CreateProduct(ProductDto productDTO)
        {
            try
            {
                
                var createProduct = new Product
                {
                    ProductName = productDTO.ProductName,
                    CreatedUserId = productDTO.CreatedUserId,
                    ProductImage = productDTO.ProductImage,
                    IsFavourite = productDTO.IsFavourite,
                    Active = productDTO.Active,
                    HSNCode = productDTO.HSNCode,
                    TotalStock = productDTO.TotalStock,
                    Variants = productDTO.Variants.Select(p => new Variants
                    {
                        Name = p.Name,
                        SubVariants = p.SubVariants.Select(p => new SubVariants
                        {
                            Option = p.Option,
                            Stock = p.Stock
                        }).ToList()
                    }).ToList()
                };

                _context.Products.Add(createProduct);
                await _context.SaveChangesAsync();

                return createProduct;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }


        public async Task<List<Product>> ListProduct()
        {
            try
            {
                var data = await _context.Products
                       .Include(p => p.Variants)
                       .ThenInclude(p => p.SubVariants)
                       .ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }


        }


        public async Task<bool> AddStock(int subVariantId, decimal quantity)
        {
            try
            {
                var subvariant = await _context.SubVariants.FindAsync(subVariantId);
                var variant = subvariant.VariantId;
                
                var data1 = await _context.Variants
                    .Where(p => p.Id == variant) 
                    .Select(p => p.ProductId)
                    .ToListAsync();

                if (subvariant == null)
                {
                    return false;
                }
                if (variant == null)
                {
                    throw new InvalidOperationException("Variant is null for the given subvariant.");
                }
                var data = await _context.Products.FirstOrDefaultAsync(p => p.Id == data1.First());
                if (data == null)
                {
                    return false;
                }

                subvariant.Stock += quantity;
                var prod = await _context.Products.FirstOrDefaultAsync(p=>p.Id==data.Id);
                prod.TotalStock += quantity;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }

        }
        public async Task<bool> RemoveStock(int subVariantId, decimal quantity)
        {
            try
            {
                var subvariant = await _context.SubVariants.FindAsync(subVariantId);
                var variant = subvariant.VariantId;

                var data1 = await _context.Variants
                    .Where(p => p.Id == variant)
                    .Select(p => p.ProductId)
                    .ToListAsync();

                if (subvariant == null)
                {
                    return false;
                }
                if (variant == null)
                {
                    throw new InvalidOperationException("Variant is null for the given subvariant.");
                }
                var data = await _context.Products.FirstOrDefaultAsync(p => p.Id == data1.First());
                if (data == null)
                {
                    return false;
                }

                subvariant.Stock -= quantity;
                var prod = await _context.Products.FirstOrDefaultAsync(p => p.Id == data.Id);
                prod.TotalStock -= quantity;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }


        }



    }
}
