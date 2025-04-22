namespace BolilleroTest;
using LogicaClass;
using BolilleroClass;

public class BolilleroTest
{
    Bolillero bolillero;
    public BolilleroTest()
    {
        bolillero = new Bolillero(10);
        bolillero.Metodo = new Azar();
    }

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

        var rta= Task<long>.Run( ()=> bolillero.Jugar([0,1,2]));
        rta.Wait();
        Assert.Equal(true, rta.Result);
    }

    [Fact]
    public void JugarPierde()
    {

        var rta= Task<long>.Run( ()=> bolillero.Jugar([4,2,1]));
        rta.Wait();
        Assert.Equal(false, rta.Result);
    }

    [Fact]
    public void GanarNveces()
    {

        var rta= Task<long>.Run(()=> bolillero.JugarNVeces([0,1],1));
        rta.Wait();
        Assert.Equal(1, rta.Result);
    }

    [Fact]
    public void HiloUso()
    {
        Simulacion simulacion= new Simulacion();
        int rta = simulacion.SimularConHilos(bolillero,[0,1,2,3,4,5,6,7,8,9],100,50);
        Assert.Equal(100, rta);
    }
}
