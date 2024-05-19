#! /bin/bash

show_help() {
    echo "********** OPTIONS **********"
    printf "  %s\n" "-n|--name               image name, default: ccadet/tutor-ui-web"
    printf "  %s\n" "-t|--target             target stage in Dockerfile, default: gatewayWithFront"
    printf "  %s\n" "--smart_tutor_api_url   base URL path for Smart Tutor service, default: http://127.0.0.1:8080/smart-tutor/api/"
    printf "  %s\n" "--frontend_app_src_url  Smart Tutor frontend application source code URL, default: https://github.com/Clean-CaDET/platform-tutor-ui-web/archive/refs/heads/keycloak-login-deploy.tar.gz"
    printf "  %s\n" "--github-repo-token     GitHub access token for private repo"
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
    --frontend_app_src_url)
    FRONTEND_APP_SRC_URL="$2"
    shift 2
    ;;
    --github-repo-token)
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
SMART_TUTOR_API_URL=${SMART_TUTOR_API_URL:-http://127.0.0.1:80/tourism-be/api/}
FRONTEND_APP_SRC_URL=${FRONTEND_APP_SRC_URL:-https://github.com/Clean-CaDET/platform-tutor-ui-web/archive/refs/heads/master.tar.gz}
GITHUB_REPO_TOKEN=${GITHUB_REPO_TOKEN}

docker build -t "${NAME}" \
    --file Dockerfile \
    --target "${TARGET}" \
    --build-arg "SMART_TUTOR_API_URL=${SMART_TUTOR_API_URL}" \
    --build-arg "FRONTEND_APP_SRC_URL=${FRONTEND_APP_SRC_URL}" \
    --build-arg "FRONTEND_APP_SRC_URL=${GITHUB_REPO_TOKEN}" \
    --no-cache files
