# LifeManager

### Bug Related to Multiple Projects within Solution
- When you have multiple projects in a single solution, for whatever reason .NET for Mac creates sub-folders for those projects one directory below the level of the main project in the solution directory.  When the code compiles/builds, if your test project for example references your main project one level above it, then the main project will reference the build output in the `\bin\` of the test project as well as its own build output in its `\bin\` directory at its level.  This causes a duplicate output error, `CS0579` (or something like that).  Here's the links to the issue:

https://stackoverflow.com/questions/10311347/duplicate-assemblyversion-attribute

One of the most common suggested fixes did not work for me, which was just to add a line of code to the .csproj file of the sub-project `<GenerateAssemblyInfo>...`

**THE FIX**:

Here's the link to the fix: https://stackoverflow.com/questions/47896241/visual-studio-mac-output-obj-bin-folder-elsewhere-not-supported

1) You have to create a `Directory.Build.props` file at the Solution level

2) Enter the following code (remove the `<configuration>` tags)
```
    <Project>
        <PropertyGroup>
            <BaseIntermediateOutputPath>..\Bin\obj\</BaseIntermediateOutputPath>
        </PropertyGroup>
    </Project>
```

3) Now your output should all go to one place...I think?  Still need to research more, but I think this finally solved the issue...I hope (2/14/21).
