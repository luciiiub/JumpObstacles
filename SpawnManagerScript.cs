using UnityEngine;

public class SpawnManagerScript : MonoBehaviour
{
    public GameObject obstaclePrefab;  

    private Vector3 spawnPos = new Vector3(25, 0, 0);  // Posicion fija donde se instanciaran los obstaculos
    private float startDelay = 2;  // Tiempo de espera antes de que empiece a generarse el primer obstaculo
    private float repeatRate = 2; // Intervalo de tiempo entre cada obstaculo que aparece

    private PlayerController playerControllerScript;  

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    void Update()
    {
      
    }

    void SpawnObstacle()
    {
        if (!playerControllerScript.gameOver)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}
