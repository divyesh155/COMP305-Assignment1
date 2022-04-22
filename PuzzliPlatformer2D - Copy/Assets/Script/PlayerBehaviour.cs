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
        if (collision.gameObject.CompareTag("Danger"))
        {
            SceneManager.LoadScene(3);
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
