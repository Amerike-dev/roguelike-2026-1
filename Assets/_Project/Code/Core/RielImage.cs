using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RielImage : MonoBehaviour
{
    public SceneManager sceneManager;
    public Sprite[] imagenes;
    public Image imagenUI;

    public string scene;
    void Start()
    {
        StartCoroutine(RielChange());
    }

    void Update()
    {
        
    }
    IEnumerator RielChange()
    {
        imagenUI.color = new Color(1, 1, 1, 1);
        imagenUI.sprite = imagenes[0];
        yield return new WaitForSeconds(2f);
        for(int i=1; i < imagenes.Length; i++)
        {
            imagenUI.sprite = imagenes[i];
        }
        sceneManager.LoadScene(scene);
    }
    /*IEnumerator Fade(float inicio, float fin, float duracion)
    {
        float tiempo = 0f;
        while (tiempo < duracion)
        {
            float
        }
    }*/
}
