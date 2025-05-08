
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnerAnimal : MonoBehaviour
{
    
    
    public Transform[] spawnPoints;

   
    [SerializeField] private GameObject[] animalsPrefab;
    private float initialDelay = 1.1f;
    private float spawnInterval = 1.3f;
   
    public int poolSize;

    // Referencia al sistema de entradas de Unity (Input System)
    // public InputActionAsset inputs;

    // Lista que almacena los animales instanciados (usados y no usados)
    [SerializeField] List<GameObject> pooledObjects = new List<GameObject>();

    void Start()
    {
        // Al iniciar el juego, se llena la piscina con el número inicial de animales
        AddToPool(poolSize);
        InvokeRepeating("SpawnAnimal", initialDelay, spawnInterval);
    }

    private void Update() 
    {
        // Si se presiona cierta acción (inputs.actionMaps[0].actions[5]) durante este cuadro...
        // if(inputs.actionMaps[0].actions[5].WasPressedThisFrame())
       
    }

    void SpawnAnimal() {
          // Selecciona un punto de aparición al azar
            int randomIndex = Random.Range(0, spawnPoints.Length);

            // Obtiene un animal que no esté activo
            GameObject animal = FirstDeactivate();

             if(animal != null) {

                animal.transform.position = spawnPoints[randomIndex].position;
                animal.transform.rotation = spawnPoints[randomIndex].rotation;

                // Activa el animal en la escena
                animal.SetActive(true);
             }
            // Lo posiciona en el punto de aparición aleatorio
    }

    // Método que agrega nuevos animales a la piscina
    void AddToPool(int poolSize)
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject animalPrefab = animalsPrefab[Random.Range(0,animalsPrefab.Length)];
            // Instancia un nuevo animal y lo desactiva
            GameObject prefabObject;
            prefabObject = Instantiate(animalPrefab, Vector3.zero, Quaternion.identity);
            prefabObject.SetActive(false);

            // Lo agrega a la lista de la piscina
            pooledObjects.Add(prefabObject);
        }
    }

    // Devuelve el primer animal que esté desactivado (libre para usar)
    public GameObject FirstDeactivate()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        // Si todos los animales están en uso, crea uno nuevo y lo retorna
        AddToPool(1);
        return pooledObjects.Last<GameObject>();
    }   

}
