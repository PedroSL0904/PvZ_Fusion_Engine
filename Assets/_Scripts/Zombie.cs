using UnityEngine;
using System.Collections;

public class Zombi : MonoBehaviour
{
    [Header("Estadísticas")]
    public float saludActual = 100f;
    public float velocidad = 0.5f;
    public float dañoPorSegundo = 20f;

    private Planta plantaObjetivo;
    private SpriteRenderer spriteRenderer;

    private Color colorOriginal;

    void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            colorOriginal = spriteRenderer.color;
        }
    }

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

        if (spriteRenderer != null)
        {
            StartCoroutine(RutinaParpadeo());
        }

        if (saludActual <= 0) Morir();
    }

    IEnumerator RutinaParpadeo()
    {
        spriteRenderer.color = Color.white;

        yield return new WaitForSeconds(0.1f);

        if (spriteRenderer != null)
        {
            spriteRenderer.color = colorOriginal;
        }
    }

    void Morir()
    {
        Destroy(gameObject);
    }
}