using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerificaMorte : MonoBehaviour {

    bool CaiuNoAcido = false;
    bool FoiVisto = false;
    [SerializeField] private float TempoMortePorAfogamento;
    private SpriteRenderer sr;



    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("acido") && !CaiuNoAcido)
        {
            CaiuNoAcido = true;
            Debug.Log("Ai, ta queimando!");
            Destroy(this.gameObject, TempoMortePorAfogamento);
        }
        
    }
   
    private void Update()
    {
        //para evitar que o isVisible tome um valor falso no inicio da renderiacao da cena
        if (sr.isVisible)
            FoiVisto = true;

        if (FoiVisto && !sr.isVisible)
            Destroy(gameObject);

    }

    


}
