using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Animator))]


public class Player_Controller : MonoBehaviour
{

    // Variables
    [Range(1,100)]
    [SerializeField] private float speed = 5.0f;
    private float rotationSpeed = 200.0f;
    private Animator anim;

    private Rigidbody rb;
    
    private float x, y;

    // impowerup es para el power up de multiply score
    public bool impowerup;

    // ihavepowerup es para el power up del pescado
    public bool ihavepowerup;
    private float PowerUpforce = 15;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Player_Movement();       
    }

    // L�gica movimiento y rotaci�n del player
    private void Player_Movement()
    {
        // Funciones
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        anim.SetFloat("Speed_X", x);
        anim.SetFloat("Speed_Y", y);

        // Movimiento player
        //transform.Translate(0, 0, y * Time.deltaTime * speed);
        
        rb.AddRelativeForce (Vector3.forward.normalized * y * speed);

        // Rotaci�n player
        transform.Rotate(0, x * Time.deltaTime * rotationSpeed, 0);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ThrowEnemy_PowerUp"))
        {
            ihavepowerup = true;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "MultiplyScore_PowerUp")
        {
            Destroy(other.gameObject);
            StartCoroutine(MultiplyScoreDuring10Seconds());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && ihavepowerup)
        {
            // Logica si estoy con el powerUp
            Rigidbody rbEnemy = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 throwEnemy = (collision.gameObject.transform.position - transform.position);
            rbEnemy.AddForce(throwEnemy * PowerUpforce, ForceMode.Impulse);

            StartCoroutine(ThrowEnemyDuring10Seconds());
        }
        else
        {
            // Logica muerte del player
            if (collision.gameObject.CompareTag("Enemy"))
            {
                anim.SetBool("isdead", true);

                StartCoroutine(DeathAnimationAfter3Seconds());

            }
        }
    }
    // Coroutine death del player
    IEnumerator DeathAnimationAfter3Seconds()
    {
        yield return new WaitForSeconds(3f);
        GameManager.instance.EndGame();
        GameManager.instance.restartScore(0);
    }

    // Coroutine para el effecto del PowerUp del pescado
    IEnumerator ThrowEnemyDuring10Seconds()
    {
        ihavepowerup = true;
        yield return new WaitForSeconds(10);
        ihavepowerup = false;
    }
    
    // Coroutine para el effecto del PowerUp del pescado
    IEnumerator MultiplyScoreDuring10Seconds()
    {
        impowerup = true;
        yield return new WaitForSeconds(20);
        impowerup = false;
    }
}


