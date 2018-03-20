namespace Menu
{
    public class MenuState
    {
        public static State Previous
        { get; protected set; }
        public static State Current
        { get; protected set; }

        public static void SetState(State state)
        {
            MenuStateFabric.GetState(state).Enable();
        }

        public static bool CurrentIs(State state)
        {
            return (Current == state);
        }

        public State Value
        { get; private set; }

        public MenuState(State state)
        {
            Value = state;
        }

        public virtual void Enable()
        {
            Previous = Current;
            Current = Value;
            EventManager.Instance.QueueEvent(new MenuChangeStateEventData(Value));
        }
    }
}