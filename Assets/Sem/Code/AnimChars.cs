using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.ParticleSystemJobs;
public class AnimChars : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Animator animator;
    public float speed;
    public Transform TestTramsform;
    public ParticleSystem fire;
    public ParticleSystem death;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.destination = TestTramsform.position;
        Invoke("Fire",2f);
    }
    // Update is called once per frame
    void Update()
    {
        speed = navMeshAgent.velocity.magnitude / navMeshAgent.speed;
        animator.SetFloat("Speed", speed);
    }
    public void Fire()
    {
        Debug.Log("Firing");
        fire.Play();
        animator.SetTrigger("Fire");
    }
    public void DeathParticle()
    {
        death.Play();
    }
}
