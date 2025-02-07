using Managers;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class GameStart : MonoBehaviour
{
    private void Start()
    {
        InputManager.Instance._clickAction.performed += OnMouseLeftClick;

        EventManager.Instance.AddListener(EventName.ClickMouse, OnCreatePiece);
    }

    private void OnCreatePiece()
    {
        Debug.Log("OnCreatePiece");
        StartCoroutine(AssetManager.Instance.LoadAssetAsync<GameObject>("Prefabs/BlackPiece", InstantiateObj));
    }

    private void InstantiateObj(GameObject obj)
    {
        Instantiate(obj, UIManager.Instance.GetUI("Board")).SetActive(true);
    }

    private void OnMouseLeftClick(InputAction.CallbackContext context)
    {
        EventManager.Instance.Dispatch(EventName.ClickMouse);
    }
}
