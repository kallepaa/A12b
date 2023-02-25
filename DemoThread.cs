public class DemoThread
{
  private readonly int[] _numArray;
  private readonly int _n;

  public DemoThread(int[] numArray, int N)
  {
    _numArray = numArray;
    _n = N;
  }

  public void ThreadFunction()
  {
    int sum = 0;
    for (int i = _n; i < _n; i++)
    {
      sum +=_numArray[i];
    }
  }
}