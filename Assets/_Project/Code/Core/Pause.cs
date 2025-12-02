using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public Scene scene;
    public Canvas canvasPause;
    public Canvas canvasMenu;
    public Canvas canvasSettings;

    public void Start()
    {
        canvasPause.enabled = false;
        canvasMenu.enabled = false;
        canvasSettings.enabled = false;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canvasPause.enabled = true;
            Time.timeScale = 0;
        }
    }

    public void CloseMenu()
    {
        canvasPause.enabled = false;
        Time.timeScale = 1;
    }

    public void EnableMenu()
    {
        canvasMenu.enabled = true;
    }

    public void YesMenu()
    {
        SceneManager.Instance.LoadScene("GameMenu");
    }

    public void NoMenu()
    {
        canvasMenu.enabled = false;
    }

    public void Settings()
    {
        canvasSettings.enabled = true;
    }

    public void CloseSettings()
    {
        canvasSettings.enabled = false;
    }
}
