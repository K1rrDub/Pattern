using System;

internal class VmBuilder
{
    private int _memSize;
    private Action _readCommand;
    private Action<char> _writeCommand;
    private bool _addLoopCommands;

    public VmBuilder(int memSize)
    {
        _memSize = memSize;
    }

    public VmBuilder AddBasicCommands(Action readCommand, Action<char> writeCommand)
    {
        _readCommand = readCommand;
        _writeCommand = writeCommand;
        return this;
    }

    public VmBuilder AddLoopCommands()
    {
        _addLoopCommands = true;
        return this;
    }

    public Vm Build(string program)
    {
        var vm = new Vm(_memSize, _readCommand, _writeCommand, _addLoopCommands);
        vm.LoadProgram(program);
        return vm;
    }
}

internal class Vm
{
    private int _memSize;
    private Action _readCommand;
    private Action<char> _writeCommand;
    private bool _addLoopCommands;
    private string _program;

    public Vm(int memSize, Action readCommand, Action<char> writeCommand, bool addLoopCommands)
    {
        _memSize = memSize;
        _readCommand = readCommand;
        _writeCommand = writeCommand;
        _addLoopCommands = addLoopCommands;
    }

    public void LoadProgram(string program)
    {
        _program = program;
    }

    public void Run()
    {
        
        Console.WriteLine($"Running program: {_program}");
    }
}

internal class Program
{
    private static void Main()
    {
        var vmBuilder = new VmBuilder(memSize: 60)
            .AddBasicCommands(() => Console.Read(), Console.Write)
            .AddLoopCommands();

        var program1 = "Program 1";
        var program2 = "Program 2";

        vmBuilder.Build(program1).Run();
        vmBuilder.Build(program2).Run();
    }
}