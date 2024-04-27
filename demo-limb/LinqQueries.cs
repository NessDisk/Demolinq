public class LinqQueries
{
    private List<Book> librosCollection = new List<Book>();
     
    public LinqQueries()
    {
        using(StreamReader reader = new StreamReader("books.json"))
        {
            string json = reader.ReadToEnd();
            this.librosCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() {PropertyNameCaseInsensitive = true});
        }
    }  
    public IEnumerable<Book> TodaLaColeccion()
    {
        return librosCollection;
    }

    public IEnumerable<Book> TodaLaColeccionMayorDel2000()
    {
        // Extension metodo
        // return librosCollection.Where(p => p.PublishedDate.Year >2000 );

        // Query Expresion
        return  from l in librosCollection where l.PublishedDate.Year > 2000 select l;
    }

      public IEnumerable<Book> TodaLaColeccionConMasDe250Pag()
    {
        //extension methods
        //return librosCollection.Where(p=> p.PageCount > 250 && p.Title.Contains("in Action"));

        // Query Expresion
         return  from l in librosCollection where l.PageCount > 250 && l.Title.Contains("in Action") select l;
    }

      public bool TodosLoslibrosTienenStatus()
    {
        return librosCollection.All( libro => libro.Status != string.Empty );
    }

       public bool AlgunosTienenStatus()
    {
        return librosCollection.Any( libro => libro.Status != string.Empty );
    }

         public bool AlgunLibroLanzadoEn2005()
    {
        return librosCollection.Any( libro => libro.PublishedDate.Year == 2005 );
    }

       public IEnumerable<Book> LibrosDePhyton()
    {   // Ejemplo con Extension methodJ
        return librosCollection.Where( libro => libro.Categories.Contains("Python") );
    
        //Ejemplo con Query expression (experiment)
        // return from book in librosCollection where book.Categories.Contains("Python") select book; 
    }

    // Ejemplo orderby
    public IEnumerable<Book> LibrosJavaOrdenasdosPorNombre()
    {   // Ejemplo con Extension method
        return librosCollection.Where( libro => libro.Categories.Contains("Java") ).OrderBy(libro  => libro.Title);
    
        //Ejemplo con Query expression (experiment)
        // return from book in librosCollection where book.Categories.Contains("Java") orderby book.Title  select book   ; 
    }

        // Ejemplo orderby OrderByDescending
       public IEnumerable<Book> LibrosConMasDe450PagDesn()
    {   // Ejemplo con Extension method
        // return librosCollection.Where( libro => libro.PageCount > 450 ).OrderByDescending(libro  => libro.PageCount);
    
        //Ejemplo con Query expression (experiment)
        return from book in librosCollection where book.PageCount  > 450 orderby book.Title descending   select book; 
    }

    //Ejemplo de de operador Take -> toma los primeros registros. 
       public IEnumerable<Book> Primeros4LibrosDeJava()
    {
        // Ejemplo con Extension method
        // return librosCollection.Where(libro=> libro.Categories.Contains("Java")).               OrderByDescending(libros => libros.PublishedDate ).TakeLast(3);

        //Ejemplo con Query expression (experiment)
        return (from book in librosCollection where book.Categories.Contains("Java") orderby book.PublishedDate select book ).TakeLast(3);
    }

     public IEnumerable<Book> TercerYCuartoLibroConMasDe400Pags()
    {
         // Ejemplo con Extension method
        return librosCollection.Where( libros => libros.PageCount > 400).Skip(2).Take(2);

        //Ejemplo con Query expression (experiment)
        // return (from book in librosCollection where book.PageCount > 400 select book).Skip(2).Take(2);
    }
    public IEnumerable<Book> SelectTablaNombreYNumeroDePaginas()
    {        
        return librosCollection.Select(libro => new Book(){ Title =libro.Title , PageCount = libro.PageCount});
    }

    public long  CountLibrosEntre200Y500Paginas(){

         // Ejemplo con Extension method
    // return librosCollection.Count(libros => libros.PageCount >= 200 && libros.PageCount <= 500);        
        
       //Ejemplo con Query expression (experiment)
        return (from libro in librosCollection where libro.PageCount >= 200 && libro.PageCount <= 500 select libro).LongCount();
        
    }

    public DateTime LibroConMenorFechaDePublicacion()
    {
        return librosCollection.Min( libro => libro.PublishedDate);
    }

       public int LibroMayorNumeroDePaginas()
    {
        return librosCollection.Max( libro => libro.PageCount);
    }

    public Book LibroConLaMenorCantidadDePaginasMayorQueZero()
    {
        return librosCollection.Where(libro => libro.PageCount > 0).MinBy(libro => libro.PageCount);
    }


        public Book LibroConLaFechaDePublicacionMasReciente()
    {
        return librosCollection.MaxBy(libro => libro.PublishedDate);
    }

    public int SumaDeTodaslasPaginasMayores500()
    {
        return librosCollection.Where(libros => libros.PageCount >=0 && libros.PageCount <= 500).Sum(libros => libros.PageCount);
    }

    public string TitulosLibrosConcatenado()
    {
        return librosCollection.Where(libros => libros.PublishedDate.Year > 2015).Aggregate("",( librosAcumulados, siguienteLibro)=>{

            if(librosAcumulados != string.Empty)
            {
                librosAcumulados += " - " + siguienteLibro.Title;
            }
            else
            {
                librosAcumulados +=  siguienteLibro.Title;
            }
                return librosAcumulados;
        });
    }

    public double PromedioCaracteresDeLaColeccion()
    {
        return librosCollection.Average(libros => libros.Title.Length);
    }

    public double PromedioPaginaLibro()
    {
        return librosCollection.Where(libros => libros.PageCount >= 0 && libros.PageCount <= 500 ).Average(libros => libros.PageCount);
    }

    public IEnumerable<IGrouping<int, Book>> AgruparLibrosPosterioresALos2000()
    {
        return librosCollection.Where(libros => libros.PublishedDate.Year > 2000 ).GroupBy(libros => libros.PublishedDate.Year);
    }

    public  ILookup<char, Book> DiccionariosDeLibrosPorLetra()
    {
       return librosCollection.ToLookup(libros => libros.Title[0] , libros => libros );
    }

 public IEnumerable<Book> LibrosDespuesdel2005conmasde500Pags()
    {
        var LibrosDepuesdel2005 = librosCollection.Where(p=> p.PublishedDate.Year > 2005);

        var LibrosConMasde500pag = librosCollection.Where(p=> p.PageCount > 500);

        return LibrosDepuesdel2005.Join(LibrosConMasde500pag, p=> p.Title, x=> x.Title, (p, x) => p);
    }

}