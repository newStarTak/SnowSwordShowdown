using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCtrl : MonoBehaviour
{
    public bool isLeft;
    public bool isRight;
    public bool isUp;
    public bool isDown;
    static public float waterLimit;

    public bool is1;
    public bool is2;

    // Start is called before the first frame update
    void Start()
    {
        if (is1)
        {
            waterLimit = GameObject.Find("Player1").GetComponent<PlayerCtrl>().waterTime;
        }
        else if (is2)
        {
            waterLimit = GameObject.Find("Player2").GetComponent<PlayerCtrl>().waterTime;
        }

        Invoke("MakeAgain", 0.05f);
        
        Destroy(gameObject, waterLimit);
    }

    void MakeAgain()
    {
        if(isLeft)
        {
            Instantiate(gameObject, this.transform.position + new Vector3(-1f, 0f, 0f), this.transform.rotation);
        }
        if (isRight)
        {
            Instantiate(gameObject, this.transform.position + new Vector3(1f, 0f, 0f), this.transform.rotation);
        }
        if (isUp)
        {
            Instantiate(gameObject, this.transform.position + new Vector3(0f, 1f, 0f), this.transform.rotation);
        }
        if (isDown)
        {
            Instantiate(gameObject, this.transform.position + new Vector3(0f, -1f, 0f), this.transform.rotation);
        }
    }


    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag=="HardBlock"||coll.gameObject.tag=="Bedrock"){
            Destroy(gameObject);
        }
        if (coll.gameObject.tag == "Player")
        {
            coll.gameObject.SendMessage("Hit1");
        }
    }
     
}
