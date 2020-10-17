using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerScript : MonoBehaviour
{
    private GameObject player;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player") {
           
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Player") {
            if (Input.GetKey(KeyCode.E) && player.GetComponent<PlayerScript>().itemInHand == PlayerScript.ItemInHand.COOKED_STEAK) {
                Destroy(other.transform.GetChild(0).gameObject);
                player.GetComponent<PlayerScript>().itemInHand = PlayerScript.ItemInHand.EMPTY;

                StartCoroutine(DeliverFood());                               
            }
        }
    }

    IEnumerator DeliverFood() {
        Debug.Log("Sending Food");
        //Vector3 pos = new Vector3(-25f, transform.position.y, transform.position.z);
        transform.parent.GetComponent<NavMeshAgent>().SetDestination(transform.position + new Vector3(-16f, 0, 0));
        yield return new WaitForSeconds(2);
        Destroy(transform.parent.gameObject);
    }
}
