using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic; 

public class GridManager : MonoBehaviour
{
    [Header("Dimensiones del Tablero")]
    public int columnas = 9;
    public int filas = 5;

    [Header("Tamaño Físico")]
    public float anchoCelda = 1.2f;
    public float altoCelda = 1.5f;

    [Header("Catálogo de Prefabs")]
    public GameObject prefabPlantaBase;     
    public GameObject prefabPlantaFusionada;
    public GameObject prefabGirasol;

    private int[,] tableroLogico;

    private GameObject[,] tableroVisual;

    private Dictionary<System.Tuple<int, int>, int> recetasDeFusion;

    void Start()
    {
        tableroLogico = new int[columnas, filas];
        tableroVisual = new GameObject[columnas, filas];

        recetasDeFusion = new Dictionary<System.Tuple<int, int>, int>();

        recetasDeFusion.Add(new System.Tuple<int, int>(1, 1), 2);

        Debug.Log("Tablero virtual y Motor de Fusiones inicializados.");
    }

    void Update()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 posMousePantalla = Mouse.current.position.ReadValue();
            Vector2 posMouse = Camera.main.ScreenToWorldPoint(posMousePantalla);

            RaycastHit2D[] hits = Physics2D.RaycastAll(posMouse, Vector2.zero);

            foreach (RaycastHit2D hit in hits)
            {
                if (hit.collider != null && hit.collider.CompareTag("Sol"))
                {
                    int valorSol = hit.collider.GetComponent<Sol>().valor;
                    GestorEconomia.Instancia.AgregarSoles(valorSol);
                    Destroy(hit.collider.gameObject);

                    return; 
                }
            }

            float offsetX = (columnas - 1) * anchoCelda / 2f;
            float offsetY = (filas - 1) * altoCelda / 2f;

            int x = Mathf.RoundToInt((posMouse.x + offsetX) / anchoCelda);
            int y = Mathf.RoundToInt((posMouse.y + offsetY) / altoCelda);

            if (x >= 0 && x < columnas && y >= 0 && y < filas)
            {
                int idEnCelda = tableroLogico[x, y];
                int idSemillaEnMano = UIManager.Instancia.idPlantaSeleccionada;

                if (idEnCelda != 0 && tableroVisual[x, y] == null)
                {
                    tableroLogico[x, y] = 0; 
                    idEnCelda = 0;          
                }

                if (idEnCelda == 0)
                {
                    int costo = (idSemillaEnMano == 3) ? 50 : 100;

                    if (GestorEconomia.Instancia.GastarSoles(costo))
                    {
                        Plantar(x, y, idSemillaEnMano);
                    }
                }
                else
                {
                    IntentarFusion(x, y, idEnCelda, idSemillaEnMano);
                }
            }
        }
    }

    void Plantar(int x, int y, int idPlanta)
    {
        float offsetX = (columnas - 1) * anchoCelda / 2f;
        float offsetY = (filas - 1) * altoCelda / 2f;
        Vector2 posicionFisica = new Vector2((x * anchoCelda) - offsetX, (y * altoCelda) - offsetY);

        GameObject prefabAInstanciar = null;

        if (idPlanta == 1)
        {
            prefabAInstanciar = prefabPlantaBase;
        }
        else if (idPlanta == 2)
        {
            prefabAInstanciar = prefabPlantaFusionada;
        }
        else if (idPlanta == 3)
        {
            prefabAInstanciar = prefabGirasol;
        }

        if (prefabAInstanciar != null)
        {
            GameObject nuevaPlanta = Instantiate(prefabAInstanciar, posicionFisica, Quaternion.identity);

            tableroLogico[x, y] = idPlanta;
            tableroVisual[x, y] = nuevaPlanta;

            Debug.Log($"Se plantó el ID {idPlanta} en la celda [{x}, {y}]");
        }
    }

    void IntentarFusion(int x, int y, int idBase, int idNueva)
    {
        var receta = new System.Tuple<int, int>(idBase, idNueva);

        if (recetasDeFusion.ContainsKey(receta))
        {
            int idResultado = recetasDeFusion[receta];
            Debug.Log($"¡Fusión Exitosa! {idBase} + {idNueva} = {idResultado}");

            Destroy(tableroVisual[x, y]);

            Plantar(x, y, idResultado);
        }
        else
        {
            Debug.LogWarning($"No existe fusión para {idBase} + {idNueva}");
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        float offsetX = (columnas - 1) * anchoCelda / 2f;
        float offsetY = (filas - 1) * altoCelda / 2f;

        for (int x = 0; x < columnas; x++)
        {
            for (int y = 0; y < filas; y++)
            {
                Vector2 pos = new Vector2((x * anchoCelda) - offsetX, (y * altoCelda) - offsetY);
                Gizmos.DrawWireCube(pos, new Vector3(anchoCelda, altoCelda, 0));
            }
        }
    }
}