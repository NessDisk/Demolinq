// See https://aka.ms/new-console-template for more information

// ----

LinqQueries queries = new LinqQueries();

// ----

// ImprimirValores(queries.TodaLaColeccion());

// ImprimirValores(queries.TodaLaColeccionMayorDel2000());

// ----

// ImprimirValores(queries.TodaLaColeccionConMasDe250Pag());



void ImprimirValores(IEnumerable<Book> listadelibros)
{
    Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
    foreach(var item in listadelibros)
    {
        Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}

void ImprimirGrupo(IEnumerable<IGrouping<int,Book>> ListadeLibros)
{
    foreach(var grupo in ListadeLibros)
    {
        Console.WriteLine("");
        Console.WriteLine($"Grupo: { grupo.Key }");
        Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
        foreach(var item in grupo)
        {
            Console.WriteLine("{0,-60} {1, 15} {2, 15}",item.Title,item.PageCount,item.PublishedDate.Date.ToShortDateString()); 
        }
    }
}


void ImprimirDiccionario(ILookup<char, Book> ListadeLibros, char letra)
{
   Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
   foreach(var item in ListadeLibros[letra])
   {
         Console.WriteLine("{0,-60} {1, 15} {2, 15}",item.Title,item.PageCount,item.PublishedDate.Date.ToShortDateString()); 
   }
}

// ----
//Ejemplo de operador All y Any
// Console.WriteLine("Todos tienen estatus : " + queries.TodosLoslibrosTienenStatus());
// Console.WriteLine("algunos tienen estatus : " + queries.AlgunosTienenStatus());
// Console.WriteLine("algunos libro lanzado en 2005 : " + queries.AlgunLibroLanzadoEn2005());
// ----
// Ejemplo  uso del operador contains 
// ImprimirValores(queries.LibrosDePhyton());

//Ejemplo libros ordenados por el nombre por el nombre
// ImprimirValores(queries.LibrosJavaOrdenasdosPorNombre());

// ejemplo de libros ordenados por el numero de paginas de manera desendente
// ImprimirValores(queries.LibrosConMasDe450PagDesn()); 

// Ejemplo del operador Take. Se trae los primeros cuatro libros de la condicion.
    // ImprimirValores(queries.Primeros4LibrosDeJava());

// Ejemplo del operador Skip, Que salta una cierta cantidad de valores de la lista.
    // ImprimirValores(queries.TercerYCuartoLibroConMasDe400Pags());

// Ejemplo de Select
// Ya que solo hay hay 2 tables la fecha es nula y la funcion la pone por defecto como "1/01/0001"
// Para conseguir eliminar la table y evitar errores lo mas conveniente es hacer un Tipo nuevo
// Solo con esas dos tablas.
    // ImprimirValores(queries.SelectTablaNombreYNumeroDePaginas());

    // Ejemplo del operador Count cuenta el tamaño de la lista.
    // Console.WriteLine( "La cantidad de libros "+ queries.CountLibrosEntre200Y500Paginas());

// Ejemplo del operador Min
    // Console.WriteLine( "Libro con la menor fecha de publicación "+ queries.LibroConMenorFechaDePublicacion());


// Ejemplo del operador Max
    // Console.WriteLine( "Libro con el mayor numero de paginas "+ queries.LibroMayorNumeroDePaginas());

// Ejemplo operador MinBy
    // var libroMenorNumeroDepaginas = queries.LibroConLaMenorCantidadDePaginasMayorQueZero();
    // Console.WriteLine(  $"{libroMenorNumeroDepaginas.Title}  -  {libroMenorNumeroDepaginas.PageCount}");

// Ejemplo operador MaxBy
    // var libroMayorFechaPublicacion = queries.LibroConLaFechaDePublicacionMasReciente();
    // Console.WriteLine(  $"{libroMayorFechaPublicacion.Title}  -  {libroMayorFechaPublicacion.PublishedDate}");

// Ejemplo de operador Sum
    // Console.WriteLine( "La sumatoria de todos los libros de 200 a 500 paginas es: " + queries.SumaDeTodaslasPaginasMayores500());

// Ejemplo de operador Aggregate. que concatena los valores en un string.
    // Console.WriteLine(queries.TitulosLibrosConcatenado());

// Ejemplo de operador Average. Da el promedio de una coleccion de numeros. 
// Console.WriteLine(" Promedio "+queries.PromedioCaracteresDeLaColeccion());

// Ejemplo de operador Average. Da el promedio de una coleccion de numeros. 
    // Console.WriteLine(" Promedio paginas libro "+queries.PromedioPaginaLibro());

// Ejemplo de Clausula GroupBy(). agrupo dependiendo una clausula. 
    // ImprimirGrupo(queries.AgruparLibrosPosterioresALos2000());

// Ejemplo de Clausula LookUp, que agrupo como si fuera un diccionario
// siendo que si uno le solucita una letra se trae todo ese grupo
//    var DiccionarioLibros = queries.DiccionariosDeLibrosPorLetra();
//     ImprimirDiccionario(DiccionarioLibros, 'C');

// Ejemplo de Inner Join para relacionar tablas
ImprimirValores(queries.LibrosDespuesdel2005conmasde500Pags());

//  Retos 
  List<Animal> animales = new List<Animal>();
    animales.Add(new Animal() { Nombre = "Hormiga", Color = "Rojo" });
    animales.Add(new Animal() { Nombre = "Lobo", Color = "Gris" });
    animales.Add(new Animal() { Nombre = "Elefante", Color = "Gris" });
    animales.Add(new Animal() { Nombre = "Pantegra", Color = "Negro" });
    animales.Add(new Animal() { Nombre = "Gato", Color = "Negro" });
    animales.Add(new Animal() { Nombre = "Iguana", Color = "Verde" });
    animales.Add(new Animal() { Nombre = "Sapo", Color = "Verde" });
    animales.Add(new Animal() { Nombre = "Camaleon", Color = "Verde" });
    animales.Add(new Animal() { Nombre = "Gallina", Color = "Blanco" });

    void ImprimirAnimal(IEnumerable<Animal> animal)
    {
        foreach(var item in animal)
            {
                Console.WriteLine("{0,-60} {1, 15}", item.Nombre, item.Color);
            }

    }
// IEnumerable<IGrouping<int,Animal>> animal
     void ImprimirGroupAnimal(IEnumerable<IGrouping<string,Animal>> animal)
    {
        foreach(var item in animal)
            {
                 Console.WriteLine("");
                 Console.WriteLine($"Grupo: { item.Key }");
                    foreach(var grupo in item )
                    {
                        Console.WriteLine("{0,-60} {1, 15} ",grupo.Nombre,grupo.Color); 
                    }
            }

    }

    //reto 1
    // Escribe tu código aquí
    // filtra todos los animales que sean de color verde que su nombre inicie con una vocal
    // List<Animal> animaleslist = new List<Animal>();
    
    // animaleslist.AddRange(animales.Where(p => p.Color == "Verde" && "AEIOUaeiou".Contains(p.Nombre[0]) ));

    //    foreach(var item in animaleslist)
    // {
    //     Console.WriteLine("{0,-60} {1, 15}", item.Nombre, item.Color);
    // }

    // Reto 2
     // Escribe tu código aquí
    // Retorna los elementos de la colleción animal ordenados por nombre
    // List<Animal> animaleslist = new List<Animal>();
    // animaleslist.AddRange(animales.OrderBy(p => p.Nombre) );
    // ImprimirAnimal(animaleslist);

    // Reto 3
    // Escribe tu código aquí
    // Retorna los datos de la colleción Animales agrupada por color 
    // IEnumerable<IGrouping<string,Animal>> animalesGroupByColor = animales.GroupBy( animal => animal.Color);
    // ImprimirGroupAnimal(animalesGroupByColor);

      public class Animal
  {
    public string Nombre {get;set;}
    public string Color {get;set;}
  }