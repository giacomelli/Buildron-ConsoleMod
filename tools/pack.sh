echo ================[ Starting packing mod
./build.sh linux
echo
./build.sh mac
echo
./build.sh win
echo

echo ================[ Compressing mod
pushd $PWD/../build/linux/Mods/ >/dev/null
zip -r -q ../../ConsoleMod.linux.zip ConsoleMod

popd >/dev/null
pushd $PWD/../build/mac/Buildron.app/Mods/ >/dev/null
zip -r -q ../../../ConsoleMod.mac.zip ConsoleMod

popd >/dev/null
pushd $PWD/../build/win/Mods/ >/dev/null
zip -r -q ../../ConsoleMod.win.zip ConsoleMod

popd >/dev/null
echo ================[ Mod packages .zip available at build folder:
pushd ../build >/dev/null
ls *.zip
popd >/dev/null
echo
echo ================[ Mod pack done.
