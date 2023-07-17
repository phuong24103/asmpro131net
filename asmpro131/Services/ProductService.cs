using asmpro131.IServices;
using asmpro131_Shared.Data;
using asmpro131_Shared.Models;
using asmpro131_Shared.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace asmpro131.Services
{
    public class ProductService : IProductService
    {
        MyDbContext _context;
        public ProductService()
        {
            _context = new MyDbContext();
        }
        public async Task<bool> CreateProduct(Product product)
        {

            if (product == null) return false;
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProduct(Guid id)
        {
            try
            {
                var product = _context.Products.Find(id);
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Product> GetProductByCS(string name, Guid colorId, Guid sizeId)
        {

            Product productView = await
                (from a in _context.Products
                 where a.Name == name && a.ColorID == colorId && a.SizeID == sizeId
                 select new Product()
                 {
                     Id = a.Id,
                     Name = a.Name,
                     Price = a.Price,
                     AvailableQuantity = a.AvailableQuantity,
                     ImageUrl = a.ImageUrl,
                     Manufacturer = a.Manufacturer,
                     Status = a.Status,
                     Likes = a.Likes,
                     Description = a.Description,
                     ColorID = a.ColorID,
                     SizeID = a.SizeID
                 }).FirstAsync();
            return productView;
        }

        public async Task<ProductView> GetProductById(Guid id)
        {
            ProductView productView = await
               (from a in _context.Products
                join b in _context.Colors on a.ColorID equals b.Id
                join c in _context.Sizes on a.SizeID equals c.Id
                where a.Id == id
                select new ProductView()
                {
                    Id = a.Id,
                    Name = a.Name,
                    Price = a.Price,
                    AvailableQuantity = a.AvailableQuantity,
                    ImageUrl = a.ImageUrl,
                    Manufacturer = a.Manufacturer,
                    Status = a.Status,
                    Likes = a.Likes,
                    Description = a.Description,
                    ColorID = a.ColorID,
                    SizeID = a.SizeID,
                    Color = b,
                    Size = c
                }).FirstAsync();
            return productView;
        }

        public async Task<List<ProductView>> GetProductByName(string name)
        {
            List<ProductView> lstProductView = new List<ProductView>();
            lstProductView = await
                (from a in _context.Products
                 join b in _context.Colors on a.ColorID equals b.Id
                 join c in _context.Sizes on a.SizeID equals c.Id
                 select new ProductView()
                 {
                     Id = a.Id,
                     Name = a.Name,
                     Price = a.Price,
                     AvailableQuantity = a.AvailableQuantity,
                     ImageUrl = a.ImageUrl,
                     Manufacturer = a.Manufacturer,
                     Status = a.Status,
                     Likes = a.Likes,
                     Description = a.Description,
                     ColorID = a.ColorID,
                     SizeID = a.SizeID,
                     Color = b,
                     Size = c
                 }).Where(p => p.Name.ToLower().Contains(name.ToLower())).ToListAsync();
            return lstProductView;
        }

        public async Task<List<ProductView>> ShowListProduct()
        {
            List<ProductView> lstProductView = await
              (from a in _context.Products
               join b in _context.Colors on a.ColorID equals b.Id
               join c in _context.Sizes on a.SizeID equals c.Id
               select new ProductView()
               {
                   Id = a.Id,
                   Name = a.Name,
                   Price = a.Price,
                   AvailableQuantity = a.AvailableQuantity,
                   ImageUrl = a.ImageUrl,
                   Manufacturer = a.Manufacturer,
                   Status = a.Status,
                   Likes = a.Likes,
                   Description = a.Description,
                   ColorID = a.ColorID,
                   SizeID = a.SizeID,
                   Color = b,
                   Size = c
               }).ToListAsync();
            return lstProductView;
        }

        public async Task<bool> UpdateProduct(ProductView product)
        {
            try
            {
                var n = _context.Products.Find(product.Id);
                n.Name = product.Name;
                n.Price = product.Price;
                n.AvailableQuantity = product.AvailableQuantity;
                n.ImageUrl = product.ImageUrl;
                n.Manufacturer = product.Manufacturer;
                n.Status = product.Status;
                n.Likes = product.Likes;
                n.Description = product.Description;
                n.ColorID = product.ColorID;
                n.SizeID = product.SizeID;
                _context.Update(n);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
