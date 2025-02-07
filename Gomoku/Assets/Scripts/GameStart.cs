using System;
using Managers;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class GameStart : MonoBehaviour
{
    private void Awake()
    {
        InputManager.Instance.Init();
    }

    private void Start()
    {
        EventManager.Instance.AddListener(EventName.ClickMouse, OnCreatePiece);
    }

    private void OnCreatePiece()
    {
        StartCoroutine(AssetManager.Instance.LoadAssetAsync<GameObject>("Prefabs/BlackPiece", InstantiatePiece));
    }

    private void InstantiatePiece(GameObject obj)
    {
        Instantiate(obj, UIManager.Instance.GetUI("Board")).SetActive(true);
    }
}
