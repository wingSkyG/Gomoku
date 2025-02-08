using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Object = UnityEngine.Object;

namespace Managers
{
    public class AssetManager : BaseSingleton<AssetManager>
    {
        public T LoadAsset<T>(string path) where T : Object
        {
            if (string.IsNullOrEmpty(path))
            {
                Debug.LogError("路径不能为空！");
                return null;
            }

            var opHandle = Addressables.LoadAssetAsync<T>(path);
            var asset = opHandle.WaitForCompletion();
            if (asset == null)
            {
                Debug.LogError("加载失败" + path);
            }

            return asset;
        }
        
        public IEnumerator LoadAssetAsync<T>(string path, Action<T> callBack) where T : Object
        {
            if (string.IsNullOrEmpty(path))
            {
                Debug.LogError("路径不能为空！");
                yield break;
            }
            
            AsyncOperationHandle<T> opHandle;
            opHandle = Addressables.LoadAssetAsync<T>(path);
            yield return opHandle;

            switch (opHandle.Status)
            {
                case AsyncOperationStatus.Failed:
                    Debug.LogError(opHandle.OperationException);
                    yield break;
                case AsyncOperationStatus.Succeeded:
                    callBack?.Invoke(opHandle.Result);
                    break;
                case AsyncOperationStatus.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}