using System.Collections.Generic;
using LogicaClass;
namespace BolilleroClass;

public class Bolillero
{
    public List<short> Bolillas= new List<short>();
    public List<short> SBolillas= new List<short>();
    public short NVeces;

    public Logica Metodo;

    public Bolillero(short CantidadB)
    {
        for(short b=0;b<CantidadB;b++)
        {
            Bolillas.Add(b);
        }
    }

    public Bolillero(List<short> cantidad)
    {
        Bolillas=cantidad;
    }

    public void DevolverBolillas()
    {
        if(SBolillas.Count>0)
        for(int n=0;n< SBolillas.Count;n++)
        {
            Bolillas.Add(SBolillas[n]);
        }
        SBolillas.Clear();
    }

    public void SacarBolillas()
    {
            Metodo.SacarBolillas(this);
    }

    public bool Jugar(List<short> c)
    {
        bool rta=true;
        for(short b=0;b<c.Count;b++)
        {
            SacarBolillas();
            if(c[b]!=SBolillas[b])
            rta=false;
        }
        
    return rta;
    }

    public short JugarNVeces(List<short> jugada, short cantidad)
    {
        short gano=0;
        for(short c=0;c<cantidad;c++)
        {
            if(Jugar(jugada))
            gano++;

            DevolverBolillas();
        }
        return gano;
    }
}

