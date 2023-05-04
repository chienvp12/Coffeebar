using System;
using Coffee.Entities;

namespace Coffee.Repository
{
    public interface ICoffeeBarRepo
    {
        public Task<List<CoffeeBar>> GetCoffeeBars();
    }
}