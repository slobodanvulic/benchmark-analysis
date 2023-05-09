using BenchmarkDotNet.Attributes;

namespace ResultBenchmark;

[MemoryDiagnoser(false)]
public class Benchmarks
{
    [Params(1000)]
    public int Iterations;

    [Benchmark]
    public void Faiil_UsingExceptions()
    {
        for (int i = 0; i < Iterations; i++)
        {
            Event ev = null ;
            try
            {
                ev = EventService.RaiseEvent_WithExceptions("");
            }
            catch (ValidationException)
            {
            }
            catch (Exception)
            {
            }

            if (ev != null)
            {
                DoSth(ev.Message);
            }
        }
    }

    [Benchmark]
    public void Faiil_UsingResultType()
    {
        for (int i = 0; i < Iterations; i++)
        {
            var result = EventService.RaiseEvent_WithResult("");

            if(result.IsSuccess)
            {
                DoSth(result.Value.Message);
            }
        }
    }

    [Benchmark]
    public void Success_UsingExceptions()
    {
        for (int i = 0; i < Iterations; i++)
        {
            Event ev = null;
            try
            {
                ev = EventService.RaiseEvent_WithExceptions("test1");
            }
            catch (ValidationException)
            {
            }
            catch (Exception)
            {
            }

            if(ev != null)
            {
                DoSth(ev.Message);
            }
        }
    }

    [Benchmark]
    public void Success_UsingResultType()
    {
        for (int i = 0; i < Iterations; i++)
        {
            var result = EventService.RaiseEvent_WithResult("test2");

            if (result.IsSuccess)
            {
                DoSth(result.Value.Message);
            }
        }
    }

    private string DoSth(string message)
    {
        return message.ToUpper();
    }

}
