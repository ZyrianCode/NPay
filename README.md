# NPay

## About

NPay is a simple virtual payments app built as a modular monolith.
 
Originally maded by devmentors.

Reviewed by Zelender.

Architecture and some code refactored and fixed by Zelender.


## Fixes: 

+Dependencies

+Commands and Queries composed to one files with Handlers for better manipulations.

+Architecture missed layers was added.

+Some files was moved to new layers.

+Added Roots as markers for friend assemblies (In future that will be new system for managing routes).

+Renamed some bad names.

+Decoupled some layers.

+All Extensions now working properly.

**How to start the solution?**
----------------

Start the infrastructure using [Docker](https://docs.docker.com/get-docker/):

```
docker-compose up -d
```

Start API located under Bootstrapper project:

```
cd src/Bootstrapper/NPay.Bootstrapper
dotnet run
```
