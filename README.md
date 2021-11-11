# Calculator

When a process has to perform hundreds of different calculations and some calculations 
depend on the outcome of other calculations where specifications for the calculations are certain to change often.
This sample is by far the fastest and cleanest way to approach such a situation by utilizing **SOLID principles**.

## Solution

The registration below will automatically load all the classes that implement ICalculation, that have been added to the project containing the calculations, thereby obeying the single resposibility and open closed principle.

```
Assembly.GetAssembly(typeof(CompanyCarCalculation)).GetTypes()
		.Where(type => type.GetInterfaces().Contains(typeof(ICalculation))).ToList()
		.ForEach(type => services.AddTransient(typeof(ICalculation), type));
```

Calculations are segregated by two types of interfaces

**IStandalone** - Calculations that will be processed separately.  
**IDependant**  - Calculations that depend on the outcome of other calculations.

The calculators will be injected in the constructor of the CalculationRunner. In the constructor the segregation 
between IStandalone and IDependant calculations will be made based on their type.

All calculations will be processed asynchronous. When a calculation has completed, the outcome is added to the concurrent shared collection.
Dependent calculations will be processed as soon as their predicate has been fulfilled.
