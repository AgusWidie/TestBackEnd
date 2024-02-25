using Backend_School.WebApi.RabbitMQ;
using Backend_School.WebApi.Services;
using Backend_School.WebApi.Services.Administrasi;
using Backend_School.WebApi.Services.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Linq;
using System.Text;

namespace Backend_School.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddHttpContextAccessor();
            //services.AddDbContext<SchoolContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SchoolContext")));
            //services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddScoped<IMessageProducer, MessageProducer>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ITahunService, TahunService>();
            services.AddScoped<ILogErrorService, LogErrorService>();
            services.AddScoped<ILogErrorSendEmail, LogErrorSendEmail>();
            services.AddScoped<IAbsenGuruService, AbsenGuruService>();
            services.AddScoped<IGetMenuService, GetMenuService>();
            services.AddScoped<IAbsenSiswaService, AbsenSiswaService>();
            services.AddScoped<IConfigurasiPembayaranService, ConfigurasiPembayaranService>();
            services.AddScoped<IDataConfigPembayaranService, DataConfigPembayaranService>();
            services.AddScoped<IGuruService, GuruService>();
            services.AddScoped<IJadwalGuruService, JadwalGuruService>();
            services.AddScoped<IJadwalPiketGuruService, JadwalPiketGuruService>();
            services.AddScoped<IKelasService, KelasService>();
            services.AddScoped<IMenuPenggunaRoleService, MenuPenggunaRoleService>();
            services.AddScoped<IMenuRoleService, MenuRoleService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IPelajaranService, PelajaranService>();
            services.AddScoped<IPelanggaranService, PelanggaranService>();
            services.AddScoped<IPenggunaService, PenggunaService>();
            services.AddScoped<IPenggunaRoleService, PenggunaRoleService>();
            services.AddScoped<IPenilaianService, PenilaianService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ISiswaService, SiswaServices>();
            services.AddScoped<ITahunAjaranService, TahunAjaranService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IWaliKelasService, WaliKelasService>();

            services.AddScoped<IDaftarUlangService, DaftarUlangService>();
            services.AddScoped<IPembayaranService, PembayaranService>();
            services.AddScoped<ISPPService, SPPService>();
            services.AddScoped<IUangBangunanService, UangBangunanService>();
            services.AddScoped<ITabunganSiswaService, TabunganSiswaService>();

            services.AddScoped<IPelanggaranSiswaService, PelanggaranSiswaService>();
            services.AddScoped<IPenilaianSiswaService, PenilaianSiswaService>();
            services.AddScoped<IRaportSiswaService, RaportSiswaService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Backend Sekolah API", Version = "v1.0" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });

            // Adding Authentication  
            services
                    .AddAuthentication
                    (options =>
                    {
                        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    })
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = Configuration["Jwt:Issuer"],
                            ValidAudience = Configuration["Jwt:Audience"],
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                        };
                        options.SaveToken = true;
                    });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            if (env.IsProduction() || env.IsStaging())
            {
                app.UseExceptionHandler("/Error/index.html");
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Backend Sekolah API v1.0"));
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
