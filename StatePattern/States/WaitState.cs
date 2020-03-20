using StatePattern.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.States
{
    public class WaitState : IColorState, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private LightColors _color;

        public LightColors Color
        {
            get
            {
                return _color;
            }
            private set
            {
                if(_color != value)
                {
                    _color = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Color)));
                }
            }
        }

        public WaitState()
        {
            Task t = new Task(() =>
            {
                bool light = false;
                while (true)
                {
                    Color = (light = !light) ? LightColors.Orange : LightColors.None;
                    Task.Delay(2000).Wait();
                }
            });

            t.Start();
        }
        
    }
}
