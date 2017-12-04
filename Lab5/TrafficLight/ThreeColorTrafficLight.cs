using System;

namespace TrafficLightApp
{
    public class ThreeColorTrafficLight : TrafficLightBase
    {
        protected TrafficColor PreviewColor;

        public override void ChangeState()
        {
            switch (StateColor)
            {
                case TrafficColor.Green:
                case TrafficColor.Red:
                    StateColor = TrafficColor.Yellow;
                    break;
                case TrafficColor.Yellow:
                {
                    PreviewColor = PreviewColor == TrafficColor.Red ? TrafficColor.Green : TrafficColor.Red;
                    StateColor = TrafficColor.Red;
                    break;
                }
                case TrafficColor.None:
                    On();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(StateColor));
            }
        }
    }
}