using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.Events;

namespace Managers
{
    public class EventManager : BaseSingleton<EventManager>
    {
        // private Dictionary<UnityEvent, UnityAction> _eventDic = new Dictionary<UnityEvent, UnityAction>();
        
        public void AddListener(UnityEvent eventName, UnityAction listener)
        {
            eventName.AddListener(listener);
            // _eventDic.Add(eventName, listener);
        }
        
        // public void AddListener(string eventName, UnityAction listener)
        // {
        //     UnityEvent eventName = new UnityEvent();
        //     _eventDic.Add(eventName, listener);
        // }

        public void Dispatch(UnityEvent eventName)
        {
            eventName?.Invoke();
        }
    }
}