using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NetworkMainMethods : MonoBehaviour
{
    [SerializeField]
    private InputField _inputField;

    public async void OnStartServerButtonDown()
    {
        await RelayManager.Instance.SetupRelay();
        SceneManager.sceneLoaded += StartHost;
        SceneManager.LoadScene("LoadingScene");
    }

    private void StartHost(Scene loadedScene, LoadSceneMode loadSceneMode)
    {
        NetworkManager.Singleton.StartHost();
        NetworkManager.Singleton.SceneManager.LoadScene("Map_2", LoadSceneMode.Single);
        SceneManager.sceneLoaded -= StartHost;
    }

    public async void OnJoinToServerButtonDown()
    {
        await RelayManager.Instance.JoinRelay(_inputField.text);
        SceneManager.sceneLoaded += StartClient;
        SceneManager.LoadScene("Map_2");
    }

    private void StartClient(Scene loadedScene, LoadSceneMode loadSceneMode)
    {
        NetworkManager.Singleton.StartClient();
    }
}
