using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviourPun
{
    private Animator anim;

    private bool timerRunning = false;
    private float timeRemaining = 3f;

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
        timerRunning = true;
        timeRemaining = 1f;
        RunTimer();
    }

    private void RunTimer() {
        if (timerRunning) {
            if (timeRemaining > 0) {
                timeRemaining -= Time.deltaTime;
            }
            else {
                timeRemaining = 0;
                timerRunning = false;
                Respawn();
            }
        }
    }

    private void Respawn() {
        Scene scene = SceneManager.GetActiveScene();
        //Different game scenes will have different spawn locations
        if (scene.name == "Forest") {
            transform.position = new Vector3(0f, 5f, 0f);
        }
        if (scene.name == "City") {
            transform.position = new Vector3(-96f, 3f, -25f);
        }
        anim.SetTrigger("respawn");
    }

}
