using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNDrop : MonoBehaviour {
    bool isDrag;
    bool isMoved;
    public bool todestroy;
    float pos;
	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        isMoved = false;
        isDrag = false;
        todestroy = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (isDrag)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector2 rayPoint = ray.GetPoint(pos);
            transform.position = rayPoint;
        }
	}

    void OnMouseDown()
    {
        isDrag = true;
        pos = Vector2.Distance(transform.position, Camera.main.transform.position);
        if (!isMoved)
        {
            Instantiate(gameObject);
        }
    }

    void OnMouseUp()
    {
        isDrag = false;
        isMoved = true;
        if (todestroy)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D colliderInfo)
    {
        if (colliderInfo.gameObject.tag.CompareTo("Trash") == 0)
        {
            todestroy = true;
        }
    }
}
