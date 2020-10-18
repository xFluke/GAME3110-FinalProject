using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class CustomerScript : MonoBehaviour
{
    private GameObject player;
    public bool foodReq;
    public GameObject steak;
    private NavMeshAgent nma;
    public GameObject delObj;
    // Start is called before the first frame update
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        nma = GetComponent<NavMeshAgent>();
        
        InvokeRepeating("CheckDistance", 0.5f,0.5f);
    }

    // Update is called once per frame
    void Update() {
      //  Debug.Log(nma.remainingDistance);
       
        if (foodReq == true)
        FoodRequest();
    }
    void CheckDistance()
    {
        if (nma.remainingDistance < 0.5f)
        {
            foodReq = true;
            CancelInvoke("CheckDistance");
        }
       
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
        transform.GetComponent<NavMeshAgent>().SetDestination(transform.position + new Vector3(-16f, 0, 0));
        yield return new WaitForSeconds(2);
        Destroy(transform.gameObject);
    }

   void FoodRequest()
    {
       
        Instantiate(steak, new Vector3(transform.position.x, transform.position.y + 2 , transform.position.z),Quaternion.identity);
        foodReq = false;
        Debug.Log("requesting food");
        
    }
}
