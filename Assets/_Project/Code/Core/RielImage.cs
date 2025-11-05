using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RielImage : MonoBehaviour
{
    public SceneManager sceneManager;
    public GameObject back;
    public GameObject back1;
    public GameObject logo;
    public Sprite[] imagenes;
    public Image imagenUI;
    public CanvasGroup canGroup;
    public float fadeTime=1f;
    private float contador = 0f;
    public bool activado = false;

    public string scene;
    void Start()
    {
        canGroup = GetComponent<CanvasGroup>();
        if (canGroup == null)
        {
            canGroup = logo.AddComponent<CanvasGroup>();
        }
        canGroup.alpha = 0f;
        StartCoroutine(Logo());
    }
    void Update()
    {
        FadeLogo();
    }
    //Riel
    IEnumerator RielChange()
    {
        back.SetActive(true);
        yield return new WaitForSeconds(2f);
        back.SetActive(false);
        for(int i=0; i < imagenes.Length; i++)
        {
            imagenUI.sprite = imagenes[i];
            yield return new WaitForSeconds(2f);
        }
        sceneManager.LoadScene(scene);
    }
    IEnumerator Logo()
    {
        back1.SetActive(true);
        back.SetActive(false);
        yield return new WaitForSeconds(5f);
        StartCoroutine(RielChange());
    }
    //Fade
    public void FadeLogo()
    {
        contador += Time.deltaTime;
        if (contador >= 0.5f && !activado)
        {
            activado = true;
            StartCoroutine(FadeTransicion());
        }
    }
    IEnumerator FadeTransicion()
    {
        float time = 0f;
        while (time < 1.5f)
        {
            canGroup.alpha = Mathf.Lerp(0f, 1f, time / 2f);
            time += Time.deltaTime;
            yield return null;
        }
        canGroup.alpha = 1f;
        back1.SetActive(false);
        yield return new WaitForSeconds(2f);
        time = 0f;
        while (time < 1.5f)
        {
            canGroup.alpha= Mathf.Lerp(1f, 0f,time/2f);
            time += Time.deltaTime;
            yield return null;
        }
        canGroup.alpha = 0f;
    }
}
