using System;
using UnityEngine;

public class BlessingController : MonoBehaviour
{
    public PlayerController playerController;
    public Canvas canvasBlessing;
    public Canvas canvasEnter;

    private void Start()
    {
        canvasBlessing.enabled = false;
        canvasEnter.enabled = false;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            canvasEnter.enabled = true;
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                Debug.Log("Ya se abrio");
                playerController.enabled = false;
                canvasBlessing.enabled = true;
            }
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            canvasEnter.enabled = false;
        }
    }
}
