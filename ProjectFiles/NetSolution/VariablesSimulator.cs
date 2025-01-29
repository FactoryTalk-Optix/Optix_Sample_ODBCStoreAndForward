#region Using directives
using System;
using UAManagedCore;
using FTOptix.NetLogic;
#endregion

public class VariablesSimulator : BaseNetLogic
{
    public override void Start()
    {
        // Get local variables
        runVariable = LogicObject.GetVariable("RunSimulation");
        sine = LogicObject.GetVariable("Sine");
        ramp = LogicObject.GetVariable("Ramp");
        cosine = LogicObject.GetVariable("Cosine");
        // Start simulation
        simulationTask = new PeriodicTask(Simulation, 250, LogicObject);
        simulationTask.Start();
    }

    private void Simulation()
    {
        if (runVariable.Value)
        {
            if (integerCounter <= 99)
                integerCounter++;
            else
                integerCounter = 0;
            
            decimalCounter = decimalCounter + 0.05;

            ramp.Value = integerCounter;
            sine.Value = Math.Sin(decimalCounter) * 100;
            cosine.Value = Math.Cos(decimalCounter) * 50;
        }
    }

    public override void Stop()
    {
        simulationTask?.Dispose();
    }

    private PeriodicTask simulationTask;
    private int integerCounter;
    private double decimalCounter;
    private IUAVariable runVariable;
    private IUAVariable sine;
    private IUAVariable cosine;
    private IUAVariable ramp;
}
