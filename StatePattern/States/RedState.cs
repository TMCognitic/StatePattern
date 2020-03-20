using StatePattern.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatePattern.States
{
    public class RedState : IColorState
    {
        public LightColors Color
        {
            get
            {
                return LightColors.Red;
            }
        }
    }
}
