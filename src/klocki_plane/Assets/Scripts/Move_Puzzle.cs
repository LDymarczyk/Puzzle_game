using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Puzzle : MonoBehaviour {

    public  Sprite[]    sprites;
    public  float       speed       =   1;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        moving();
    }

    public void moving() {
        transform.position  -=  new Vector3( speed * Time.deltaTime, 0, 0 );
    }

    public void goto_start() {
        int rand    =   Random.Range(0, 3);
        GetComponent<SpriteRenderer>().sprite = sprites[rand];
        transform.position  =   new Vector3( 15, 0, 0 );
    }

}
