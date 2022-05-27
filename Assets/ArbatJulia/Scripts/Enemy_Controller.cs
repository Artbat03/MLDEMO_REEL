using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Animator))]

public class Enemy_Controller : MonoBehaviour
{
    // Variables
    public int rutine;
    public float chronometer;
    [SerializeField] private Animator anim;
    public Quaternion angle;
    public float grade;

    public GameObject target;

    private Player_Controller _playerController;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Controller>();
        
        target = GameObject.FindGameObjectWithTag("Player");
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        Enemy_Movement();

        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }

    private void Enemy_Movement()
    {
        // Lógica para posición de enemigo y target a distancia (fuera del angulo de vista)
        if(Vector3.Distance(transform.position, target.transform.position) > 5)
        {
            // Lógica para cancelar la acción de correr
            anim.SetBool("iswalking", false);

            // Lógica para mover aleatoriamente al enemigo por el mapa
            chronometer += 1 * Time.deltaTime;

            if(chronometer >= 4)
            {
                rutine = Random.Range(0, 2);
                chronometer = 0;

                switch (rutine)
                {
                    case 0:
                        anim.SetBool("iswalking", true);
                        break;

                    case 1:
                        grade = Random.Range(0, 360);
                        angle = Quaternion.Euler(0, grade, 0);
                        rutine++;
                        break;

                    case 2:
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, angle, 0.5f);
                        transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                        anim.SetBool("iswalking", true);
                        break;
                }
            }
                                 
            else
            {
                var lookPos = target.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                transform.Translate(Vector3.forward * 2 * Time.deltaTime);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && _playerController.ihavepowerup)
        {
            anim.SetBool("isdead", true);
            StartCoroutine(EnemyisDeathAfter3Seconds());
        }
    }

    // Coroutine para death del jugador
    IEnumerator EnemyisDeathAfter3Seconds()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
