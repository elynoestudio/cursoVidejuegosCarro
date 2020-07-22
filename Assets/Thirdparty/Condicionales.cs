using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Condicionales : MonoBehaviour
{
    [SerializeField]
   private bool hambre = false;
    [SerializeField]
   private bool dinero = true;
    [SerializeField]
   private bool tiempo = true;
    [SerializeField]
   private int caso = 58;

  

   void Start(){





//variables
      switch (caso) 
      {
          case 1: //constantes 
            Func();
          break;
          case 2:
            print("Este es el caso numero 2");
          break;
          case 58:
            print("Este es el caso numero 3");
          break;
          case 89:
            print("Este es el caso numero 4");
          break;
          case 5:
            print("Este es el caso numero 5");
          break;
          
          default:
           print("No hay caso");
           break;
      }

   }

   public void Func(){
       if (!tiempo == dinero)
                {
                    print("verdad");
                }
                else{
                    print("falso");
                }
   }

}
