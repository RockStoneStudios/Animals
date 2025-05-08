using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class SpawnerBala : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;
    [SerializeField] private List<GameObject> pooledBalls = new List<GameObject>();
    [SerializeField] private Transform positionBalls;
  
    int poolSize = 5;


    void Start()
    {
      
        AddPool(poolSize);
    }

    void AddPool(int poolSize){
        for(int i = 0; i < poolSize; i++){
           GameObject ball = Instantiate(ballPrefab,positionBalls.position,positionBalls.rotation);
           ball.transform.SetParent(positionBalls.transform);
           ball.SetActive(false);
           pooledBalls.Add(ball);
        }
    }

    void SpawnerBall() {
        GameObject ball = FirstDesactivate();
        if(ball != null){
            ball.transform.position = positionBalls.position;
            ball.transform.rotation = positionBalls.rotation;
            ball.SetActive(true);
        }
    }


   private  GameObject FirstDesactivate() {
        for (int i = 0; i< pooledBalls.Count; i++){
            if(!pooledBalls[i].activeInHierarchy){
                return pooledBalls[i];
            }
        }

        AddPool(1);
        return pooledBalls.Last<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            SpawnerBall();
        }
    }
}
