using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int BlockHP;
    public Sprite[] Set;

    public GameObject WaterBucket;
    public GameObject HardBlock;

    public bool Target;

    // Start is called before the first frame update
    void Start()
    {
        BlockHP=3;
        Target=false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="Blade"){
            BlockHP-=1;
            this.GetComponent<SpriteRenderer>().sprite=Set[BlockHP];
            if(BlockHP<=0){
                Instantiate(WaterBucket,this.transform.position, this.transform.rotation);
                Destroy(gameObject);
            }
        }
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag=="HardBlock"){
            Destroy(gameObject);
        }
    }
}
