using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public GameObject customerSpawnPoint;
    public GameObject customerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnCustomer", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnCustomer() {
        GameObject customer = Instantiate(customerPrefab, customerSpawnPoint.transform.position, Quaternion.identity);
        customer.GetComponent<NavMeshAgent>().SetDestination(new Vector3(-9f, 1.5f, 0.8f));
    }
}
