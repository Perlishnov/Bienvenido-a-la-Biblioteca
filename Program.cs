using System;

class Libro
{
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public bool Disponible { get; set; }
}

class Program
{
    static Libro[] catalogo = new Libro[100];
    static int cantidadLibros = 0;

    static void Main(string[] args)
    {
        InicializarCatalogo();

        bool salir = false;
        while (!salir)
        {
            Console.WriteLine("Bienvenido a la Biblioteca");
            Console.WriteLine("1. Agregar libro");
            Console.WriteLine("2. Buscar libro por título");
            Console.WriteLine("3. Buscar libro por autor");
            Console.WriteLine("4. Prestar libro");
            Console.WriteLine("5. Devolver libro");
            Console.WriteLine("6. Mostrar información de libros disponibles");
            Console.WriteLine("7. Salir");
            Console.Write("Ingrese la opción deseada: ");

            string opcion = Console.ReadLine();
            Console.WriteLine();

            switch (opcion)
            {
                case "1":
                    AgregarLibro();
                    break;
                case "2":
                    BuscarLibroPorTitulo();
                    break;
                case "3":
                    BuscarLibroPorAutor();
                    break;
                case "4":
                    PrestarLibro();
                    break;
                case "5":
                    DevolverLibro();
                    break;
                case "6":
                    MostrarLibrosDisponibles();
                    break;
                case "7":
                    salir = true;
                    Console.WriteLine("Gracias por utilizar la Biblioteca. ¡Hasta luego!");
                    break;
                default:
                    Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void InicializarCatalogo()
    {
        catalogo[0] = new Libro { Titulo = "1984", Autor = "George Orwell", Disponible = true };
        catalogo[1] = new Libro { Titulo = "Cien años de soledad", Autor = "Gabriel García Márquez", Disponible = true };
        catalogo[2] = new Libro { Titulo = "Don Quijote de la Mancha", Autor = "Miguel de Cervantes", Disponible = true };
        catalogo[3] = new Libro { Titulo = "Orgullo y prejuicio", Autor = "Jane Austen", Disponible = true };
        catalogo[4] = new Libro { Titulo = "Matar a un ruiseñor", Autor = "Harper Lee", Disponible = true };
        catalogo[5] = new Libro { Titulo = "Ulises", Autor = "James Joyce", Disponible = true };
        catalogo[6] = new Libro { Titulo = "En busca del tiempo perdido", Autor = "Marcel Proust", Disponible = true };
        catalogo[7] = new Libro { Titulo = "El gran Gatsby", Autor = "F. Scott Fitzgerald", Disponible = true };
        catalogo[8] = new Libro { Titulo = "Donde el camino se corta", Autor = "M. Scott Peck", Disponible = true };
        catalogo[9] = new Libro { Titulo = "1984", Autor = "George Orwell", Disponible = true };

        cantidadLibros = 10;
    }

    static void AgregarLibro()
    {
        Console.WriteLine("Agregar nuevo libro");

        if (cantidadLibros >= catalogo.Length)
        {
            Console.WriteLine("El catálogo está lleno. No se pueden agregar más libros.");
            return;
        }

        Console.Write("Título del libro: ");
        string titulo = Console.ReadLine();

        Console.Write("Autor del libro: ");
        string autor = Console.ReadLine();

        catalogo[cantidadLibros] = new Libro { Titulo = titulo, Autor = autor, Disponible = true };
        cantidadLibros++;

        Console.WriteLine("El libro se ha agregado correctamente.");
    }

    static void BuscarLibroPorTitulo()
    {
        Console.WriteLine("Buscar libro por título");

        Console.Write("Ingrese el título del libro: ");
        string tituloBusqueda = Console.ReadLine();

        bool encontrado = false;

        foreach (Libro libro in catalogo)
        {
            if (libro != null && libro.Titulo.Equals(tituloBusqueda, StringComparison.CurrentCultureIgnoreCase))
            {
                Console.WriteLine($"Título: {libro.Titulo}");
                Console.WriteLine($"Autor: {libro.Autor}");
                Console.WriteLine(libro.Disponible ? "Disponible" : "No disponible");
                encontrado = true;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("No se encontró ningún libro con el título proporcionado.");
        }
    }

    static void BuscarLibroPorAutor()
    {
        Console.WriteLine("Buscar libro por autor");

        Console.Write("Ingrese el autor del libro: ");
        string autorBusqueda = Console.ReadLine();

        bool encontrado = false;

        foreach (Libro libro in catalogo)
        {
            if (libro != null && libro.Autor.Equals(autorBusqueda, StringComparison.CurrentCultureIgnoreCase))
            {
                Console.WriteLine($"Título: {libro.Titulo}");
                Console.WriteLine(libro.Disponible ? "Disponible" : "No disponible");
                encontrado = true;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("No se encontró ningún libro con el autor proporcionado.");
        }
    }

    static void PrestarLibro()
    {
        Console.WriteLine("Prestar libro");

        Console.Write("Ingrese el título del libro a prestar: ");
        string tituloBusqueda = Console.ReadLine();

        bool encontrado = false;

        foreach (Libro libro in catalogo)
        {
            if (libro != null && libro.Titulo.Equals(tituloBusqueda, StringComparison.CurrentCultureIgnoreCase))
            {
                if (libro.Disponible)
                {
                    libro.Disponible = false;
                    Console.WriteLine("El libro ha sido prestado con éxito.");
                }
                else
                {
                    Console.WriteLine("El libro no está disponible para prestar en este momento.");
                }

                encontrado = true;
                break;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("No se encontró ningún libro con el título proporcionado.");
        }
    }

    static void DevolverLibro()
    {
        Console.WriteLine("Devolver libro");

        Console.Write("Ingrese el título del libro a devolver: ");
        string tituloBusqueda = Console.ReadLine();

        bool encontrado = false;

        foreach (Libro libro in catalogo)
        {
            if (libro != null && libro.Titulo.Equals(tituloBusqueda, StringComparison.CurrentCultureIgnoreCase))
            {
                if (!libro.Disponible)
                {
                    libro.Disponible = true;
                    Console.WriteLine("El libro ha sido devuelto con éxito.");
                }
                else
                {
                    Console.WriteLine("El libro ya se encuentra disponible.");
                }

                encontrado = true;
                break;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("No se encontró ningún libro con el título proporcionado.");
        }
    }

    static void MostrarLibrosDisponibles()
    {
        Console.WriteLine("Libros disponibles:");

        bool encontrado = false;

        foreach (Libro libro in catalogo)
        {
            if (libro != null && libro.Disponible)
            {
                Console.WriteLine($"Título: {libro.Titulo}");
                Console.WriteLine($"Autor: {libro.Autor}");
                Console.WriteLine();
                encontrado = true;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("No hay libros disponibles en este momento.");
        }
    }
}
