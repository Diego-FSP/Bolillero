using LogicaClass;
using BolilleroClass;
using System.Threading.Tasks;
public class Simulacion
{
    public int SimularSinHilos(Bolillero bolillero, List<int> Jugada, int CVeces)
    {
        int gano=bolillero.JugarNVeces(Jugada,CVeces);
        
        return gano;
    }

    public int SimularConHilos(Bolillero bolillero, List<int> Jugada, int CVeces, int CHilos)
    {
        int gano=0;
        Task<int>[] tareas= new Task<int>[CHilos];
        
        for(int h=0;h<CHilos;h++)
        {
            //Bolillero b = bolillero;
            tareas[h]=  Task.Run<int>(()=> bolillero.Clonar().JugarNVeces(Jugada,CVeces / CHilos));
        }
        
        Task<int>.WaitAll();

        for(int h=0;h<CHilos;h++)
        {
            gano+=tareas[h].Result;
        }
        return gano;
    }

//ASYNC|-----------------------------------------------------------------------------------------------------------------------------------------------------
    public async Task<int> SimularConHilosAsync(Bolillero bolillero, List<int> Jugada, int CVeces, int CHilos)
    {
        int gano=0;
        Task<int>[] tareas= new Task<int>[CHilos];
        
        for(int h=0;h<CHilos;h++)
        {
            //Bolillero b = bolillero;
            tareas[h]= Task.Run<int>(()=> bolillero.Clonar().JugarNVeces(Jugada,CVeces / CHilos));
        }

        await Task.WhenAll(tareas);
        

        for(int h=0;h<CHilos;h++)
        {
            gano+=tareas[h].Result;
        }
        return gano;
    }

    public async Task<int> SimularParallelAsync(Bolillero bolillero, List<int> Jugada, int CVeces, int CHilos)
    {
        int gano=0;
        int[] jugadas= new int[CHilos];
        await Task.Run( () =>
            Parallel.For(0,
            CHilos, 
            i=>
                {                    
                    jugadas[i] =+ bolillero.Clonar().JugarNVeces(Jugada,CVeces/CHilos);
                    
                }
            )
        );

        for(int c=0;c<CHilos;c++)
        gano+=jugadas[c];
        
        return gano;
    }
//|----------------------------------------------------------------------------------------------------------------------------------------------------------
}