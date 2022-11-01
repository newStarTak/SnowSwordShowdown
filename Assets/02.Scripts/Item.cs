using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int ItemNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="Player"){
            if(ItemNumber==0){
                other.gameObject.GetComponent<PlayerCtrl>().bucketCount++;
                
            }
            else if(ItemNumber==1){
                other.gameObject.GetComponent<PlayerCtrl>().isKnifeUpgraded=true;
            }
            else if(ItemNumber==2){
                other.gameObject.GetComponent<PlayerCtrl>().waterTime += 0.05f;
            }
            Destroy(gameObject);
        }
    }
}
