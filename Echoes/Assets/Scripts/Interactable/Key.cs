using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject interactUI;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        GameObject parentUI = GameObject.Find("UI");
        interactUI = parentUI.transform.GetChild(0).gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            interactUI.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            interactUI.SetActive(false);
            player.GetComponent<S_PlayerMovement>()._hasKey = true;
            Destroy(gameObject);
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
