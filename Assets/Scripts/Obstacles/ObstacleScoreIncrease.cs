using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScoreIncrease : MonoBehaviour
{
     AudioManager audioManager;

    private void Awake(){

        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
            Score.instance.UpdateScore();
            audioManager.PlaySFX(audioManager.pass);
        }
    }
}
