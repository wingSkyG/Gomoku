using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Managers
{
    public class InputManager : BaseSingleton<InputManager>
    {
        public Vector2 MouseValue;
        
        private InputControls _inputControls;
        private InputAction _clickMouseLeft;

        public InputManager()
        {
            _inputControls = new InputControls();
            _inputControls.Enable();
            
            _clickMouseLeft = _inputControls.UI.Click;
        }

        public void Init()
        {
            _clickMouseLeft.performed += OnMouseLeftClick;
        }

        public void Update()
        {
            MouseValue = Mouse.current.position.ReadValue();
            Debug.Log(MouseValue);
        }
        
        private void OnMouseLeftClick(InputAction.CallbackContext callbackContext)
        {
            // EventManager.Instance.Dispatch(EventName.ClickMouse);
            EventManager.Instance.Dispatch<Vector2>(EventName.ClickMouse, MouseValue);
        }

        ~InputManager()
        {
            _inputControls.Disable();
        }
    }
}