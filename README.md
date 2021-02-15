# LifeManager

### Bug Related to Multiple Projects within Solution
- When you have multiple projects in a single solution, for whatever reason .NET for Mac creates sub-folders for those projects one directory below the level of the main project in the solution directory.  When the code compiles/builds, if your test project for example references your main project one level above it, then the main project will reference the build output in the `\bin\` of the test project as well as its own build output in its `\bin\` directory at its level.  This causes a duplicate output error, `CS0579` (or something like that).  Here's the link to the issue:

https://stackoverflow.com/questions/10311347/duplicate-assemblyversion-attribute

One of the most common suggested fixes did not work for me, which was just to add a line of code to the .csproj file of the sub-project `<GenerateAssemblyInfo>...`

**THE FIX**:

I had to right click on the test project and edit its properties via the `Options` item.  From there I had to change the edit the build output path to be in the same `bin\` directory as the main project (one level above the path that Visual Studio for Mac tries to generate it at, which is the test project's folder in the solution).

Once I made this change, rebuilt the project, then it all started working.  Tough to figure out bug, but glad I was able to get this one more or less on my own.  Definitely a win that I won't forget.
