using eCommerce.SharedLibrary.Interface;
using OrderApi.Domain.Entities;
using System.Linq.Expressions;

namespace OrderApi.Application.Interfaces;

public interface IOrder : IGeneric<Order>
{
    Task<IEnumerable<Order>> GetOrdersAsync(Expression<Func<Order, bool>> predicate);
    //Task<IEnumerable<Order>> GetOrdersAsync(Expression<Predicate<Order>> predicate);
}
