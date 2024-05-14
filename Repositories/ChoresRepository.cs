




using MySqlConnector;

namespace chorescore.Repositories;

public class ChoresRepository
{
    private readonly IDbConnection _db;
    public ChoresRepository(IDbConnection db)
    {
        _db = db;
    }


    internal Chore CreateChore(Chore choreData)
    {
        string sql = @"
        INSERT INTO chores(name, description)
        VALUES(@name, @description);

        SELECT * FROM chores WHERE id = LAST_INSERT_ID();
        ";

        Chore chore = _db.Query<Chore>(sql, choreData).FirstOrDefault();
        return chore;
    }
    internal void CancelChore(int choreId)
    {
        string sql = "DELETE FROM chores WHERE id = @choreId;";
        _db.Execute(sql, new { choreId });
    }

    internal List<Chore> GetAllChores()
    {
        string sql = "SELECT * FROM chores;";
        List<Chore> chores = _db.Query<Chore>(sql).ToList();
        return chores;
    }

    internal Chore GetChoreById(int choreId)
    {
        string sql = "SELECT * FROM chores WHERE id = @choreId";
        Chore chore = _db.Query<Chore>(sql, new { choreId }).FirstOrDefault();
        return chore;
    }

    internal Boolean UpdateChore(int choreId, Chore choreToUpdate)
    {
        string sql = @"
        UPDATE chores 
        SET  
        name = @choreToUpdate.name
        description = @choreToUpdate.description
        isCompleted = @choreToUpdate.isCompleted
        WHERE id = @choreId";


        MySqlParameter paraName = new MySqlParameter("@name", MySqlDbType.VarChar);
        paraName.Value = choreToUpdate.Name;
        MySqlParameter paraDesc = new MySqlParameter("@description", MySqlDbType.VarChar);
        paraDesc.Value = choreToUpdate.Description;
        MySqlParameter paraCompleted = new MySqlParameter("@isCompleted", MySqlDbType.Bool);
        paraCompleted.Value = choreToUpdate.isCompleted;


        int updateSuccess = _db.Execute(sql, new List<MySqlParameter> { paraName, paraDesc, paraCompleted });
        return updateSuccess > 0;
    }

}