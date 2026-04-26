using UnityEngine;

public class HitboxEnemigo : MonoBehaviour
{
    public Zombi scriptZombiPrincipal;

    public void AplicarDañoEnZombi(float daño)
    {
        scriptZombiPrincipal.RecibirDaño(daño);
    }

    void OnTriggerEnter2D(Collider2D otroObjeto)
    {
        Planta plantaTocada = otroObjeto.GetComponent<Planta>();

        if (plantaTocada != null)
        {
            scriptZombiPrincipal.EmpezarAComer(plantaTocada);
        }
    }
}