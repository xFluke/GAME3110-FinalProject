using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeScript : MonoBehaviour
{
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            gameObject.GetComponentInParent<Animator>().SetBool("playerInRange", true);
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player") {
            gameObject.GetComponentInParent<Animator>().SetBool("playerInRange", false);
        }
    }
}
