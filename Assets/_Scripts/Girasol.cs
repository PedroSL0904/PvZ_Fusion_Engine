using UnityEngine;

public class Girasol : Planta
{
    [Header("Producción")]
    public GameObject prefabSol;
    public float ritmoDeGeneracion = 10f;

    private float temporizadorSoles;

    protected override void Update()
    {
        temporizadorSoles += Time.deltaTime;
        if (temporizadorSoles >= ritmoDeGeneracion)
        {
            GenerarSol();
            temporizadorSoles = 0f;
        }
    }

    void GenerarSol()
    {
        GameObject nuevoSol = Instantiate(prefabSol, transform.position, Quaternion.identity);

        Sol scriptSol = nuevoSol.GetComponent<Sol>();
        if (scriptSol != null)
        {
            scriptSol.ConfigurarParabola(transform.position);
        }
    }
}