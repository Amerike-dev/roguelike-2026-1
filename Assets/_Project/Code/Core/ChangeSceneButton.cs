using UnityEngine;

public class ChangeSceneButton : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        SceneManager.Instance.LoadScene(sceneName);
    }
}
