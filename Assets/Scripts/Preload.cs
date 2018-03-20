using UnityEngine.SceneManagement;
using UnityEngine;

public class Preload : MonoBehaviour {

    private void Start()
    {
        Menu.MenuState.SetState(Menu.State.MainMenu);
        SceneManager.LoadSceneAsync(1);
    }

}
