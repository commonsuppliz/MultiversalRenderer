using System;
using System.Collections.Generic;
using Python.Runtime;
using MultiversalRenderer.Interfaces;
using System.Threading.Tasks;
public class PythonProcessorScope : IAsyncDisposable, IMultiversalScope, IDisposable
{
    private bool _disposed;
    private bool _initCompleted;
    private Py.GILState? _scope = null;
    public PythonProcessorScope() { }

    public ValueTask DisposeAsync()
    {
        PythonEngine.Shutdown();
        _scope?.Dispose();
        _disposed = true;
        return new ValueTask(Task.CompletedTask);
    }

    public void disposeScriptEngine()
    {
        PythonEngine.Shutdown();
        _scope.Dispose();
        _disposed = true;
        
    }

    public string getMultivasalScopeName()
    {
        throw new NotImplementedException();
    }
    private static List<string> _invokeScriptNames = new List<string>{ "text/python", "text/py" };
    public string[] getMultiversalInvokeScriptNames()
    {
        return _invokeScriptNames.ToArray();
    }

    public IMultiversalScriptProcessor getMultiversalScriptProcessor()
    {
        PythonProcessor.PythonProcessor _new = new PythonProcessor.PythonProcessor();
        _new.multiversalscope = this;
        return _new;

    }

    public IMultiversalWindow getMultiversalWindow()
    {
        throw new NotImplementedException();
    }

    public IMultiversalWindowType getMutilversalWindowType()
    {
        throw new NotImplementedException();
    }

    public void initScriptEngine()
    {
        PythonEngine.Initialize();
        _initCompleted = true;
         _scope = Py.GIL();
 
    }

    public bool isDefaultMultiversalProcessor()
    {
        throw new NotImplementedException();
    }

    public bool isInitCompleted()
    {
        throw new NotImplementedException();
    }

    public void relaseMultiversal()
    {
        throw new NotImplementedException();
    }

    public void setMultiversalWindow(IMultiversalWindow window)
    {
        throw new NotImplementedException();
    }

    public void setMutilversalWindowType(IMultiversalWindowType windowType)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        PythonEngine.Shutdown();
        _scope.Dispose();
        _disposed = true;
        
    }
}
