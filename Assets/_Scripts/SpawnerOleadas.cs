using System.Collections;
using UnityEngine;

[System.Serializable]
public class Oleada
{
    public string nombre = "Oleada X";
    public int cantidadZombis;
    public float ritmoAparicion; 
}

public class SpawnerOleadas : MonoBehaviour
{
    [Header("Configuración de Nivel")]
    public Oleada[] oleadas;
    public float tiempoPreparacionInicial = 15f; 
    public float tiempoDescansoEntreOleadas = 20f; 

    [Header("Referencias")]
    public GameObject prefabZombiBasico;

    [Header("Alineación con el Tablero Lógico")]
    public int filas = 5;
    public float altoCelda = 1.5f;
    public float posicionXSpawneo = 8f; 

    private float offsetY;

    void Start()
    {
        offsetY = (filas - 1) * altoCelda / 2f;

        StartCoroutine(RutinaDeOleadas());
    }

    IEnumerator RutinaDeOleadas()
    {
        Debug.Log("⏳ Nivel iniciado. Tiempo de preparación...");
        yield return new WaitForSeconds(tiempoPreparacionInicial);

        for (int i = 0; i < oleadas.Length; i++)
        {
            Debug.Log($"🧟‍♂️ ¡Iniciando {oleadas[i].nombre}!");

            for (int z = 0; z < oleadas[i].cantidadZombis; z++)
            {
                InstanciarZombi();
                yield return new WaitForSeconds(oleadas[i].ritmoAparicion);
            }

            if (i < oleadas.Length - 1)
            {
                Debug.Log("☕ Pausa entre oleadas...");
                yield return new WaitForSeconds(tiempoDescansoEntreOleadas);
            }
        }

        Debug.Log("🚩 ¡ÚLTIMA OLEADA TERMINADA! (Esperando a que mueran para ganar)");
    }

    void InstanciarZombi()
    {
        int filaAleatoria = Random.Range(0, filas);

        float posicionY = (filaAleatoria * altoCelda) - offsetY;

        Vector2 posicionFinal = new Vector2(posicionXSpawneo, posicionY);
        Instantiate(prefabZombiBasico, posicionFinal, Quaternion.identity);
    }
}