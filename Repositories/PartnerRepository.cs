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
            return connection.Query<Partner>("SELECT * FROM Partners").OrderByDescending(p => p.CreatedAtUtc).ToList();
        }
    }

    public int Add(Partner partner, out string errorMessage)
    {
        errorMessage = string.Empty;
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var existingPartner = connection.Query<Partner>("SELECT * FROM Partners WHERE ExternalCode = @ExternalCode", new { ExternalCode = partner.ExternalCode }).FirstOrDefault();
            if (existingPartner != null)
            {
                errorMessage = "External Code must be unique.";
                return 0;
            }

            var sql = @"
            INSERT INTO Partners (FirstName, LastName, Address, PartnerNumber, CroatianPIN, PartnerTypeId, CreatedAtUtc, CreateByUser, IsForeign, ExternalCode, Gender) 
            VALUES (@FirstName, @LastName, @Address, @PartnerNumber, @CroatianPIN, @PartnerTypeId, GETUTCDATE(), @CreateByUser, @IsForeign, @ExternalCode, @Gender);
            SELECT CAST(SCOPE_IDENTITY() as int);";
            var id = connection.QuerySingle<int>(sql, partner);
            return id;
        }
    }

    public bool Delete(int partnerId)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var sql = "DELETE FROM Partners WHERE PartnerId = @PartnerId";
            var affectedRows = connection.Execute(sql, new { PartnerId = partnerId });
            return affectedRows > 0;
        }
    }

    public Partner GetPartnerById(int partnerId)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var sql = "SELECT * FROM Partners WHERE PartnerId = @PartnerId";
            return connection.Query<Partner>(sql, new { PartnerId = partnerId }).FirstOrDefault();
        }
    }

}
