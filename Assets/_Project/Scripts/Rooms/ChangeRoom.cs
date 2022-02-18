using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeRoom : MonoBehaviour
{
    [SerializeField] RoomData roomData;

    //Add transition stuff here
    void OnTriggerEnter(Collider other)
    {
        ChangeScene(roomData.SceneName);
    }

    void ChangeScene(string sceneName) => SceneManager.LoadScene(sceneName);
}