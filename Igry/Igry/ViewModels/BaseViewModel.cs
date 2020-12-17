using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Igry.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
