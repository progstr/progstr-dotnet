#!/usr/bin/env bash
SCRIPT_DIR=`dirname $0`
pushd .
cd $SCRIPT_DIR
mono ~/w/dotnet/xunit/xunit.gui.exe debug.xunit &
popd
