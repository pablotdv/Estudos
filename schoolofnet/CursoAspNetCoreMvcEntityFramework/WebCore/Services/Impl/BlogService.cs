using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebCore.Data;
using WebCore.Models.ManageBlog;
using WebCore.Services.Spec;

namespace WebCore.Services.Impl
{
    public class BlogService : IBlogService
    {
        private ApplicationDbContext _db;

        public BlogService(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Salvar(Blog blog)
        {
            if (blog.ID > 0)
            {
                _db.Blog.Attach(blog);
                _db.Entry(blog).State = EntityState.Modified;
            }
            else _db.Blog.Add(blog);

            _db.SaveChanges();
        }

        public Blog Obter(int id)
        {
            return _db.Blog.Find(id);
        }

        public IEnumerable<Blog> Listar()
        {
            return _db.Blog.ToList();
        }

        public void Deletar(int id)
        {
            var blog = _db.Blog.Find(id);
            _db.Remove(blog);
            _db.SaveChanges();
        }
    }
}
