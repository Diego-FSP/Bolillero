using LogicaClass;
namespace BolilleroClass;

public class Bolillero
{
    public List<int> Bolillas= new List<int>();
    public List<int> SBolillas= new List<int>();
    public int NVeces;

    public Logica Metodo;

    public Bolillero(int CantidadB)
    {
        for(int b=0;b<CantidadB;b++)
        {
            Bolillas.Add(b);
        }
    }

    private Bolillero(Bolillero original)
    {
        Metodo = original.Metodo;
        Bolillas = new List<int>(original.Bolillas);
        SBolillas = new List<int>(original.SBolillas);
    }

    public void DevolverBolillas()
    {
        if(SBolillas.Count>0)
            Bolillas.AddRange(SBolillas);
        SBolillas.Clear();
    }

    public void SacarBolillas()
    {
            Metodo.SacarBolillas(this);
    }

    public bool Jugar(List<int> c)
    {        
        for(int b=0;b<c.Count;b++)
        {
            SacarBolillas();
            if(c[b]!=SBolillas[b])
            return false;
        }        
        return true;
    }

    public int JugarNVeces(List<int> jugada, int cantidad)
    {
        int gano=0;
        for(int c=0;c<cantidad;c++)
        {
            if(Jugar(jugada))
                gano++;

            DevolverBolillas();
        }
        return gano;
    }

    public Bolillero Clonar() => new Bolillero(this);
}

