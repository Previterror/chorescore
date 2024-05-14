namespace chorescore.Controllers;

[ApiController]
[Route("api/chores")]

public class ChoresController : ControllerBase
{
    private readonly ChoresService _choresService;
    public ChoresController(ChoresService choresService)
    {
        _choresService = choresService;
    }


    [HttpPost]
    public ActionResult<Chore> CreateChore([FromBody] Chore choreData)
    {
        try
        {
            Chore chore = _choresService.CreateChore(choreData);
            return Ok(chore);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpPut("{choreId}")]
    public ActionResult<Chore> UpdateChore(int choreId, [FromBody] Chore choreData)
    {
        try
        {
            Chore chore = _choresService.UpdateChore(choreId, choreData);
            return Ok(chore);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpDelete("{choreId}")]
    public ActionResult<string> CancelChore(int choreId)
    {
        try
        {
            string message = _choresService.CancelChore(choreId);
            return Ok(message);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }

    [HttpGet]
    public ActionResult<List<Chore>> GetAllChores()
    {
        try
        {
            List<Chore> chores = _choresService.GetAllChores();
            return Ok(chores);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }
    }

    [HttpGet("{choreId}")]
    public ActionResult<Chore> GetChoreById(int choreId)
    {
        try
        {
            Chore chore = _choresService.GetChoreById(choreId);
            return Ok(chore);
        }
        catch (Exception exception)
        {

            return BadRequest(exception.Message);
        }
    }



}