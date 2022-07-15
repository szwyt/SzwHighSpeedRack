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
            //ע��Http������
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //��appsettings.json�е�JwtSettings�����ļ���ȡ��JwtSettings�У����Ǹ������ط��õ�
            services.Configure<JwtSettings>(Configuration.GetSection("JwtSettings"));

            //���ڳ�ʼ����ʱ�����Ǿ���Ҫ�ã�����ʹ��Bind�ķ�ʽ��ȡ����
            //�����ð󶨵�JwtSettingsʵ����
            var jwtSettings = new JwtSettings();
            Configuration.Bind("JwtSettings", jwtSettings);

            //#region ����
            //services.AddCors(options =>
            //    options.AddPolicy("AllowSameDomain",
            //    builder => builder.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins(new[] { "http://localhost:5001" }))
            //);
            //#endregion

            services.AddControllers(o =>
            {
                // ȫ���쳣����
                o.Filters.Add(typeof(GlobalExceptionsFilter));
            });

            // ������Ȩ��
            // Ȼ����ôд [Authorize(Policy = "Admin")]
            services.AddAuthorization(options =>
            {
                //���ڽ�ɫ
                options.AddPolicy("Client", policy => policy.RequireRole("Client").Build());//������ɫ
                options.AddPolicy("Admin", policy => policy.RequireRole("Admin").Build());
                options.AddPolicy("SystemOrAdmin", policy => policy.RequireRole("Admin", "System"));//��Ĺ�ϵ
                options.AddPolicy("SystemAndAdmin", policy => policy.RequireRole("Admin").RequireRole("System"));//�ҵĹ�ϵ
            });
            //��������֤
            services.AddAuthentication(options =>
            {
                ////��֤middleware����
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                //jwt token��������
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    //Token�䷢����
                    ValidIssuer = jwtSettings.Issuer,
                    //�䷢��˭
                    ValidAudience = jwtSettings.Audience,
                    //�����keyҪ���м���
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
                    Description = "JWT��Ȩ(���ݽ�������ͷ�н��д���) ֱ�����¿�������Bearer {token}��ע������֮����һ���ո�\"",
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
                c.IncludeXmlComments(xmlPath, true); //��ӿ�������ע�ͣ�true��ʾ��ʾ������ע�ͣ�
            });

            //����
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder
                    //�����κ���Դ����������
                    //TODO: �µ� CORS �м���Ѿ���ֹ�������� Origin�������� AllowAnyOrigin Ҳ������Ч
                    //AllowAnyOrigin()
                    //����������ʵ���
                    //TODO: Ŀǰ.NET Core 3.1 �� bug, ��ʱͨ�� SetIsOriginAllowed ���
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

            //��Ӿ�̬�ļ�
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
            //�����Ȩ��֤
            app.UseAuthentication();
            //��Ҫ���� app.UseAuthorization ��ǰ��
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
                c.RoutePrefix = string.Empty;//������Ҫ�ǲ���Ҫ������swagger���Ĭ��ǰ׺
            });

            //����֧������·������index.html������ʼҳ.
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