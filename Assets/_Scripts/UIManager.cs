using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public static UIManager Instancia;
    public TextMeshProUGUI textoSoles;

    public int idPlantaSeleccionada = 0;

    public bool modoPalaActivo = false;

    [Header("Tarjetas y Cooldowns")]
    public Image overlayLanzaguisantes;
    public Image overlayGirasol;
    public float cooldownLanzaguisantes = 7.5f;
    public float cooldownGirasol = 7.5f;

    private bool lanzaguisantesListo = true;
    private bool girasolListo = true;

    void Awake()
    {
        Instancia = this;
    }

    public void ActualizarSolesUI(int cantidad)
    {
        textoSoles.text = cantidad.ToString();
    }

    public void SeleccionarLanzaguisantes()
    {
        if (lanzaguisantesListo)
        {
            idPlantaSeleccionada = 1;
            modoPalaActivo = false; 
        }
    }

    public void SeleccionarGirasol()
    {
        if (girasolListo)
        {
            idPlantaSeleccionada = 3;
            modoPalaActivo = false; 
        }
    }

    public void SeleccionarPala()
    {
        modoPalaActivo = true;
        idPlantaSeleccionada = 0; 
    }

    public void DeseleccionarPlanta()
    {
        idPlantaSeleccionada = 0;
        modoPalaActivo = false; 
    }

    public void IniciarCooldown(int idPlanta)
    {
        if (idPlanta == 1)
            StartCoroutine(RutinaCooldown(overlayLanzaguisantes, cooldownLanzaguisantes, 1));
        else if (idPlanta == 3)
            StartCoroutine(RutinaCooldown(overlayGirasol, cooldownGirasol, 3));
    }

    IEnumerator RutinaCooldown(Image overlay, float tiempoCooldown, int idPlanta)
    {
        if (idPlanta == 1) lanzaguisantesListo = false;
        else if (idPlanta == 3) girasolListo = false;

        overlay.fillAmount = 1f;
        float tiempoPasado = 0f;

        while (tiempoPasado < tiempoCooldown)
        {
            tiempoPasado += Time.deltaTime;
            overlay.fillAmount = 1f - (tiempoPasado / tiempoCooldown);
            yield return null;
        }

        overlay.fillAmount = 0f;

        if (idPlanta == 1) lanzaguisantesListo = true;
        else if (idPlanta == 3) girasolListo = true;
    }
}