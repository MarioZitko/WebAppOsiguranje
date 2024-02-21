using Dapper;
using System.Collections.Generic;
using System.Data;
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

    public Policy GetPolicyById(int id)
    {
        using (IDbConnection dbConnection = new SqlConnection(_connectionString))
        {
            dbConnection.Open();
            return dbConnection.QueryFirstOrDefault<Policy>("SELECT * FROM Policies WHERE PolicyId = @Id", new { Id = id });
        }
    }

    public bool DeletePolicy(int id)
    {
        using (IDbConnection dbConnection = new SqlConnection(_connectionString))
        {
            dbConnection.Open();
            int rowsAffected = dbConnection.Execute("DELETE FROM Policies WHERE PolicyId = @Id", new { Id = id });
            return rowsAffected > 0;
        }
    }
}
