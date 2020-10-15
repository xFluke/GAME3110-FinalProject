using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public GameObject customerSpawnPoint;
    public GameObject customerPrefab;
    public List<GameObject> customerList;

    // Start is called before the first frame update
    void Start()
    {
        //Invoke("SpawnCustomer", 5f);
        InvokeRepeating("SpawnCustomer", 5f,5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnCustomer() {
        GameObject customer = Instantiate(customerPrefab, customerSpawnPoint.transform.position, Quaternion.identity);
        customerList.Add(customer);
        if(customerList.Count <= 1)
        customer.GetComponent<NavMeshAgent>().SetDestination(new Vector3(-9f, 1.5f, 0.8f));
        else
        for(int i = 1; i < customerList.Count; i++)
            {
                customerList[i].GetComponent<NavMeshAgent>().SetDestination(new Vector3(-9f , 1.5f, (0.8f + i)));   
            }
    }

}
