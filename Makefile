# Requirements:
#  - Visual Studio (ensure devenv.exe is in %PATH%)
#  - NuGet (ensure nuget.exe is in %PATH%)

#VERSION = $(shell sed -ne 's/.*<ApplicationVersion>\([^<]*\).*/\1/p' build.config)
CONFIG = Release

VSWHERE = "${ProgramFiles(x86)}/Microsoft Visual Studio/Installer/vswhere.exe"
DEVENV = "$(shell $(VSWHERE) | sed -ne 's/^productPath: //p' | sed 's/devenv.exe/devenv.com/' | head -n 1)"

all:
	$(DEVENV) Emoji.Wpf.sln //clean $(CONFIG)
	$(DEVENV) Emoji.Wpf.sln //build $(CONFIG)
	# Disable warning 5128 until https://github.com/NuGet/Home/issues/8713 is fixed
	nuget pack Emoji.Wpf/Emoji.Wpf.csproj -Properties Configuration=Release -Properties NoWarn=NU5128

clean:
	$(DEVENV) Emoji.Wpf.sln //clean $(CONFIG)
	rm -f *.nupkg

