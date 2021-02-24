# Requirements:
#  - MSBuild (found through vswhere.exe)
#  - dotnet (ensure dotnet.exe is in %PATH%)

CONFIG = Release

VSWHERE = "${ProgramFiles(x86)}/Microsoft Visual Studio/Installer/vswhere.exe"
MSBUILD = "$(shell $(VSWHERE) -find msbuild | head -n 1)/Current/Bin/MSBuild.exe"

all:
	$(MSBUILD) Emoji.Wpf.sln -t:clean -p:configuration=$(CONFIG)
	$(MSBUILD) Emoji.Wpf.sln -t:build -p:configuration=$(CONFIG)
	dotnet pack --no-build -c $(CONFIG) Emoji.Wpf/Emoji.Wpf.csproj

clean:
	$(MSBUILD) Emoji.Wpf.sln -t:clean -p:configuration=$(CONFIG)
	rm -f *.nupkg

