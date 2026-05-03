using UnityEngine;

public class Cortadora : MonoBehaviour
{
    [Header("Configuración")]
    public float velocidad = 6f;
    private bool encendida = false;

    void Update()
    {
        if (encendida)
        {
            transform.Translate(Vector2.right * velocidad * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D otroObjeto)
    {
        HitboxEnemigo hitbox = otroObjeto.GetComponent<HitboxEnemigo>();

        if (hitbox != null)
        {
            encendida = true;

            hitbox.AplicarDañoEnZombi(9999f);

            Destroy(gameObject, 5f);
        }
    }
}