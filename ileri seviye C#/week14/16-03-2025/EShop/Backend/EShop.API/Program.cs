using System.Text;
using EShop.API.Middlewares;
using EShop.Data.Abstract;
using EShop.Data.Concrete;
using EShop.Data.Concrete.Contexts;
using EShop.Data.Concrete.Repositories;
using EShop.Entity.Concrete;
using EShop.Services.Abstract;
using EShop.Services.Concrete;
using EShop.Services.Mapping;
using EShop.Shared.Configurations.Auth;
using EShop.Shared.Configurations.Email;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EShopDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("RemoteConnection"));
});

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 8;
    options.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<EShopDbContext>().AddDefaultTokenProviders();

builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));
builder.Services.Configure<AppUrlConfig>(builder.Configuration.GetSection("AppUrl"));
builder.Services.Configure<EmailConfig>(builder.Configuration.GetSection("EmailConfig"));

var jwtConfig = builder.Configuration.GetSection("JwtConfig").Get<JwtConfig>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; //amacı jwt token ile gelen istekleri konttrol etmek.
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtConfig?.Issuer,
        ValidAudience = jwtConfig?.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig?.Secret ?? ""))
    };
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(); //veritabanına erişim için kullanılacak olan unıtofwork sınıfı.
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddScoped<IAuthService, AuthManager>(); //amacı: kullanıcıların giriş yapabilmesi için gerekli olan işlemleri yapmak.
builder.Services.AddScoped<ICategoryService, CategoryManager>(); //kategoriler için gerekli işlemleri yapmak.
builder.Services.AddScoped<IProductService, ProductManager>(); //ürünler için gerekli işlemleri yapmak.
builder.Services.AddScoped<ICartService, CartManager>();
builder.Services.AddScoped<IOrderService, OrderManager>();
builder.Services.AddScoped<IImageService, ImageManager>();
builder.Services.AddScoped<IEmailService, EmailManager>();
builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<IApiClientService, ApiClientManager>();

builder.Services.AddAutoMapper(typeof(MappingProfile));


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseStaticFiles();

app.UseMiddleware<ApiKeyMiddleware>(); //amacı api key ile gelen istekleri kontrol etmek.

app.UseAuthentication(); //jwt token kontrolü

app.UseAuthorization(); //yetkilendirme kontrolü

app.MapControllers(); //cpntrollerlarımızı kullanabilmek için

app.Run();
