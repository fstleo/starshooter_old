using System.Collections.Generic;

namespace Menu
{
    internal static class MenuStateFabric
    {

        private static Dictionary<State, MenuState> states = new Dictionary<State, MenuState>();

        public static MenuState GetState(State state)
        {
            if (states.ContainsKey(state))
            {
                return states[state];
            }
            else
            {
                MenuState m = new MenuState(state);
                states.Add(state, m);
                return m;
            }
        }
    }
}