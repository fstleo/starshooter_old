using UnityEngine;

namespace Menu
{

    public abstract class MenuStateView : MonoBehaviour
    {

        [SerializeField]
        State stateType;

        protected MenuState menuState;

        private GameObject go;

        protected virtual void Awake()
        {
            go = gameObject;
        }

        protected virtual void Start()
        {
            menuState = MenuStateFabric.GetState(stateType);
            EventManager.Instance.AddListener<MenuChangeStateEventData>(OnStateChange);
            if (MenuState.CurrentIs(stateType))
                Show();
            else
                Hide();
            
        }

        protected virtual void OnDestroy()
        {
            if (EventManager.Instance != null)
                EventManager.Instance.RemoveListener<MenuChangeStateEventData>(OnStateChange);
        }

        protected virtual void HandleBackEvent(BackEvent ev)
        {
            ReturnToPrevious();
        }

        public virtual void Show()
        {
            go.SetActive(true);
            EventManager.Instance.AddListener<BackEvent>(HandleBackEvent);
        }

        public virtual void Hide()
        {
            go.SetActive(false);
            EventManager.Instance.RemoveListener<BackEvent>(HandleBackEvent);
        }

        protected void OnStateChange(MenuChangeStateEventData data)
        {
            if (data.state == stateType)
            {
                Show();
            }
            else if (go.activeSelf)
            {
                Hide();
            }
        }

        protected void SetState(State state)
        {
            MenuState.SetState(state);
        }

        protected void ReturnToPrevious()
        {
            MenuState.SetState(MenuState.Previous);
        }
    }
}