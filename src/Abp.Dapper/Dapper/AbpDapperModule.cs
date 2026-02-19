using Abp.Dependency;
using Abp.Modules;
using Abp.Orm;
using Abp.Reflection.Extensions;
using Slapper;
using System;

namespace Abp.Dapper
{
    [DependsOn(typeof(AbpKernelModule))]
    public class AbpDapperModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactionScopeAvailable = false;
            Slapper.AutoMapper.Configuration.TypeConverters.Add(new Slapper.AutoMapper.Configuration.EnumConverter());
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpDapperModule).GetAssembly());

            using (IScopedIocResolver scope = IocManager.CreateScope())
            {
                ISecondaryOrmRegistrar[] additionalOrmRegistrars = scope.ResolveAll<ISecondaryOrmRegistrar>();

                foreach (ISecondaryOrmRegistrar registrar in additionalOrmRegistrars)
                {
                    if (registrar.OrmContextKey == AbpConsts.Orms.EntityFrameworkCore)
                    {
                        registrar.RegisterRepositories(IocManager, EfBasedDapperAutoRepositoryTypes.Default);
                    }
                    else
                    {
                        throw new InvalidOperationException("OrmContextKey is not supported: " + registrar.OrmContextKey);
                    }
                    //if (registrar.OrmContextKey == AbpConsts.Orms.EntityFramework)
                    //{
                    //    registrar.RegisterRepositories(IocManager, EfBasedDapperAutoRepositoryTypes.Default);
                    //}

                    //if (registrar.OrmContextKey == AbpConsts.Orms.NHibernate)
                    //{
                    //    registrar.RegisterRepositories(IocManager, NhBasedDapperAutoRepositoryTypes.Default);
                    //}

                }
            }
        }
    }
}
