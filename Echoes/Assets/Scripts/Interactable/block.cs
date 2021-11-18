using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float actRange;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
    }

    private void Update()
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
    }
}
