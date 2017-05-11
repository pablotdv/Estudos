using System.Collections.Generic;
using System.Threading.Tasks;
using WebCore.Models.ManageBlog;
using WebCore.ViewModels;

namespace WebCore.Services.Spec
{
    public interface IBlogService
    {
        void Deletar(int id);
        IEnumerable<Blog> Listar();
        Blog Obter(int id);
        void Salvar(Blog blog);
        Task SalvarAsync(Blog blog);
        Task<Blog> ObterAsync(int? id);
    }
}