namespace BolilleroTest;
using LogicaClass;
using BolilleroClass;
using Microsoft.VisualBasic;

public class BolilleroTest
{
    Bolillero bolillero;

    [Fact]
    public void SacarBolilla()
    {
        bolillero= new Bolillero(10);
        bolillero.Metodo= new Orden();

        Assert.Equal(10,bolillero.Bolillas.Count);
        Assert.Equal(0,bolillero.SBolillas.Count);
        
        bolillero.SacarBolillas();
        Assert.Equal(9,bolillero.Bolillas.Count);
        Assert.Equal(1,bolillero.SBolillas.Count);
    }
    
    [Fact]
    public void Reingresar()
    {
        bolillero= new Bolillero(10);
        bolillero.Metodo= new Orden();
        Assert.Equal(10,bolillero.Bolillas.Count);

        bolillero.SacarBolillas();
        Assert.Equal(9,bolillero.Bolillas.Count);
        Assert.Equal(1,bolillero.SBolillas.Count);

        bolillero.DevolverBolillas();
        Assert.Equal(10,bolillero.Bolillas.Count);
        Assert.Equal(0,bolillero.SBolillas.Count);

    }

    [Fact]
    public void JugarGana()
    {
        bolillero= new Bolillero([0,1,2,3]);
        bolillero.Metodo= new Orden();

        var rta= Task<long>.Run( ()=> bolillero.Jugar([0,1,2]));
        rta.Wait();
        Assert.Equal(true, rta.Result);
    }

    [Fact]
    public void JugarPierde()
    {
        bolillero= new Bolillero([4,2,1]);
        bolillero.Metodo= new Orden();

        var rta= Task<long>.Run( ()=> bolillero.Jugar([0,1,2]));
        rta.Wait();
        Assert.Equal(false, rta.Result);
    }

    [Fact]
    public void GanarNveces()
    {
        bolillero= new Bolillero([0,1]);
        bolillero.Metodo= new Orden();

        var rta= Task<long>.Run(()=> bolillero.JugarNVeces([0,1],1));
        rta.Wait();
        Assert.Equal(1, rta.Result);
    }
}

