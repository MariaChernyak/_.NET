using System;

namespace TrafficLightApp
{
    public class TwoColorTrafficLight : TrafficLightBase
    {
        public override void ChangeState()
        {
            switch (StateColor)
            {
                case TrafficColor.None:
                    On();
                    break;
                case TrafficColor.Green:
                    StateColor = TrafficColor.Red;
                    break;
                case TrafficColor.Red:
                    StateColor = TrafficColor.Green;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(StateColor));
            }
        }
    }
}