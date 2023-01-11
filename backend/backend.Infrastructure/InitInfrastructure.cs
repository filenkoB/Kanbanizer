﻿using backend.DBEngine;
using backend.Infrastructure.Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace backend.Infrastructure
{
    public static class InitInfrastructure
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services) {
            AddDbContext(services);
            AddDbConnector(services);
            return services;
        }

        private static IServiceCollection AddDbContext(IServiceCollection services) {
            return services.AddDbContext<CanbanDbContext>();
        }

        private static IServiceCollection AddDbConnector(IServiceCollection services) {
            services.AddTransient<IDbConnection, SqlConnection>(factory => 
                new SqlConnection("Server=localhost;Database=CANBAN_DB;User Id=CANBAN_migr;Password=CANBAN_migr;"));
            services.AddTransient<IDBConnector, DapperConnector>();
            return services;
        }
    }
}
