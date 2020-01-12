using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace RandomPassword
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChangedEvent(string propertyName)
        {
            if (PropertyChanged == null) return;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    class PasswordViewModel : ViewModel
    {
        private PasswordModel _passwordModel;

        private ObservableCollection<PasswordClass> passwordList;

        public PasswordViewModel(PasswordModel passwordModel)
        {
            _passwordModel = passwordModel;
        }

        public void ReloadList(int num, int bits)
        {
            passwordList = _passwordModel.GetPassword(num, bits);
            RaisePropertyChangedEvent("PasswordList");
        }

        public ICollectionView PasswordList
        {
            get
            {
                return CollectionViewSource.GetDefaultView(passwordList);
            }
        }
    }
}
