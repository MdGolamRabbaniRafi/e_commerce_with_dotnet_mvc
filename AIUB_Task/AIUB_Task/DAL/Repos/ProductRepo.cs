using AIUB_Task.DAL.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AIUB_Task.DAL.Repos
{
    public class ProductRepo
    {
        public static bool AddCategory(Category category)
        {
            var db = new AIUB_TaskEntities1();
            db.Categories.Add(category);
            var a = db.SaveChanges();
            return a > 0;
        }

        public static List<Product> GetAllProducts()
        {
            using (var db = new AIUB_TaskEntities1())
            {
                return db.Products.ToList();
            }
        }

        public static List<Product> LowStockCheck()
        {
            using (var db = new AIUB_TaskEntities1())
            {
                return db.Products.Where(p => p.Quantity < 3).ToList();
            }
        }

        public static Product SearchProduct(int Id)
        {
            var db = new AIUB_TaskEntities1();
            var product = db.Products.Find(Id);
            return product;
        }

        public static void UpdateProduct(Product updatedProduct)
        {
            var db = new AIUB_TaskEntities1();
            db.Products.Attach(updatedProduct);
            db.Entry(updatedProduct).State = EntityState.Modified;
            db.SaveChanges();
        }

        public static Product AddProduct(Product product)
        {
            var db = new AIUB_TaskEntities1();
            db.Products.Add(product);
            var a = db.SaveChanges();
            return a > 0 ? product : null;
        }

        public static bool AddProductColors(int[] colors, int productId)
        {
            var db = new AIUB_TaskEntities1();
            var productColors = colors.Select(colorId => new ProductColor
            {
                ProductId = productId,
                ColorId = colorId
            }).ToList();

            db.ProductColors.AddRange(productColors);
            return db.SaveChanges() > 0;
        }

        public static bool AddProductSize(int[] sizes, int productId)
        {
            var db = new AIUB_TaskEntities1();
            var productSize = sizes.Select(size => new ProductSize
            {
                ProductId = productId,
                SizeId = size
            }).ToList();

            db.ProductSizes.AddRange(productSize);
            return db.SaveChanges() > 0;
        }

        public static bool RemoveProductSize(int productId)
        {
            using (var db = new AIUB_TaskEntities1())
            {
                var productSizesToRemove = db.ProductSizes.Where(ps => ps.ProductId == productId);
                db.ProductSizes.RemoveRange(productSizesToRemove);
                return db.SaveChanges() > 0;
            }
        }

        public static bool RemoveProductOrderColorMapper(int productId)
        {
            using (var db = new AIUB_TaskEntities1())
            {
                var productColorsToRemove = db.ProductColorOrderMappers.Where(pc => pc.ProductId == productId);
                db.ProductColorOrderMappers.RemoveRange(productColorsToRemove);
                return db.SaveChanges() > 0;
            }
        }

        public static bool RemoveProductOrderSizeMapper(int productId)
        {
            using (var db = new AIUB_TaskEntities1())
            {
                var productSizesToRemove = db.ProductOrderSizeMappers.Where(ps => ps.ProductId == productId);
                db.ProductOrderSizeMappers.RemoveRange(productSizesToRemove);
                return db.SaveChanges() > 0;
            }
        }

        public static bool RemoveProductColor(int productId)
        {
            using (var db = new AIUB_TaskEntities1())
            {
                var productColorsToRemove = db.ProductColors.Where(pc => pc.ProductId == productId);
                db.ProductColors.RemoveRange(productColorsToRemove);
                return db.SaveChanges() > 0;
            }
        }
        public static bool RemoveProductOrderMapper(int productId)
        {
            using (var db = new AIUB_TaskEntities1())
            {
                var productColorsToRemove = db.ProductOrderMappers.Where(pc => pc.ProductId == productId);
                db.ProductOrderMappers.RemoveRange(productColorsToRemove);
                return db.SaveChanges() > 0;
            }
        }

        public static bool UpdateProductColor(int[] colors, int id)
        {
            var remove = RemoveProductColor(id);
            return remove && AddProductColors(colors, id);
        }

        public static bool UpdateProductSize(int[] sizes, int id)
        {
            var remove = RemoveProductSize(id);
            return remove && AddProductSize(sizes, id);
        }

        public static bool RemoveProduct(int productId)
        {
            using (var db = new AIUB_TaskEntities1())
            {
                RemoveProductColor(productId);
                RemoveProductSize(productId);
                RemoveProductOrderColorMapper(productId);
                RemoveProductOrderSizeMapper(productId); 
                RemoveProductOrderMapper(productId);

                var product = db.Products.Find(productId);
                if (product != null)
                {
                    db.Products.Remove(product);
                    return db.SaveChanges() > 0;
                }
                return false;
            }
        }

        public static bool ConfirmDelete(int id)
        {
            return RemoveProduct(id);
        }
    }
}
