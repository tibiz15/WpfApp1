using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    class UserViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public DateTime? _birthDate;

        private User User = new User();

        //Try to bind directly to the User!!!

        private Visibility _bDayVisibility = Visibility.Hidden;

        private Visibility _fieldsVisibility = Visibility.Hidden;

        public Visibility BDayVisibility
        {
            get { return _bDayVisibility; }
            set
            {
                _bDayVisibility = value;
                OnPropertyChanged("BDayVisibility");
            }
        }

        public Visibility FieldsVisibility
        {
            get { return _fieldsVisibility; }
            set
            {
                _fieldsVisibility = value;
                OnPropertyChanged("FieldsVisibility");
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Age
        {
            get { return "Your age: " + User.Age; }
            set {  }
        }

        public string Zodiac
        {
            get { return "Your zodiac sign: " + User.Zodiac; }
            set { }
        }

        public string ChineseZodiac
        {
            get { return "Your chinese zodiac sign: " + User.ChineseZodiac; }
            set { }
        }

        public DateTime BirthDate
        {
            get { return (DateTime)_birthDate; }
            set
            {
                BDayVisibility = Visibility.Hidden;
                FieldsVisibility = Visibility.Hidden;

                Update(value);
               
            }
        }


        private async void Update(DateTime value)
        {
            await Task.Run(() => UpdateInfo(value));
        }

        internal void UpdateInfo(DateTime value)
        {

            
            User.BirthDate = value;

            if (User.ValidDate)
            {
                
                _birthDate = value;

                OnPropertyChanged("Age");
                OnPropertyChanged("Zodiac");
                OnPropertyChanged("ChineseZodiac");

                FieldsVisibility = Visibility.Visible;
                if (User.isBDay)
                {
                    BDayVisibility = Visibility.Visible;
                }
                
            }
            else
            {
                MessageBox.Show("Invalid date!");
                _birthDate = null;
            }

        }



    }
}
