namespace BolilleroTest;
using LogicaClass;
using BolilleroClass;

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
        bolillero.SacarBolillas();
        bolillero.SacarBolillas();
        bolillero.SacarBolillas();
        bolillero.SacarBolillas();

        bool rta= bolillero.Gano([0,1,2,3]);
        Assert.Equal(true,rta);
        
    }

}
/*
public void TestSacarBolilla()
    {
        BolilleroTest(10);
        Console.WriteLine("N° bolitas contenidas: "+bolillero.Bolillas.Count);
        Console.WriteLine("N° bolitas sacadas: "+bolillero.SBolillas.Count);
        Console.WriteLine("");
        
        bolillero.SacarBolillas();
        Console.WriteLine("N° bolitas contenidas: "+bolillero.Bolillas.Count);
        Console.WriteLine("N° bolitas sacadas: "+bolillero.SBolillas.Count);

    }

public BolilleroTest(int Cantidad)
    {
        bolillero= new Bolillero(Cantidad);
        bolillero.Metodo= new Orden();
    }
*/