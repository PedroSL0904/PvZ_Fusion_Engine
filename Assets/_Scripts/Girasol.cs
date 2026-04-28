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
        Vector2 offsetAleatorio = new Vector2(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));
        Vector2 posicionSpawneo = (Vector2)transform.position + offsetAleatorio;

        Instantiate(prefabSol, posicionSpawneo, Quaternion.identity);
    }
}