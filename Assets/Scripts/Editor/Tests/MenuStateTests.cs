using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using Menu;

public class MenuStateTests {

    bool eventCatched = false;

    [SetUp]
    public void SetUp()
    {
        GameObject go = new GameObject();
        go.AddComponent<EventManager>();     
    }

	[Test]
	public void SetStateTest()
    {
        
        MenuState.SetState(State.MainMenu);
        Assert.IsTrue(MenuState.CurrentIs(State.MainMenu));
    }

    [Test]
    public void PreviousStateTest()
    {
        MenuState.SetState(State.MainMenu);
        Assert.IsTrue(MenuState.CurrentIs(State.MainMenu));
        MenuState.SetState(State.Game);
        Assert.IsTrue(MenuState.CurrentIs(State.Game));
        Assert.IsTrue(MenuState.Previous == State.MainMenu);
    }
}
