using Maracanema.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Maracanema.ViewModel
{
    public class JogadorViewModel
    {
        public ObservableCollection<Jogador> Jogadores { get; set; }

        private ICommand _executarCommand
        {
            get;
            set;
        }

        public JogadorViewModel()
        {
            Jogadores = new ObservableCollection<Jogador>();
        }

        public ICommand ExecutarCommand
        {
            get
            {
                return _executarCommand ?? (_executarCommand = new Command(() =>
                  {
                      Jogadores.Add(new Jogador()
                      {
                          Id = Jogadores.Count,
                          NmJogador = "Jogador " + Jogadores.Count,
                          DtNascimento = DateTime.Now,
                          NmPosicao = "Goleiro"
                      });
                  }));
            }
        }
    }
}
