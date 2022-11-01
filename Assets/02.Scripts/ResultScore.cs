using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScore : MonoBehaviour
{
    public Text ScoreBoard;
    public Text GameResult;
    // Start is called before the first frame update
    void Start()
    {
        ScoreBoard.text=""+Score.RedScore/2+"-"+Score.GreenScore/2;
        if(Score.RedScore>Score.GreenScore){
            GameResult.text="Red\nWin!!";
        }
        else{
            GameResult.text="Green\nWin!!";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
