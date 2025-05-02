using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

public class StealthEnemyController : MonoBehaviour
{
    public NavMeshAgent Enemy;
    public Transform Target;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        Enemy = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Enemy.SetDestination(Target.position);

        if (Input.GetKeyDown(KeyCode.W))
        {
            _animator.SetBool(("idleToWalk"), true);
            
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetTrigger("Jump");
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            _animator.SetTrigger("Crouch");
        }
    }
}
