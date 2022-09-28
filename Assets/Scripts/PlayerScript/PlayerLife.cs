using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerLife : MonoBehaviourPun
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision) { 
        if (collision.gameObject.CompareTag("Trap")) {
            Die();
        }
    }

    private void Die() {
        anim.SetTrigger("death");
    }

    private void Respawn() {
        transform.position = new Vector3(0f, 5f, 0f);
        anim.SetTrigger("respawn");
    }

}
