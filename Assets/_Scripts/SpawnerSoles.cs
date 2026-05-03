using System.Collections;
using UnityEngine;

public class SpawnerSoles : MonoBehaviour
{
    [Header("Configuración de Generación")]
    public GameObject prefabSol;
    public float tiempoPrimerSol = 7f; 
    public float intervaloEntreSoles = 10f; 

    [Header("Límites de Pantalla")]
    public float limiteIzquierdoX = -8f;
    public float limiteDerechoX = 8f;
    public float alturaAparicionY = 6f; 

    [Header("Alineación Matemática")]
    public int filas = 5;
    public float altoCelda = 1.5f;
    private float offsetY;

    void Start()
    {
        offsetY = (filas - 1) * altoCelda / 2f;

        StartCoroutine(RutinaSolesCielo());
    }

    IEnumerator RutinaSolesCielo()
    {
        yield return new WaitForSeconds(tiempoPrimerSol);

        while (true)
        {
            GenerarSolDelCielo();
            yield return new WaitForSeconds(intervaloEntreSoles);
        }
    }

    void GenerarSolDelCielo()
    {
        float posXAleatoria = Random.Range(limiteIzquierdoX, limiteDerechoX);
        Vector2 posicionInicio = new Vector2(posXAleatoria, alturaAparicionY);

        int filaAleatoria = Random.Range(0, filas);
        float destinoY = (filaAleatoria * altoCelda) - offsetY;

        GameObject nuevoSol = Instantiate(prefabSol, posicionInicio, Quaternion.identity);

        Sol scriptSol = nuevoSol.GetComponent<Sol>();
        if (scriptSol != null)
        {
            scriptSol.ConfigurarCaida(destinoY);
        }
    }
}