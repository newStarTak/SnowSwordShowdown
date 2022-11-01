using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public float ItemTime;
    public GameObject[] ItemSet;
    int ItemNumber;
    bool ItemOn;
    // Start is called before the first frame update
    void Start()
    {
        ItemTime=5.0f;
        ItemOn=true;
    }

    // Update is called once per frame
    void Update()
    {
        ItemTime-=Time.deltaTime;
        if(ItemTime<=0&&ItemOn){
            ItemOn=false;
            ItemNumber=Random.Range(0,3);
            Instantiate(ItemSet[ItemNumber],this.transform.position,Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="Player"){
            ItemTime=5.0f;
            ItemOn=true;
        }
        
    }
}
