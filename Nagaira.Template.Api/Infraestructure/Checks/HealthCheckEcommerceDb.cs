﻿using Microsoft.Extensions.Diagnostics.HealthChecks;
using Nagaira.Core.Extentions.Exceptions;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Nagaira.Template.Api.Infraestructure.Checks
{
    public class HealthCheckEcommerceDb : IHealthCheck
    {
        private readonly string _connectionString;

        public HealthCheckEcommerceDb(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    await connection.OpenAsync(cancellationToken);
                    if (connection.State == ConnectionState.Open) return HealthCheckResult.Healthy("La base de datos está en buen estado.");

                    return HealthCheckResult.Unhealthy("La base de datos no pudo establecer conexión.");

                }
                catch (DbException ex)
                {
                    return HealthCheckResult.Unhealthy($"Error al verificar la base de datos: {MessageException.ShowException(ex)}");
                }
            }
        }
    }
}
