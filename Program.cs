using listtodo;
using listtodo.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// Esta instrucción es sólo para postgresql
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddNpgsql<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));
var app = builder.Build();

app.MapGet("/dbconexion", async([FromServices] TareasContext dbContext)=>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos creada en memoria "+dbContext.Database.IsInMemory());
});

app.MapGet("/", () => "Hello World!");

// Get Data
app.MapGet("/api/tareas", async ([FromServices] TareasContext dbContext)=>{

    return Results.Ok(dbContext.Tareas.Include(p=>p.Categoria));

});

app.MapPost("/api/tareas", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea)=>{

    tarea.TareaId=Guid.NewGuid();
    tarea.Fecha_Creacion=DateTime.UtcNow;
    await dbContext.AddAsync(tarea);

    await dbContext.SaveChangesAsync();
    return Results.Ok();

});

app.MapPut("/api/tareas/{id}", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea,[FromRoute] Guid id)=>{

    var tareaActual=dbContext.Tareas.Find(id);

    if (tareaActual!=null)
    {

        tareaActual.CategoriaId=tarea.CategoriaId;
        tareaActual.Titulo=tarea.Titulo;
        tareaActual.PrioridadTarea=tarea.PrioridadTarea;
        tareaActual.Descripcion=tarea.Descripcion;

        await dbContext.SaveChangesAsync();
        return Results.Ok();
 
    }

    return Results.NotFound();

});

app.MapDelete("/api/tareas/{id}", async ([FromServices] TareasContext dbContext,[FromRoute] Guid id)=>{
    var tareaActual=dbContext.Tareas.Find(id);

    if (tareaActual!=null)
    {

        dbContext.Remove(tareaActual);

        await dbContext.SaveChangesAsync();
        return Results.Ok();
 
    }

    return Results.NotFound();
});



app.Run();
