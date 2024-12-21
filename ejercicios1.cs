namespace MiProyecto
{

    class Producto
    {
        public string Nombre;
        public double Precio;
        public int Cantidad;
        // constructor que inicializa con todas las propiedades del objeto.
        public Producto(string nombre,double precio, int cantidad)
        {
            this.Nombre = nombre;
            this.Precio = precio;
            this.Cantidad = cantidad;
        }

    }

    class Tienda
    {
        //cree una lista para contener los productos de la tienda.
        public string Nombre;
        public List<Producto> Productos = new List<Producto>();
        // constructor que inicializa con el nombre de la tienda.
        public Tienda(string nombre) 
        {
            this.Nombre = nombre;
        }
        //agrega un producto nuevo a la tienda.
        public void AgregarProducto(Producto ProductoAAgregar)
        {
            Productos.Add(ProductoAAgregar);
            Console.WriteLine($"ahora hay {ProductoAAgregar.Nombre} en la tienda comprelo ya!!!");
        }
        //muestra la lista completa de todos los elementos disponibles en la tienda y sus caracteristica(nombre, etc).
        public void MostrarInventario()
        {
            Console.WriteLine("estos son todos los productos en stock: ");
            foreach (Producto producto in Productos)
            {
                Console.WriteLine($"Nombre: {producto.Nombre}");
                Console.WriteLine($"Precio: {producto.Precio}");
                Console.WriteLine($"Cantidad: {producto.Cantidad}");
            }
        }
        //vende un producto que se le especifique en la cantidad especificada.
        public void VenderProducto(string NombreProducto, int CantidadDelProducto)
        {
            //verificar que haya stock suficiente para la compra.
            foreach (Producto producto in Productos)
            {
            //verifica que el producto especificado tenga stock.
                if((producto.Nombre == NombreProducto) && (producto.Cantidad >= CantidadDelProducto ))
                {
                    producto.Cantidad -= CantidadDelProducto;
                    Console.WriteLine($"has comprado exitosamente {CantidadDelProducto} {producto.Nombre} ");
                    Console.WriteLine($"stock disponible de ese producto {producto.Cantidad}");
                }    
                if((producto.Nombre == NombreProducto) && (producto.Cantidad < CantidadDelProducto ))
                {
                    Console.WriteLine($"no puede vender tanta cantidad de {NombreProducto} ya que no hay tanto , intente con una cantidad menor");
                }
            }
        }
        //devuelve el valor total de todos los productos en stock.
        public int CalcularTotalInventario()
        {
            int CantidadTotalDelInventario = 0;
            //recorre la lista sumando la cantidad total de todos los productos.
            foreach (Producto producto in Productos)
            {
                CantidadTotalDelInventario += producto.Cantidad;
            }
            return CantidadTotalDelInventario;
        }

    }

    class Calculadora() 
    {
        public int NumeroA =0;
        public int NumeroB =0;

        public int Sumar(int A, int B)
        {
            return A + B;
        }

        public int Restar(int A, int B)
        {
            return A - B;
        }

        public int Multiplicar(int A,int B)
        {
            return A * B;
        }

        public int? Dividir(int A,int B)
        {
            if (B == 0)
            {
                Console.WriteLine("la divicion por cero no esta defininda.");
                return 0;
            }
            else 
            {
                return A/B;
            }
        }

    }

    class Alumno
    {
        public string Nombre;
        public int Edad;

        public Alumno(string Nombre,int Edad)
        {
            this.Nombre = Nombre;
            this.Edad = Edad;
        }
    }

    class Curso
    {
        public string Nombre;

        public Curso(string Nombre)
        {
            this.Nombre = Nombre;
        }
        // crea una lista de objetos de tipo Alumno.
        List<Alumno> alumnos = new List<Alumno>();

        public void AgregarAlumno(string NombreAgregar, int EdadAgregar)
        {
        //agrega un nuevo objeto de tipo alumno al final de la lista.
            alumnos.Add(new Alumno(NombreAgregar,EdadAgregar));
        }
        
        public void MostrarAlumnos() 
        {
        //recorre la lista de alumnos y imprime su contenido.
            foreach (Alumno alumno in alumnos)
            {
                Console.WriteLine($"lista completa de alumnos: Nombre: {alumno.Nombre} , Edad: {alumno.Edad}");

            }

        }
    }




    class Rectangulo
    {
        public int ancho;
        public int alto;

        public Rectangulo()
        {
            this.ancho = 0;
            this.alto = 0;
        }

        public int calcularArea()
        {
            return ancho * alto;
        }

        public int calcularPerimetro()
        {
            return 2 * (ancho + alto);
        }
    }


    class CuentaBancaria
    {
        public int NumeroCuenta = 0;
        public double Saldo;

        public CuentaBancaria(double SaldoPredeterminado)
        {
            this.Saldo = SaldoPredeterminado;
        }

        public double Depositar(double SaldoAAgregar)
        {
            Saldo = Saldo + SaldoAAgregar;
            return Saldo;
        }

        public double Retirar(double SaldoAExtraer)
        {
            if(SaldoAExtraer > Saldo) 
            {
                Console.WriteLine("la operacion no se puede realizar porque no hay suficiente dinero en la cuenta.");
            } 
            else
            {
                Saldo = Saldo - SaldoAExtraer;
            }
            return Saldo;
        }

        public void MostrarSaldo()
        {
            Console.WriteLine($"saldo actual de la cuenta: {Saldo}");
        }

    }

}
