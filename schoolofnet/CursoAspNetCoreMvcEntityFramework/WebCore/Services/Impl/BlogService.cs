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
        private DbContextOptions<ApplicationDbContext> options;

        public void Salvar(Blog blog)
        {
            using (ApplicationDbContext db = new ApplicationDbContext(options))
            {
                if (blog.ID > 0)
                {
                    db.Blog.Attach(blog);
                    db.Entry(blog).State = EntityState.Modified;
                }
                else db.Blog.Add(blog);

                db.SaveChanges();
            }
        }

        public Blog Obter(int id)
        {
            using (var db = new ApplicationDbContext(options))
            {
                return db.Blog.Find(id);
            }
        }

        public IEnumerable<Blog> Listar()
        {
            using (var db = new ApplicationDbContext(options))
            {
                return db.Blog.ToList();
            }
        }

        public void Deletar(int id)
        {
            using (var db = new ApplicationDbContext(options))
            {
                var blog = db.Blog.Find(id);
                db.Remove(blog);
                db.SaveChanges();
            }
        }
    }
}
