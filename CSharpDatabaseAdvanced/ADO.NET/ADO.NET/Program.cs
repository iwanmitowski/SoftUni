using Microsoft.Data.SqlClient;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ADO.NET
{
    internal class Program
    {
        static string masterConnectionString = @"Server=.;Database=master;Integrated Security=true;TrustServerCertificate=True";
        static string minionsDbConnectionString = @"Server=.;Database=MinionsDB;Integrated Security=true;TrustServerCertificate=True";


        static async Task Main(string[] args)
        {
            //await using var connection = new SqlConnection(masterConnectionString);
            //await Problem01_1(connection);

            await using var connection = new SqlConnection(minionsDbConnectionString);

            using (connection)
            {
                //await Problem01_2(connection);
                //await Problem02(connection);
                //await Problem03(connection);
                await Problem04(connection);
            }

            await connection.CloseAsync();
        }

        static async Task Problem01_1(SqlConnection connection)
        {
            await connection.OpenAsync();
            var query = @"CREATE DATABASE MinionsDB";

            var cmd = new SqlCommand(query, connection);
            await cmd.ExecuteNonQueryAsync();

            Console.WriteLine("Database created successfully!");
        }

        static async Task Problem01_2(SqlConnection connection)
        {
            await connection.OpenAsync();
            var query = @"CREATE TABLE Countries 
                (
                    Id INT PRIMARY KEY IDENTITY, 
                    Name VARCHAR(50)
                )
                CREATE TABLE Towns
                (
                    Id INT PRIMARY KEY IDENTITY, 
                    Name VARCHAR(50), 
                    CountryCode INT FOREIGN KEY REFERENCES Countries(Id)
                )
                CREATE TABLE Minions
                (
                    Id INT PRIMARY KEY IDENTITY, 
                    Name VARCHAR(30), 
                    Age INT, 
                    TownId INT FOREIGN KEY REFERENCES Towns(Id)
                )
                CREATE TABLE EvilnessFactors
                (
                    Id INT PRIMARY KEY IDENTITY, 
                    Name VARCHAR(50)
                )
                CREATE TABLE Villains 
                (
                    Id INT PRIMARY KEY IDENTITY, 
                    Name VARCHAR(50), 
                    EvilnessFactorId INT FOREIGN KEY REFERENCES EvilnessFactors(Id)
                )
                CREATE TABLE MinionsVillains 
                (
                    MinionId INT FOREIGN KEY REFERENCES Minions(Id),
                    VillainId INT FOREIGN KEY REFERENCES Villains(Id),
                    CONSTRAINT PK_MinionsVillains 
                    PRIMARY KEY (MinionId, VillainId)
                )";

            var cmd = new SqlCommand(query, connection);
            await cmd.ExecuteNonQueryAsync();

            query = @"INSERT INTO Countries ([Name]) 
                        VALUES ('Bulgaria'), 
                               ('England'), 
                               ('Cyprus'), 
                               ('Germany'), 
                               ('Norway')
                INSERT INTO Towns ([Name], CountryCode) 
                        VALUES ('Plovdiv', 1),
                               ('Varna', 1),
                               ('Burgas', 1),
                               ('Sofia', 1),
                               ('London', 2),  
                               ('Southampton', 2),    
                               ('Bath', 2),  
                               ('Liverpool', 2),  
                               ('Berlin',  3),
                               ('Frankfurt', 3),   
                               ('Oslo', 4)
                
                INSERT INTO Minions (Name,Age, TownId) 
                        VALUES ('Bob', 42, 3),
                               ('Kevin', 1, 1),        
                               ('Bob ', 32, 6),
                               ('Simon', 45, 3),    
                               ('Cathleen', 11, 2),  
                               ('Carry ', 50, 10), 
                               ('Becky', 125, 5),
                               ('Mars', 21, 1),
                               ('Misho', 5, 10),
                               ('Zoe', 125, 5),
                               ('Json', 21, 1)
                
                INSERT INTO EvilnessFactors (Name) 
                        VALUES ('Super good'),  
                               ('Good'),      
                               ('Bad'),      
                               ('Evil'),
                               ('Super evil')
                        
                INSERT INTO Villains (Name, EvilnessFactorId) 
                        VALUES ('Gru', 2),      
                               ('Victor', 1),       
                               ('Jilly', 3),
                               ('Miro', 4),
                               ('Rosen', 5),    
                               ('Dimityr', 1),   
                               ('Dobromir', 2)
                
                INSERT INTO MinionsVillains (MinionId, VillainId) 
                        VALUES (4,2),
                               (1, 1),
                               (5, 7),
                               (3, 5),
                               (2, 6),
                               (11, 5),
                               (8, 4),
                               (9, 7),
                               (7, 1),
                               (1, 3),
                               (7, 3),
                               (5, 3),
                               (4, 3),
                               (1, 2),
                               (2, 1),
                               (2, 7)";

            cmd = new SqlCommand(query, connection);
            var inserted = await cmd.ExecuteNonQueryAsync();

            Console.WriteLine(inserted + " inserted rows");
        }

        static async Task Problem02(SqlConnection connection)
        {
            await connection.OpenAsync();
            var query = @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
    FROM Villains AS v 
    JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
GROUP BY v.Id, v.Name 
  HAVING COUNT(mv.VillainId) > 3 
ORDER BY COUNT(mv.VillainId)";

            var cmd = new SqlCommand(query, connection);
            using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var name = reader.GetString(0);
                var count = reader.GetInt32(1);
                Console.WriteLine($"{name} - {count}");
            }

            Console.WriteLine("Task completed");
        }

        static async Task Problem03(SqlConnection connection)
        {
            Console.WriteLine("Enter id:");
            int id = int.Parse(Console.ReadLine());
            await connection.OpenAsync();

            var query = @"SELECT Name FROM Villains WHERE Id = @Id";
            var cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Id", id);

            string name = (string) await cmd.ExecuteScalarAsync();


                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine($"No villain with ID {id} exists in the database");
                }
                Console.WriteLine("Villain:" + name);


            query = @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                         m.Name, 
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @Id
                                ORDER BY m.Name";
            cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Id", id);
            using var reader = await cmd.ExecuteReaderAsync();

            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var rowNumber = reader.GetInt64(0);
                    var minionName = reader.GetString(1);
                    var age = reader.GetInt32(2);

                    Console.WriteLine($"{rowNumber}. {minionName} {age}");
                }
            }

            Console.WriteLine("Task completed");
        }

        static async Task Problem04(SqlConnection connection)
        {
            var minionInput = Console.ReadLine().Split(" ").ToArray();
            var villainInput = Console.ReadLine().Split(" ").ToArray(); ;

            await connection.OpenAsync();

            var query = @"SELECT Id FROM Towns WHERE Name = @townName";
            var cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@townName", minionInput[3]);

            var townId = (int?) await cmd.ExecuteScalarAsync();

            if (townId == null)
            {
                query = @"INSERT INTO Towns (Name) VALUES (@townName)";
                cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@townName", minionInput[3]);
                await cmd.ExecuteNonQueryAsync();
                Console.WriteLine($"Town {minionInput[3]} was added to the database.");
            }

            query = @"SELECT Id FROM Towns WHERE Name = @townName";
            cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@townName", minionInput[3]);
            townId = (int?)await cmd.ExecuteScalarAsync();

            query = @"SELECT Id FROM Villains WHERE Name = @Name";
            cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Name", villainInput[1]);
            var villainId = (int?) await cmd.ExecuteScalarAsync();

            if (villainId == null)
            {
                query = @"INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";
                cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@villainName", villainInput[1]);
                await cmd.ExecuteNonQueryAsync();
                Console.WriteLine($"Villain {villainInput[1]} was added to the database.");
            }

            query = @"SELECT Id FROM Villains WHERE Name = @Name";
            cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Name", villainInput[1]);
            villainId = (int?)await cmd.ExecuteScalarAsync();

            query = @"INSERT INTO Minions (Name, Age, TownId) VALUES (@nam, @age, @townId)";
            cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@nam", minionInput[1]);
            cmd.Parameters.AddWithValue("@age", int.Parse(minionInput[2]));
            cmd.Parameters.AddWithValue("@townId", townId);
            await cmd.ExecuteNonQueryAsync();

            query = @"SELECT Id FROM Minions WHERE Name = @Name";
            cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Name", minionInput[1]);

            var minionId = (int?) await cmd.ExecuteScalarAsync();

            query = @"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@villainId, @minionId)";
            cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@villainId", villainId);
            cmd.Parameters.AddWithValue("@minionId", minionId);

            await cmd.ExecuteNonQueryAsync();


            Console.WriteLine($"Successfully added {minionInput[1]} to be minion of {villainInput[1]}.");
        }

    }
}
