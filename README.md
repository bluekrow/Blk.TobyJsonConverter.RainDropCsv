# Blk.TobyJsonConverter.RainDropCsv
This a console application that converts your [Toby](https://www.gettoby.com/) exported bookmarks json file , to a [RainDrop](https://raindrop.io/) compatible csv file.

# Requirements
This application is built using:
- JetBrains Rider as IDE
- netCore 8 as framework
- C# as language
- Testing Tools
  - xUnit
  - FluentAssertions
  - Verify

# Getting started
First, clone from the repo:
```
git clone git@github.com:bluekrow/Blk.TobyJsonConverter.RainDropCsv.git
```

Next, restore the packages
```
cd Blk.TobyJsonConverter.RainDropCsv
dotnet restore
```

Then build it:
```
dotnet build
```

You can run the tests, although they should have been automatically run with every merge/push to the main branch
```
dotnet test
```


Finally, you can run it. The application receives two parameters:
- arg1: input Toby json file path
- arg2: output RainDrop csv file path  
```
dotnet run <arg1> <arg2>
```
Note: currently, if you don't add arguments when running, the application will use predefined file paths, most probably not existing in your local machine. 
