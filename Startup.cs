using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Flying_Cow_TMSAPI
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
            //// ע��Swagger����
            //services.AddSwaggerGen(c =>
            //{
            //    // ����ĵ���Ϣ
            //    c.SwaggerDoc("v1", new OpenApiInfo
            //    {
            //        Title = "Flying_Cow_TMSAPI",
            //        Version = "v1",
            //        Description = "ASP.NET CORE WebApi",

            //    });
            //    // ʹ�÷����ȡxml�ļ�����������ļ���·��
            //    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            //    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            //    // ����xmlע��. �÷����ڶ����������ÿ�������ע�ͣ�Ĭ��Ϊfalse.
            //    c.IncludeXmlComments(xmlPath, true);
            //});
            services.AddDbContext<Model.TMSDBContext>(
               options => options.UseSqlServer("Data Source=10.3.158.51;Initial Catalog=TMSDB;User Id=sa;Password=123;")
               );

            services.AddControllers();

            //��������
            services.AddCors(s =>
            {
                s.AddPolicy("cors", p =>
                {
                    p.WithOrigins("http://localhost:52767")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();//ָ������cookie
                });
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //// ����Swagger�м��
            //app.UseSwagger();

            //// ����SwaggerUI
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Flying_Cow_TMSAPI");

            //});
            app.UseRouting();

            app.UseCors("cors");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
