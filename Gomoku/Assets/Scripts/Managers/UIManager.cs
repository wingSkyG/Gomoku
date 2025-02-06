using UnityEngine;

namespace Managers
{
    public class UIManager : BaseSingleton<UIManager>
    {
        public RectTransform GetUI(string path)
        {
            if (path == null)
            {
                Debug.LogError("路径不能为空！");
                return null;
            }

            return (RectTransform)GameObject.Find(path).transform;
        }
    }
}