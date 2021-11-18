using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class S_MonsterAI_Basic : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Transform _player;

    //Patroling
    [SerializeField] Transform[] _walkPoints;
    private Vector3 _currentWalkPoint;
    private int _currentWalkPointID;
    private Vector3 _distanceToWalkPoint;

    //Attacking
    [SerializeField] private float _distanceFromPlayer;
    [SerializeField] private float _distanceToPush;
    [SerializeField] private float _pushForce;
    [SerializeField] private float _timeBetweenAttacks;
    private bool _alreadyAtatcked;

    //States
    [SerializeField] private float _sightRange;
    private bool _playerInRange;

    private float _attackDelay;

    private void Awake()
    {
        _player = GameObject.Find("Player").transform;
        _currentWalkPoint = _walkPoints[0].position;
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (_attackDelay > 0)
        {
            _attackDelay -= Time.deltaTime;
            return;
        }

        float distance = Vector3.Distance(transform.position, _player.position);
        _playerInRange = distance <= _distanceFromPlayer;

        if(!_playerInRange)
        {
            Patrolling();
        }
        else
        {
            if (distance > _distanceToPush)
                ChasePlayer();
            else
            { 
                _player.GetComponent<Rigidbody>().AddForce((_player.position - transform.position).normalized * _pushForce);
                _attackDelay = _timeBetweenAttacks;
            }
        }
    }

    private void Patrolling()
    {
        _agent.SetDestination(_currentWalkPoint);
        _distanceToWalkPoint = transform.position - _currentWalkPoint;
        
        if(_distanceToWalkPoint.magnitude < 2f)
        {
            SwitchWalkPoint();
        }
    }

    private void SwitchWalkPoint()
    {
        _currentWalkPointID = _currentWalkPointID == 0 ? 1 : 0;
        _currentWalkPoint = _walkPoints[_currentWalkPointID].position;
    }

    private void ChasePlayer()
    {
        _agent.SetDestination(_player.position);
    }
}
