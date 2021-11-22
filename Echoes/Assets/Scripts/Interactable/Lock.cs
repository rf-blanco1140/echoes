using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject interactUI;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject doorLock;
    [SerializeField] bool lastDoor =false;
    AudioManager audioManager;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        GameObject parentUI = GameObject.Find("UI");
        interactUI = parentUI.transform.GetChild(0).gameObject;
        pauseMenu = parentUI.transform.GetChild(1).gameObject;
        doorLock = gameObject.transform.GetChild(0).gameObject;
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            interactUI.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E) && player.GetComponent<S_PlayerMovement>()._hasKey ==true)
        {
            interactUI.SetActive(false);
            audioManager.PlaySound("UnlockDoor");
            if(lastDoor)
            {
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
            }
            else { Destroy(doorLock); }
        }
        if(other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E) && player.GetComponent<S_PlayerMovement>()._hasKey == false)
        {
            interactUI.SetActive(false);
            audioManager.PlaySound("DoorLocked");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            interactUI.SetActive(false);
        }
    }
}
