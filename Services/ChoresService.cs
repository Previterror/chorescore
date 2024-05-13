
namespace chorescore.Services;

public class ChoresService
{

    private readonly ChoresRepository _repository;
    public ChoresService(ChoresRepository repository)
    {
        _repository = repository;
    }
    internal List<Chore> GetAllChores()
    {
        List<Chore> chores = _repository.GetAllChores();
        return chores;
    }
}