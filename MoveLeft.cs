using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 30; 
    private PlayerController playerControllerScript;  
    private float leftBound = -15;    // Limite izquierdo para destruir objetos

    void Start()
    {
      
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        // Si el juego no ha terminado, mueve el objeto hacia la izquierda
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        // Si el objeto sale del limite izquierdo y es un obstaculo, lo destruye
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle")) 
        {
            Destroy(gameObject);
        }
    }
}
