using StatePattern.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatePattern.States
{
    public class OrangeState : IColorState
    {
        public LightColors Color
        {
            get
            {
                return LightColors.Orange;
            }
        }
    }
}
