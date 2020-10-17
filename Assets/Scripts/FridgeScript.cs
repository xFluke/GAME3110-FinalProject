using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeScript : MonoBehaviour
{
    private GameObject player;
    public GameObject steakPrefab;

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

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Player") {
            if (Input.GetKey(KeyCode.E) && player.GetComponent<PlayerScript>().itemInHand == PlayerScript.ItemInHand.EMPTY) {
                Debug.Log("Getting Food");
                
                GameObject steak = Instantiate(steakPrefab, player.transform);
                steak.transform.position += new Vector3(0, 1.1f, 0);
                steak.transform.localScale = new Vector3(8, 8, 8);

                player.GetComponent<PlayerScript>().itemInHand = PlayerScript.ItemInHand.RAW_STEAK;
            }
        }
    }
}
