using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy : Damageable
{    
    [SerializeField] private Transform _destination;
    [SerializeField] private AudioSource _hitSFX;
    [SerializeField] private AudioSource _deathSFX;
    private NavMeshAgent NavMeshAgent;
    private int _playerPoints;
    private bool _isActive;
    private float _enemyRange = 40f;
    private float _walkRadius = 10f;
    private float _timer;
    private float _wanderTimer = 3f;
    Vector3 _finalPosition;

    private void Awake()
    {
        NavMeshAgent = GetComponent<NavMeshAgent>();
        _timer = _wanderTimer;
    }

    private void Update()
    {
         
        transform.LookAt(Camera.main.transform.position, Vector3.up); //To have 2D sprite always look at camera

        _playerPoints = PointsManager.TotalPoints;

        switch (_playerPoints)
        {
            case 1:
                _isActive = true;
                break;
            case 4:
                GetComponent<NavMeshAgent>().speed = 5;
                break;
            case 8:
                GetComponent<NavMeshAgent>().speed = 8;
                break;
        }

        if (_isActive)
        {
            ChasePlayer();
        }
    }

    enum EnemyState
    {
        Idle,
        Chasing
    }

    private void ChasePlayer()
    {
        float _distanceToPlayer = Vector3.Distance(_destination.position, this.transform.position);
        EnemyState _enemyState;

        if (_distanceToPlayer < _enemyRange)
        {
            _enemyState = EnemyState.Chasing;
        }
        else
        {
            _enemyState = EnemyState.Idle;
        }

        switch (_enemyState)
        {
            case EnemyState.Idle:
                Roam();
                break;
            case EnemyState.Chasing:
                NavMeshAgent.destination = _destination.position;
                break;
        }

    }

    private void Roam()
    {
        _timer += Time.deltaTime;
        if (_timer >= _wanderTimer)
        {
            Debug.Log("roaming");
            Vector3 _randomDirection = Random.insideUnitSphere * _walkRadius;
            _randomDirection += transform.position;
            NavMeshHit _hit;
            NavMesh.SamplePosition(_randomDirection, out _hit, _walkRadius, 1);
            _finalPosition = _hit.position;
            _timer = 0;
        }

        NavMeshAgent.destination = _finalPosition;

    }

    public override void TakeDamage(float damage, Vector3 hitPos, Vector3 hitNormal)
    {
        if (!_hitSFX.isPlaying)
        {
            _hitSFX.Play();
        }
        
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            _deathSFX.Play();
            Die();
            PointsManager.TotalPoints++;
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("Death");
        }

    }

}
