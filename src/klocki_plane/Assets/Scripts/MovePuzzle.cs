using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePuzzle : MonoBehaviour {

    public  Sprite[]    sprites;
    public  float       speed       =   1;

    // Update is called once per frame
    void Update() {
        Moving();
    }

    public void Moving() {
        transform.position  -=  new Vector3( speed * Time.deltaTime, 0, 0 );
    }

    public void GoToStart() {
        int rand            =   Random.Range(0, 3);
        transform.position  =   new Vector3( 15, 0, 0 );
        GetComponent<SpriteRenderer>().sprite = sprites[rand];
    }

}
