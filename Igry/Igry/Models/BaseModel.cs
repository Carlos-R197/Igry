using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Igry.Models
{
    public class BaseModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
