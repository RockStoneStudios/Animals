using UnityEngine;

public class Wall : MonoBehaviour
{

    [SerializeField] private PoolObjectQueue ball;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Respawn")) {
        
        
          ball.ReturnToPool(other.gameObject);

  
        }
    }
}
