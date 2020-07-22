using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Muerte : MonoBehaviour
{

    [SerializeField]
    GameObject controllers;


    public void OnTriggerEnter(Collider otro){
        if (otro.gameObject.tag == "Carro")
        {
            controllers.GetComponent<MenuJuego>().GameOver();
        }
    }
}
