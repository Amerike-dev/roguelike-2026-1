using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_G : MonoBehaviour
{
    public CanvasGroup deathPanel;
    public GameObject deathUI;

    public void Start()
    {
        deathPanel.alpha = 0f;
        deathUI.SetActive(false);
    }
    public void DeathUI()
    {
        StartCoroutine(DeathFade());
    }
    IEnumerator DeathFade()
    {
        float time = 0f;
        while (time < 1.5f)
        {
            deathPanel.alpha = Mathf.Lerp(0f, 1f, time / 2f);
            time += Time.deltaTime;
            yield return null;
        }
        deathPanel.alpha = 1f;
        yield return new WaitForSeconds(1f);
        deathUI.SetActive(true);
    }
}
