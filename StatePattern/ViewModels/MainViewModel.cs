using StatePattern.Commands;
using StatePattern.Models;
using StatePattern.States;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StatePattern.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private Dictionary<LightColors, IColorState> _states;

        private RelayCommand _callCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        private IColorState _state;
        private bool _isActive;

        public IColorState State
        {
            get
            {
                return _state;
            }

            set
            {                
                if (_state != value)
                {
                    _state = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(State)));
                    CallCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                if (_isActive != value)
                {
                    _isActive = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(State)));
                    CallCommand.RaiseCanExecuteChanged();

                    if (value)
                        State = _states[LightColors.Green];
                    else
                        State = _states[LightColors.None];
                }
            }
        }

        public MainViewModel()
        {
            
            _states = new Dictionary<LightColors, IColorState>()
            { 
                [LightColors.Green] = new GreenState(),
                [LightColors.None] = new WaitState(),
                [LightColors.Orange] = new OrangeState(),
                [LightColors.Red] = new RedState(),
            };
            IsActive = true;            
        }

        public RelayCommand CallCommand
        {
            get
            {
                return _callCommand ??= new RelayCommand(Call, CanCall);
            }
        }

        private bool CanCall()
        {
            return IsActive && State == _states[LightColors.Green];
        }

        private async void Call()
        {
            State = _states[LightColors.Orange];
            await Task.Delay(3000);
            
            if(IsActive)
            {
                State = _states[LightColors.Red];
                await Task.Delay(10000);
            }

            if (IsActive)
            {
                State = _states[LightColors.Green];
            }            
        }
    }
}
