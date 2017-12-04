namespace TrafficLightApp
{
    public abstract class TrafficLightBase : ITrafficLight
    {
        protected TrafficLightBase()
        {
            StateColor = TrafficColor.None;
        }

        public TrafficColor StateColor { get; set; }

        public abstract void ChangeState();

        public virtual void On()
        {
            StateColor = TrafficColor.Green;
        }

        public virtual void Off()
        {
            StateColor = TrafficColor.None;
        }
    }
}