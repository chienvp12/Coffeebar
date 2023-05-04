using System;
using Coffee.Entities;

namespace Coffee.Repository
{
    public interface IBillRepo
    {
        public Task<List<Bill>> GetBills();
    }
}