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
    [SerializeField] private float _walkSpeed;

    //Attacking
    [SerializeField] private float _distanceFromPlayerSight;
    [SerializeField] private float _distanceFromPlayerHearing;
    [SerializeField] private float _distanceToPush;
    [SerializeField] private float _pushForce;
    [SerializeField] private float _timeBetweenAttacks;
    [SerializeField] private float _runningSpeed;

    //States
    [SerializeField] private bool _playerInVisualRange;
    [SerializeField] private bool _playerInHearinglRange;


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
        _playerInVisualRange = distance <= _distanceFromPlayerSight;
        _playerInHearinglRange = distance <= _distanceFromPlayerHearing;

        if((_playerInHearinglRange && _player.GetComponent<S_PlayerMovement>().IsRunning()) || (_playerInVisualRange))
        {
            if (distance > _distanceToPush)
                ChasePlayer();
            else
            {
                AttackPlayer();
            }
        }
        else
        {
            Patrolling();
        }
       
    }

    private void Patrolling()
    {
        _agent.speed = _walkSpeed;
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
        _agent.speed = _runningSpeed;
        _agent.SetDestination(_player.position);
    }

    private void AttackPlayer()
    {
        _player.GetComponent<Rigidbody>().AddForce((_player.position - transform.position).normalized * _pushForce);
        _player.GetComponent<S_HpPlayer>().HurtPlayerCharacter();
        _attackDelay = _timeBetweenAttacks;
    }
}
