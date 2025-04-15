using LogicaClass;
using BolilleroClass;
class Simulacion
{
    public short SimularSinHilos(Bolillero bolillero, List<short> Jugada, short CVeces)
    {
        short gano=bolillero.JugarNVeces(Jugada,CVeces);
        
        return gano;
    }

    public long SimularConHilos(Bolillero bolillero, List<short> Jugada, short CVeces, short CHilos)
    {
        short gano=0;
        Task<short>[] tareas= new Task<short>[CHilos];
        for(short h=0;h<CHilos;h++)
        {
            var b =bolillero.Clonar();
            tareas[h]=  Task<short>.Run(()=> bolillero.JugarNVeces(Jugada,CVeces));
        }
        
        return gano;
    }
}