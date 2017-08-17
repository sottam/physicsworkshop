using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragnDrop : MonoBehaviour {
    private Rigidbody2D rb;
    private CircleCollider2D cc;

    private CuDeArremesso cda;

    private bool isBeingDragged = false;

    private GameObject yoda;

    private bool mouseup = false;

	// Use this for initialization
	void Start () {

        cda = GetComponent<CuDeArremesso>();
        yoda = GameObject.Find("yoda");
        rb = GetComponent<Rigidbody2D>();
        cc = GetComponent<CircleCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (isBeingDragged)
        {
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
            transform.position = Vector3.ClampMagnitude(transform.position - yoda.transform.position, 5f);
            transform.position += yoda.transform.position;
            //FIM USANDO CLAMP

            

        }
	}

    private void FixedUpdate()
    {
        if (mouseup && cda.isInYodaTrigger)
        {
            Vector3 OneDirection = transform.position - yoda.transform.position;
            float force = Mathf.Min(1 / OneDirection.magnitude, 100);
            rb.AddForce(OneDirection.normalized * force * 1000);
            mouseup = false;
        }
    }

    private void OnMouseDown()
    {
        isBeingDragged = true;
        rb.bodyType = RigidbodyType2D.Kinematic;
        cc.enabled = false;
    }

    private void OnMouseUp()
    {
        isBeingDragged = false;
        rb.bodyType = RigidbodyType2D.Dynamic;
        cc.enabled = true;

        mouseup = true;
        
    }
}
