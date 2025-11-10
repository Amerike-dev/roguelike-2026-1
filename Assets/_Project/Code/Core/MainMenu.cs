using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject menu;
    public GameObject front;
    public void PanelHide()
    {
        front.SetActive(false);
        menu.SetActive(true);
    }
}
