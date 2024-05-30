using AIUB_Task.BLL.DTOs;
using AIUB_Task.Classes;
using AIUB_Task.DAL.EF;
using AIUB_Task.DAL.Repos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace AIUB_Task.BLL.Services
{
    public class ProductService
    {
        public static bool AddCategory(CategoryDTO category)
        {
            var mapper = MapperClass.MappedCategory(category);
            var category1 = mapper.Map<Category>(category);
            return ProductRepo.AddCategory(category1);
        }
        public static ProductDTO SearchProduct(int id)
        {
            
            var product = ProductRepo.SearchProduct(id);
            var mapper = MapperClass.MappedProduct(product);
            var productmap = mapper.Map<Product>(product);
            var uploadPath = HttpContext.Current.Server.MapPath("~/Uploads");
            var filePath = Path.Combine(uploadPath, product.Image);

            if (File.Exists(filePath))
            {
                byte[] fileBytes = File.ReadAllBytes(filePath);

                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new ByteArrayContent(fileBytes);

                var fileExtension = Path.GetExtension(product.Image);
                if (!string.IsNullOrEmpty(fileExtension))
                {

                    response.Content.Headers.ContentType = new MediaTypeHeaderValue(FileExtention.GetContentTypeFromExtension(fileExtension));
                }
                var productDto = new ProductDTO
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Quantity = (int)product.Quantity,
                    price =(int) product.price,
                    CategoryId =(int) product.Category_Id,
                    ImageData = fileBytes
                };
                return productDto;
            }
            return null;
        }
        public static Product AddProduct(ProductDTO product)
        {
            string path = HttpContext.Current.Server.MapPath("~/Uploads/");
            var Image = product.Image;
            string fileName="";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (Image != null)
            {
                fileName = Path.GetFileName(Image.FileName);
                var filePath = Path.Combine(path, fileName);
                Image.SaveAs(filePath);
            }

            var mapper = MapperClass.MappedProduct(product);
            var product1 = mapper.Map<Product>(product);
            product1.Image = fileName;
            return ProductRepo.AddProduct(product1);
        }
        public static bool AddProductColors(int[] colors,int id)
        {

            return ProductRepo.AddProductColors(colors,id);
        }
        public static bool AddProductSize(int[] size, int id)
        {

            return ProductRepo.AddProductSize(size, id);
        }
        public static bool UpdateProductColors(int[] colors, int id)
        {

            return ProductRepo.UpdateProductColor(colors, id);
        }
        public static bool UpdateProductSize(int[] size, int id)
        {

            return ProductRepo.UpdateProductSize(size, id);
        }

        public static void UpdateProduct(ProductDTO updatedProduct)
        {
            string path = HttpContext.Current.Server.MapPath("~/Uploads/");
            var Image = updatedProduct.Image;
            string fileName = "";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (Image != null)
            {
                fileName = Path.GetFileName(Image.FileName);
                var filePath = Path.Combine(path, fileName);
                Image.SaveAs(filePath);
            }
            var mapper = MapperClass.MappedProduct(updatedProduct);
             var product = mapper.Map<Product>(updatedProduct);
            product.Image = fileName;
    
              ProductRepo.UpdateProduct(product);
        }

        public static List<ProductDTO> GetAllProducts()
        {
            var products = ProductRepo.GetAllProducts(); // Assuming you have a method in your repository to fetch all products
            var productList = new List<ProductDTO>();

            foreach (var product in products)
            {
                var uploadPath = HttpContext.Current.Server.MapPath("~/Uploads");
                var filePath = Path.Combine(uploadPath, product.Image);

                byte[] fileBytes = null;
                if (File.Exists(filePath))
                {
                    fileBytes = File.ReadAllBytes(filePath);
                }

                var productDto = new ProductDTO
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Quantity = product.Quantity ?? 0,
                    price = product.price ?? 0,
                    CategoryId = product.Category_Id ?? 0,
                    ImageData = fileBytes
                };

                productList.Add(productDto);
            }

            return productList;
        }
        public static bool ConfirmDelete(int id)
        {

            return ProductRepo.ConfirmDelete(id);
        }
        public static List<ProductDTO> LowStockCheck()
        {
            var products = ProductRepo.LowStockCheck(); 
            var productList = new List<ProductDTO>();

            foreach (var product in products)
            {
                var uploadPath = HttpContext.Current.Server.MapPath("~/Uploads");
                var filePath = Path.Combine(uploadPath, product.Image);

                byte[] fileBytes = null;
                if (File.Exists(filePath))
                {
                    fileBytes = File.ReadAllBytes(filePath);
                }

                var productDto = new ProductDTO
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Quantity = product.Quantity ?? 0,
                    price = product.price ?? 0,
                    CategoryId = product.Category_Id ?? 0,
                    ImageData = fileBytes
                };

                productList.Add(productDto);
            }

            return productList;
        }


    }
}