


namespace chorescore.Services;

public class ChoresService
{

    private readonly ChoresRepository _repository;
    public ChoresService(ChoresRepository repository)
    {
        _repository = repository;
    }

    internal string CancelChore(int choreId)
    {
        Chore choreToCancel = GetChoreById(choreId);
        _repository.CancelChore(choreId);
        return $"Chore id {choreId} has been canceled.";
    }

    internal Chore CreateChore(Chore choreData)
    {
        Chore chore = _repository.CreateChore(choreData);
        return chore;
    }

    internal List<Chore> GetAllChores()
    {
        List<Chore> chores = _repository.GetAllChores();
        return chores;
    }

    internal Chore GetChoreById(int choreId)
    {
        Chore chore = _repository.GetChoreById(choreId);

        if (chore == null)
        {
            throw new Exception($"Invalid ID: {choreId}");
        }
        return chore;
    }
}