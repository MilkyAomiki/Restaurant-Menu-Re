using ApplicationCore.DataTransformation;
using ApplicationCore.Entities.Data;
using ApplicationCore.Entities.DataRepresentation;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;

namespace ApplicationCore.Services
{
    public class MenuService : IMenuService<MenuItem, SearchData>
    {
        private readonly IRepository<MenuItem> _repository;

        public int Count => _repository.Count;

        public MenuService(IRepository<MenuItem> repository) => _repository = repository;

        public void AddNewItem(MenuItem item) => _repository.Add(item);

        public MenuItem ChangeItem(MenuItem item) => _repository.Update(item);

        public void DeleteItem(int id) => _repository.Delete(id);

        public MenuItem GetItem(int id) => _repository.GetById(id);

        public List<MenuItem> ListAllItems() => _repository.ListAll();

        public List<MenuItem> ListAllItems(int index, int count, SearchData searchItem = null)
        {
            searchItem = SurveyForNullProperties(searchItem);

            if (searchItem != null)
            {
                var expressionChecker = Expressions.GenerateComparisonExpressions(searchItem);
                return _repository.ListAll(index, count, expressionChecker);
            }
            return _repository.ListAll(index, count);
        }

        public List<MenuItem> ListAllItems(int index, int count, string orderColumn, string orderType, SearchData searchItem = null)
        {
            searchItem = SurveyForNullProperties(searchItem);

            if (searchItem != null)
            {
                var expressionChecker = Expressions.GenerateComparisonExpressions(searchItem);
                return _repository.ListAll(index, count, orderColumn, orderType, expressionChecker);
            }

            return _repository.ListAll(index, count, orderColumn, orderType);
        }

        public List<MenuItem> Find(Func<MenuItem, bool> rules) => _repository.Find(rules);

        private SearchData SurveyForNullProperties(SearchData searchData)
        {
            var props = searchData.GetType().GetProperties();
            bool doesContainNonDefault = false;
            for (int i = 0; i <  props.Length; i++)
            {
                var val = props[i].GetValue(searchData);
                if (val != null)
                {
                    doesContainNonDefault = true;
                    break;
                }
            }
            if (doesContainNonDefault == false)
            {
                searchData = null;
            }
            return searchData;
        }
    }
}
