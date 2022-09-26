using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(menuName = "Singletons/MasterManager")]
public class MasterManager : SingletonScriptableObject<MasterManager>
{
    [SerializeField]
    private GameSettings _gameSettings;
    public static GameSettings GameSettings { get { return Instance._gameSettings; } }
    /*[SerializeField]
    private List<NetworkPrefab> _networkedPrefabs = new List<NetworkPrefab>();

    public static GameObject NetworkInstantiate(GameObject obj, Vector3 position, Quaternion rotation)
    {
        
        foreach (NetworkPrefab networkPrefab in Instance._networkedPrefabs)
        {
            if (networkPrefab.Prefab == obj)
            {
                GameObject result = PhotonNetwork.Instantiate(networkPrefab.Path, position, rotation);
                return result;

            }
            else
            {
                Debug.LogError("Path is empty for gameObject name" + networkPrefab.Prefab);
                return null;
            }
        }
        
        return null;
    }

    
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void PopulateNetworkedPrefabs()
    {
#if UNITY_EDITOR
        Instance._networkedPrefabs.Clear();

        GameObject[] results = Resources.LoadAll<GameObject>("");
        Debug.Log($"results: {results.Length}");
        for (int i = 0; i < results.Length; i++)
        {
            if (results[i].GetComponent<PhotonView>() != null)
            {
                string path = AssetDatabase.GetAssetPath(results[i]);
                Instance._networkedPrefabs.Add(new NetworkPrefab(results[i], path));
            }
        }


#endif
    }
    */

}
