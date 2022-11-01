using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    float LifeTime;
    public GameObject Score;
    // Start is called before the first frame update
    void Start()
    {
        LifeTime=0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        LifeTime-=Time.deltaTime;
        if(LifeTime<=0){
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            if(coll.gameObject.name=="Player2"){
                Score.GetComponent<Score>().RedWin();
                GameObject.Find("Player1").SendMessage("GameFin");
                GameObject.Find("Player2").SendMessage("GameFin");
            }
            else{
                Score.GetComponent<Score>().GreenWin();
                GameObject.Find("Player1").SendMessage("GameFin");
                GameObject.Find("Player2").SendMessage("GameFin");
            }
            Destroy(coll.gameObject);
        }
    }
}
