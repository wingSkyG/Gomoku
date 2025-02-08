using GameLogic.Board;
using Managers;
using UnityEngine;
using Object = System.Object;

public class GameStart : MonoBehaviour
{
    private void Awake()
    {
        InputManager.Instance.Init();
    }

    private void Start()
    {
        EventManager.Instance.AddListener(EventName.ClickMouse, OnCreatePiece);

        BoardCtrl boardCtrl = new BoardCtrl();
    }

    private void Update()
    {
        InputManager.Instance.Update();
    }

    private void OnCreatePiece(Vector2 createPosition)
    {
        GameObject obj;
        obj = AssetManager.Instance.LoadAsset<GameObject>("Assets/Resources_moved/Prefabs/BlackPiece.prefab");
        obj = Instantiate(obj, UIManager.Instance.GetUI("Board"));
        obj.transform.position = createPosition;
    }
}
