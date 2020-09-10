using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

//TODO: Implement methods

namespace Infrastructure.Data
{
    public class MenuRepository : IRepository<MenuItem>
    {
        public MenuRepository(MenuContext context)
        {

        }

        public void Add(MenuItem entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(MenuItem entity)
        {
            throw new NotImplementedException();
        }

        public MenuItem GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<MenuItem> ListAll()
        {
            throw new NotImplementedException();
        }

        public MenuItem Update(MenuItem entity)
        {
            throw new NotImplementedException();
        }
    }
}
