using System.Data.SqlClient;
using Dapper;

namespace WebAppOsiguranje
{
    public class DatabaseService
    {
        private readonly string _connectionString;

        public DatabaseService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void InitializeDatabase()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var createPartnersTable = @"
                    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Partners]') AND type in (N'U'))
                    BEGIN
                        CREATE TABLE Partners (
                            PartnerId INT IDENTITY(1,1) PRIMARY KEY,
                            FirstName NVARCHAR(255) NOT NULL,
                            LastName NVARCHAR(255) NOT NULL,
                            Address NVARCHAR(MAX),
                            PartnerNumber CHAR(20) NOT NULL,
                            CroatianPIN CHAR(11),
                            PartnerTypeId INT NOT NULL,
                            CreatedAtUtc DATETIME NOT NULL,
                            CreateByUser NVARCHAR(255) NOT NULL,
                            IsForeign BIT NOT NULL,
                            ExternalCode NVARCHAR(20),
                            Gender CHAR(1) NOT NULL CHECK(Gender IN ('M', 'F', 'N'))
                        )
                    END";

                var createPoliciesTable = @"
                    IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Policies]') AND type in (N'U'))
                    BEGIN
                        CREATE TABLE Policies (
                            PolicyId INT IDENTITY(1,1) PRIMARY KEY,
                            PolicyNumber NVARCHAR(15) NOT NULL,
                            Amount DECIMAL(18, 2) NOT NULL,
                            PartnerId INT NOT NULL,
                            FOREIGN KEY (PartnerId) REFERENCES Partners(PartnerId)
                        )
                    END";

                connection.Execute(createPartnersTable);
                connection.Execute(createPoliciesTable);
            }
        }
    }
}
