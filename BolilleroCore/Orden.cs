using BolilleroClass;
namespace LogicaClass;

public class Orden: Logica
{
    public override void SacarBolillas(Bolillero bolillero)
    {
        bolillero.SBolillas.Add(bolillero.Bolillas[0]);
        bolillero.Bolillas.RemoveAt(0);
    }
}