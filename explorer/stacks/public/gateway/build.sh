#! /bin/bash

show_help() {
    echo "********** OPTIONS **********"
    printf "  %s\n" "-n|--name               image name, default: explorer/tourism-ui-web"
    printf "  %s\n" "-t|--target             target stage in Dockerfile, default: gatewayWithFront"
    printf "  %s\n" "--tourism_api_url       base URL path for via-ventura service, default: http://localhost:80/tourism-be/api/"
    printf "  %s\n" "--tourism_wss_url       base URL path for websocket via-ventura service, default: http://localhost:80/websocket/hub"
    printf "  %s\n" "--frontend_app_src_url  via-ventura frontend application source code URL, default: https://github.com/Clean-CaDET/platform-tutor-ui-web/archive/refs/heads/master.tar.gz"
    printf "  %s\n" "--github_repo_token    GitHub access token for private repo"
}

POSITIONAL=()
while [[ $# -gt 0 ]]
do
key="$1"

case $key in
    -n|--name)
    NAME="$2"
    shift 2
    ;;
    -t|--target)
    TARGET="$2"
    shift 2
    ;;
    --tourism_api_url)
    TOURISM_API_URL="$2"
    shift 2
    ;;
    --tourism_wss_url)
    TOURISM_WSS_URL="$2"
    shift 2
    ;;
    --frontend_app_src_url)
    FRONTEND_APP_SRC_URL="$2"
    shift 2
    ;;
    --github_repo_token)
    GITHUB_REPO_TOKEN="$2"
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

NAME=${NAME:-explorer/tourism-ui-web}
TARGET=${TARGET:-gatewayWithFront}
TOURISM_API_URL=${TOURISM_API_URL:-http://localhost:80/tourism-be/api/}
TOURISM_WSS_URL=${TOURISM_WSS_URL:-http://localhost:80/websocket/hub}
FRONTEND_APP_SRC_URL=${FRONTEND_APP_SRC_URL:-https://github.com/Clean-CaDET/platform-tutor-ui-web/archive/refs/heads/master.tar.gz}
GITHUB_REPO_TOKEN=${GITHUB_REPO_TOKEN}

docker build -t "${NAME}" \
    --file Dockerfile \
    --target "${TARGET}" \
    --build-arg "TOURISM_API_URL=${TOURISM_API_URL}" \
    --build-arg "TOURISM_WSS_URL=${TOURISM_WSS_URL}" \
    --build-arg "FRONTEND_APP_SRC_URL=${FRONTEND_APP_SRC_URL}" \
    --build-arg "GITHUB_REPO_TOKEN=${GITHUB_REPO_TOKEN}" \
    --no-cache files
