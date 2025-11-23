
using BurgerStore.Helperss.DIHelper;
using BurgerStore.Helperss.Extensions;
using BurgerStore.Mapperss.MapperConfig;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var appSettings = builder.Configuration.GetSection("AppSettings");
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly)
                 .AddPostgreSqlDbContext(appSettings)
                 .AddAuthentication()
                 .AddJwt(appSettings)
                 .AddIdentityExtension()
                 .AddCors()
                 .AddSwagger();
                 
                 


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



DIHelper.InjectDbRepositories(builder.Services);
DIHelper.InjectServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
