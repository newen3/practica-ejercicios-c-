namespace Practica
{
//manejo de alquileres de distinto vehiculos utilizando herencia.
class Vehiculo
{
    public string marca;
    public string modelo;
    public int ano;

    public Vehiculo(string marca,string modelo, int ano)
    {
        this.marca = marca;
        this.modelo = modelo;
        this.ano = ano;
    }

    public virtual void MostrarDetalles()
    {
        Console.WriteLine("informacion sobre el Vehiculo");
        Console.WriteLine($"Marca: {marca}, Modelo: {modelo}, Año: {ano}");
    }

    public virtual double PrecioAlquiler(int dias)
    {
        return dias * 20.0;// establece un precio base para cualquier vehiculo.
    }

}

class Auto : Vehiculo// clase dericada de vehiculo.
{
    public int cantidadAcientos;

    //creo un contructor para inicializar por defecto las propiedades, hereda las que ya estaba en vehiculo.
    public Auto(string marca,string modelo, int ano,int cantidadAcientos) : base(marca,modelo,ano)
    {
        this.cantidadAcientos = cantidadAcientos;
    }

    //muestra la informacion del vehiculo a alquilar.
    public override void MostrarDetalles()
    {
        Console.WriteLine("AUTO");
        base.MostrarDetalles();
        Console.WriteLine($"cantidad de acientos: {cantidadAcientos}");
    }

    //calcula el precio segun la cantidad de dias para una bicicleta.
    public override double PrecioAlquiler(int dias)
    {
        return (dias * 20.0) + ((dias * 20.0)*(2.0/10.0));//aumenta el precio base un 20 porciento.
    }

}

class Moto : Vehiculo// clase dericada de vehiculo
{
    public int cilindrada;

    //creo un contructor para inicializar por defecto las propiedades, hereda las que ya estaba en vehiculo.
    public Moto(string marca,string modelo,int ano,int cilindrada) : base(marca, modelo,ano)
    {
        this.cilindrada = cilindrada;
    }

    //muestra la informacion del vehiculo a alquilar.
    public override void MostrarDetalles()
    {
        Console.WriteLine("MOTO");
        base.MostrarDetalles();
        Console.WriteLine($"Cilindrada: {cilindrada}");
    }

    //calcula el precio segun la cantidad de dias para una bicicleta.
    public override double PrecioAlquiler(int dias)
    {
        return (dias * 20.0) + (dias*20.0)*(1.0/10.0);//aumenta el precio base en un 10 porciento.
    }
}

class Bicicleta : Vehiculo// clase dericada de vehiculo
{
    public int rodado;

    //creo un contructor para inicializar por defecto las propiedades, hereda las que ya estaba en vehiculo.
    public Bicicleta(string marca, string modelo,int ano, int rodado) : base(marca,modelo,ano)
    {
        this.rodado = rodado;
    }

    //muestra la informacion del vehiculo a alquilar.
    public override void MostrarDetalles()
    {
        Console.WriteLine("BICICLETA");
        base.MostrarDetalles();
        Console.WriteLine($"rodado: {rodado}");
    }

    //calcula el precio segun la cantidad de dias para una bicicleta.
    public override double PrecioAlquiler(int dias)
    {
        return (20.0 * dias);//precio mas barato(precio base)
    }
}

class Alquiler
{
    public Vehiculo vehiculo {get;set;}
    public DateTime fechaDeInicio {get;set;}
    public DateTime fechaDeVencimiento {get;set;} 

    public Alquiler(Vehiculo vehiculo, DateTime fechaDeInicio,DateTime fechaDeVencimiento)
    {
        this.vehiculo = vehiculo;
        this.fechaDeInicio= fechaDeInicio;
        this.fechaDeVencimiento = fechaDeVencimiento;
    }
    //calcula y devuelve la cantidad de dias que estara en alquiler el vehiculo segun la fecha de inicio y la fecha de vencimiento del alquiler.
    public int CalcularDiasDeAlquiler()
    {
        return (fechaDeVencimiento - fechaDeInicio).Days;
    }
    //calcula y devuelve el precio del alquiler del vehiculo.
    public double PrecioAlquiler()
    {
        int diasDeAlquiler = CalcularDiasDeAlquiler();
        return vehiculo.PrecioAlquiler(diasDeAlquiler);
    }
    //muestra toda la informacion del alquiler del vehiculo.
    public void MostrarDetallesDelAlquiler()
    {
        Console.WriteLine("datos sobre el alquiler:");
        Console.WriteLine($"usted alquilo por {CalcularDiasDeAlquiler()} dias:");
        vehiculo.MostrarDetalles();
        Console.WriteLine($"por lo tanto el precio a cobrar es : {PrecioAlquiler()}");
    }

}

class Programa 
{
    static void Main(string[] args)
    {
        Auto auto = new Auto("Renaul","modeloauto",2000,5);
        Bicicleta bicicleta = new Bicicleta("marcabici","modelobici",2023,200);
        Moto moto1 = new Moto("ninja","titan",2020,100);
        Moto moto2 = new Moto("honda","modelmoto",2003,123);

        Alquiler alquiler1 = new Alquiler(moto2,new DateTime(2024, 12, 1), new DateTime(2024, 12, 25));

        alquiler1.MostrarDetallesDelAlquiler();
    }
}
    
}