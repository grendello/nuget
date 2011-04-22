# A temporary copy of the NuGet mercurial repository at [codeplex](http://nuget.codeplex.com "NuGet")

This copy exists because some of the changes necessary to make NuGet (default branch)
run on Mono cannot be submitted upstream (as they are merely work-arounds for assemblies
missing on Mono). Until the missing assemblies/classes are implemented I plan to put the
Mono-specific changes here and if any of them turn out to be useful for the upstream, I
will submit them there as well.

All the Mono stuff lives in the '**mono**' branch of this repository. The '**master**' branch holds
some changeset from the main NuGet mercurial repository.

# Compiling

Currently you should not try to compile the _NuGet.sln_ solution since it will fail on some projects.

I haven't tried compiling the package with MonoDevelop, so your mileage my vary there. I used Mono's
**xbuild** command with Mono from the master branch to compile the projects mentioned below.

> Note that a few NuGet projects are configured to treat errors as warnings. Therefore in order to
> compile them, you should use the command below:
>
> 	  xbuild /property:TreatWarnigsAsErrors=false projectfile.csproj

Alternatively in the top directory of the **mono** branch there exists a build script (_build.sh_) which
will build all the projects which are usable on Mono now.

# What works?

NuGet consists of a number of separate projects, not all of which can be used on Linux. The state of 
components is outlined below. If a component isn't mentioned in this document it means it either has
not been tested yet or that it does not work at all. Subsection titles correspond to project names
under the _src_ directory in NuGet sources.

## Core

Compiles without problems, client command runs so at this point it is assumed that the core works correctly
with Mono

## CommandLine

Mostly seems to work fine with the following exceptions:

*      Commands/ProjectFactory.cs
       Had to disable compiling of this file since it relies on the **Microsoft.Build** assembly which isn't
       implemented by Mono yet.
*      The 'pack' command (Commands/PackCommand.cs)
       It will work if you build your package from a _.nuspec_ file, fail if you attempt to build a project
       file (_.csproj_, _.vbproj_ etc)

Tested commands:

*      list
*      install
*      pack

## Bootstrapper

Downloads NuGet.exe without problems.
