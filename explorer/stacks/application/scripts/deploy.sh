#! /bin/bash

show_help() {
    echo "********** OPTIONS **********"
    printf "  %s\n" "-s|--stage                    stage/environment"
    printf "  %s\n" "-e|--environment-file         path to configuration template file which utilizes environment variables, default: ../env.conf.template"
    printf "  %s\n" "-c|--compose-file             path to docker compose file, default: ../application.yml"
    printf "  %s\n" "-r|--cors                     CORS configuration, required"
}


POSITIONAL=()
while [[ $# -gt 0 ]]
do
key="$1"

case $key in
    -e|--environment-file)
    ENVIRONMENT_TEMPLATE_FILE="$2"
    shift 2
    ;;
    -s|--stage)
    STAGE="$2"
    shift 2
    ;;
    -c|--compose-file)
    COMPOSE_FILE="$2"
    shift 2
    ;;
    -r|--cors)
    EXPLORER_CORS="$2"
    shift 2
    ;;
    -h|--help)
    shift 2
    show_help
    exit 0
    ;;
    *)    
    POSITIONAL+=("$1")
    shift
    ;;
esac
done
set -- "${POSITIONAL[@]}"

EXPLORER_CORS=${EXPLORER_CORS}
export STAGE=${STAGE:-dev}
STACK_NAME="explorer_application_${STAGE}"
COMPOSE_FILE=${COMPOSE_FILE:-../application.yml}
ENVIRONMENT_TEMPLATE_FILE=${ENVIRONMENT_TEMPLATE_FILE:-../env.conf.template}
ENVIRONMENT_FILE=./env.${STAGE}.conf


if [[ -z ${EXPLORER_CORS} ]]; then
    echo "CORS must be set!"
    echo "Use -r|--cors option or set EXPLORER_CORS variable."
    exit 1
fi

echo "********** CONFIGURATION **********"
echo "STAGE                     | ${STAGE}"
echo "ENVIRONMENT TEMPLATE FILE | ${ENVIRONMENT_TEMPLATE_FILE}"
echo "STACK NAME                | ${STACK_NAME}"
echo "COMPOSE FILE              | ${COMPOSE_FILE}"

printf "%s" "${EXPLORER_CORS}" \
    | docker secret create "explorer_cors_${STAGE}" - > /dev/null || exit


envsubst < "${ENVIRONMENT_TEMPLATE_FILE}" > "${ENVIRONMENT_FILE}"
# docker-compose --env-file "${ENVIRONMENT_FILE}" \
#                --file "${COMPOSE_FILE}" config \
#                | docker stack deploy -c - "${STACK_NAME}"

docker stack deploy -c "${COMPOSE_FILE}" "${STACK_NAME}"

rm "${ENVIRONMENT_FILE}"