using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using WebSchool.Middleware;
using WebSchool.Service;
using WebSchool.Service.Interface;

namespace WebSchool
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
            services.AddControllersWithViews();
            services.AddHttpContextAccessor();

            services.AddScoped<ILoginPenggunaService, LoginPenggunaService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ITahunService, TahunService>();
            services.AddScoped<IMenuPenggunaRoleService, MenuPenggunaRoleService>();
            services.AddScoped<IGetMenuService, GetMenuService>();
            services.AddScoped<IAbsenGuruService, AbsenGuruService>();
            services.AddScoped<IAbsenSiswaService, AbsenSiswaService>();
            services.AddScoped<IConfigurasiPembayaranService, ConfigurasiPembayaranService>();
            services.AddScoped<IDataConfigPembayaranService, DataConfigPembayaranService>();
            services.AddScoped<IGuruService, GuruService>();
            services.AddScoped<IJadwalGuruService, JadwalGuruService>();
            services.AddScoped<IJadwalPiketGuruService, JadwalPiketGuruService>();
            services.AddScoped<IKelasService, KelasService>();
            services.AddScoped<IMenuRoleService, MenuRoleService>();
            services.AddScoped<IPelajaranService, PelajaranService>();
            services.AddScoped<IPelanggaranService, PelanggaranService>();
            services.AddScoped<IPenggunaRoleService, PenggunaRoleService>();
            services.AddScoped<IPenggunaService, PenggunaService>();
            services.AddScoped<IPenilaianService, PenilaianService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ISiswaService, SiswaService>();
            services.AddScoped<ITahunAjarService, TahunAjarService>();
            services.AddScoped<IWaliKelasService, WaliKelasService>();

            services.AddScoped<IDaftarUlangService, DaftarUlangService>();
            services.AddScoped<IPembayaranService, PembayaranService>();
            services.AddScoped<ISPPService, SPPService>();
            services.AddScoped<ITabunganSiswaService, TabunganSiswaService>();
            services.AddScoped<IUangBangunanService, UangBangunanService>();

            services.AddScoped<IPelanggaranSiswaService, PelanggaranSiswaService>();
            services.AddScoped<IPenilaianSiswaService, PenilaianSiswaService>();
            services.AddScoped<IRaportSiswaService, RaportSiswaService>();

            // services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //.AddCookie(options =>
            // {
            //     options.LoginPath = "/Login/Index";
            // });

            // services.AddAuthentication(options =>
            // {
            //     options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //     options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //     options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            // });

            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(15);
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();
            app.UseAuthorization();
            app.UseAuthentication();
            app.UseMiddleware<ErrorMiddleware>();

            //app.Run(context => { throw new Exception("error"); });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}
