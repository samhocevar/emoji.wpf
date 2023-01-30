# Requirements:
#  - dotnet (ensure dotnet.exe is in %PATH%)

CONFIG = Release

all:
	dotnet msbuild -target:clean -p:configuration=$(CONFIG) Emoji.Wpf.sln
	dotnet msbuild -target:build -p:configuration=$(CONFIG) Emoji.Wpf.sln
	dotnet pack --no-build -c $(CONFIG) Emoji.Wpf/Emoji.Wpf.csproj

clean:
	dotnet msbuild -target:clean -p:configuration=$(CONFIG) Emoji.Wpf.sln
