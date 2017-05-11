using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebCore.Data;
using WebCore.Models.ManageBlog;
using WebCore.ViewModels;
using WebCore.Services.Spec;
using AutoMapper;

namespace WebCore.Controllers
{
    public class BlogsEFController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IBlogService _service;
        private readonly IMapper _mapper;

        public BlogsEFController(ApplicationDbContext context, IBlogService service, IMapper mapper)
        {
            _context = context;
            _service = service;
            _mapper = mapper;
        }

        // GET: BlogsEF
        public async Task<IActionResult> Index()
        {
            return View(await _context.Blog.ToListAsync());
        }

        // GET: BlogsEF/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blog
                .SingleOrDefaultAsync(m => m.ID == id);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        // GET: BlogsEF/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BlogsEF/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Tilulo,Resumo,Url,Autor,Captcha")] BlogViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Captcha == "123789")
                {
                    //Blog blog = Mapper.Map<BlogViewModel, Blog>(model);

                    var blog = _mapper.Map<Blog>(model);

                    await _service.SalvarAsync(blog);

                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        // GET: BlogsEF/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
                        
            var blog = await _service.ObterAsync(id);

            if (blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }

        // POST: BlogsEF/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Tilulo,Resumo,Url,Autor")] Blog blog)
        {
            if (id != blog.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogExists(blog.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(blog);
        }

        // GET: BlogsEF/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blog
                .SingleOrDefaultAsync(m => m.ID == id);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        // POST: BlogsEF/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blog = await _context.Blog.SingleOrDefaultAsync(m => m.ID == id);
            _context.Blog.Remove(blog);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool BlogExists(int id)
        {
            return _context.Blog.Any(e => e.ID == id);
        }
    }
}
