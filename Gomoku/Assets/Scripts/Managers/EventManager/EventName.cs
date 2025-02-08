using UnityEngine;
using UnityEngine.Events;

namespace Managers
{
    public static class EventName
    {
        // public static UnityEvent ClickMouse = new UnityEvent();
        public static UnityEvent<Vector2> ClickMouse = new UnityEvent<Vector2>();
    }
}