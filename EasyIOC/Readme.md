# Easy IOC
This is an IOC library, automating the process of building the ServiceProvider, with Microsoft IOC container.
EasyIOC uses Castle.Windsor-style installers and attributes to automatically register all services from all application assemblies.
This means, that the programmer, doesn't have to manuall call an installation extension method for each library.

## How to use?
There are two ways of installing your library with EasyIOC.
You should consider, 

## Why is it in the Courier repository?
Currently, Easy IOC is not mature enough to be an external dependency.
It will be developed, as a part of the Courier project, untill it is stable enough to be exported to an external package.

## Why .Net 3.1?
Framework version is intentionally kept at 3.1 level for compability with wide range of projects.
The IOC container was introduced in .Net core 3.1 and not all projects can be migrated to .Net6.
Therefore, untill .Net core 3.1 is officially supported, EasyIoc will not be migrated.   
