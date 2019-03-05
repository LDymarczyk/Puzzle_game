using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Touch_Puzzle : MonoBehaviour {

    public  Text    points;
    private int     point_counter   =   0;
    private bool    can_touch       =   false;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        touch2D();
    }

    public void touch() {
        Touch touch = Input.touches[0];
        Ray touchRay = Camera.main.ScreenPointToRay( touch.position );
        RaycastHit[] hits = Physics.RaycastAll( touchRay );
        foreach ( RaycastHit hit in hits ) {

            if (touch.phase == TouchPhase.Began) {
                var go = hit.transform.gameObject;
                point_counter++;
                points.text = point_counter.ToString() + " " + go.name;
            }

        }
    }

    public void touch2D() {
        for (var i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position), Vector2.zero);
                // RaycastHit2D can be either true or null, but has an implicit conversion to bool, so we can use it like this
                if (hitInfo && can_touch && hitInfo.transform.gameObject == this.gameObject)
                {
                    var go = hitInfo.transform.gameObject;
                    point_counter++;
                    points.text = point_counter.ToString() + " " + go.name;
                    // Here you can check hitInfo to see which collider has been hit, and act appropriately.
                }
            }
        }
    }

    public void OnTriggerEnter2D( Collider2D collision) {
        if (collision == null) { return; }
        GameObject detect = collision.transform.gameObject;

        if (detect == GameObject.Find("Puzzle Move"))
        {
            collision.transform.GetComponent<Move_Puzzle>().goto_start();
            can_touch = false;
        }
        else if (detect == GameObject.Find("Puzzle Touch"))
        {
            can_touch = true;
        }
        else
        {
            can_touch = false;
        }
    }

}
