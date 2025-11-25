using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class BlessingController : MonoBehaviour
{
    public PlayerController playerController;
    public Canvas canvasBlessing;
    public Canvas canvasEnter;
    
    [Header("BUttons and TMP")]
    public Button[] buttons = new Button[3];
    public TextMeshProUGUI[] texts = new TextMeshProUGUI[3];
    
    private bool isInTrigger = false;
    private List<Blessing> allBlessings = new List<Blessing>();
    private Blessing[] currentOptions = new Blessing[3];

    private void Awake()
    {
        InitializeBlessings();
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i;
            buttons[i].onClick.RemoveAllListeners();
            buttons[i].onClick.AddListener(() => SelectBlessing(index));
        }
    }

    private void Start()
    {
        canvasBlessing.enabled = false;
        canvasEnter.enabled = false;
    }

    private void Update()
    {
        if (isInTrigger && Input.GetButtonDown("Submit_Tec"))
        {
            if (!canvasBlessing.enabled)
            {
                if (playerController != null) playerController.enabled = false;
                
                SelectRandomBlessings();
                canvasBlessing.enabled = true;
                canvasEnter.enabled = false;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            isInTrigger = true;
            canvasEnter.enabled = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            isInTrigger = false;
            canvasEnter.enabled = false;
        }
    }
    
    private void InitializeBlessings()
    {
        allBlessings.Add(new Blessing("Blessing 1", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", TypeBlessing.Speed, 4));
        allBlessings.Add(new Blessing("Blessing 2", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", TypeBlessing.Humidity, 4));
        allBlessings.Add(new Blessing("Blessing 3", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", TypeBlessing.Speed, 4));
        allBlessings.Add(new Blessing("Blessing 4", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", TypeBlessing.Humidity, 4));
        allBlessings.Add(new Blessing("Blessing 5", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", TypeBlessing.Speed, 4));
        allBlessings.Add(new Blessing("Blessing 6", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", TypeBlessing.Humidity, 4));
        
    }

    private void SelectRandomBlessings()
    {
        currentOptions = new Blessing[3];
        if (allBlessings.Count < 3) return;
        
        HashSet<int> selectedIndexes = new HashSet<int>();
        while (selectedIndexes.Count < 3)
        {
            selectedIndexes.Add(UnityEngine.Random.Range(0, allBlessings.Count));
        }

        int i = 0;
        foreach (int index in selectedIndexes)
        {
            currentOptions[i] = allBlessings[index];
            if (texts[i] != null) texts[i].text = currentOptions[i].ToString();
            i++;
        }
    }

    public void SelectBlessing(int index)
    {
        if (index >= 0 && index < currentOptions.Length && currentOptions[index] != null)
        {
            Blessing selected = currentOptions[index];
            
            if (playerController != null && playerController.player != null) playerController.player.ApplyBlessing(selected);

            canvasBlessing.enabled = false;
            canvasEnter.enabled = true;
            if (playerController != null) playerController.enabled = true;
        }
    }
}
