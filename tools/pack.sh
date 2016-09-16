echo ================[ Starting packing mod
./build.sh linux
echo
./build.sh mac
echo
./build.sh win
echo

echo ================[ Compressing mod
pushd $PWD/../build/linux/Mods/ >/dev/null
zip -vrq ../../ConsoleMod.linux.zip ConsoleMod -x "*.DS_Store"

popd >/dev/null
pushd $PWD/../build/mac/Buildron.app/Mods/ >/dev/null
zip -vrq ../../../ConsoleMod.mac.zip ConsoleMod -x "*.DS_Store"

popd >/dev/null
pushd $PWD/../build/win/Mods/ >/dev/null
zip -vrq ../../ConsoleMod.win.zip ConsoleMod -x "*.DS_Store"

popd >/dev/null
echo ================[ Mod packages .zip available at build folder:
pushd ../build >/dev/null
ls *.zip
popd >/dev/null
echo
echo ================[ Mod pack done.
