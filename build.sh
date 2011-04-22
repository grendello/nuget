#!/bin/bash
PROJECTS="Core Bootstrapper CommandLine"
CWD="`pwd`"

for p in $PROJECTS; do
	cd "src/$p"
	xbuild /property:TreatWarningsAsErrors=false "$@" "$p.csproj"
	cd "$CWD"
done

