using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    public float movementSpeed = 4.0f;
    public float movement;
    public float jumpForce;
    private Rigidbody2D _rigidbody2D;
    public Transform _transform;
    public SpriteRenderer sp;
    public CinemachineCameraOffset cs;
    public GameObject text1;
    public GameObject text2;
    public GameObject platform;
    public GameObject tiltPlatform;

    [Header("Platforms")]
    public GameObject floating;
    public GameObject moving;
    public GameObject tilting;
    public GameObject bouncing;
    public GameObject collapsing;
    public GameObject ferris;
    public GameObject exploding;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
        sp = GetComponent<SpriteRenderer>();
        cs = GetComponent<CinemachineCameraOffset>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");

        if(movement > 0 || movement < 0)
        {
            transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;
        }

        if(Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody2D.velocity.y) < 0.001f)
        {
            _rigidbody2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
       
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Platform"))
        {
            this.transform.parent = col.transform;
        }
        if(col.gameObject.CompareTag("Slope"))
        {
            _transform.eulerAngles = new Vector3(0, 0, 45);
        }
        
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.gameObject.CompareTag("RedCrystal"))
        {
            sp.color = Color.red;
            Destroy(collision.gameObject);
            text1.SetActive(true);
            text2.SetActive(false);
            platform.SetActive(true);
        }
         if(collision.gameObject.CompareTag("Finish") && sp.color == Color.red)
        {
            SceneManager.LoadScene(2);
        }
        if (collision.gameObject.CompareTag("Restart"))
        {
            SceneManager.LoadScene(4);
        }

        if(collision.gameObject.CompareTag("P1Left"))
        {
            tiltPlatform.transform.eulerAngles = Vector3.forward * 50;
        }

        if (collision.gameObject.CompareTag("Moving"))
        {
            moving.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Floating"))
        {
            floating.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Tilting"))
        {
            tilting.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Bouncing"))
        {
            bouncing.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Collapsing"))
        {
            collapsing.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Ferris"))
        {
            ferris.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Exploding"))
        {
            exploding.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Moving"))
        {
            moving.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Floating"))
        {
            floating.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Tilting"))
        {
            tilting.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Bouncing"))
        {
            bouncing.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Collapsing"))
        {
            collapsing.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Ferris"))
        {
            ferris.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Exploding"))
        {
            exploding.SetActive(false);
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Platform"))
        {
            this.transform.parent = null;
        }
        if (col.gameObject.CompareTag("Slope"))
        {
            _transform.eulerAngles = new Vector3(0, 0, 0);
            
        }

    }
}
