#!/bin/bash
set -e
version="0.0.0"
if [ -n "$1" ]; then version="$1"
fi

tag="0.0.0"
if [ -n "$2" ]; then tag="$2"
fi
tag=${tag/tags\//}

dotnet test .\\src\\CR.WorkingDayService.Tests\\CR.WorkingDayService.Tests.csproj

dotnet pack .\\src\\CR.WorkingDayService\\CR.WorkingDayService.csproj -o ..\\..\\dist -p:Version="$version" -p:PackageVersion="$version" -p:Tag="$tag" -c Release