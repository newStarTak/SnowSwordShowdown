using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWaterBucket : MonoBehaviour
{
    public GameObject Block;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            {
                Instantiate(Block, this.transform.position, this.transform.rotation);
            }
    }
}
