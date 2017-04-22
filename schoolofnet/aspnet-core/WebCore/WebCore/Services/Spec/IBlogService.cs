using System.Collections.Generic;
using WebCore.Models.ManageBlog;

namespace WebCore.Services.Spec
{
    public interface IBlogService
    {
        void Deletar(int id);
        IEnumerable<Blog> Listar();
        Blog Obter(int id);
        void Salvar(Blog blog);
    }
}