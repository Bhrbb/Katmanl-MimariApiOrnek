using Autofac;
using Autofac.Core;
using KatmanlıMimariApi.Core.Repositories;
using KatmanlıMimariApi.Core.Services;
using KatmanlıMimariApi.Core.UnitOfWorks;
using KatmanliMimariApi.Repository;
using KatmanliMimariApi.Repository.Repository;
using KatmanliMimariApi.Repository.UnitOfWork;
using KatmanliMimariApi.Services.Mapping;
using KatmanliMimariApi.Services.Services;
using System.Reflection;
using Module = Autofac.Module;

namespace KatmanliMimariApi.Api.Moduls
{
    public class RepoServiceModul: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IServices<>)).InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();





            var apiAssembly=Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x=>x.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerLifetimeScope();
            //it says there, make the interfaces implement the ones that end with repo
            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<ProductServiceWithCaching>().As<IProductService>();



        }
    }
}
