using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnerBullet : MonoBehaviour
{
    [SerializeField] private Transform playerPosition;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private List<GameObject> poolObjects = new List<GameObject>();
    private PlayerInput playerInput;
    private InputAction atackAction;
    [SerializeField] int poolSize;
    private bool inputReady = false;

    void Start()
    {
        Debug.Log("Script SpawnerBullet");
        playerInput = GetComponent<PlayerInput>();
        atackAction = playerInput.actions["Attack"];
        
        AddToPool(poolSize);
         Invoke(nameof(EnableInput), 0.15f);
        
    }

    void EnableInput(){
        inputReady = true;
    }


    void Update()
    {
        if(inputReady && atackAction.WasPressedThisFrame()){
            
           SpawnBullet();
        }
    }

 
  private void SpawnBullet() {
            GameObject bullet = FirstDesactivate();
            bullet.transform.position = playerPosition.position + new Vector3(0,1.7f,0);
            bullet.SetActive(true);
  }




 private void AddToPool(int poolSize) {
    for(int i = 0; i<poolSize; i++){
        GameObject bullet = Instantiate(bulletPrefab,Vector3.zero,Quaternion.identity);
        
        bullet.SetActive(false);
        poolObjects.Add(bullet);
    }
     Debug.Log(poolObjects);
   }

 private   GameObject FirstDesactivate(){
    for(int i = 0; i< poolObjects.Count; i++){
        if(!poolObjects[i].activeInHierarchy){
           return poolObjects[i];
        }
    }
    AddToPool(1);
    return poolObjects.Last<GameObject>();
 }

}
