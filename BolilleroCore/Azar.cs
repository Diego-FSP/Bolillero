using BolilleroClass;

namespace LogicaClass;

class Azar: Logica
{
    Random azar= new Random();
    public override void SacarBolillas(Bolillero bolillero)
    {
        int indice= azar.Next(0,bolillero.Bolillas.Count);
        bolillero.SBolillas.Add(bolillero.Bolillas[indice]);
        bolillero.Bolillas.RemoveAt(indice);
    }
}