using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using WebAppOsiguranje.Models;

public class PolicyRepository
{
    private readonly string _connectionString;

    public PolicyRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IEnumerable<Policy> GetAllPolicies()
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            return connection.Query<Policy>("SELECT * FROM Policies").ToList();
        }
    }

    public void AddPolicy(Policy policy)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var sql = @"INSERT INTO Policies (PolicyNumber, Amount, PartnerId) VALUES (@PolicyNumber, @Amount, @PartnerId)";
            connection.Execute(sql, policy);
        }
    }
}
