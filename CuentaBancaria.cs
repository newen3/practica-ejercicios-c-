
//ejercicios de encapsulamiento cuenta bancaria.
//
class CuentaBancaria
{
    public int numeroDeCuenta {get; set;}
    public int saldo {get; private set;}
    public string titular {get;set;}
    public int limiteDeCredito {get;set;}

    //constructor que permite dar valores por defecto a las propiedades de la clase.
    public CuentaBancaria(int numeroDeCuenta, int saldo, string titular, int limiteDeCredito)
    {
        this.numeroDeCuenta = numeroDeCuenta;        
        this.saldo = saldo;
        this.titular = titular;
        this.limiteDeCredito = limiteDeCredito;      
    }
    //deposita dinero en la cuenta.
    public void Depositar(int CantidadADepositar)
    {
        saldo += CantidadADepositar;
        Console.WriteLine($"se a ingresado US$ {CantidadADepositar} en la cuenta");
    }
    //retira una cantidad de dinero del saldo de la cuenta si la cantidad no supera a la suma del saldo y el limite de credito de la cuenta, 
    //si la cantidad es mayor al saldo etonces tambien quitara dinero del credito dejando al saldo en cero.
    public void Retirar(int CantidadARetirar)
    {
        int saldoInicial = saldo;
        int limiteDeCreditoInicial = limiteDeCredito;
        if(!(CantidadARetirar > (saldo + limiteDeCredito)))
        {
            RetirarDineroSegunCorresponda(CantidadARetirar);
        }
        else
        {
            Console.WriteLine("la cantidad que quiere retirar supera el saldo de la cuenta mas el limite de credito");
        }
    }

    //trasfiere una cantidad de dinero a una cuenta si la cantidad de dinero a trasferir no supera la suma del saldo y el limite de credito,
    //ademas si la cantidad a trasferir es mayor que el saldo entonces resta la cantidad a trasferir al saldo y lo que falte lo repone con el credito 
    //dejando el saldo en 0 y dejando el credito en una cantidad menor. 
    public void Transferir(CuentaBancaria cuentaATrasferir,int cantidadATrasferir)
    {
        if(!(cantidadATrasferir > (saldo + limiteDeCredito)))
        {
            TransferirDineroSegunCorresponda(cuentaATrasferir,cantidadATrasferir);
        }
        else
        {
            Console.WriteLine("la cantidad que quieres trasferir supera al saldo mas el limite de credito, ingresa una cantidad menor");
        }
    }

    //ademas si la cantidad a trasferir es mayor que el saldo entonces resta la cantidad a trasferir al saldo y lo que falte lo repone con el credito 
    //dejando el saldo en 0 y dejando el credito en una cantidad menor. si no solo transfiere la cantidad de dinero a la cuenta y resta la cantidad al saldo. 
    public void TransferirDineroSegunCorresponda(CuentaBancaria cuentaATrasferir,int cantidadATrasferir)
    {
        if(cantidadATrasferir > saldo)
        {
            cuentaATrasferir.saldo += cantidadATrasferir;
            saldo -=cantidadATrasferir;
            limiteDeCredito += saldo;
            saldo = 0;
            Console.WriteLine($"trasferiste US$ {cantidadATrasferir} a la cuenta de {cuentaATrasferir.titular} , tu saldo ahora es de 0 y tu credito en {limiteDeCredito}");
        } 
        else
        {
            cuentaATrasferir.saldo += cantidadATrasferir;
            saldo -= cantidadATrasferir;
            Console.WriteLine($"trasferiste US$ {cantidadATrasferir} a la cuenta de {cuentaATrasferir.titular}, tu saldo es ahora es de {saldo}");
        } 
    }
 
    public void RetirarDineroSegunCorresponda(int CantidadARetirar)
    {
        if(CantidadARetirar > saldo)
        {
            saldo -= CantidadARetirar;
            limiteDeCredito += saldo;
            saldo = 0;
            Console.WriteLine($"se retiro el saldo de la cuenta quedando en 0 y como la cantidad a retirar era mayor que el saldo se utilizo el credito quedando en {limiteDeCredito}");
        } 
        else
        {
            saldo -= CantidadARetirar;
            Console.WriteLine($"se retiro {CantidadARetirar} del saldo quedando el saldo en {saldo}");
        }   
    }

}


class Programa 
{
    static void Main(string[] args)
    {
        //instancio las clases que voy ausar y les doy valores a las propiedades por defecto.
        CuentaBancaria MyCuentaBancaria = new CuentaBancaria(1233,1000,"Romina",500);
        CuentaBancaria CuentaAmigo = new CuentaBancaria(2341,10,"Julieta",400);

        //no puede se accesida porque la definicion de la propiedad en set es privada.
        // CuentaAmigo.saldo = 2000;

        //utilizo lo metodos
        MyCuentaBancaria.Retirar(1200);
        MyCuentaBancaria.Transferir(CuentaAmigo,250);
        Console.WriteLine($"julieta tiene de saldo {CuentaAmigo.saldo}");

        CuentaAmigo.Transferir(MyCuentaBancaria,260);

        Console.WriteLine($"Romina tiene de saldo {MyCuentaBancaria.saldo}");

    }
 
}




