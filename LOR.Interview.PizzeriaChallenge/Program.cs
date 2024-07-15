using Autofac;
using LOR.Interview.PizzeriaChallenge.Config;
using LOR.Interview.PizzeriaChallenge.Interfaces;
using LOR.Interview.PizzeriaChallenge.Models;
using LOR.Interview.PizzeriaChallenge.Services;
using System;
using System.ComponentModel;
using IContainer = Autofac.IContainer;

namespace LOR.Interview.PizzeriaChallenge
{
    /// <summary>
    /// Entry point of the Pizzeria Challenge application.
    /// Autofac is used to manage dependencies between various services
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                var container = ConfigureContainer();
                using (var scope = container.BeginLifetimeScope())
                {
                    var application = scope.Resolve<PizzeriaApplication>();
                    application.Run();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong, please try again.");
                Console.WriteLine(ex.Message);
            }
        }

        private static IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();


            builder.RegisterType<Store>().As<IStore>().WithParameter("cityName", Constants.DefaultCityName).InstancePerLifetimeScope();
            builder.RegisterType<PizzaFactory>().As<IPizzaFactory>().InstancePerLifetimeScope();
            builder.RegisterType<Menu>().As<IMenu>().InstancePerLifetimeScope();
            builder.RegisterType<StoreService>().As<IStoreService>().InstancePerLifetimeScope();
            builder.RegisterType<PizzaSelectionService>().As<IPizzaSelectionService>().InstancePerLifetimeScope();
            builder.RegisterType<OrderService>().As<IOrderService>().InstancePerLifetimeScope();
            builder.RegisterType<MenuService>().As<IMenuService>().InstancePerLifetimeScope();
            builder.RegisterType<CustomerService>().As<ICustomerService>().InstancePerLifetimeScope();

            builder.RegisterType<PizzeriaApplication>();

            return builder.Build();
        }
    }
}