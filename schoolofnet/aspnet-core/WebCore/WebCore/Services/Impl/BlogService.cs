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
        private readonly ApplicationDbContext _context;

        public BlogService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Salvar(Blog blog)
        {
            if (blog.ID > 0)
            {
                _context.Blog.Attach(blog);
                _context.Entry(blog).State = EntityState.Modified;
            }
            else _context.Blog.Add(blog);

            _context.SaveChanges();
        }

        public async Task SalvarAsync(Blog blog)
        {
            if (blog.ID > 0)
            {
                _context.Blog.Attach(blog);
                _context.Entry(blog).State = EntityState.Modified;
            }
            else await _context.Blog.AddAsync(blog);

            await _context.SaveChangesAsync();

        }

        public Blog Obter(int id)
        {
            return _context.Blog.Find(id);
        }

        public async Task<Blog> ObterAsync(int? id)
        {
            return await _context.Blog.FindAsync(id);
        }

        public IEnumerable<Blog> Listar()
        {
            return _context.Blog.ToList();
        }

        public void Deletar(int id)
        {
            var blog = _context.Blog.Find(id);
            _context.Remove(blog);
            _context.SaveChanges();
        }

        
    }
}
