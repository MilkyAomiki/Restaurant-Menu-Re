using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace ApplicationCore.Services
{
    public class MenuService : IMenuService<MenuItem>
    {
        private readonly IRepository<MenuItem> _repository;

        public int Count => _repository.Count;

        public MenuService(IRepository<MenuItem> repository) => _repository = repository;

        public void AddNewItem(MenuItem item) => _repository.Add(item);

        public MenuItem ChangeItem(MenuItem item) => _repository.Update(item);

        public void DeleteItem(int id) => _repository.Delete(id);

        public MenuItem GetItem(int id) => _repository.GetById(id);

        public List<MenuItem> ListAllItems() => _repository.ListAll();

        public List<MenuItem> ListAllItems(int index, int count, MenuItem searchItem = null)
        {
            if (searchItem != null)
            {
                var expressionChecker = GenerateComparisonExpressions(searchItem);
                return _repository.ListAll(index, count, expressionChecker);

            }
            return _repository.ListAll(index, count);
        }

        private List<Expression<Func<MenuItem, bool>>> GenerateComparisonExpressions(MenuItem searchItem)
        {
            List<Expression<Func<MenuItem, bool>>> expressions = new List<Expression<Func<MenuItem, bool>>>();
            var properties = searchItem.GetType().GetProperties();

            for (int i = 0; i < properties.Length; i++)
            {
                    Expression<Func<MenuItem, bool>> expr;
                    switch (properties[i].Name)
                    {
                        case "Title":
                        if (searchItem.Title == default) break;
                            expr = (MenuItem item) => item.Title.Contains(searchItem.Title);
                            expressions.Add(expr);
                            break;
                        case "Description":
                        if (searchItem.Description == default) break;
                            expr = (MenuItem item) => item.Description.Contains(searchItem.Description);
                            expressions.Add(expr);
                            break;
                        case "Ingredients":
                        if (searchItem.Ingredients == default) break; 
                            expr = (MenuItem item) => item.Ingredients.Contains(searchItem.Ingredients);
                            expressions.Add(expr);
                            break;
                        case "Grams":
                        if (searchItem.Grams == default) break;
                            expr = (MenuItem item) => item.Grams.Value == (searchItem.Grams).Value;
                            expressions.Add(expr);
                            break;
                        case "Calories":
                        if (searchItem.Calories == default) break; 
                            expr = (MenuItem item) => item.Calories.Value == (searchItem.Calories).Value;
                            expressions.Add(expr);
                            break;
                        case "CookingTime":
                        if (searchItem.CookingTime == default) break;
                            expr = (MenuItem item) => item.CookingTime.Value == (searchItem.CookingTime).Value;
                            expressions.Add(expr);
                            break;
                        case "Price":
                        if (searchItem.Price == default) break;
                            expr = (MenuItem item) => item.Price.Value == (searchItem.Price).Value;
                            expressions.Add(expr);
                            break;
                        case "CreationDate":
                        if (searchItem.CreationDate == default) break;
                            expr = (MenuItem item) => item.CreationDate.CompareTo(searchItem.CreationDate) == 0;
                            expressions.Add(expr);
                            break;
                    }            
            }

            return expressions;
        }

        public List<MenuItem> ListAllItems(int index, int count, string orderColumn, string orderType, MenuItem searchItem = null)
        {
            if (searchItem != null)
            {
                var expressionChecker = GenerateComparisonExpressions(searchItem);
                return _repository.ListAll(index, count, orderColumn, orderType, expressionChecker);

            }

            return _repository.ListAll(index, count, orderColumn, orderType);
        }

        public List<MenuItem> Find(Func<MenuItem, bool> rules) => _repository.Find(rules);
    }
}
