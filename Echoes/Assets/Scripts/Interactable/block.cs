using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject interactUI;
    //[SerializeField] float actRange;
    AudioManager audioManager;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        interactUI = GameObject.Find("UI").transform.GetChild(0).gameObject;
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
        if(other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            audioManager.PlaySound("StoneOpen");
            interactUI.SetActive(false);
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

    /*private void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if(Input.GetKeyDown(KeyCode.E) && distance<= actRange)
        {
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, actRange);
    }*/
}
