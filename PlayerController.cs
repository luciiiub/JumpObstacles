using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Componentes del jugador
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;

    // Particulas y sonidos
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip crashSound;
    public AudioClip jumpSound;

    // Parametros de movimiento
    public float jumpForce = 10;   // Fuerza del salto
    public float gravityModifier;     // Multiplicador de gravedad

    // Estado del jugador
    public bool isOnGround = true;   // Verifica si el jugador esta en el suelo
    public bool gameOver = false;   // Indica si el juego termino

    void Start()
    {
        // Obtener componentes necesarios
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        // Aumenta la gravedad global
        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
        // Salto al presionar espacio, solo si esta en el suelo y el juego no ha terminado
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);   // Salto
            isOnGround = false;    // Evita doble salto!!!
            playerAnim.SetTrigger("Jump_trig"); // Animacion de salto
            dirtParticle.Stop();   // Detiene particulas de tierra
            playerAudio.PlayOneShot(jumpSound, 1.0f);    // Sonido de salto
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Si toca el suelo, puede volver a saltar
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();    // Activa particulas de tierra
        }
        // Si choca con un obstaculo, termina el juego
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("GameOver!");

            playerAnim.SetBool("Death_b", true);   // Activa animacion de muerte
            playerAnim.SetInteger("DeathType_int", 1);    

            explosionParticle.Play();    // Particulas de explosion
            dirtParticle.Play();  
            playerAudio.PlayOneShot(crashSound, 1.0f);   // Sonido de choque
        }
    }
}
