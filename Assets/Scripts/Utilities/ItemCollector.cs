using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//code is not longer needed in a separate file
//keeping file in case it is needed later
public class ItemCollector : MonoBehaviour
{
    private int carrots = 0;

    public int GetCarrots {
        get {
            return carrots;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Carrot")) {
            Destroy(collision.gameObject);
            carrots++;
        }
    }
}
