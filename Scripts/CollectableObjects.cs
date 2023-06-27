using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObjects : MonoBehaviour
{
    public float distance,timer;
    public GameObject[] collectables,spawnPos;
    public int randNumber,randomIndex,randPos;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        randomIndex = Random.Range(0, collectables.Length);
    }

    // Update is called once per frame
    void Update()
    {
        
            timer += Time.deltaTime;
            if (timer > 0.75f)
            {
                randomIndex = Random.Range(0, collectables.Length);
                timer = 0;
            }
            randPos = Random.Range(0, 2);
            randNumber = Random.Range(-250, -100);
            distance = player.transform.position.z - collectables[randomIndex].transform.position.z;
            if (distance  > 5f)
            {
                collectables[randomIndex].transform.position = new Vector3(spawnPos[randPos].transform.position.x, 0.27f, this.player.transform.position.z + 5f);
            
            }
        }
    
}
