
using UnityEngine;



public class MetaorScript : MonoBehaviour
{
   
    
    public float timer,distance;
    [SerializeField] private ParticleSystem effects;
    [SerializeField] private Rigidbody _rigidbody;
    private bool zeminde = false;
    public int randomIndex=0;

    public GameObject player,metaor;
    public GameObject[] spawnPos;
    
    // Start is called before the first frame update
    void Start()
    {
        effects = GetComponent<ParticleSystem>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;
        if (timer > 1f)
        {
            randomIndex = Random.Range(0, spawnPos.Length);
            timer = 0;
        }
        
        distance = player.transform.position.z - spawnPos[randomIndex].transform.position.z;
        if (distance  > 30f)
        {
            Instantiate(metaor, new Vector3(spawnPos[randomIndex].transform.position.x,spawnPos[randomIndex].transform.position.y,spawnPos[randomIndex].transform.position.z), Quaternion.identity);
            spawnPos[randomIndex].transform.position = new Vector3(spawnPos[randomIndex].transform.position.x, 59f, this.player.transform.position.z + 60f);
            
        }
        
        
    }
    private void OnCollisionEnter(Collision other)
    {
        
    }

    
}
