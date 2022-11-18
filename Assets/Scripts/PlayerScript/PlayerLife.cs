using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        Scene scene = SceneManager.GetActiveScene();
        //Different game scenes will have different spawn locations
        if (scene.name == "Forest") {
            transform.position = new Vector3(0f, 5f, 0f);
        }
        else if (scene.name == "City") {
            transform.position = new Vector3(-96f, 3f, -25f);
        }
        anim.SetTrigger("respawn");
    }

}
