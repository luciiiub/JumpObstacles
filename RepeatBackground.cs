using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos; // Guarda la posicion inicial del fondo
    private float repeatWidth;  // Mitad del ancho del fondo 
    
    void Start()
    {
        startPos = transform.position;   // Almacena la posicion inicial
        repeatWidth = GetComponent<BoxCollider>().size.x / 2; // Calcula el ancho del fondo
    }

    void Update()
    {
        // Si el fondo se ha desplazado completamente hacia la izquierda
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;   //lo reinicia a su posicion original
        }
    }
}
