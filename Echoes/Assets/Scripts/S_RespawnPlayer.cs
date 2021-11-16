using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_RespawnPlayer : MonoBehaviour
{
    [SerializeField] private Transform _spawnPointTransform;

    public void RespawnPlayer(GameObject pCharacter)
    {
        pCharacter.transform.position = _spawnPointTransform.position;
    }
}
