using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Municao : MonoBehaviour {

    [SerializeField] private int municao;
    [SerializeField] private GameObject Bomba;

    public static bool BombaNaTela = true;

    void FixedUpdate()
    {
        if (BombaNaTela == false && municao > 0)
        {
            Instantiate(Bomba, transform.position + Vector3.right, Quaternion.identity);
            municao--;
            BombaNaTela = true;
        }
    }
}
