using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{   
    public GameObject placesManager;
    public GameObject[] places;
    UnityEngine.AI.NavMeshAgent agent;
    private int currentTargetPlace = 0;
    // Start is called before the first frame update
    void Start()
    {
        //places = placesManager.GetComponent<PlacesManager>().places;
        agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.SetDestination(places[currentTargetPlace].transform.position);
    }
    // Update is called once per frame
    private int nextPlace(){
        if (currentTargetPlace == ((places.Length)-1))
           currentTargetPlace = 0;
        else 
            ++currentTargetPlace;
        return currentTargetPlace ;
    }
    void LateUpdate()
    {
        if (agent.hasPath || agent.pathPending)
            return;
        agent.SetDestination(places[nextPlace()].transform.position);
        
    }

}
