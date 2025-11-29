# RefFile

[![NugetShield]][NugetPackage]

[NugetPackage]: https://www.nuget.org/packages/RefFile  
[NugetShield]: https://img.shields.io/nuget/v/RefFile  

A generator for .NET 10 file-based apps, designed to reference external source files.  

This generator allows you to reference another file and include its contents in the build.  
Since [multi-file support](https://github.com/dotnet/sdk/blob/d04687c325ff9e2cbc8836c14136a7fd49d82dae/documentation/general/dotnet-run-file.md#multiple-c-files) for file-based apps is expected to be added in .NET 11, this is intended as a temporary workaround until then.  
Note that this generator assumes the referenced file is C# source code.  
It is not valid for other types of files.  

## Usage

Add the `RefFileAttribute` to the assembly and specify the referenced filename as its argument.  
The filename is interpreted as a relative path from the file where the attribute is declared.  

Important note: any file-based apps directives written at the beginning of the referenced file will be removed.  
Therefore, directives such as `#:package` or `#:property` inside the referenced file will have no effect.  

## Example

- common.cs  
    ```csharp:common.cs
    public record CommonData(string Name)
    {
        public void Print() => Console.WriteLine(this.Name);
    }
    ```

- app.cs  
    ```csharp:app.cs
    #!/usr/bin/env -S dotnet run --file
    #:package RefFile@0.1.1

    [assembly: RefFile("common.cs")]

    var data = new CommonData("abc");
    data.Print();
    ```
