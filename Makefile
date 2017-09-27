# Requirements:
#  - Visual Studio (ensure devenv.exe is in %PATH%)
#  - NuGet (ensure nuget.exe is in %PATH%)

#VERSION = $(shell sed -ne 's/.*<ApplicationVersion>\([^<]*\).*/\1/p' build.config)
CONFIG = Release

# XXX: this is necessary until vswhere.exe actually works
VS150COMNTOOLS = C:\\Program\ Files\ \(x86\)\\Microsoft\ Visual\ Studio\\2017\\Community\\Common7\\Tools
DEVENV = $(VS150COMNTOOLS)\\..\\..\\Common7\\IDE\\devenv.com

all:
	$(DEVENV) Emoji.Wpf.sln //rebuild $(CONFIG)
	nuget pack Emoji.Wpf/Emoji.Wpf.csproj -Properties Configuration=Release

clean:
	$(DEVENV) Emoji.Wpf.sln //clean $(CONFIG)
	rm -f *.nupkg

