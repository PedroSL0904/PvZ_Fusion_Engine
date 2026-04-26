using UnityEngine;

public class Zombi : MonoBehaviour
{
    [Header("Estadísticas")]
    public float saludActual = 100f;
    public float velocidad = 0.5f;
    public float dañoPorSegundo = 20f; 

    private Planta plantaObjetivo;

    void Update()
    {
        if (plantaObjetivo != null)
        {
            plantaObjetivo.RecibirDaño(dañoPorSegundo * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * velocidad * Time.deltaTime);
        }
    }

    public void EmpezarAComer(Planta plantaEncontrada)
    {
        plantaObjetivo = plantaEncontrada;
    }

    public void RecibirDaño(float cantidad)
    {
        saludActual -= cantidad;
        if (saludActual <= 0) Morir();
    }

    void Morir()
    {
        Destroy(gameObject);
    }
}