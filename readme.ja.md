# RefFile

[![NugetShield]][NugetPackage]

[NugetPackage]: https://www.nuget.org/packages/RefFile
[NugetShield]: https://img.shields.io/nuget/v/RefFile

.NET10 の file-based apps 向けの、別ソースファイルの参照を目的とするジェネレータです。  

このジェネレータでは、別のファイルを参照してそのファイル内容をビルドに含めます。  
.NET11 では file-based apps での[複数ファイルサポート](https://github.com/dotnet/sdk/blob/d04687c325ff9e2cbc8836c14136a7fd49d82dae/documentation/general/dotnet-run-file.md#multiple-c-files)が追加される予定であるため、これはそれまでの繋ぎに使う代替手段を想定したものです。  
なお、このジェネレータでは参照ファイルがC#ソースコードであることを前提としています。  
その他の種類のファイルに対しては有効ではありません。  

## 使用方法

アセンブリの属性として `RefFileAttribute` を付与し、その引数で参照ファイル名を指定する。  
ファイル名は属性を記述したファイルからの相対パスとして解釈される。  

注意事項として、参照するファイル先頭に記述された file-based apps 用のディレクティブは除去される。  
そのため、参照されるファイル内に `#:package` や `#:property` を記述しても効果はない。  


## 使用例

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
    #:package RefFile@0.1.0

    [assembly: RefFile("common.cs1")]

    var data = new CommonData("abc");
    data.Print();
    ```
