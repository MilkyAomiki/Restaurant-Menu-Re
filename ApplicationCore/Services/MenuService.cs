using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System.Collections.Generic;


namespace ApplicationCore.Services
{
    public class MenuService : IMenuService<MenuItem>
    {
        private readonly IRepository<MenuItem> _repository;

        public int Count => _repository.Count;

        public MenuService(IRepository<MenuItem> repository)
        {
            _repository = repository;
        }

        public void AddNewItem(MenuItem item)
        {
            _repository.Add(item);
        }

        public MenuItem ChangeItem(MenuItem item)
        {
            return _repository.Update(item);
        }

        public void DeleteItem(int id)
        {
            _repository.Delete(id);
        }

        public MenuItem GetItem(int id)
        {
            return _repository.GetById(id);
        }

        //TODO [Q] Лучше назвать GetAll, о том что это "лист" говорит тип возвращаемого значения 
        // -- List (глагол) - перечислять 
        public List<MenuItem> ListAllItems()
        {
            return _repository.ListAll();
        }

        public List<MenuItem> SelectRange(int index, int count)
        {
            return _repository.SelectRange(index, count);
        }
    }
}
