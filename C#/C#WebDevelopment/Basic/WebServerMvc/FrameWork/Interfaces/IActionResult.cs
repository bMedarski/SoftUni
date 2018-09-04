namespace FrameWork.Interfaces
{
    public interface IActionResult : IInvocable
    {
		IRenderable Action { get; set; }
    }
}
