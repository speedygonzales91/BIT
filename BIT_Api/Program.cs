using BIT_Business.Repository;
using BIT_Business.Repository.IRepository;
using BIT_DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();

builder.Services.AddCors(o => o.AddPolicy("BIT", builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();

}));

builder.Services.AddRouting(options => options.LowercaseUrls = true);


builder.Services.AddControllers()
    .AddJsonOptions(opt => opt.JsonSerializerOptions.PropertyNamingPolicy = null)
                .AddNewtonsoftJson(opt => {
                    opt.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("BIT");

app.UseAuthorization();

app.MapControllers();

app.Run();
