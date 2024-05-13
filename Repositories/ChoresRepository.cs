



namespace chorescore.Repositories;

public class ChoresRepository
{
    private readonly IDbConnection _db;
    public ChoresRepository(IDbConnection db)
    {
        _db = db;
    }

    internal void CancelChore(int choreId)
    {
        string sql = "DELETE FROM chores WHERE id = @choreId;";
        _db.Execute(sql, new { choreId });
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
}