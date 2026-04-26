using UnityEngine;

public class Proyectil : MonoBehaviour
{
    [Header("Configuración")]
    public float velocidad = 5f;
    public float daño = 20f; 
    public float tiempoDeVida = 4f;

    void Start()
    {
        Destroy(gameObject, tiempoDeVida);
    }

    void Update()
    {
        transform.Translate(Vector2.right * velocidad * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D otroObjeto)
    {
        HitboxEnemigo hitbox = otroObjeto.GetComponent<HitboxEnemigo>();

        if (hitbox != null)
        {
            hitbox.AplicarDañoEnZombi(daño);

            Destroy(gameObject);
        }
    }
}