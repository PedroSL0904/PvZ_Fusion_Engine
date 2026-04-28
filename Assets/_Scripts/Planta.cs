using UnityEngine;

public class Planta : MonoBehaviour
{
    [Header("Estadísticas")]
    public float salud = 100f;

    [Header("Configuración de Disparo")]
    public GameObject prefabProyectil;
    public float ritmoDeDisparo = 1.5f;

    private float temporizador;

    protected virtual void Update()
    {
        if (prefabProyectil != null)
        {
            temporizador += Time.deltaTime;
            if (temporizador >= ritmoDeDisparo)
            {
                Disparar();
                temporizador = 0f;
            }
        }
    }

    void Disparar()
    {
        Instantiate(prefabProyectil, transform.position, Quaternion.identity);
    }

    public void RecibirDaño(float cantidad)
    {
        salud -= cantidad;
        if (salud <= 0)
        {
            Destroy(gameObject); 
        }
    }
}