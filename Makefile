# Requirements:
#  - Visual Studio (ensure devenv.exe is in %PATH%)
#  - NuGet (ensure nuget.exe is in %PATH%)

#VERSION = $(shell sed -ne 's/.*<ApplicationVersion>\([^<]*\).*/\1/p' build.config)
CONFIG = Release

VSWHERE = "${ProgramFiles(x86)}/Microsoft Visual Studio/Installer/vswhere.exe"
MSBUILD = "$(shell $(VSWHERE) -find msbuild | head -n 1)/Current/Bin/MSBuild.exe"

all:
	$(MSBUILD) Emoji.Wpf.sln -t:clean -p:configuration=$(CONFIG)
	$(MSBUILD) Emoji.Wpf.sln -t:build -p:configuration=$(CONFIG)
	# Disable warning 5128 until https://github.com/NuGet/Home/issues/8713 is fixed
	nuget pack Emoji.Wpf/Emoji.Wpf.csproj -Properties Configuration=Release -Properties NoWarn=NU5128

clean:
	$(DEVENV) Emoji.Wpf.sln //clean $(CONFIG)
	rm -f *.nupkg

