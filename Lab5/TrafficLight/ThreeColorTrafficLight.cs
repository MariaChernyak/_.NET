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
                    StateColor = PreviewColor == TrafficColor.Red ? TrafficColor.Green : TrafficColor.Red;
                    PreviewColor = StateColor;
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
