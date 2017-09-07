using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Municao : MonoBehaviour {

    [SerializeField] private int municao;
    [SerializeField] private GameObject Bomba;


    public void SpawnNewBomb()
    {
        if (municao > 0)
        {
            Instantiate(Bomba, transform.position + Vector3.right + Vector3.back, Quaternion.identity);
            municao--;
        }
    }
}
