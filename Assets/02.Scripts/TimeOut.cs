using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TimeOut : MonoBehaviour
{
    float Limit;
    public Text TimeText;
    public bool GameFin;
    // Start is called before the first frame update
    void Start()
    {
        Limit=180.0f;
        GameFin=false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameFin){
            Limit-=Time.deltaTime;
            TimeText.text=""+(int)Limit;
        }
        if(Limit<=0){
            GameFin=true;
            Invoke("GameFinish",2.0f);
            GameObject.Find("Player1").SendMessage("GameFin");
            GameObject.Find("Player2").SendMessage("GameFin");
        }
    }

    void GameFinish(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
