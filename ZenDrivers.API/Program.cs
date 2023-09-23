using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ZenDrivers.API.Communication.Domain.Model;
using ZenDrivers.API.Communication.Domain.Repository;
using ZenDrivers.API.Communication.Domain.Services;
using ZenDrivers.API.Communication.Mapping;
using ZenDrivers.API.Communication.Persistence.Repositories;
using ZenDrivers.API.Communication.Services;
using ZenDrivers.API.Drivers.Domain.Model;
using ZenDrivers.API.Drivers.Domain.Repositories;
using ZenDrivers.API.Drivers.Domain.Services;
using ZenDrivers.API.Drivers.Mapping;
using ZenDrivers.API.Drivers.Persistence.Repositories;
using ZenDrivers.API.Drivers.Services;
using ZenDrivers.API.Security.Authorization.Handlers.Implementations;
using ZenDrivers.API.Security.Authorization.Handlers.Interfaces;
using ZenDrivers.API.Security.Authorization.Middleware;
using ZenDrivers.API.Security.Authorization.Settings;
using ZenDrivers.API.Security.Domain.Repositories;
using ZenDrivers.API.Security.Domain.Services;
using ZenDrivers.API.Security.Persistence.Repositories;
using ZenDrivers.API.Security.Services;
using ZenDrivers.API.Shared.Domain.Repositories;
using ZenDrivers.API.Shared.Persistence.Contexts;
using ZenDrivers.API.Shared.Persistence.Repositories;
using ZenDrivers.API.Recruiters.Domain.Model;
using ZenDrivers.API.Recruiters.Domain.Repositories;
using ZenDrivers.API.Recruiters.Domain.Services;
using ZenDrivers.API.Recruiters.Mapping;
using ZenDrivers.API.Recruiters.Persistence.Repositories;
using ZenDrivers.API.Recruiters.Services;
using ZenDrivers.API.Security.Mapping;
using ZenDrivers.API.Shared.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add CORS
builder.Services.AddCors();

//Add services to the container
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//AppSettings Configuration
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddSwaggerGen(options =>
{
    //Add API Documentation Information

    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Innovamind API",
        Description = "Innovamind RESTful API",
        TermsOfService = new Uri("https://innova-mind.com/tos"),
        Contact = new OpenApiContact
        {
            Name = "INNOVAMIND.studio",
            Url = new Uri ("https://acme.studio")
        },
        License = new OpenApiLicense
        {
            Name = "Innovamind Resources License",
            Url = new Uri("https://innova-mind.com/license")
        }
    });
    options.EnableAnnotations();
    options.AddSecurityDefinition("bearearAuth", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Description = "JWT Authorization header using the Bearer Scheme"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "bearearAuth"}
            },
            Array.Empty<string>()
        }
    });
});



// Add Database Connection

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(connectionString)
    .LogTo(Console.WriteLine, LogLevel.Information)
    .EnableSensitiveDataLogging()
    .EnableDetailedErrors());

//Add lowecase routes

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IJwtHandler, JwtHandler>();

builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();

builder.Services.AddScoped<IRecruiterRepository, RecruiterRepository>();
builder.Services.AddScoped<IRecruiterService, RecruiterService>();
builder.Services.AddScoped<IGenericMap<Recruiter, Recruiter>, RecruiterMap>();

builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IGenericMap<Company, Company>, CompanyMap>();

builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IGenericMap<Post, Post>, PostMap>();

builder.Services.AddScoped<ILicenseRepository, LicenseRepository>();
builder.Services.AddScoped<ILicenseService, LicenseService>();
builder.Services.AddScoped<IGenericMap<License, License>, LicenseMap>();

builder.Services.AddScoped<ILicenseCategoryRepository, LicenseCategoryRepository>();
builder.Services.AddScoped<ILicenseCategoryService, LicenseCategoryService>();
builder.Services.AddScoped<IGenericMap<LicenseCategory, LicenseCategory>, LicenseCategoryMap>();

builder.Services.AddScoped<IDriverRepository, DriverRepository>();
builder.Services.AddScoped<IDriverService, DriverService>();
builder.Services.AddScoped<IGenericMap<Driver, Driver>, DriverMap>();

builder.Services.AddScoped<IDriverExperienceRepository, DriverExperienceRepository>();
builder.Services.AddScoped<IDriverExperienceService, DriverExperienceService>();
builder.Services.AddScoped<IGenericMap<DriverExperience, DriverExperience>, DriverExperienceMap>();

builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<IGenericMap<Message, Message>, MessageMap>();

//AutoMapper Configuration

builder.Services.AddAutoMapper(
    typeof(ZenDrivers.API.Security.Mapping.ModelToResourceProfile),
    typeof(ZenDrivers.API.Security.Mapping.ResourceToModelProfile),
    typeof(ZenDrivers.API.Recruiters.Mapping.ResourceToModelProfile),
    typeof(ZenDrivers.API.Recruiters.Mapping.ModelToResourceProfile),
    typeof(ZenDrivers.API.Drivers.Mapping.ResourceToModelProfile),
    typeof(ZenDrivers.API.Drivers.Mapping.ModelToResourceProfile),
    typeof(ZenDrivers.API.Communication.Mapping.ResourceToModelProfile),
    typeof(ZenDrivers.API.Communication.Mapping.ModelToResourceProfile)
);

var app = builder.Build();

// Validation for ensuring Database Objects are created
using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("v1/swagger.json", "v1");
        options.RoutePrefix = "swagger";
        //Added To View the tags in swagger
        options.DisplayOperationId();
    });


// Configure CORS
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
);

//Configure Error Handler Middleware
app.UseMiddleware<ErrorHandlerMiddleware>();

//Configure JWT Handling
app.UseMiddleware<JwtMiddleware>();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
