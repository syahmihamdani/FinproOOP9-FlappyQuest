using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score instance;
    private int score;
    [SerializeField] private TextMeshProUGUI currentScore;
    [SerializeField] private TextMeshProUGUI bestScore;


    private void Awake(){
        if(instance == null){
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        currentScore.text = score.ToString();   
        bestScore.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
        UpdateBestScore();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateBestScore(){
        if(score>PlayerPrefs.GetInt("BestScore")){
            PlayerPrefs.SetInt("BestScore", score);
            bestScore.text = score.ToString();
        }
    }

    public void UpdateScore(){
        score++;
        currentScore.text = score.ToString();
        UpdateBestScore();
    }
}
