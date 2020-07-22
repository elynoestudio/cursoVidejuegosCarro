using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuJuego : MonoBehaviour
{
  
  [SerializeField]
  private GameObject panelPausa;

[SerializeField]
  private GameObject panelGO;
  public void Pausa(){

      Time.timeScale = 0.0001f;
      panelPausa.SetActive(true);
  }

  public void Reiniciar(){
      Time.timeScale = 1;
      SceneManager.LoadScene("HacerCarrito");
  }

  public void Continuar(){
      Time.timeScale = 1;
      panelPausa.SetActive(false);
  }

  public void SalirAlMenu(){
      SceneManager.LoadScene("MenuPrincipal");
  }

  public void GameOver(){
      Time.timeScale = 0.0001f;
      panelGO.SetActive(true);
  }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pausa();
        }
    }
}
