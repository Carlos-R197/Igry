using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Igry.Objects
{
    public class BaseObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
