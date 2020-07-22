using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
  [SerializeField]
    private Transform objetivo;
    [SerializeField]
    private Vector3 desface;
    [SerializeField]
    private float velocidadDeMovimiento = 10f;
    [SerializeField]
    private float velocidadDeGiro = 10f;

    public void VerObjetivo()
    {
        Vector3 direccion = objetivo.position - this.transform.position;
        Quaternion direccionARotar = Quaternion.LookRotation(direccion, Vector3.up);

        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, direccionARotar, velocidadDeGiro * Time.deltaTime);
    }

    public void SeguirObjetivo()
    {
        Vector3 posicionObjetivo = objetivo.position +
            objetivo.forward * desface.z +
            objetivo.right * desface.x +
            objetivo.up * desface.y;
        this.transform.position = Vector3.Lerp(transform.position, posicionObjetivo, velocidadDeMovimiento*Time.deltaTime);
    }

    void FixedUpdate()
    {
        VerObjetivo();
        SeguirObjetivo();
    }
}
