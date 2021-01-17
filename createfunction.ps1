#!/bin/powershell
docker kill $(docker ps -q)
.\faas-cli.exe build -f .\lochkreisvisualizer.yml
docker run -p "8081:3000" docker.io/sopor10/lochkreisvisualizer:latest