if [ "$1" == "linux" ]
then
  BUILD_TARGET="StandaloneLinux"
elif [ "$1" == "mac" ]
then
  BUILD_TARGET="StandaloneOSXIntel"
elif [ "$1" == "win" ]
then
  BUILD_TARGET="StandaloneWindows"
else
  echo "ERROR: invalid platform. Valid are: linux, mac or win."
  exit
fi

echo ================[ Building mod for $1
echo ================[ Compiling mod C# class library...
xbuild ../src/Code/ConsoleMod.sln /verbosity:quiet /t:rebuild /p:Configuration=$1 >/dev/null

echo ================[ Starting mod asset building...
/Applications/Unity/Unity.app/Contents/MacOS/Unity -projectPath $PWD/../src/Unity/ConsoleMod -quit -batchmode -executeMethod ModBuilder.BuildFromCommandLine $PWD/../build BUILD_TARGET

echo ================[  Build mod done.
