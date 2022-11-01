using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public static int RedScore=0;
    public static int GreenScore=0;
    public Text ScoreBoard;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        LoadScoreBoard();
    }

    public void RedWin(){
        RedScore+=1;
        LoadScoreBoard();
        GameSet();
    }
    public void GreenWin(){
        GreenScore+=1;
        LoadScoreBoard();
        GameSet();
    }
    public void LoadScoreBoard(){
        ScoreBoard.text=""+RedScore/2+"-"+GreenScore/2;
    }
    public void GameSet(){
        if(RedScore/2>=3){
            SceneManager.LoadScene("Result");
        }
        else if(GreenScore/2>=3){
            SceneManager.LoadScene("Result");
        }
        else{
            Invoke("GameFin",2.0f); 
        }
    }

    void GameFin(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
}
