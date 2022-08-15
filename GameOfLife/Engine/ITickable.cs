namespace GameOfLife.Engine;

public interface ITickable
{
    public void Tick(float deltaTime);
}