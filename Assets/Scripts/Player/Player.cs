using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    [SerializeField] private float playerVelocity = 3f;
    [SerializeField] private float rotationSpeed = 10f;

    private Rigidbody2D rb;
    AudioManager audioManager;
    private static Player instance;

    private void Awake(){

        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
         if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame){
            audioManager.PlaySFX(audioManager.flap);
            rb.velocity = Vector2.up * playerVelocity;
        }
    }

    private void FixedUpdate(){
        transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * rotationSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision){
        GameManager.instance.GameOver();
    }
}
