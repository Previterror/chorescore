
namespace chorescore.Repositories;

public class ChoresRepository
{
    private readonly IDbConnection _db;
    public ChoresRepository(IDbConnection db)
    {
        _db = db;
    }

    internal List<Chore> GetAllChores()
    {
        string sql = "SELECT * FROM chores;";
        List<Chore> chores = _db.Query<Chore>(sql).ToList();
        return chores;
    }
}