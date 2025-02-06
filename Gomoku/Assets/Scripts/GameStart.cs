using Managers;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class GameStart : MonoBehaviour
{
    private InputControls _inputControls;
    private InputAction _inputAction;
    private UnityEvent _unityEvent = new UnityEvent();

    private void Awake()
    {
        _inputControls = new InputControls();
        _inputAction = _inputControls.UI.Click;
    }

    private void OnEnable()
    {
        _inputControls.Enable();
    }

    private void OnDisable()
    {
        _inputControls.Enable();
    }

    void Start()
    {
        _inputAction.performed += OnClick;
        _unityEvent.AddListener(OnCreatePiece);
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

    private void OnClick(InputAction.CallbackContext context)
    {
        _unityEvent?.Invoke();
    }

    void Update()
    {
        
    }
}
