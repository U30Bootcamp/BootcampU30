using UnityEngine;

public class CollectibleObjectEffect : MonoBehaviour
{
    [SerializeField] private Transform icon;
    [SerializeField] private float animationSpeed;
    
    private bool _isMoving;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.GetComponent<Collider>().enabled = false;
            _isMoving = true;
            Destroy(gameObject, 2f);
        }
    }

    private void Update()
    {
        if (_isMoving)
        {
            transform.position = Vector3.Lerp(transform.position, icon.position, animationSpeed * Time.deltaTime);
        }
    }
}
