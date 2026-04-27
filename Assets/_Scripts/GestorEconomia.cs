using UnityEngine;

public class GestorEconomia : MonoBehaviour
{
    public static GestorEconomia Instancia;

    [Header("Billetera")]
    public int solesActuales = 50; 

    void Awake()
    {
        if (Instancia == null)
        {
            Instancia = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        UIManager.Instancia.ActualizarSolesUI(solesActuales);
    }

    public void AgregarSoles(int cantidad)
    {
        solesActuales += cantidad;
        Debug.Log($"☀️ Soles recogidos. Saldo total: {solesActuales}");
        UIManager.Instancia.ActualizarSolesUI(solesActuales);
    }

    public bool GastarSoles(int costo)
    {
        if (solesActuales >= costo)
        {
            solesActuales -= costo;
            Debug.Log($"💸 Compra exitosa. Saldo restante: {solesActuales}");
            UIManager.Instancia.ActualizarSolesUI(solesActuales);
            return true;
        }

        Debug.LogWarning("❌ ¡No tienes suficientes soles!");
        return false;
    }
}