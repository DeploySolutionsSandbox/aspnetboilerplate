using FluentMigrator.Runner.Conventions;
using FluentMigrator.Runner.Initialization;
using FluentMigrator.Runner.VersionTableInfo;
using Microsoft.Extensions.Options;
using System;

namespace Abp.Zero.FluentMigrator;

[VersionTableMetaData]
public class VersionTable : DefaultVersionTableMetaData
{
    public VersionTable(IConventionSet conventionSet, IOptions<RunnerOptions> runnerOptions) : base(conventionSet, runnerOptions)
    {
    }

    //[Obsolete("Use dependency injection")]
    //public VersionTable() : base()
    //{
    //}

    //[Obsolete("Use dependency injection")]
    //public VersionTable(string schemaName) : base(schemaName)
    //{
    //}

    public override string TableName
    {
        get
        {
            return "AbpVersionInfo";
        }
    }
}