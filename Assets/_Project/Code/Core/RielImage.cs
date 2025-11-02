using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RielImage : MonoBehaviour
{
    public SceneManager sceneManager;
    public GameObject back;
    public GameObject logo;
    public Sprite[] imagenes;
    public Image imagenUI;

    public string scene;
    void Start()
    {
        StartCoroutine(Logo());
    }
    IEnumerator RielChange()
    {
        logo.SetActive(false);
        back.SetActive(true);
        yield return new WaitForSeconds(2f);
        back.SetActive(false);
        
        for(int i=0; i < imagenes.Length; i++)
        {
            imagenUI.sprite = imagenes[i];
            Debug.Log("Hola");
            yield return new WaitForSeconds(2f);
        }
        sceneManager.LoadScene(scene);
    }
    IEnumerator Logo()
    {
        back.SetActive(false);
        logo.SetActive(true);
        yield return new WaitForSeconds(2f);
        StartCoroutine(RielChange());
    }
}
