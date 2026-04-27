using UnityEngine;
using TMPro; 

public class UIManager : MonoBehaviour
{
    public static UIManager Instancia;

    public TextMeshProUGUI textoSoles;

    public int idPlantaSeleccionada = 1;

    void Awake()
    {
        Instancia = this;
    }

    public void ActualizarSolesUI(int cantidad)
    {
        textoSoles.text = cantidad.ToString();
    }

    public void SeleccionarLanzaguisantes() { idPlantaSeleccionada = 1; }
    public void SeleccionarGirasol() { idPlantaSeleccionada = 3; }
}