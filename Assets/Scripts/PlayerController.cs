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
}
