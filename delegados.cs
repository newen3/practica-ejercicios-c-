using system;

//calculadora flexible con delegados.

//declaracion del delegado para usar con dos parametros de tipo double.
public delegate double Operacion(double numero1,double numero2);

class Calculadora
{
    public double Sumar(double numero1,double numero2) => numero1 + numero2;
    public double Restar(double numero1,double numero2) => numero1 - numero2;
    public double Multiplicar(double numero1,double numero2) => numero1 * numero2;

    public double Dividir(double numero1,double numero2)
    {
        if(numero2 == 0)
        {
            throw new DivideByZeroException("No se puede dividir por cero.");
        }
        else
        {
            return numero1 / numero2;
        }
    }
}


class GestorCalculadora : Calculadora
{
    //propiedades del objeto.

    public int opcion {get;private set;}
    public double numero1 {get;private set;}
    public double numero2 {get;private set;}

    public void PedirDatosAlUsuario()
    {
        //pide al usuario ingresar datos.
        Console.WriteLine("que operacion quiere usar:");
        Console.WriteLine("suma precione 1");
        Console.WriteLine("resta precione 2");
        Console.WriteLine("multiplicacion precione 3");
        Console.WriteLine("divicion precione 4");
        
        opcion = Convert.ToInt32(Console.ReadLine()); 

        Console.WriteLine("ingrese un numero para la operacion: ");
        numero1 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("ingrese el segundo numero para la operacion");
        numero2 = Convert.ToDouble(Console.ReadLine());

    }
    // da inicio a la utilidad de la calculadora en si dependiendo de los datos que haya introducido el usuario.
    public double Calcular()
    {
        //inicializa el delegado con valor null.
        Operacion? operacion = null;

        //elige que metodo va tener el delegado segun el valor de opcion que habia indicado el usuario.
        switch (opcion)
        {  
            case 1:
                operacion = base.Sumar;
                break;
            case 2: 
                operacion = base.Restar;
                break;
            case 3: 
                operacion = base.Multiplicar;
                break;
            case 4: 
                operacion = base.Dividir;
                break;
            default: 
                Console.WriteLine("opcion no valida");
                break;
        }
        return operacion(numero1,numero2);
    }


}


class Programa 
{
    static void Main(string[] args)
    {
        GestorCalculadora MyCalc = new GestorCalculadora();

        MyCalc.PedirDatosAlUsuario();

        double resultado = MyCalc.Calcular();

        Console.WriteLine($"resutado: {resultado}");

    }
}
