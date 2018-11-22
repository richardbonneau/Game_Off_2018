


using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    NavMeshAgent agent;
    Animator anim;
    string animName, animNameOld;
    public Transform target;

    void Awake() {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        anim.SetBool("Idle", true);
    }

    void Update() {
        agent.destination = target.position;
        anim.SetBool("Idle", false);
        anim.SetBool("MoveForward", true);
    }
}