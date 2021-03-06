﻿using Dal.AbstractInterfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Concrete.EntityFramework.Repository
{
    public class EfCategoriesRepository : EfGenericRepository<Categories>, ICategoriesRepository
    {
        public EfCategoriesRepository():base()
        {
            
        }

        public int addCategory(Categories category)
        {
            try
            {
                context.Categories.Add(category);
                context.SaveChanges();
                return category.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool deleteCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public List<Categories> GetCategories()
        {
            try
            {
                return context.Categories.Include(x => x.Books).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Categories GetCategoriesById(int categoryId, bool IncludeBooks)
        {
            throw new NotImplementedException();
        }

        public List<Categories> GetUserFavoriteCategories(int userId)
        {
            try
            {
                return context.UserFavoritesCategories.Where(x => x.userId == userId).Include(x => x.Category).Select(x => x.Category).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool MakeFavorite(int userId, int categoryId)
        {
            try
            {
                context.UserFavoritesCategories.Add(new UserFavoritesCategories() { categoryId = categoryId, userId = userId });
                return Convert.ToBoolean(context.SaveChanges());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RemoveFavorite(int userId, int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
