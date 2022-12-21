namespace AvaMed_Back
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<Projeto.Data.Contexto.AvamedContext>();
            
            builder.Services.AddScoped<
                Projeto.Data.Interfaces.IBeneficiarioRepositorio,
                Projeto.Data.Repositorio.BeneficiarioRepositorio>();

            builder.Services.AddScoped<
                Projeto.Data.Interfaces.IEspecialidadeRepositorio,
                Projeto.Data.Repositorio.EspecialidadeRepositorio>();

            builder.Services.AddScoped<
                Projeto.Data.Interfaces.IAgendamentoRepositorio,
                Projeto.Data.Repositorio.AgendamentoRepositorio>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MinhaRegraCors",
                    policy =>
                    {
                        policy.AllowAnyHeader()
                        .AllowAnyOrigin()
                        .AllowAnyMethod();
                    });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("MinhaRegraCors");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}