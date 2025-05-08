using UnityEngine;

public class MovementAnimal : MonoBehaviour
{
    // [SerializeField] private Transform limit;
    [SerializeField] private float speedMovement = 5.8f;
    [SerializeField] private Transform offPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offPoint = GameObject.FindWithTag("Limit").transform;
    }


    void FixedUpdate()
    {
        if(transform.position.z > -9.8f) {
            transform.Translate(0,0,1* speedMovement * Time.fixedDeltaTime);
        }
        else if (transform.position.z <= offPoint.position.z){
            gameObject.SetActive(false);
            Debug.Log("GAME OVER !!");
        }
    }
}
