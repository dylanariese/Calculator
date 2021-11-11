# Calculator

When a process has to perform hundreds of different calculations, some calculations 
depend on the outcome of other calculations and where specifications for the calculations are certain to change often.
This sample is by far the fastest and cleanest way to approach such a situation by utilizing **SOLID principles**.

## Solution

The registration below will automatically load all the classes that implement ICalculation, that have been added to the project containing the calculations, thereby obeying the single resposibility and open closed principle.

![image](https://user-images.githubusercontent.com/2542864/141286305-f3059c1b-5bac-4166-ba41-7fe54e9d169d.png)

Calculations are segregated by two types of interfaces

**IStandalone** - Calculations that will be processed separately.  
**IDependant**  - Calculations that depend on the outcome of other calculations.

The calculators will be injected in the constructor of the CalculationRunner. In the constructor the segregation 
between IStandalone and IDependant calculations will be made based on their type.

![image](https://user-images.githubusercontent.com/2542864/141286151-c8c94ad0-aa3d-42e2-bd0e-865ffbf24976.png)

All calculations will be processed asynchronous. When a calculation has completed, the outcome is added to the concurrent shared collection.

![image](https://user-images.githubusercontent.com/2542864/141286901-35fc3cbd-ee93-4792-94e8-27e9685131de.png)

Dependent calculations will be processed as soon as their predicate has been fulfilled.

![image](https://user-images.githubusercontent.com/2542864/141287707-117c42cb-2cba-40dd-8d9e-f6949df56af4.png)

![image](https://user-images.githubusercontent.com/2542864/141288690-03d08b5b-3fce-42d4-8371-90dfcc3fc0df.png)
