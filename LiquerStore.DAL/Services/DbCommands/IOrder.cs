using LiquerStore.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LiquerStore.DAL.Services.DbCommands
{
    public interface IOrder
    {
        OrderModel GetOrderById(int? id);
        IList<OrderModel> GetAllOrdersByUser(ApplicationUser user);
        void AddOrder(OrderModel order);
        void UpdateOrderByModel(OrderModel order);

        IList<OrderModel> GetAllOrders();
        IList<OrderModel> GetAllActiveOrders();
    }

    public class OrderService : IOrder
    {
        private ApplicationDbContext db;

        public OrderService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public OrderModel GetOrderById(int? id)
        {
            // Get a whisky based on id
            return db.Orders.FirstOrDefault(r => r.Id == id);
        }

        public IList<OrderModel> GetAllOrdersByUser(ApplicationUser user)
        {
           return db.Orders.Where(r => r.Customer.Id == user.Id).ToList();
        }

        public void AddOrder(OrderModel order)
        {
            // Add a whisky to the db
            db.Orders.Add(order);
            db.SaveChanges();
        }

        public void UpdateOrderByModel(OrderModel order)
        {
            db.Attach(order).State = EntityState.Modified;
            db.Orders.Update(order);

            db.SaveChanges();
        }

        public IList<OrderModel> GetAllOrders()
        {
            return db.Orders.ToList();
            //return from s in db.Storages
            //orderby s.Whisky.Name
            //select s;
        }

        public IList<OrderModel> GetAllActiveOrders()
        {
            return db.Orders.Where(r => !r.Completed).ToList();
        }
    }
}