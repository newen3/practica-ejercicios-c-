//espacios de nombres utilizados.
using System;
using MiProyecto;
using System.Collections.Generic;


namespace MiProyecto
{
        class Programa 
    {
        static void Main(string[] args)
        {
        //creo la tineda.
        Tienda MyTienda = new Tienda("Perez");

        //instancio los producto.
        Producto yerva = new Producto("yerva",5,40);
        Producto mermelada = new Producto("mermelada",9,70);
        Producto azucar = new Producto("azucar",10,13);

        //agregos los productos.
        MyTienda.AgregarProducto(yerva);
        MyTienda.AgregarProducto(mermelada);
        MyTienda.AgregarProducto(azucar);

        MyTienda.VenderProducto("mermelada",21);


        /* PLANTILLA PARA CREAR OBJETOS.
            //crea un objeto.
            Auto miAuto = new Auto("amarillo","modelo",0);
            miAuto.color = "Rojo";
            miAuto.modelo = "voyage ranger";
            miAuto.ano = 2017;
            //muestra por consola las propiedades del objeto
            Console.WriteLine($" color del auto: {miAuto.color}");
            Console.WriteLine($"modelo del auto: {miAuto.modelo} del año {miAuto.ano}");

            //llama a los metodos.
            miAuto.arrancar();
            miAuto.acelerar(100);
            miAuto.cambiarColor("Azul");
            Console.WriteLine($"el auto cambio de color ahora es de color {miAuto.color}");
        */ 
        }
    }
}


