using Autofac;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using SzwHighSpeedRack.EntityFrameworkCore;

namespace SzwHighSpeedRackApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //注入Http上下文
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //将appsettings.json中的JwtSettings部分文件读取到JwtSettings中，这是给其他地方用的
            services.Configure<JwtSettings>(Configuration.GetSection("JwtSettings"));

            //由于初始化的时候我们就需要用，所以使用Bind的方式读取配置
            //将配置绑定到JwtSettings实例中
            var jwtSettings = new JwtSettings();
            Configuration.Bind("JwtSettings", jwtSettings);

            //#region 跨域
            //services.AddCors(options =>
            //    options.AddPolicy("AllowSameDomain",
            //    builder => builder.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins(new[] { "http://localhost:5001" }))
            //);
            //#endregion

            services.AddControllers(o =>
            {
                // 全局异常过滤
                o.Filters.Add(typeof(GlobalExceptionsFilter));
            });

            // 策略授权。
            // 然后这么写 [Authorize(Policy = "Admin")]
            services.AddAuthorization(options =>
            {
                //基于角色
                options.AddPolicy("Client", policy => policy.RequireRole("Client").Build());//单独角色
                options.AddPolicy("Admin", policy => policy.RequireRole("Admin").Build());
                options.AddPolicy("SystemOrAdmin", policy => policy.RequireRole("Admin", "System"));//或的关系
                options.AddPolicy("SystemAndAdmin", policy => policy.RequireRole("Admin").RequireRole("System"));//且的关系
            });
            //添加身份验证
            services.AddAuthentication(options =>
            {
                ////认证middleware配置
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                //jwt token参数设置
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    //Token颁发机构
                    ValidIssuer = jwtSettings.Issuer,
                    //颁发给谁
                    ValidAudience = jwtSettings.Audience,
                    //这里的key要进行加密
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.UTF8Encoding.UTF8.GetBytes(jwtSettings.SecurityKey))
                };
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "SzwHighSpeedRackApi",
                        Version = "v1"
                    });

                //c.OperationFilter<SwaggerOperationFilter>();

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT授权(数据将在请求头中进行传输) 直接在下框中输入Bearer {token}（注意两者之间是一个空格）\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath, true); //添加控制器层注释（true表示显示控制器注释）
            });

            //跨域
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder
                    //允许任何来源的主机访问
                    //TODO: 新的 CORS 中间件已经阻止允许任意 Origin，即设置 AllowAnyOrigin 也不会生效
                    //AllowAnyOrigin()
                    //设置允许访问的域
                    //TODO: 目前.NET Core 3.1 有 bug, 暂时通过 SetIsOriginAllowed 解决
                    //.WithOrigins(Configuration["CorsConfig:Origin"])
                    .SetIsOriginAllowed(t => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
                });
            });

            var serverVersion = new MariaDbServerVersion(new Version(8, 0, 27));
            string connectionString = "Server=127.0.0.1; Port=3306; Uid=root; Pwd=Aa000000; Database=warranty_base;SslMode=None";
            services.AddChimp<MySqlContext>(options =>
            {
                options.UseMySql(connectionString, serverVersion, m =>
                {
                    m.UseNewtonsoftJson(MySqlCommonJsonChangeTrackingOptions.FullHierarchyOptimizedFast);
                });

            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddHttpClient();
        }


        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterModule<ModuleRegister>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //添加静态文件
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), @"Files")),
                RequestPath = new PathString("/Files")
            });

            //app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors();
            //身份授权认证
            app.UseAuthentication();
            //需要放在 app.UseAuthorization 的前面
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.IndexStream = () => GetType().GetTypeInfo().Assembly.GetManifestResourceStream("SzwHighSpeedRackApi.index.html");
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SzwHighSpeedRackApi v1");
                c.DocExpansion(DocExpansion.None);
                c.RoutePrefix = string.Empty;//这里主要是不需要再输入swagger这个默认前缀
            });

            //可以支持虚拟路径或者index.html这类起始页.
            app.Run(ctx =>
            {
                ctx.Response.Redirect("/index.html");
                return Task.FromResult(0);
            });
        }
    }

    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddChimp<T>(this IServiceCollection services,
           Action<DbContextOptionsBuilder> options) where T : BaseContext
        {
            services.AddDbContext<T>(options);
            services.AddScoped<BaseContext, T>();
            return services;
        }
    }
}