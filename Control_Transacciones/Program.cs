

using Control_Transacciones.Models;

class Program
{
    static void Main(string[] args)
    {
        addTemaSolistaTransaction();
    }

    public static void addTemaSolistaTransaction()
    {
        Console.WriteLine("Metodo agregar lIBRO,  autor,  genero");
        LibroContext context = new LibroContext();
        Libro libro = new Libro();
        Autor autor = new Autor();
        Genero genero = new Genero();
        var transaction = context.Database.BeginTransaction();

        try
        {
            //Agregar Autor
            autor.Name = "Antoine de Saint-Exupéry";
            autor.edad = 50;            
            context.SaveChanges();

            //Agregar Genero
            genero.Categoria = "Aventura";           
            context.SaveChanges();

            //Agregar Libro
            libro.Titulo = "El principito";
            libro.Paginas = 120;
            libro.genero = genero;
            libro.autor = autor; 
            
            context.Libros.Add(libro);
            context.SaveChanges();

            if (string.IsNullOrEmpty(autor.Name) || genero.Categoria == null || libro.Titulo == null)
            {
                Console.WriteLine("Ha ingresado uno o más campos vacíos. Rollback ejecutado.");
                transaction.Rollback();
            }
            else
            {
                transaction.Commit();
                Console.WriteLine("Datos agregados exitosamente");
            }
            
        }
        catch (Exception e)
        {
            transaction.Rollback();
            Console.WriteLine("Error " + e.ToString());
        }
    }
}