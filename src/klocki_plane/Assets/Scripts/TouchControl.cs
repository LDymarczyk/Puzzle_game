using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchControl : MonoBehaviour {

    public  Text        points;

    private GameObject  move_puzzle;
    private GameObject  touch_enabler;
    private GameObject  touch_area;
    private int         point_counter   =   0;
    private bool        can_touch       =   false;

    // Start is called before the first frame update
    void Start() {
        touch_area      =   this.transform.GetChild(0).gameObject;
        move_puzzle     =   GameObject.Find("Puzzle Touch");
        touch_enabler   =   move_puzzle.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update() {
        OnTouch();
    }

    public RaycastHit2D[] Touch2D( TouchPhase touchPhase ) {
        List<RaycastHit2D>  result  =   new List<RaycastHit2D>();
        for ( var i = 0; i < Input.touchCount; ++i ) {
            if ( Input.GetTouch(i).phase == touchPhase ) {
                Vector3         hitPoint    =   Camera.main.ScreenToWorldPoint( Input.GetTouch(i).position );
                RaycastHit2D    hitInfo     =   Physics2D.Raycast( hitPoint, Vector2.zero );
                result.Add( hitInfo );
            }
        }
        
        return result.ToArray();
    }

    public void OnTouch() {
        foreach( var touch in Touch2D( TouchPhase.Began ) ) {
            if ( touch ) {
                GameObject hit = touch.transform.gameObject;
                if ( hit == touch_area ) {
                    if ( can_touch ) { AddPoint(); }
                    else { SubPoint(); }
                }
            }
        }
    }

    public void AddPoint() {
        point_counter++;
        ShowPoints();
        move_puzzle.GetComponent<MovePuzzle>().GoToStart();
    }

    public void SubPoint() {
        point_counter--;
        ShowPoints();
    }

    public void ShowPoints() {
        points.text = "Punkty " + point_counter.ToString();
    }

    public void OnTriggerEnter2D( Collider2D collision) {
        if ( collision == null ) { return; }
        GameObject detect   =   collision.transform.gameObject;

        if ( detect == move_puzzle ) {
            collision.transform.GetComponent<MovePuzzle>().GoToStart();
            can_touch = false;

        } else if ( detect == touch_enabler ) {
            can_touch = true;

        } else {
            can_touch = false;
        }
    }

}
