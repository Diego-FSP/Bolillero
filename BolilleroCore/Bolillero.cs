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
        NVeces=1;
    }

    public Bolillero(List<short> cantidad)
    {
        Bolillas=cantidad;
        NVeces=1;
    }

    public Bolillero(List<short> cantidad, short veces)
    {
        Bolillas=cantidad;
        NVeces=veces;
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

    public bool Gano(List<short> c)
    {
        bool rta=true;
        for(short b=0;b<SBolillas.Count;b++)
        if(c[b]!=Bolillas[b])
        rta=false;

        return rta;
    }
}

