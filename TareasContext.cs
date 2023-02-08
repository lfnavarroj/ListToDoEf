using listtodo.models;
using Microsoft.EntityFrameworkCore;

namespace listtodo;

public class TareasContext:DbContext
{
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Tarea> Tareas { get; set; }

    public TareasContext (DbContextOptions<TareasContext> options):base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Categoria> CategoriaInit=new List<Categoria>();

        CategoriaInit.Add(new Categoria(){ CategoriaId=Guid.Parse("5a43313d-6e2a-4666-b098-14c6202585cd"), Nombre="Actividades Profesionales", Peso=20});
        CategoriaInit.Add(new Categoria(){ CategoriaId=Guid.Parse("20047306-0797-461d-800d-74e736547342"), Nombre="Actividades Personales", Peso=30});
        CategoriaInit.Add(new Categoria(){ CategoriaId=Guid.Parse("2ccf4029-8541-40f4-b897-76179426ec58"), Nombre="Actividades Académicas", Peso=60});

        modelBuilder.Entity<Categoria>(categoria=>
        {
            categoria.ToTable("Categoria");
            categoria.HasKey(p=>p.CategoriaId);
            categoria.Property(p=>p.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(p=>p.Descripcion).IsRequired(false);
            categoria.Property(p=>p.Peso);

            categoria.HasData(CategoriaInit);
        });  

        List<Tarea> TareasInit=new List<Tarea>();
        TareasInit.Add(new Tarea(){ TareaId=Guid.Parse("56e5f716-7371-42b5-b406-f71ec23e610e"),CategoriaId=Guid.Parse("5a43313d-6e2a-4666-b098-14c6202585cd"),Titulo="Realizar curso de Flask",Descripcion="Realizar el curso en cualquier momento",PrioridadTarea=Prioridad.Baja,Fecha_Creacion=DateTime.UtcNow});
        TareasInit.Add(new Tarea(){ TareaId=Guid.Parse("56e5f716-7371-42b5-b406-f71ec23e610a"),CategoriaId=Guid.Parse("5a43313d-6e2a-4666-b098-14c6202585cd"),Titulo="Realizar curso de Python",Descripcion="Realizar el curso en cualquier momento",PrioridadTarea=Prioridad.Baja,Fecha_Creacion=DateTime.UtcNow});
        TareasInit.Add(new Tarea(){ TareaId=Guid.Parse("56e5f716-7371-42b5-b406-f71ec23e610b"),CategoriaId=Guid.Parse("20047306-0797-461d-800d-74e736547342"),Titulo="Ir a casa de mi mamá",Descripcion="Realizar el curso en cualquier momento",PrioridadTarea=Prioridad.Baja,Fecha_Creacion=DateTime.UtcNow});


        modelBuilder.Entity<Tarea>(tarea=>
        {
            tarea.ToTable("Tarea");
            tarea.HasKey(p=>p.TareaId);
            tarea.HasOne(p=>p.Categoria).WithMany(p=>p.Tareas).HasForeignKey(p=>p.CategoriaId);
            tarea.Property(p=>p.Titulo).IsRequired().HasMaxLength(200);
            tarea.Property(p=>p.Descripcion).IsRequired(false);
            tarea.Property(p=>p.PrioridadTarea);
            tarea.Property(p=>p.Fecha_Creacion);
            tarea.Ignore(p=>p.Resumen);

            tarea.HasData(TareasInit);
            
        });
    }

}