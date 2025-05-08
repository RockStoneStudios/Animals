using System.Collections.Generic;
using UnityEngine;

public class PoolObjectQueue : MonoBehaviour
{
    // C#
   
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Queue<GameObject> pool = new Queue<GameObject>();
    [SerializeField] private Transform positionBall;
    private int poolSize= 6;

    void Start()
    {
        AddPool(poolSize);
    }

    private void AddPool(int poolSize){
      for(int i = 0; i< poolSize; i++){
         GameObject ball = Instantiate(ballPrefab,positionBall.position,positionBall.rotation);
         ball.SetActive(false);
         ball.transform.SetParent(positionBall.transform);
         pool.Enqueue(ball); 
      }
    }

    void  SpawnerBall(){
       if(pool.Count > 0){
            GameObject ball = pool.Dequeue();
            ball.transform.position = positionBall.position;
            ball.transform.rotation = positionBall.rotation;
            ball.SetActive(true);
       }else {
         AddPool(1);
         SpawnerBall();
       }


    }
    
    public void ReturnToPool(GameObject ball){
        ball.SetActive(false);
        pool.Enqueue(ball);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            SpawnerBall();
        }
    }
}
