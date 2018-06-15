using System.ComponentModel;

namespace WpfTestApp.Models
{
    public class TestModel : INotifyPropertyChanged
    {
        private string _name;
        public string Name {
            get { return _name; }
            set {
                if (_name != value)
                {
                    _name = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
                }
            }
        }

        private string _value;
        public string Value {
            get { return _value; }
            set {
                _value = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Value"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
