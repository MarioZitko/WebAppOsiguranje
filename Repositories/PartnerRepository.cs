using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using WebAppOsiguranje.Models;

public class PartnerRepository
{
    private readonly string _connectionString;

    public PartnerRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IEnumerable<Partner> GetAll()
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            return connection.Query<Partner>("SELECT * FROM Partners").ToList();
        }
    }

    public void Add(Partner partner)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var sql = @"INSERT INTO Partners (FirstName, LastName, Address, PartnerNumber, CroatianPIN, PartnerTypeId, CreatedAtUtc, CreateByUser, IsForeign, ExternalCode, Gender) 
                        VALUES (@FirstName, @LastName, @Address, @PartnerNumber, @CroatianPIN, @PartnerTypeId, @CreatedAtUtc, @CreateByUser, @IsForeign, @ExternalCode, @Gender)";
            connection.Execute(sql, partner);
        }
    }

    // Implementacija ostalih metoda po potrebi...
}
