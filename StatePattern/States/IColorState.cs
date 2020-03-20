using StatePattern.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatePattern.States
{
    public interface IColorState
    {
        LightColors Color { get; }
    }
}
