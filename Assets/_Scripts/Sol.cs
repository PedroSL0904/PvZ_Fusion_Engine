using System.Collections;
using UnityEngine;

public class Sol : MonoBehaviour
{
    public int valor = 25;
    public float tiempoDeVida = 15f;

    private Collider2D miCollider;

    void Awake()
    {
        miCollider = GetComponent<Collider2D>();
    }

    public void ConfigurarCaida(float destinoY)
    {
        StartCoroutine(RutinaCaida(destinoY));
        Destroy(gameObject, tiempoDeVida); 
    }

    IEnumerator RutinaCaida(float destinoY)
    {
        float velocidadCaida = 2f;
        while (transform.position.y > destinoY)
        {
            transform.Translate(Vector3.down * velocidadCaida * Time.deltaTime);
            yield return null;
        }
    }

    public void ConfigurarParabola(Vector2 origen)
    {
        StartCoroutine(RutinaParabola(origen));
        Destroy(gameObject, tiempoDeVida); 
    }

    IEnumerator RutinaParabola(Vector2 origen)
    {
        float duracionSalto = 0.6f;
        float tiempo = 0f;

        Vector2 destino = origen + new Vector2(Random.Range(-0.8f, 0.8f), Random.Range(-0.8f, 0.2f));
        float alturaMaxima = 1.5f;

        while (tiempo < duracionSalto)
        {
            tiempo += Time.deltaTime;
            float t = tiempo / duracionSalto; 

            float x = Mathf.Lerp(origen.x, destino.x, t);
            float y = Mathf.Lerp(origen.y, destino.y, t) + Mathf.Sin(t * Mathf.PI) * alturaMaxima;

            transform.position = new Vector2(x, y);
            yield return null;
        }
    }

    public void RecolectarYVolar()
    {
        if (miCollider != null) miCollider.enabled = false;

        StopAllCoroutines();

        StartCoroutine(RutinaVueloUI());
    }

    IEnumerator RutinaVueloUI()
    {
        float velocidadVuelo = 15f;

        while (true)
        {
            Vector3 posPantallaUI = UIManager.Instancia.textoSoles.transform.position;
            Vector3 destinoWorld = Camera.main.ScreenToWorldPoint(posPantallaUI);

            transform.position = Vector3.MoveTowards(transform.position, destinoWorld, velocidadVuelo * Time.deltaTime);

            if (Vector3.Distance(transform.position, destinoWorld) < 0.5f)
            {
                GestorEconomia.Instancia.AgregarSoles(valor);
                Destroy(gameObject);
                yield break; 
            }

            yield return null;
        }
    }
}