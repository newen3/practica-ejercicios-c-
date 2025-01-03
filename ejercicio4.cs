using System;
using Practica;

public abstract class Viaje 
{
    //los tipos de clases en los que se separan todos los viajes , tipo1 mas varato, tipo 3 mas caro. 
    public enum ClaseViaje
    {
        Clase1,
        Clase2,
        Clase3
    }
    //definicion de las propiedades que tendran todos los viajes
    public string Destino {get;set;}
    public ClaseViaje TipoViaje {get;set;} 
    public int Duracion {get;set;}
    public double CostoBase{get;set;}
    public bool EstadoReservacion = false;

    //contructor de la clase abstracta.
    public Viaje(string destino,int duracion,ClaseViaje tipoViaje,double costoBase)
    {
        this.Destino = destino;
        this.TipoViaje = tipoViaje;
        this.Duracion = duracion;
        this.CostoBase = costoBase;
    }


    //metodo abstracto que calcula el costo total del viaje segun el tipo de viaje.
    abstract public double CalcularCostoTotal();

    //imprime la informacion basica del viaje.
    public void ImprimirDetalles()
    {
        Console.WriteLine("INFORMACION GENERAL DEL VIAJE: ");
        Console.WriteLine($"Destino: {Destino}");
        Console.WriteLine($"Duracion: {Duracion}");
        Console.WriteLine($"Costo Base: {CostoBase}");
    }

}

//interfas contiene el/los metos que utilizaran todos los viajes.
interface IReservable
{
    //metodos que todo viaje tiene que contener.

    //pone en true el estado de la reservacion , si la variable esta en true muestra un mensaje por consola diciendo que la reservacion ya esta echa.
    void Reservar();

    //cancela el estado de la reservacion si esta en true, si esta en false muestra un mensaje por consola diciendo que la reservacion no existe.
    void CancelaReservacion();

    //devuelve muestra el estado de la reservacion actualmente.
    void ChequearEstadoDeReservacion();
 
}

class ViajeAvion : Viaje, IReservable
{

    //contructor de la clase viaje en avion.
    public ViajeAvion(string destino,int duracion,ClaseViaje tipoViaje,double costoBase) : base(destino,duracion,tipoViaje,costoBase)
    {
    }

    //calcula el costo total del viaje segun el tipo de clase en la que viaje el pasajero.

    public override double CalcularCostoTotal()
    {
        switch (TipoViaje)
        {
            case ClaseViaje.Clase1:
                return CostoBase * 2.0;
            case ClaseViaje.Clase2:
                return CostoBase * (7.0/3.0);
            case ClaseViaje.Clase3:
                return CostoBase * (10.0/3.0);
            default:
                throw new InvalidOperationException("El tipo de viaje no es válido."); // Lanza una excepción si no es válido

        }
    } 

    public void Reservar()
    {
        if (EstadoReservacion == false)
        {
            EstadoReservacion = true;
        }
        else
        {
            Console.WriteLine($"no puede volver a reservar un viaje en avion a {Destino} porque ya esta reservada");
        }
    }
    
    public void CancelaReservacion()
    {
        if(EstadoReservacion == true)
        {
            EstadoReservacion = false;
        }
        else
        {
            Console.WriteLine($"no puede cancelar la reservacion en avion a {Destino}, porque no existe una reservacion");
        }
    }

    public void ChequearEstadoDeReservacion()
    {
        Console.WriteLine($"estado de la reservacion del viaje en avion a {Destino}: {EstadoReservacion}");
    }


}

class ViajeBarco : Viaje, IReservable
{

    public ViajeBarco(string destino,int duracion,ClaseViaje tipoViaje,double costoBase) : base(destino,duracion,tipoViaje,costoBase)
    {

    }

    public void Reservar()
    {
        if (EstadoReservacion == false)
        {
            EstadoReservacion = true;
        }
        else
        {
            Console.WriteLine($"no puede volver a reservar un viaje en barco a {Destino} porque ya esta reservada");
        }
    }

    public override double CalcularCostoTotal()
    {
        switch (TipoViaje)
        {
            case ClaseViaje.Clase1:
                return CostoBase * 2;
            case ClaseViaje.Clase2:
                return CostoBase * (3/2);
            case ClaseViaje.Clase3:
                return CostoBase * (10/3);
            default:
                throw new InvalidOperationException("El tipo de viaje no es válido."); // Lanza una excepción si no es válido
        }
    } 

    public  void CancelaReservacion()
    {
        if(EstadoReservacion == true)
        {
            EstadoReservacion = false;
        }
        else
        {
            Console.WriteLine($"no puede cancelar la reservacion en barco a {Destino}, porque no existe una reservacion");
        }
    }

    public void ChequearEstadoDeReservacion()
    {
        Console.WriteLine($"estado de la reservacion del viaje en barco a {Destino}: {EstadoReservacion}");
    }

}

class ViajeBuss : Viaje, IReservable
{
    public int NumeroParadas{get;set;}

    public ViajeBuss(string destino,int duracion,ClaseViaje tipoViaje,int numeroParadas,double costoBase) : base(destino,duracion,tipoViaje,costoBase)
    {
        this.NumeroParadas = numeroParadas;
    }

    public override double CalcularCostoTotal()
    {
       return CostoBase + (NumeroParadas * 100);
    } 

    public void Reservar()
    {
        if (EstadoReservacion == false)
        {
            EstadoReservacion = true;
        }
        else
        {
            Console.WriteLine($"no puede volver a reservar un viaje en Buss a {Destino} porque ya esta reservada");
        }
    }

    public void CancelaReservacion()
    {
        if(EstadoReservacion == true)
        {
            EstadoReservacion = false;
        }
        else
        {
            Console.WriteLine($"no puede cancelar la reservacion en buss a {Destino}, porque no existe una reservacion");
        }
    }

    public void ChequearEstadoDeReservacion()
    {
        Console.WriteLine($"estado de la reservacion del viaje en buss a {Destino}: {EstadoReservacion}");
    }

}


class Programa 
{
    static void Main(string[] args)
    {
        //variable que representa el costo base de cualquier viaje , ese costo base lo indico aca porque podria ser variable en el tiempo(la empresa podria aumentarlo)
        double costoBase = 200.0;

        Console.WriteLine($"indique el destino de su viaje: ");
        string destino = Console.ReadLine();


        ViajeBuss MyViaje = new ViajeBuss(destino,5,Viaje.ClaseViaje.Clase1,15,costoBase); 

        MyViaje.ImprimirDetalles();

        Console.WriteLine("costo total del micro");
        Console.WriteLine($"{MyViaje.CalcularCostoTotal()}");

    }
}

