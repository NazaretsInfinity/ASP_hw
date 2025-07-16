using ASPrazorpages.Services;
using ASPrazorpages.Services.Implementations;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using System.Reflection;

namespace ASPrazorpages_HW
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();


            #region Services autoregistration with Microsoft DI
            // var assembler = typeof(Program).Assembly;
            // //type - de name of class

            //IEnumerable<Type> serviceTypes = assembler.GetTypes()
            // .Where(type => type.IsClass && !type.IsAbstract && type.Name.EndsWith("Service"));

            // foreach(Type serviceType in  serviceTypes)
            // {
            //     Type? interfaceType = serviceType.GetInterface($"I{serviceType.Name}");

            //     if (interfaceType == null) continue;

            //     builder.Services.AddScoped(interfaceType, serviceType);
            // }
            #endregion

            #region Service registration with Autofac 
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()); // we designates we're gonna use other packet instead of Mic DI 

            builder.Host.ConfigureContainer<ContainerBuilder>(ContainerBuilder =>
            {
                //ContainerBuilder.RegisterType<TimeService>()
                //                .As<ITimeService>();

                //ContainerBuilder.RegisterType<StringService>()
                //                .As<IStringService>();      


                Assembly assembler = typeof(Program).Assembly;

                ContainerBuilder.RegisterAssemblyTypes(assembler)
                                .Where(type => type.Name.EndsWith("Service"))
                                .AsImplementedInterfaces()
                                .InstancePerLifetimeScope();
            });
            #endregion

            #region adding services manually
            //builder.Services.AddScoped<ITimeService,TimeService>(); //regisyering service 
            //builder.Services.AddScoped<IStringService,StringService>();
            #endregion


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
