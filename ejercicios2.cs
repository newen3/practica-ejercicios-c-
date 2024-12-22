namespace MiProyecto 
{


class ArrayDeNumeros
{
    public int[] Numeros = new int[10];  

    public void Ingresar10Enteros()
    {
        string NumeroAConvertir;
        Console.WriteLine("ingrese 10 numeros enteros: ");
    
        for (int i = 0; i < 10; i++)
        {
            NumeroAConvertir = Console.ReadLine();
            Numeros[i] = int.Parse(NumeroAConvertir);
        }
    }

    public void MostrarListaDeNumerosIngresados()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"{Numeros[i]}");
        }
    }

    public int MostrarElNumeroMasPequeno()
    {
        int NumeroMasPequeno = Numeros[0];
        for (int i = 1; i < 10; i++)
        {
            if(Numeros[i] < NumeroMasPequeno)
            {
                NumeroMasPequeno = Numeros[i];
            }
        }
        return NumeroMasPequeno;
    }

    public int MostrarElNumeroMasGrande()
    {
        int NumeroMasGrande = Numeros[0];
        for (int i = 1; i < 10; i++)
        {
            if(Numeros[i] > NumeroMasGrande)
            {
                NumeroMasGrande = Numeros[i];
            }
        }
        return NumeroMasGrande;
    }

}



}