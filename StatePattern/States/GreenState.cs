using StatePattern.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatePattern.States
{
    public class GreenState : IColorState
    {
        public LightColors Color
        {
            get
            {
                return LightColors.Green;
            }
        }
    }
}
