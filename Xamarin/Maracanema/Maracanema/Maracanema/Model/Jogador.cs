using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Maracanema.Model
{
    public class Jogador : INotifyPropertyChanged
    {
        private int _id;
        private string _nmJogador;
        private DateTime _dtNascimento;
        private string _nmPosicao;

        public int Id
        {
            get { return _id; }
            set { _id = value; Notificacao(); }
        }

        public string NmJogador
        {
            get { return _nmJogador; }
            set { _nmJogador = value; Notificacao(); }
        }
        public DateTime DtNascimento
        {
            get { return _dtNascimento; }
            set { _dtNascimento = value; Notificacao(); }
        }
        public string NmPosicao
        {
            get { return _nmPosicao; }
            set { _nmPosicao = value; Notificacao(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void Notificacao([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null && string.IsNullOrWhiteSpace(propertyName))
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
