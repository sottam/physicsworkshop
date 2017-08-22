using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragnDrop : MonoBehaviour {
    public float clickRange = 5f;
    public float forceConstant = 1000f;
    public Color unclickableColor;

    private bool canBeDragged = true;
    private bool isInYodaTrigger = false;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Collider2D cc;

    private bool isBeingDragged = false;

    private GameObject yoda;

    private bool mouseup = false;

	// Use this for initialization
	void Start () {

        yoda = GameObject.FindGameObjectWithTag("yoda");
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        cc = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x - yoda.transform.position.x > clickRange) {
            canBeDragged = false;
            sr.color = unclickableColor;
        } else {
            canBeDragged = true;
            sr.color = Color.white;
        }

        if (isBeingDragged) {
            Vector3 aux = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            transform.position = new Vector3(aux.x, aux.y, transform.position.z);

            //USANDO CHEGAGEM
            /*
            if (transform.position.x > Camera.main.transform.position.x)
            {
                //OnMouseUp();
                transform.position = new Vector3(Camera.main.transform.position.x, transform.position.y, transform.position.z);
            }
            */
            //FIM USANDO CHECAGEM

            //USANDO CLAMP
            var x = Mathf.Max(transform.position.x, yoda.transform.position.x);
            var y = Mathf.Max(transform.position.y, yoda.transform.position.y);
            transform.position = new Vector3(x, y, transform.position.z);

            transform.position = Vector3.ClampMagnitude(transform.position - yoda.transform.position, clickRange);
            transform.position += yoda.transform.position;
            //FIM USANDO CLAMP

            

        }
	}

    private void ThrowBall() {
        Vector3 throwDirection = transform.position - yoda.transform.position;
        float force = Mathf.Clamp(1 / throwDirection.magnitude, .35f, 1);
        rb.AddForce(throwDirection.normalized * force * forceConstant);
    }

/*
    private void FixedUpdate() {
        if (rb.bodyType == RigidbodyType2D.Dynamic) {
            if (mouseup && isInYodaTrigger) {
                ThrowBall();
                print ("caralho2");
                mouseup = false;
            }
        }
    } */

    private void OnMouseDown() {
        if (canBeDragged) {
            isBeingDragged = true;
            rb.bodyType = RigidbodyType2D.Kinematic;
            cc.enabled = false;
        }
    }

    private void OnMouseUp() {
        isBeingDragged = false;
        rb.bodyType = RigidbodyType2D.Dynamic;
        cc.enabled = true;

        mouseup = true;
        
    }
    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("yoda")) {
            isInYodaTrigger = true;
            if (mouseup) {
                ThrowBall();
                mouseup = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("yoda")) {
            isInYodaTrigger = false;
        }
    }
}
