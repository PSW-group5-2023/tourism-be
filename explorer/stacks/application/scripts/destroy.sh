#! /bin/bash

POSITIONAL=()
while [[ $# -gt 0 ]]
do
key="$1"

case $key in
    -s|--stage)
    STAGE="$2"
    shift 2
    ;;
    *)    
    POSITIONAL+=("$1")
    shift
    ;;
esac
done
set -- "${POSITIONAL[@]}"

STAGE=${STAGE:-dev}
STACK_NAME="explorer_application_${STAGE}"

docker stack rm "${STACK_NAME}"
docker secret rm "explorer_jwt_key_${STAGE}"
docker secret rm "explorer_cors_${STAGE}"

docker service rm explorer_application_${STAGE}_database
docker network rm application_network_${STAGE}