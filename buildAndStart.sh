#!/bin/bash
tag="ghcr.io/mitchfen/mitchfen_xyz:latest"
docker build -t $tag .
if [$? -ne 0]; then
  echo "Failed to build image."
else
  docker container run -p 80:80 --rm $tag
fi

