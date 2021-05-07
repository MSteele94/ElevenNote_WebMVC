﻿using ElevenNote_Data;
using ElevenNote_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote_Services
{
    public class CategoryService
    {
        public bool CreateCategory(CategoryCreate model)
        {
            var entity = new Category()
            {
                Subject = model.Subject,
                Notes = model.Notes
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Categories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public CategoryDetail GetCategoryById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Categories
                    .Single(e => e.CategoryId == id);
                return
                    new CategoryDetail
                    {
                        CategoryId = (entity.CategoryId is null) ? null : entity.CategoryId,
                        Subject = entity.Subject,
                        Notes = entity.Notes
                    };
            }
        }
        public bool UpdateCategory(CategoryEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Categories
                    .Single(e => e.CategoryId == model.CategoryId);
                entity.CategoryId = (entity.CategoryId is null) ? null : entity.CategoryId;
                entity.Subject = entity.Subject;
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CategoryListItem> GetCategories()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Categories
                    .Select(
                        e =>
                        new CategoryListItem
                        {
                            CategoryId = e.CategoryId,
                            Subject = e.Subject
                        });
                return query.ToArray();
            }
        }
        public bool DeleteCategory (int categoryId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Categories
                    .Single(e => e.CategoryId == categoryId);
                ctx.Categories.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}