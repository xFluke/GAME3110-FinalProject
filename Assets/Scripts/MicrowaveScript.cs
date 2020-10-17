using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrowaveScript : MonoBehaviour
{
    private GameObject player;
    private bool foodInside = false;
    private bool foodCooking = false;

    [SerializeField]
    private GameObject cookedSteakPrefab;
    [SerializeField]
    private GameObject emptyMicrowave;
    [SerializeField]
    private GameObject fullMicrowave;

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
        if (other.gameObject.tag == "Player" && !foodInside) {
            gameObject.GetComponentInParent<Animator>().SetBool("playerInRange", true);
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player" && !foodInside) {
            gameObject.GetComponentInParent<Animator>().SetBool("playerInRange", false);
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Player") {
            
            // Microwaving with raw steak in hand
            if (Input.GetKey(KeyCode.E) && player.GetComponent<PlayerScript>().itemInHand == PlayerScript.ItemInHand.RAW_STEAK && !foodCooking) {

                Destroy(other.transform.GetChild(0).gameObject);
                foodInside = true;
                foodCooking = true;
                player.GetComponent<PlayerScript>().itemInHand = PlayerScript.ItemInHand.EMPTY;

                gameObject.GetComponentInParent<Animator>().SetBool("playerInRange", false);

                emptyMicrowave.SetActive(false);
                fullMicrowave.SetActive(true);

                StartCoroutine(MicrowaveFood());
            }

            // Taking cooked steak out
            if (Input.GetKey(KeyCode.E) && foodInside && player.GetComponent<PlayerScript>().itemInHand == PlayerScript.ItemInHand.EMPTY && !foodCooking) {            
                GameObject steak = transform.parent.Find("FoodSpawn").GetChild(0).gameObject;

                steak.transform.SetParent(player.transform);
                steak.transform.SetPositionAndRotation(player.transform.position + new Vector3(0, 1.1f, 0), Quaternion.identity);

                foodInside = false;

                player.GetComponent<PlayerScript>().itemInHand = PlayerScript.ItemInHand.COOKED_STEAK;
            }

        }
    }

    IEnumerator MicrowaveFood() {
        yield return new WaitForSeconds(3f);
        gameObject.GetComponentInParent<Animator>().SetBool("playerInRange", true);

        emptyMicrowave.SetActive(true);
        fullMicrowave.SetActive(false);

        GameObject steak = Instantiate(cookedSteakPrefab);
        steak.transform.localScale = new Vector3(8, 8, 8);
        steak.transform.SetParent(transform.parent.Find("FoodSpawn"));
        steak.transform.SetPositionAndRotation(steak.transform.parent.position, Quaternion.identity);

        foodCooking = false;
    }
}
