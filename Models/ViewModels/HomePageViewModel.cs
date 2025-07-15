using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace GGStore.Models.ViewModels
{
    public class HomePageViewModel
    {
        public List<Product> FeaturedProducts { get; set; } = new List<Product>();
        public List<Product> NewArrivals { get; set; } = new List<Product>();
        public List<Product> BestSellers { get; set; } = new List<Product>();
        public List<Product> SaleProducts { get; set; } = new List<Product>();
        public List<Category> Categories { get; set; } = new List<Category>();
        public List<Brand> FeaturedBrands { get; set; } = new List<Brand>();
        public List<ProductReview> LatestReviews { get; set; } = new List<ProductReview>();
    }
}
