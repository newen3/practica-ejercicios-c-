using System;


class Libro
{
    public string Nombre;
    public string Autor;
    public bool Disponibilidad;

    public Libro(string Nombre, string Autor, bool Disponibilidad)
    {
        this.Nombre = Nombre;
        this.Autor = Autor;
        this.Disponibilidad = Disponibilidad;
    }

    public void PrestarLibro()
    {
        if(Disponibilidad == true)
        {
            Disponibilidad = false;
            Console.WriteLine($"te emos prestado el libro {Nombre}");
        }
        else 
        {
            Console.WriteLine($"parece que ya as pedido {Nombre} tienes que devolverlo");
        }
    }

    public void DevolverLibro()
    {
        if(Disponibilidad == false)
        {
            Disponibilidad = true;
            Console.WriteLine($"gracias por devolver el libro {Nombre} ahora puedes pedir otra ves");
        }
        else
        {
            Console.WriteLine($"parece que no le debes ningun libro a la biblioteca");
        }
    }
}

class Biblioteca
{
    public List<Libro> Libros = new List<Libro>();

    public void AgregarLibro(Libro LibroAIngresar)
    {
        if(BuscarLibro(LibroAIngresar.Nombre) == null)
        {
            Libros.Add(LibroAIngresar);
            Console.WriteLine($"se ingreso el libro {LibroAIngresar.Nombre} correctamente");
        }
        else
        {
            Console.WriteLine($"el libro {LibroAIngresar.Nombre} no se ingreso porque ya esta en la biblioteca");
        }
    }

    public void MostrarLibros()
    {
        foreach (Libro libro in Libros)
        {
            Console.WriteLine($"Nombre: {libro.Nombre} , Autor: {libro.Autor}, disponibilidad: {libro.Disponibilidad}");
        }
    }

    public void MostrarLibrosDisponibles()
    {
        Console.WriteLine($"LISTA DE LIBROS DISPONIBLES: ");
        foreach (Libro libro in Libros)
        {
            if(libro.Disponibilidad == true)
            {
                Console.WriteLine($"Nombre: {libro.Nombre}");
                Console.WriteLine($"Escritor: {libro.Autor}");
            }
        }
    }

    public Libro BuscarLibro(string Nombre)
    {
        foreach (Libro libro in Libros)
        {
            if(Nombre == libro.Nombre)
            {
                return libro;
            }
        }
        return null;
    }
}


class Programa
{
    static void Main(string[] args)
    {
        Libro PrimerLibro = new Libro("Guia del autoestopista galactico","Douglas Adams",true);
        Libro SegundoLibro = new Libro("los ojos del perro siberiano","Antonio Santa Ana",true);
        Libro TercerLibro = new Libro("El universo en una cascara de nuez","stephen hawking",true);

        Biblioteca MyBiblioteca = new Biblioteca();

        MyBiblioteca.AgregarLibro(PrimerLibro);
        MyBiblioteca.AgregarLibro(SegundoLibro);
        MyBiblioteca.AgregarLibro(TercerLibro);

        MyBiblioteca.AgregarLibro(SegundoLibro);

        PrimerLibro.PrestarLibro();
        SegundoLibro.PrestarLibro();
        SegundoLibro.PrestarLibro();

        SegundoLibro.DevolverLibro();
        SegundoLibro.PrestarLibro();


        MyBiblioteca.MostrarLibrosDisponibles();
    }
}