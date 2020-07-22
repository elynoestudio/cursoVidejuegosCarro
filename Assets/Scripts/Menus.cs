using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{

    [SerializeField]
    private GameObject MenuInicio;
    [SerializeField]
    private GameObject MenuOpciones;

    public void Jugar()
	{
        SceneManager.LoadScene("HacerCarrito");
	}

    public void AbrirMenuDeOpciones()
    {
        MenuOpciones.SetActive(true);
        MenuInicio.SetActive(false);
    }
    public void CerrarMenuDeOpciones()
    {
        MenuOpciones.SetActive(false);
        MenuInicio.SetActive(true);
    }

    public void CerrarApp()
    {
        Application.Quit();
    }
}
