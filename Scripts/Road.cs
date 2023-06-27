using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public GameObject roads;
    private List<GameObject> clone = new List<GameObject>();
    
    private float distance;
    public float createDistance = 0f;

    private int index=0;
    private int cloneindex = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject newRoad = Instantiate(roads, new Vector3(0, 0, createDistance), roads.transform.rotation);
            clone.Add(newRoad);
            createDistance += 5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(this.gameObject.transform.position, clone[index].transform.position);
        if (distance > 5)
        {
            if (index <2)
            {
                index += 1;
            }
            else
            {
                index = 0;
            }
            clone[cloneindex].transform.position = new Vector3(0, 0, createDistance);
            createDistance += 5f;
            cloneindex = index;

        }
    }
}
