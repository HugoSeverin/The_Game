using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //CORE Singleton mode
    public static PlayerController instance; 

    private Rigidbody2D rb;
    private float moveH, moveV;
    [SerializeField]
    public float movespeed = 5.0f;
    public string scenePassword;

    //Attaque
    public GameObject arrow;
    public float arrowForce;

    //Obj
    public bool IgotKey = false;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            if(instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        moveH = Input.GetAxisRaw("Horizontal") * movespeed;
        moveV = Input.GetAxisRaw("Vertical") * movespeed;
        rb.velocity = new Vector2(moveH, moveV);
    }

    private void Update()
    {
        if (GetComponentInChildren<HealthBar>().hp <= 0)
        {
            Destroy(gameObject);
            Debug.Log("MDR t'es mort sale merde");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newArrow = Instantiate(arrow, transform.position, Quaternion.identity);
            newArrow.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, arrowForce));
        }
    }

    public void gotKey() {
        Debug.Log("you got the key");
        IgotKey = true;
    }

    public bool playerGotKey() {
        return IgotKey;
    }
}
