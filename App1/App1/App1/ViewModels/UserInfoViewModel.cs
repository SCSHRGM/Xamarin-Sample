using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace App1
{
    public class UserInfoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #region Page2

        private string _name, _engName;
        private bool _isEnabled;

        private UserInfoModel UserInfo { set; get; }

        public UserInfoViewModel(UserInfoModel userInfo)
        {
            this.UserInfo = userInfo;
            _name = this.UserInfo.Name;
            _engName = this.UserInfo.EngName;
        }

        public string NameLabel { get { return "中文姓名"; } }
        public string EngNameLabel { get { return "英文姓名"; } }
        public string ButtonText { get { return "存檔"; } }

        public string NameText
        {
            get { return _name; }
            set 
            {
                _name = value;
                OnPropertyChanged();

                ValidateInput();
            }
        }

        public string EngNameText
        {
            get { return _engName; }
            set
            {
                _engName = value;
                OnPropertyChanged();

                ValidateInput();
            }
        }

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                _isEnabled = value;
                OnPropertyChanged();
            }
        }

        private void ValidateInput()
        {
            this.IsEnabled = !(String.IsNullOrEmpty(_name) || String.IsNullOrEmpty(_engName));
        }

        public bool Save()
        {
            UserInfo.Name = _name;
            UserInfo.EngName = _engName;
            return true;
        }

        #endregion

        #region Page 3

        private bool _finished;

        public bool Finished
        {
            get { return _finished; }
            set 
            { 
                _finished = value;
                OnPropertyChanged("Finished");
            }
        }

        private ICommand _saveCommand;

        public ICommand SaveCommand
        {
            get 
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new Command(() =>
                    {
                        UserInfo.Name = _name;
                        UserInfo.EngName = _engName;
                        this.Finished = true;
                    });
                }
                return _saveCommand; 
            }
        }

        #endregion
    }
}
