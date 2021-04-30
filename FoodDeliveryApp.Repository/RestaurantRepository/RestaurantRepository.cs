using FoodDeliveryApp.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryApp.Repository.RestaurantRepository
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly DataContext _context;

        public RestaurantRepository (DataContext context)
        {
            _context = context;
        }

        public Restaurant AddRestaurant(Restaurant res)
        {
            _context.Restaurants.Add(res);
            _context.SaveChanges();
            return res;
        }

        public void EditRestaurant(Restaurant res)
        {
            _context.Restaurants.Update(res);
            _context.SaveChanges();
        }

        public void DeleteRestaurant(Restaurant res)
        {
            _context.Restaurants.Remove(res);
            _context.SaveChanges();
        }
           

        public List<Restaurant> GetRestaurants()
        {
            return _context.Restaurants.ToList();
        }

        public Restaurant GetRestaurant(int id)
        {
            return _context.Restaurants.SingleOrDefault(x => x.Id == id);
        }
    }
}
