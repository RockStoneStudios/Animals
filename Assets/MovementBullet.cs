using UnityEngine;

public class MovementBullet : MonoBehaviour
{
    [SerializeField] private float speedMovement;
    [SerializeField] private Transform firstPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        firstPoint = GameObject.FindWithTag("Finish").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speedMovement * Time.deltaTime);
        if(transform.position.z >= firstPoint.position.z){
            gameObject.SetActive(false);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Choque con {other.gameObject.name}");
        gameObject.SetActive(false);
        other.gameObject.SetActive(false);
    }
}
