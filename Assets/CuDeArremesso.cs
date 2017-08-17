using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuDeArremesso : MonoBehaviour {

    [HideInInspector] public bool isInYodaTrigger = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Debug.Log(isInYodaTrigger);

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("yoda"))
        {
            isInYodaTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("yoda"))
        {
            isInYodaTrigger = false;
        }
    }
}
