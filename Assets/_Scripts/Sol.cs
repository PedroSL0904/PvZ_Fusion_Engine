using UnityEngine;

public class Sol : MonoBehaviour
{
    public int valor = 25;
    public float tiempoDeVida = 8f; 

    void Start()
    {
        Destroy(gameObject, tiempoDeVida);
    }
}